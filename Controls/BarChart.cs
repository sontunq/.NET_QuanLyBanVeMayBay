using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class BarChart : Control
    {
        private List<KeyValuePair<string, decimal>> _data = new List<KeyValuePair<string, decimal>>();

        public BarChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            Size = new Size(600, 300);
        }

        public void SetData(IEnumerable<KeyValuePair<string, decimal>> data)
        {
            _data = data.ToList();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_data.Count == 0)
            {
                TextRenderer.DrawText(g, "Chưa có giao dịch thanh toán", AppTheme.FontBase, ClientRectangle, AppTheme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            const int left = 58, right = 8, top = 24, bottom = 30;
            var plot = new Rectangle(left, top, Width - left - right, Height - top - bottom);
            if (plot.Width < 60 || plot.Height < 40) return;

            decimal max = Math.Max(_data.Max(x => x.Value), 0);
            if (max <= 0) max = 1;
            decimal step = NiceStep(max / 4);
            decimal axisMax = Math.Ceiling(max / step) * step;

            using (var grid = new Pen(Color.FromArgb(230, 236, 238)) { DashStyle = DashStyle.Dash })
            {
                for (decimal t = 0; t <= axisMax; t += step)
                {
                    float y = plot.Bottom - (float)(t / axisMax) * plot.Height;
                    if (t > 0) g.DrawLine(grid, plot.Left, y, plot.Right, y);
                    TextRenderer.DrawText(g, DinhDang.TienNgan(t), AppTheme.FontSmall, new Rectangle(0, (int)y - 9, left - 10, 18),
                        AppTheme.Muted, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                }
            }
            using (var axis = new Pen(Color.FromArgb(221, 229, 232)))
                g.DrawLine(axis, plot.Left, plot.Bottom, plot.Right, plot.Bottom);

            int n = _data.Count;
            float slot = plot.Width / (float)n;
            float bw = Math.Min(46f, slot * 0.58f);
            for (int i = 0; i < n; i++)
            {
                decimal v = Math.Max(_data[i].Value, 0);
                float h = (float)(v / axisMax) * plot.Height;
                float x = plot.Left + i * slot + (slot - bw) / 2;
                if (h > 0.5f)
                {
                    using (var path = TopRounded(new RectangleF(x, plot.Bottom - h, bw, h), Math.Min(6f, h)))
                    using (var b = new SolidBrush(i == n - 1 ? AppTheme.Accent : AppTheme.Primary))
                        g.FillPath(b, path);
                }
                var col = new Rectangle((int)(plot.Left + i * slot), 0, (int)slot, 0);
                TextRenderer.DrawText(g, _data[i].Key, AppTheme.FontSmall, new Rectangle(col.X, plot.Bottom + 7, col.Width, 18),
                    AppTheme.Muted, TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(g, DinhDang.TienNgan(_data[i].Value), AppTheme.FontLabel,
                    new Rectangle(col.X, (int)(plot.Bottom - h) - 19, col.Width, 16), AppTheme.Text, TextFormatFlags.HorizontalCenter);
            }
        }

        private static GraphicsPath TopRounded(RectangleF r, float radius)
        {
            var p = new GraphicsPath();
            float d = radius * 2;
            p.AddLine(r.X, r.Bottom, r.X, r.Y + radius);
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddLine(r.Right, r.Y + radius, r.Right, r.Bottom);
            p.CloseFigure();
            return p;
        }

        private static decimal NiceStep(decimal raw)
        {
            double r = (double)raw;
            if (r <= 0) return 1;
            double mag = Math.Pow(10, Math.Floor(Math.Log10(r)));
            double norm = r / mag;
            double nice = norm <= 1 ? 1 : norm <= 2 ? 2 : norm <= 5 ? 5 : 10;
            return (decimal)(nice * mag);
        }
    }
}
