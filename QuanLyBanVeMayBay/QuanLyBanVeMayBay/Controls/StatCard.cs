using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class StatCard : Control
    {
        private string _caption = "Chỉ số";
        private string _value = "—";
        private string _glyph = "";
        private Color _iconBack = AppTheme.PrimarySoft;
        private Color _iconColor = AppTheme.Primary;
        private Color _valueColor = AppTheme.Heading;

        public StatCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(260, 104);
        }

        [Category("Giao diện"), DefaultValue("Chỉ số")]
        public string Caption { get { return _caption; } set { _caption = value; Invalidate(); } }

        [Category("Giao diện"), DefaultValue("—")]
        public string Value { get { return _value; } set { _value = value; Invalidate(); } }

        [Category("Giao diện"), DefaultValue("")]
        public string Glyph { get { return _glyph; } set { _glyph = value ?? ""; Invalidate(); } }

        [Category("Giao diện")]
        public Color IconBack { get { return _iconBack; } set { _iconBack = value; Invalidate(); } }

        [Category("Giao diện")]
        public Color IconColor { get { return _iconColor; } set { _iconColor = value; Invalidate(); } }

        [Category("Giao diện")]
        public Color ValueColor { get { return _valueColor; } set { _valueColor = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(AppTheme.BackgroundOf(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var card = new Rectangle(5, 2, Width - 11, Height - 10);
            AppTheme.DrawShadow(g, card, 12, 5);
            using (var path = AppTheme.RoundedRect(card, 12))
            {
                using (var b = new SolidBrush(Color.White)) g.FillPath(b, path);
                using (var p = new Pen(AppTheme.Border)) g.DrawPath(p, path);
            }

            var icon = new Rectangle(card.X + 18, card.Y + (card.Height - 48) / 2, 48, 48);
            using (var path = AppTheme.RoundedRect(icon, 12))
            using (var b = new SolidBrush(_iconBack))
                g.FillPath(b, path);
            if (IconFont.Available && _glyph.Length > 0)
                using (var f = IconFont.Get(16F))
                    TextRenderer.DrawText(g, _glyph, f, icon, _iconColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            int tx = icon.Right + 16;
            TextRenderer.DrawText(g, _caption, AppTheme.FontBase, new Rectangle(tx, card.Y + 20, card.Right - tx - 10, 22),
                AppTheme.Muted, TextFormatFlags.EndEllipsis);
            TextRenderer.DrawText(g, _value, AppTheme.FontBig, new Rectangle(tx - 2, card.Y + 42, card.Right - tx - 6, 40),
                _valueColor, TextFormatFlags.EndEllipsis);
        }
    }
}
