using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class InputBox : Panel
    {
        private bool _focused;

        public InputBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            Padding = new Padding(12, 11, 12, 6);
            Size = new Size(240, 42);
            Cursor = Cursors.IBeam;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.GotFocus += Child_FocusChanged;
            e.Control.LostFocus += Child_FocusChanged;
            e.Control.BackColor = Color.White;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Controls.Count > 0) Controls[0].Focus();
        }

        private void Child_FocusChanged(object sender, EventArgs e)
        {
            _focused = Controls.Cast<Control>().Any(c => c.Focused);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(AppTheme.BackgroundOf(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (var path = AppTheme.RoundedRect(r, 8))
            {
                using (var b = new SolidBrush(Color.White)) g.FillPath(b, path);
                using (var p = new Pen(_focused ? AppTheme.Primary : AppTheme.InputBorder, _focused ? 2f : 1f))
                    g.DrawPath(p, path);
            }
        }
    }
}
