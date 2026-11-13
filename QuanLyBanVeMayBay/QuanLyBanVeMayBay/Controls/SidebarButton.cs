using System.ComponentModel;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class SidebarButton : Button
    {
        private bool _active, _hover;
        private string _glyph = "";

        public SidebarButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = AppTheme.PrimaryDark;
            ForeColor = AppTheme.SidebarText;
            Font = new Font("Segoe UI", 10.5F);
            Size = new Size(248, 46);
            Margin = Padding.Empty;
            Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleLeft;
        }

        [Category("Giao diện"), DefaultValue("")]
        public string Glyph
        {
            get { return _glyph; }
            set { _glyph = value ?? ""; Invalidate(); }
        }

        [Category("Giao diện"), DefaultValue(false)]
        public bool Active
        {
            get { return _active; }
            set { _active = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Color back = _active ? AppTheme.SidebarActive : _hover ? AppTheme.SidebarHover : AppTheme.PrimaryDark;
            Color fore = _active || _hover ? Color.White : AppTheme.SidebarText;
            g.Clear(back);

            if (_active)
                using (var b = new SolidBrush(AppTheme.Accent))
                    g.FillRectangle(b, 0, 0, 4, Height);

            if (IconFont.Available && _glyph.Length > 0)
            {
                using (var f = IconFont.Get(12F))
                    TextRenderer.DrawText(g, _glyph, f, new Rectangle(22, 0, 24, Height), fore,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            using (var f = new Font(Font, _active ? FontStyle.Bold : FontStyle.Regular))
                TextRenderer.DrawText(g, Text, f, new Rectangle(58, 0, Width - 62, Height), fore,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if (Focused && ShowFocusCues)
                using (var p = new Pen(AppTheme.SidebarMuted) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                    g.DrawRectangle(p, 6, 4, Width - 13, Height - 9);
        }
    }
}
