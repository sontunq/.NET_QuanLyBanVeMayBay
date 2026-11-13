using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class SeatLegend : Control
    {
        public SeatLegend()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(440, 56);
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var items = new (Color Fill, Color Border, string Text)[]
            {
                (Color.White, AppTheme.SeatEconomy, "Phổ thông"),
                (Color.White, AppTheme.SeatPremium, "PT đặc biệt"),
                (Color.White, AppTheme.SeatBusiness, "Thương gia"),
                (AppTheme.PrimaryDark, AppTheme.PrimaryDark, "Đang chọn"),
                (AppTheme.Accent, AppTheme.Accent, "Trong đơn"),
                (AppTheme.SeatTaken, AppTheme.SeatTaken, "Đã có người đặt"),
            };
            int colW = Math.Max(120, Width / 3);
            for (int i = 0; i < items.Length; i++)
            {
                int x = (i % 3) * colW, y = (i / 3) * 26 + 4;
                var box = new RectangleF(x + 1, y + 2, 16, 16);
                using (var path = AppTheme.RoundedRect(box, 4))
                {
                    using (var b = new SolidBrush(items[i].Fill)) g.FillPath(b, path);
                    using (var p = new Pen(items[i].Border, 2f)) g.DrawPath(p, path);
                }
                TextRenderer.DrawText(g, items[i].Text, AppTheme.FontSmall, new Point(x + 24, y + 1), AppTheme.TextSecondary);
            }
        }
    }
}
