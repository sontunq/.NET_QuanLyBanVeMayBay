using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class CardPanel : Panel
    {
        private string _title = "";
        private string _subtitle = "";
        private int _radius = 12;
        private int _shadow = 6;
        private Color _fillColor = Color.White;

        public CardPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = AppTheme.Background;
            Padding = new Padding(22, 20, 22, 20);
        }

        [Category("Giao diện"), DefaultValue("")]
        public string Title
        {
            get { return _title; }
            set { _title = value ?? ""; Invalidate(); }
        }

        [Category("Giao diện"), DefaultValue("")]
        public string Subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value ?? ""; Invalidate(); }
        }

        [Category("Giao diện"), DefaultValue(12)]
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; Invalidate(); }
        }

        [Category("Giao diện"), DefaultValue(6)]
        public int ShadowSize
        {
            get { return _shadow; }
            set { _shadow = Math.Max(0, value); Invalidate(); }
        }

        [Category("Giao diện")]
        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; Invalidate(); }
        }

        private bool ShouldSerializeFillColor() => _fillColor != Color.White;
        private void ResetFillColor() => FillColor = Color.White;

        public Rectangle CardBounds => new Rectangle(_shadow, _shadow / 2, Width - _shadow * 2 - 1, Height - _shadow * 2 - 1);

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle card = CardBounds;
            if (card.Width <= 0 || card.Height <= 0) return;
            if (_shadow > 0) AppTheme.DrawShadow(g, card, _radius, _shadow);

            using (var path = AppTheme.RoundedRect(card, _radius))
            {
                using (var b = new SolidBrush(_fillColor)) g.FillPath(b, path);
                using (var p = new Pen(AppTheme.Border)) g.DrawPath(p, path);
            }

            if (_title.Length > 0)
            {
                TextRenderer.DrawText(g, _title, AppTheme.FontCardTitle, new Point(card.X + 16, card.Y + 14), AppTheme.Heading);
                if (_subtitle.Length > 0)
                {
                    Size t = TextRenderer.MeasureText(_title, AppTheme.FontCardTitle);
                    TextRenderer.DrawText(g, _subtitle, AppTheme.FontSmall, new Point(card.X + 16 + t.Width + 4, card.Y + 19), AppTheme.Muted);
                }
            }
        }
    }
}
