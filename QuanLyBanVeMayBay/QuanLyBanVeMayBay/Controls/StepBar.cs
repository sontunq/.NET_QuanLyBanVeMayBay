using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class StepBar : Control
    {
        private int _done;
        private readonly string[] _steps = { "Chọn chuyến", "Chọn ghế", "Thanh toán" };

        public StepBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(430, 40);
        }

        [DefaultValue(0)]
        public int StepsDone
        {
            get { return _done; }
            set { _done = Math.Max(0, Math.Min(_steps.Length, value)); Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(AppTheme.BackgroundOf(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int x = 0, cy = Height / 2;
            for (int i = 0; i < _steps.Length; i++)
            {
                bool done = i < _done, current = i == _done;
                var circle = new Rectangle(x, cy - 13, 26, 26);
                if (done)
                {
                    using (var b = new SolidBrush(AppTheme.Primary)) g.FillEllipse(b, circle);
                    using (var p = new Pen(Color.White, 2.2f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                        g.DrawLines(p, new[] { new Point(x + 7, cy), new Point(x + 11, cy + 5), new Point(x + 19, cy - 5) });
                }
                else
                {
                    using (var b = new SolidBrush(current ? AppTheme.PrimarySoft : Color.FromArgb(238, 241, 243))) g.FillEllipse(b, circle);
                    using (var p = new Pen(current ? AppTheme.Primary : AppTheme.InputBorder, 2f)) g.DrawEllipse(p, circle);
                    TextRenderer.DrawText(g, (i + 1).ToString(), AppTheme.FontLabel, circle, current ? AppTheme.Primary : AppTheme.Muted,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                x += 32;
                Font f = done || current ? AppTheme.FontBold : AppTheme.FontBase;
                Size t = TextRenderer.MeasureText(_steps[i], f);
                TextRenderer.DrawText(g, _steps[i], f, new Point(x, cy - t.Height / 2), done || current ? AppTheme.Heading : AppTheme.Muted);
                x += t.Width + 8;

                if (i < _steps.Length - 1)
                {
                    using (var p = new Pen(done ? AppTheme.Primary : AppTheme.InputBorder, 2f))
                        g.DrawLine(p, x, cy, x + 22, cy);
                    x += 30;
                }
            }
        }
    }
}
