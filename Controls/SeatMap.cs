using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    /// <summary>
    /// Sơ đồ ghế nhìn từ trên xuống, mũi máy bay ở trên.
    /// Bố trí lấy hoàn toàn từ dữ liệu ghế (SoHang, CotGhe, MaHangVe, TenHangVe):
    /// cột được chia đôi hai bên lối đi; hàng có ít ghế hơn (vd Thương gia 2-2) thì ghế rộng hơn.
    /// Mỗi lần đổi hạng vé giữa hai hàng sẽ vẽ một vạch ngăn khoang kèm tên hạng.
    /// </summary>
    [DesignerCategory("Code")]
    public class SeatMap : Control
    {
        private const int SeatSize = 36, Gap = 6, Aisle = 26, Pad = 14;
        private const int RowH = SeatSize + Gap, SectionH = 26;
        private const int WingSpan = 92, NoseH = 170, TailH = 190;

        private readonly List<GheDTO> _seats = new List<GheDTO>();
        private readonly Dictionary<int, decimal> _gia = new Dictionary<int, decimal>();
        private readonly HashSet<int> _inCart = new HashSet<int>();
        private readonly Dictionary<int, Rectangle> _rects = new Dictionary<int, Rectangle>();
        private readonly Dictionary<int, int> _rowY = new Dictionary<int, int>();
        private readonly List<(int Y, string Ten, int MaHangVe)> _sections = new List<(int Y, string Ten, int MaHangVe)>();
        private readonly ToolTip _tip = new ToolTip { InitialDelay = 200, ReshowDelay = 100 };

        private List<string> _cols = new List<string>();
        private List<int> _rows = new List<int>();
        private int _cabinH;
        private int? _selected, _hover;

        private static readonly Font FontSeat = new Font("Segoe UI Semibold", 8.25F);
        private static readonly Font FontSection = new Font("Segoe UI Semibold", 7.5F);

        public event EventHandler SeatSelected;

        public SeatMap()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(420, 260);
            BackColor = Color.White;
        }

        [Browsable(false)]
        public GheDTO SelectedSeat => _seats.FirstOrDefault(s => s.MaGhe == _selected);

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? SelectedMaGhe
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        public decimal? GiaCuaHang(int maHangVe)
        {
            decimal g;
            return _gia.TryGetValue(maHangVe, out g) ? g : (decimal?)null;
        }

        public void SetData(IEnumerable<GheDTO> seats, IDictionary<int, decimal> gia)
        {
            _seats.Clear();
            _gia.Clear();
            _selected = null;
            _hover = null;
            if (seats != null) _seats.AddRange(seats);
            if (gia != null) foreach (var kv in gia) _gia[kv.Key] = kv.Value;

            _cols = _seats.Select(s => s.CotGhe).Distinct().OrderBy(c => c).ToList();
            _rows = _seats.Select(s => s.SoHang).Distinct().OrderBy(r => r).ToList();
            Layout_();
            Invalidate();
        }

        public void SetInCart(IEnumerable<int> maGhe)
        {
            _inCart.Clear();
            foreach (int id in maGhe) _inCart.Add(id);
            if (_selected != null && _inCart.Contains(_selected.Value)) _selected = null;
            Invalidate();
        }

        // ---------------------------------------------------------------- bố trí

        /// <summary>Số cột bên trái lối đi (vd A B C | D E F → 3).</summary>
        private int LeftCols => _cols.Count >= 4 ? (_cols.Count + 1) / 2 : _cols.Count;
        private int RightCols => _cols.Count - LeftCols;

        private static int SideWidth(int n) => n <= 0 ? 0 : n * SeatSize + (n - 1) * Gap;
        private int GridWidth => SideWidth(LeftCols) + (RightCols > 0 ? Aisle + SideWidth(RightCols) : 0);
        private int FuselageWidth => GridWidth + Pad * 2;
        private int X0 => WingSpan;                         // mép trái thân
        private int GridLeft => X0 + Pad;
        private int AisleLeft => GridLeft + SideWidth(LeftCols);

        private void Layout_()
        {
            _rects.Clear();
            _rowY.Clear();
            _sections.Clear();
            if (_seats.Count == 0)
            {
                Size = new Size(420, 260);
                return;
            }

            // Vị trí theo chiều dọc: thêm một dải tiêu đề mỗi khi bắt đầu khoang (hạng vé) mới
            int y = NoseH, hangTruoc = -1;
            foreach (int row in _rows)
            {
                var gheHang = _seats.Where(s => s.SoHang == row).ToList();
                int hang = gheHang.GroupBy(s => s.MaHangVe).OrderByDescending(gr => gr.Count()).First().Key;
                if (hang != hangTruoc)
                {
                    _sections.Add((y, gheHang.First(s => s.MaHangVe == hang).TenHangVe, hang));
                    y += SectionH;
                    hangTruoc = hang;
                }
                _rowY[row] = y;
                y += RowH;
            }
            _cabinH = y - NoseH;

            // Vị trí theo chiều ngang: mỗi bên lối đi chia đều cho số ghế thực có ở hàng đó
            foreach (int row in _rows)
            {
                var gheHang = _seats.Where(s => s.SoHang == row).OrderBy(s => s.CotGhe).ToList();
                var trai = gheHang.Where(s => _cols.IndexOf(s.CotGhe) < LeftCols).ToList();
                var phai = gheHang.Where(s => _cols.IndexOf(s.CotGhe) >= LeftCols).ToList();
                DatBen(trai, GridLeft, SideWidth(LeftCols), _rowY[row]);
                DatBen(phai, AisleLeft + Aisle, SideWidth(RightCols), _rowY[row]);
            }

            Size = new Size(FuselageWidth + WingSpan * 2, NoseH + _cabinH + TailH);
        }

        private void DatBen(List<GheDTO> ghe, int left, int width, int y)
        {
            if (ghe.Count == 0) return;
            int w = (width - (ghe.Count - 1) * Gap) / ghe.Count;
            for (int i = 0; i < ghe.Count; i++)
                _rects[ghe[i].MaGhe] = new Rectangle(left + i * (w + Gap), y, w, SeatSize);
        }

        private int? HitTest(Point p)
        {
            foreach (var kv in _rects)
                if (kv.Value.Contains(p)) return kv.Key;
            return null;
        }

        // ---------------------------------------------------------------- chuột

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int? h = HitTest(e.Location);
            if (h == _hover) return;
            _hover = h;
            Invalidate();

            var s = _seats.FirstOrDefault(x => x.MaGhe == h);
            if (s == null) { _tip.Hide(this); Cursor = Cursors.Default; return; }

            bool chon = s.Trong && !_inCart.Contains(s.MaGhe);
            Cursor = chon ? Cursors.Hand : Cursors.No;
            string text = $"Ghế {s.SoGhe} · {s.TenHangVe}";
            if (!s.Trong) text += "\nĐã có người đặt";
            else if (_inCart.Contains(s.MaGhe)) text += "\nĐã thêm vào đơn";
            else
            {
                decimal? gia = GiaCuaHang(s.MaHangVe);
                if (gia != null) text += "\n" + DinhDang.Tien(gia.Value);
            }
            Rectangle r = _rects[s.MaGhe];
            _tip.Show(text, this, r.Right + 4, r.Top, 2500);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hover = null;
            _tip.Hide(this);
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            var s = _seats.FirstOrDefault(x => x.MaGhe == HitTest(e.Location));
            if (s == null || !s.Trong || _inCart.Contains(s.MaGhe)) return;
            _selected = s.MaGhe;
            Invalidate();
            SeatSelected?.Invoke(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _tip.Dispose();
            base.Dispose(disposing);
        }

        // ---------------------------------------------------------------- vẽ

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_seats.Count == 0)
            {
                DrawEmpty(g);
                return;
            }

            DrawAirplane(g);
            DrawSections(g);

            // Số hàng nằm giữa lối đi
            foreach (int row in _rows)
                TextRenderer.DrawText(g, row.ToString(), AppTheme.FontSmall, new Rectangle(AisleLeft, _rowY[row], Aisle, SeatSize),
                    AppTheme.Muted, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            foreach (var s in _seats) DrawSeat(g, s, _rects[s.MaGhe]);
        }

        private void DrawEmpty(Graphics g)
        {
            var r = ClientRectangle;
            FlightCard.DrawPlane(g, new PointF(r.Width / 2f, r.Height / 2f - 30), 22f, Color.FromArgb(182, 203, 209));
            TextRenderer.DrawText(g, "Chọn một chuyến bay để xem sơ đồ ghế", AppTheme.FontBase,
                new Rectangle(0, r.Height / 2, r.Width, 30), AppTheme.Muted, TextFormatFlags.HorizontalCenter);
        }

        private void DrawSections(Graphics g)
        {
            int left = X0 + 10, right = X0 + FuselageWidth - 10;
            for (int i = 0; i < _sections.Count; i++)
            {
                var sec = _sections[i];
                int midY = sec.Y + SectionH / 2;
                string ten = sec.Ten.ToUpperInvariant();
                Size sz = TextRenderer.MeasureText(ten, FontSection);
                int cx = X0 + FuselageWidth / 2;
                var rText = new Rectangle(cx - sz.Width / 2 - 6, midY - 9, sz.Width + 12, 18);

                // Vạch ngăn khoang (trừ khoang đầu tiên ngay sau buồng lái)
                if (i > 0)
                    using (var p = new Pen(Color.FromArgb(205, 220, 224), 2f))
                    {
                        g.DrawLine(p, left, midY, rText.Left - 4, midY);
                        g.DrawLine(p, rText.Right + 4, midY, right, midY);
                    }

                using (var path = AppTheme.RoundedRect(rText, 9))
                using (var b = new SolidBrush(AppTheme.HangVeSoft(sec.MaHangVe)))
                    g.FillPath(b, path);
                TextRenderer.DrawText(g, ten, FontSection, rText, AppTheme.HangVeText(sec.MaHangVe),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void DrawAirplane(Graphics g)
        {
            int fw = FuselageWidth, x0 = X0, x1 = x0 + fw;
            float cx = x0 + fw / 2f;
            int cabinEnd = NoseH + _cabinH;
            int tailEnd = Height - 6;
            Color skin = Color.FromArgb(250, 252, 252), metal = Color.FromArgb(230, 238, 240), line = Color.FromArgb(195, 213, 218);

            using (var fill = new SolidBrush(metal))
            using (var pen = new Pen(line, 2f) { LineJoin = LineJoin.Round })
            {
                // Cánh chính: xuôi về sau, gốc cánh nằm khoảng 35% chiều dài khoang
                float wy = NoseH + _cabinH * 0.35f;
                float root = Math.Min(150f, _cabinH * 0.4f);
                var wingL = new[]
                {
                    new PointF(x0, wy),
                    new PointF(4, wy + root * 0.95f),
                    new PointF(4, wy + root * 0.95f + 26),
                    new PointF(x0, wy + root),
                };
                var wingR = wingL.Select(p => new PointF(2 * cx - p.X, p.Y)).ToArray();
                g.FillPolygon(fill, wingL); g.DrawPolygon(pen, wingL);
                g.FillPolygon(fill, wingR); g.DrawPolygon(pen, wingR);

                // Động cơ treo dưới cánh
                float ey = wy + root * 0.3f;
                foreach (float ex in new[] { x0 - 46f, x1 + 30f })
                {
                    using (var path = AppTheme.RoundedRect(new RectangleF(ex, ey, 16, 46), 8))
                    using (var b = new SolidBrush(Color.FromArgb(213, 227, 230)))
                    {
                        g.FillPath(b, path);
                        g.DrawPath(pen, path);
                    }
                }

                // Cánh đuôi ngang
                float ty = tailEnd - 70;
                var stabL = new[] { new PointF(cx - 10, ty), new PointF(cx - 78, ty + 40), new PointF(cx - 78, ty + 54), new PointF(cx - 8, ty + 40) };
                var stabR = stabL.Select(p => new PointF(2 * cx - p.X, p.Y)).ToArray();
                g.FillPolygon(fill, stabL); g.DrawPolygon(pen, stabL);
                g.FillPolygon(fill, stabR); g.DrawPolygon(pen, stabR);
            }

            // Thân: mũi nhọn dài, thân thẳng, đuôi thon dần về một điểm
            using (var body = new GraphicsPath())
            {
                body.AddBezier(x0, NoseH, x0, NoseH * 0.45f, cx - fw * 0.22f, 6, cx, 6);
                body.AddBezier(cx, 6, cx + fw * 0.22f, 6, x1, NoseH * 0.45f, x1, NoseH);
                body.AddLine(x1, NoseH, x1, cabinEnd);
                body.AddBezier(x1, cabinEnd, x1, cabinEnd + TailH * 0.45f, cx + 14, tailEnd - 24, cx + 6, tailEnd);
                body.AddLine(cx + 6, tailEnd, cx - 6, tailEnd);
                body.AddBezier(cx - 6, tailEnd, cx - 14, tailEnd - 24, x0, cabinEnd + TailH * 0.45f, x0, cabinEnd);
                body.CloseFigure();
                using (var b = new SolidBrush(skin)) g.FillPath(b, body);
                using (var p = new Pen(line, 2f)) g.DrawPath(p, body);
            }

            // Kính buồng lái
            using (var cockpit = new GraphicsPath())
            {
                float cy = 64;
                cockpit.AddBezier(cx - 34, cy + 14, cx - 18, cy - 4, cx + 18, cy - 4, cx + 34, cy + 14);
                cockpit.AddLine(cx + 34, cy + 14, cx + 27, cy + 28);
                cockpit.AddBezier(cx + 27, cy + 28, cx + 12, cy + 20, cx - 12, cy + 20, cx - 27, cy + 28);
                cockpit.CloseFigure();
                using (var b = new SolidBrush(Color.FromArgb(156, 201, 211))) g.FillPath(b, cockpit);
            }

            // Cửa sổ hai bên thân, mỗi hàng ghế một ô
            using (var b = new SolidBrush(Color.FromArgb(201, 218, 223)))
            {
                foreach (int row in _rows)
                {
                    int y = _rowY[row] + 10;
                    g.FillRectangle(b, x0 + 4, y, 4, 14);
                    g.FillRectangle(b, x1 - 8, y, 4, 14);
                }
            }

            // Cánh đuôi đứng (nhìn từ trên là một sống mảnh)
            using (var b = new SolidBrush(Color.FromArgb(213, 227, 230)))
                g.FillRectangle(b, cx - 2.5f, tailEnd - 96, 5, 84);

            var lbl = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(g, "MŨI MÁY BAY", AppTheme.FontLabel, new Rectangle(x0, NoseH - 46, fw, 20), AppTheme.Muted, lbl);
            TextRenderer.DrawText(g, "ĐUÔI MÁY BAY", AppTheme.FontLabel, new Rectangle(x0, cabinEnd + 18, fw, 20), AppTheme.Muted, lbl);
        }

        private void DrawSeat(Graphics g, GheDTO s, Rectangle r)
        {
            bool taken = !s.Trong, inCart = _inCart.Contains(s.MaGhe);
            bool sel = _selected == s.MaGhe, hover = _hover == s.MaGhe && !taken && !inCart;
            Color cls = AppTheme.HangVeColor(s.MaHangVe);

            Color fill, border, text;
            if (taken) { fill = AppTheme.SeatTaken; border = AppTheme.SeatTaken; text = AppTheme.DisabledText; }
            else if (inCart) { fill = AppTheme.Accent; border = AppTheme.Accent; text = AppTheme.AccentText; }
            else if (sel) { fill = AppTheme.PrimaryDark; border = AppTheme.PrimaryDark; text = Color.White; }
            else if (hover) { fill = AppTheme.HangVeSoft(s.MaHangVe); border = cls; text = AppTheme.HangVeText(s.MaHangVe); }
            else { fill = Color.White; border = cls; text = AppTheme.HangVeText(s.MaHangVe); }

            if (sel) AppTheme.DrawShadow(g, r, 8, 3);
            var rf = new RectangleF(r.X + 1, r.Y + 1, r.Width - 2, r.Height - 2);
            using (var path = AppTheme.RoundedRect(rf, 7))
            {
                using (var b = new SolidBrush(fill)) g.FillPath(b, path);
                using (var p = new Pen(border, 2f)) g.DrawPath(p, path);
            }
            // Lưng ghế (phía sau hành khách, tức phía đuôi)
            using (var b = new SolidBrush(Color.FromArgb(sel || inCart ? 60 : 40, taken ? Color.Gray : border)))
            using (var path = AppTheme.RoundedRect(new RectangleF(r.X + 5, r.Bottom - 8, r.Width - 10, 4), 2f))
                g.FillPath(b, path);

            TextRenderer.DrawText(g, s.SoGhe, FontSeat, new Rectangle(r.X, r.Y - 2, r.Width, r.Height - 4), text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
