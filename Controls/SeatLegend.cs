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

        private List<(int Ma, string Ten)> _hangVe = new List<(int Ma, string Ten)>();

        /// <summary>Nạp danh sách hạng vé (mã + tên lấy từ CSDL) để hiển thị chú thích.</summary>
        public void SetHangVe(IEnumerable<(int Ma, string Ten)> hangVe)
        {
            _hangVe = hangVe?.OrderBy(h => h.Ma).ToList() ?? new List<(int Ma, string Ten)>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var items = _hangVe.Select(h => (Fill: Color.White, Border: AppTheme.HangVeColor(h.Ma), Text: h.Ten)).ToList();
            items.Add((AppTheme.PrimaryDark, AppTheme.PrimaryDark, "Đang chọn"));
            items.Add((AppTheme.Accent, AppTheme.Accent, "Trong đơn"));
            items.Add((AppTheme.SeatTaken, AppTheme.SeatTaken, "Đã có người đặt"));
            int colW = Math.Max(120, Width / 3);
            for (int i = 0; i < items.Count; i++)
            {
                int x = (i % 3) * colW, y = (i / 3) * 26 + 4;
                var box = new RectangleF(x + 1, y + 2, 16, 16);
                using (var path = AppTheme.RoundedRect(box, 4))
                {
                    using (var b = new SolidBrush(items[i].Fill)) g.FillPath(b, path);
                    using (var p = new Pen(items[i].Border, 2f)) g.DrawPath(p, path);
                }
                TextRenderer.DrawText(g, items[i].Text, AppTheme.FontSmall, new Rectangle(x + 24, y + 1, colW - 28, 22), AppTheme.TextSecondary,
                    TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis);
            }
        }
    }
}
