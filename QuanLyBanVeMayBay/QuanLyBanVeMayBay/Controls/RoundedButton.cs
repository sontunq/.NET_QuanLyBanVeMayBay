using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    public enum ButtonKind
    {
        Primary,    // xanh ngọc
        Accent,     // vàng - hành động chính (Đặt vé, Thanh toán)
        Outline,    // viền xanh ngọc
        Danger,     // đỏ - hủy, xóa
        Dark        // dùng trên nền sidebar
    }

    [DesignerCategory("Code")]
    public class RoundedButton : Button
    {
        private ButtonKind _kind = ButtonKind.Primary;
        private int _radius = 8;
        private bool _hover, _down;

        public RoundedButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI Semibold", 10F);
            Size = new Size(120, 40);
            BackColor = Color.Transparent;
            UseVisualStyleBackColor = false;
        }

        [Category("Giao diện"), DefaultValue(ButtonKind.Primary)]
        public ButtonKind Kind
        {
            get { return _kind; }
            set { _kind = value; Invalidate(); }
        }

        [Category("Giao diện"), DefaultValue(8)]
        public int Radius
        {
            get { return _radius; }
            set { _radius = Math.Max(0, value); Invalidate(); }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size t = TextRenderer.MeasureText(Text ?? "", Font);
            return new Size(t.Width + 36, Math.Max(40, t.Height + 18));
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; _down = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _down = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _down = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        private void GetColors(out Color back, out Color fore, out Color border)
        {
            border = Color.Empty;
            if (!Enabled)
            {
                back = AppTheme.Disabled; fore = AppTheme.DisabledText;
                return;
            }
            switch (_kind)
            {
                case ButtonKind.Accent:
                    back = _down ? AppTheme.AccentDown : _hover ? AppTheme.AccentHover : AppTheme.Accent;
                    fore = AppTheme.AccentText;
                    break;
                case ButtonKind.Outline:
                    back = _down ? Color.FromArgb(211, 232, 237) : _hover ? AppTheme.PrimarySoft : Color.White;
                    fore = AppTheme.Primary;
                    border = AppTheme.Primary;
                    break;
                case ButtonKind.Danger:
                    back = _down ? Color.FromArgb(150, 24, 24) : _hover ? AppTheme.DangerHover : AppTheme.Danger;
                    fore = Color.White;
                    break;
                case ButtonKind.Dark:
                    back = _down ? AppTheme.PrimaryDark : _hover ? Color.FromArgb(19, 112, 138) : AppTheme.SidebarActive;
                    fore = Color.White;
                    break;
                default:
                    back = _down ? AppTheme.PrimaryDark : _hover ? AppTheme.PrimaryHover : AppTheme.Primary;
                    fore = Color.White;
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(AppTheme.BackgroundOf(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color back, fore, border;
            GetColors(out back, out fore, out border);

            var rect = new RectangleF(0.5f, 0.5f, Width - 1.5f, Height - 1.5f);
            using (var path = AppTheme.RoundedRect(rect, _radius))
            {
                using (var b = new SolidBrush(back)) g.FillPath(b, path);
                if (border != Color.Empty)
                    using (var p = new Pen(border, 1.5f)) g.DrawPath(p, path);
            }

            if (Focused && ShowFocusCues)
            {
                using (var path = AppTheme.RoundedRect(new RectangleF(3, 3, Width - 7, Height - 7), Math.Max(0, _radius - 3)))
                using (var p = new Pen(Color.FromArgb(160, fore), 1f) { DashStyle = DashStyle.Dot })
                    g.DrawPath(p, path);
            }

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        }
    }
}
