using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class FlightCard : Control
    {
        private ChuyenBayDTO _cb;
        private bool _selected, _hover;

        private static readonly Font FontTime = new Font("Segoe UI Semibold", 17F);
        private static readonly Font FontPrice = new Font("Segoe UI Semibold", 14F);

        public FlightCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            Size = new Size(560, 118);
            Cursor = Cursors.Hand;
            TabStop = true;
            Margin = new Padding(0, 0, 0, 10);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChuyenBayDTO ChuyenBay
        {
            get { return _cb; }
            set { _cb = value; Invalidate(); }
        }

        [DefaultValue(false)]
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                OnClick(EventArgs.Empty);
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(AppTheme.BackgroundOf(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var card = new Rectangle(1, 1, Width - 3, Height - 4);
            if (_selected) AppTheme.DrawShadow(g, card, 12, 4);
            Color border = _selected ? AppTheme.Primary : _hover || Focused ? Color.FromArgb(156, 201, 211) : AppTheme.Border;
            using (var path = AppTheme.RoundedRect(card, 12))
            {
                using (var b = new SolidBrush(Color.White)) g.FillPath(b, path);
                using (var p = new Pen(border, 2f)) g.DrawPath(p, path);
            }
            if (_cb == null) return;

            const int priceW = 170;
            int left = 22, right = Width - priceW - 20;

            // Giờ đi
            TextRenderer.DrawText(g, _cb.NgayGioKhoiHanh.ToString("HH:mm"), FontTime, new Point(left - 3, 14), AppTheme.Heading);
            TextRenderer.DrawText(g, _cb.MaSanBayDi + " · " + _cb.ThanhPhoDi, AppTheme.FontSmall, new Point(left, 48), AppTheme.Muted);

            // Giờ đến (căn phải trước khối giá)
            string arr = _cb.NgayGioDen.ToString("HH:mm");
            Size arrSz = TextRenderer.MeasureText(arr, FontTime);
            TextRenderer.DrawText(g, arr, FontTime, new Point(right - arrSz.Width + 3, 14), AppTheme.Heading);
            string arrCity = _cb.MaSanBayDen + " · " + _cb.ThanhPhoDen;
            Size arrCitySz = TextRenderer.MeasureText(arrCity, AppTheme.FontSmall);
            TextRenderer.DrawText(g, arrCity, AppTheme.FontSmall, new Point(right - arrCitySz.Width, 48), AppTheme.Muted);

            // Đường bay ở giữa
            int lineL = left + 96, lineR = right - Math.Max(arrSz.Width, 70) - 14;
            if (lineR - lineL > 60)
            {
                int y = 36, cx = (lineL + lineR) / 2;
                using (var p = new Pen(Color.FromArgb(182, 203, 209), 2f) { DashStyle = DashStyle.Dash })
                {
                    g.DrawLine(p, lineL, y, cx - 14, y);
                    g.DrawLine(p, cx + 14, y, lineR, y);
                }
                DrawPlane(g, new PointF(cx, y), 11f, AppTheme.Primary);
                var mid = new Rectangle(lineL, 6, lineR - lineL, 20);
                TextRenderer.DrawText(g, DinhDang.ThoiGianBay(_cb.ThoiGianBayPhut), AppTheme.FontSmall, mid, AppTheme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);
                var below = new Rectangle(lineL, 46, lineR - lineL, 20);
                TextRenderer.DrawText(g, $"Chuyến #{_cb.MaChuyenBay} · {_cb.SoHieu}", AppTheme.FontSmall, below, AppTheme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.EndEllipsis);
            }

            // Giá theo hạng (dòng dưới cùng)
            int x = left, yChip = 80;
            foreach (var hang in new[] { 1, 2, 3 })
            {
                decimal gia;
                if (!_cb.BangGia.TryGetValue(hang, out gia)) continue;
                string ten = hang == 1 ? "Phổ thông" : hang == 2 ? "PT đặc biệt" : "Thương gia";
                string text = ten + "  " + DinhDang.TienNgan(gia);
                Size sz = TextRenderer.MeasureText(text, AppTheme.FontSmall);
                if (x + sz.Width + 16 > right) break;
                var chip = new Rectangle(x, yChip, sz.Width + 14, 24);
                using (var path = AppTheme.RoundedRect(chip, 12))
                using (var b = new SolidBrush(AppTheme.HangVeSoft(hang)))
                    g.FillPath(b, path);
                TextRenderer.DrawText(g, text, AppTheme.FontSmall, chip, AppTheme.HangVeText(hang),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                x += chip.Width + 8;
            }

            // Khối giá bên phải
            int px = Width - priceW;
            using (var p = new Pen(AppTheme.Border)) g.DrawLine(p, px, 16, px, Height - 18);
            var rText = new Rectangle(px + 10, 0, priceW - 30, Height);
            TextRenderer.DrawText(g, "Giá từ", AppTheme.FontSmall, new Rectangle(rText.X, 16, rText.Width, 18), AppTheme.Muted, TextFormatFlags.Right);
            TextRenderer.DrawText(g, DinhDang.Tien(_cb.GiaThapNhat), FontPrice, new Rectangle(rText.X - 20, 34, rText.Width + 20, 30),
                AppTheme.Price, TextFormatFlags.Right);

            bool sapHet = _cb.SoGheTrong <= 5;
            string seats = _cb.SoGheTrong + " ghế trống";
            Size sSz = TextRenderer.MeasureText(seats, AppTheme.FontLabel);
            var badge = new Rectangle(rText.Right - sSz.Width - 14, 76, sSz.Width + 14, 26);
            using (var path = AppTheme.RoundedRect(badge, 13))
            using (var b = new SolidBrush(sapHet ? AppTheme.WarnBack : AppTheme.GoodBack))
                g.FillPath(b, path);
            TextRenderer.DrawText(g, seats, AppTheme.FontLabel, badge, sapHet ? AppTheme.WarnText : AppTheme.GoodText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public static void DrawPlane(Graphics g, PointF c, float s, Color color)
        {
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(new[]
                {
                    new PointF(c.X + s, c.Y),
                    new PointF(c.X + s * 0.55f, c.Y - s * 0.16f),
                    new PointF(c.X - s * 0.05f, c.Y - s * 0.16f),
                    new PointF(c.X - s * 0.45f, c.Y - s * 0.9f),
                    new PointF(c.X - s * 0.7f, c.Y - s * 0.9f),
                    new PointF(c.X - s * 0.42f, c.Y - s * 0.16f),
                    new PointF(c.X - s * 0.78f, c.Y - s * 0.16f),
                    new PointF(c.X - s * 0.98f, c.Y - s * 0.48f),
                    new PointF(c.X - s * 1.12f, c.Y - s * 0.48f),
                    new PointF(c.X - s, c.Y),
                    new PointF(c.X - s * 1.12f, c.Y + s * 0.48f),
                    new PointF(c.X - s * 0.98f, c.Y + s * 0.48f),
                    new PointF(c.X - s * 0.78f, c.Y + s * 0.16f),
                    new PointF(c.X - s * 0.42f, c.Y + s * 0.16f),
                    new PointF(c.X - s * 0.7f, c.Y + s * 0.9f),
                    new PointF(c.X - s * 0.45f, c.Y + s * 0.9f),
                    new PointF(c.X - s * 0.05f, c.Y + s * 0.16f),
                    new PointF(c.X + s * 0.55f, c.Y + s * 0.16f),
                });
                using (var b = new SolidBrush(color)) g.FillPath(b, path);
            }
        }
    }
}
