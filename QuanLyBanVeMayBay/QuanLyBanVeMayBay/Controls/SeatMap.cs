using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class SeatMap : Control
    {
        private const int SeatSize = 40, Gap = 8, Aisle = 26, RowLabel = 22, Pad = 24;
        private const int WingSpan = 92, NoseH = 118, TailH = 112, HeaderH = 28;

        private readonly List<GheDTO> _seats = new List<GheDTO>();
        private readonly Dictionary<int, decimal> _gia = new Dictionary<int, decimal>();
        private readonly HashSet<int> _inCart = new HashSet<int>();
        private readonly Dictionary<int, Rectangle> _rects = new Dictionary<int, Rectangle>();
        private readonly ToolTip _tip = new ToolTip { InitialDelay = 200, ReshowDelay = 100 };

        private List<string> _cols = new List<string>();
        private List<int> _rows = new List<int>();
        private int? _selected, _hover;

        private static readonly Font FontSeat = new Font("Segoe UI Semibold", 9F);

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

        private int AisleAfter => _cols.Count >= 4 ? (_cols.Count + 1) / 2 : -1;

        private int GridWidth
        {
            get
            {
                int n = Math.Max(1, _cols.Count);
                return RowLabel + Gap + n * SeatSize + (n - 1) * Gap + (AisleAfter > 0 ? Aisle - Gap : 0);
            }
        }

        private int FuselageWidth => GridWidth + Pad * 2;
        private int CabinHeight => HeaderH + _rows.Count * (SeatSize + Gap);

        private void Layout_()
        {
            _rects.Clear();
            if (_seats.Count == 0)
            {
                Size = new Size(420, 260);
                return;
            }
            int x0 = WingSpan;
            foreach (var s in _seats)
            {
                int ci = _cols.IndexOf(s.CotGhe), ri = _rows.IndexOf(s.SoHang);
                int x = x0 + Pad + RowLabel + Gap + ci * (SeatSize + Gap) + (AisleAfter > 0 && ci >= AisleAfter ? Aisle - Gap : 0);
                int y = NoseH + HeaderH + ri * (SeatSize + Gap);
                _rects[s.MaGhe] = new Rectangle(x, y, SeatSize, SeatSize);
            }
            Size = new Size(FuselageWidth + WingSpan * 2, NoseH + CabinHeight + TailH);
        }

        private int? HitTest(Point p)
        {
            foreach (var kv in _rects)
                if (kv.Value.Contains(p)) return kv.Key;
            return null;
        }

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

            int x0 = WingSpan;
            // Tiêu đề cột
            for (int i = 0; i < _cols.Count; i++)
            {
                int x = x0 + Pad + RowLabel + Gap + i * (SeatSize + Gap) + (AisleAfter > 0 && i >= AisleAfter ? Aisle - Gap : 0);
                TextRenderer.DrawText(g, _cols[i], AppTheme.FontLabel, new Rectangle(x, NoseH + 2, SeatSize, 20), AppTheme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            // Số hàng
            for (int i = 0; i < _rows.Count; i++)
            {
                int y = NoseH + HeaderH + i * (SeatSize + Gap);
                TextRenderer.DrawText(g, _rows[i].ToString(), AppTheme.FontSmall, new Rectangle(x0 + Pad, y, RowLabel, SeatSize), AppTheme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            foreach (var s in _seats) DrawSeat(g, s, _rects[s.MaGhe]);
        }

        private void DrawEmpty(Graphics g)
        {
            var r = ClientRectangle;
            FlightCard.DrawPlane(g, new PointF(r.Width / 2f, r.Height / 2f - 30), 22f, Color.FromArgb(182, 203, 209));
            TextRenderer.DrawText(g, "Chọn một chuyến bay để xem sơ đồ ghế", AppTheme.FontBase,
                new Rectangle(0, r.Height / 2, r.Width, 30), AppTheme.Muted, TextFormatFlags.HorizontalCenter);
        }

        private void DrawAirplane(Graphics g)
        {
            int fw = FuselageWidth, x0 = WingSpan, x1 = x0 + fw;
            float cx = x0 + fw / 2f;
            int th = Height;
            int tailTop = NoseH + CabinHeight + 6;
            Color skin = Color.FromArgb(250, 252, 252), metal = Color.FromArgb(230, 238, 240), line = Color.FromArgb(195, 213, 218);

            using (var fill = new SolidBrush(metal))
            using (var pen = new Pen(line, 2f) { LineJoin = LineJoin.Round })
            {
                // Cánh (gắn khoảng hàng thứ 2)
                float wy = NoseH + HeaderH + Math.Min(CabinHeight * 0.18f, 60);
                var wingL = new[] { new PointF(x0, wy), new PointF(6, wy + 92), new PointF(6, wy + 118), new PointF(x0, wy + 78) };
                var wingR = wingL.Select(p => new PointF(2 * cx - p.X, p.Y)).ToArray();
                g.FillPolygon(fill, wingL); g.DrawPolygon(pen, wingL);
                g.FillPolygon(fill, wingR); g.DrawPolygon(pen, wingR);

                // Động cơ
                foreach (float ex in new[] { x0 - 58f, x1 + 38f })
                {
                    using (var path = AppTheme.RoundedRect(new RectangleF(ex, wy + 60, 20, 42), 10))
                    using (var b = new SolidBrush(Color.FromArgb(213, 227, 230)))
                    {
                        g.FillPath(b, path);
                        g.DrawPath(pen, path);
                    }
                }

                // Cánh đuôi
                float ty = th - 72;
                var stabL = new[] { new PointF(cx - 26, ty), new PointF(cx - 104, ty + 46), new PointF(cx - 104, ty + 60), new PointF(cx - 18, ty + 42) };
                var stabR = stabL.Select(p => new PointF(2 * cx - p.X, p.Y)).ToArray();
                g.FillPolygon(fill, stabL); g.DrawPolygon(pen, stabL);
                g.FillPolygon(fill, stabR); g.DrawPolygon(pen, stabR);
            }

            // Thân máy bay
            using (var body = new GraphicsPath())
            {
                body.AddBezier(x0, NoseH, x0, NoseH * 0.35f, cx - fw * 0.3f, 8, cx, 8);
                body.AddBezier(cx, 8, cx + fw * 0.3f, 8, x1, NoseH * 0.35f, x1, NoseH);
                body.AddLine(x1, NoseH, x1, tailTop);
                body.AddBezier(x1, tailTop, x1, tailTop + 60, cx + 40, th - 30, cx + 16, th - 6);
                body.AddLine(cx + 16, th - 6, cx - 16, th - 6);
                body.AddBezier(cx - 16, th - 6, cx - 40, th - 30, x0, tailTop + 60, x0, tailTop);
                body.CloseFigure();
                using (var b = new SolidBrush(skin)) g.FillPath(b, body);
                using (var p = new Pen(line, 2f)) g.DrawPath(p, body);
            }

            // Kính buồng lái
            using (var cockpit = new GraphicsPath())
            {
                cockpit.AddBezier(cx - 40, 62, cx - 20, 44, cx + 20, 44, cx + 40, 62);
                cockpit.AddLine(cx + 40, 62, cx + 31, 78);
                cockpit.AddBezier(cx + 31, 78, cx + 14, 68, cx - 14, 68, cx - 31, 78);
                cockpit.CloseFigure();
                using (var b = new SolidBrush(Color.FromArgb(156, 201, 211))) g.FillPath(b, cockpit);
            }

            // Cửa sổ hai bên thân
            using (var b = new SolidBrush(Color.FromArgb(201, 218, 223)))
            {
                for (int i = 0; i < _rows.Count; i++)
                {
                    int y = NoseH + HeaderH + i * (SeatSize + Gap) + 12;
                    g.FillRectangle(b, x0 + 7, y, 5, 16);
                    g.FillRectangle(b, x1 - 12, y, 5, 16);
                }
            }

            // Sống đuôi
            using (var b = new SolidBrush(metal))
                g.FillRectangle(b, cx - 3, tailTop + 52, 6, th - tailTop - 60);

            var lbl = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(g, "MŨI MÁY BAY", AppTheme.FontLabel, new Rectangle(x0, NoseH - 32, fw, 20), AppTheme.Muted, lbl);
            TextRenderer.DrawText(g, "ĐUÔI MÁY BAY", AppTheme.FontLabel, new Rectangle(x0, tailTop + 16, fw, 20), AppTheme.Muted, lbl);
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
            using (var path = AppTheme.RoundedRect(rf, 8))
            {
                using (var b = new SolidBrush(fill)) g.FillPath(b, path);
                using (var p = new Pen(border, 2f)) g.DrawPath(p, path);
            }
            // Lưng ghế (phía sau hành khách, tức phía đuôi)
            using (var b = new SolidBrush(Color.FromArgb(sel || inCart ? 60 : 40, taken ? Color.Gray : border)))
            using (var path = AppTheme.RoundedRect(new RectangleF(r.X + 6, r.Bottom - 9, r.Width - 12, 5), 2.5f))
                g.FillPath(b, path);

            TextRenderer.DrawText(g, s.SoGhe, FontSeat, new Rectangle(r.X, r.Y - 2, r.Width, r.Height - 4), text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
