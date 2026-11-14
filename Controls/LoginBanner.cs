using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class LoginBanner : Control
    {
        private static readonly Font FontApp = new Font("Segoe UI Semibold", 13F);
        private static readonly Font FontTag = new Font("Segoe UI Semibold", 9F);
        private static readonly Font FontHeadline = new Font("Segoe UI Semibold", 26F);
        private static readonly Font FontBody = new Font("Segoe UI", 11F);

        public LoginBanner()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(520, 600);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            int w = Width, h = Height;
            g.Clear(AppTheme.PrimaryDark);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Mặt trời / vòng tròn trang trí
            using (var b = new SolidBrush(AppTheme.SidebarActive)) g.FillEllipse(b, w - 260, -120, 380, 380);
            using (var b = new SolidBrush(Color.FromArgb(19, 112, 138))) g.FillEllipse(b, w - 180, -40, 220, 220);

            // Mây
            using (var b = new SolidBrush(Color.FromArgb(34, 255, 255, 255)))
            {
                g.FillEllipse(b, 60, 190, 150, 34); g.FillEllipse(b, 110, 172, 90, 38);
                g.FillEllipse(b, w - 250, h - 300, 170, 36); g.FillEllipse(b, w - 200, h - 320, 96, 40);
            }

            // Sóng (mặt đất/biển) ở dưới
            using (var p = new GraphicsPath())
            {
                p.AddBezier(-10, h - 150, w * 0.3f, h - 230, w * 0.55f, h - 80, w + 10, h - 170);
                p.AddLine(w + 10, h - 170, w + 10, h + 10);
                p.AddLine(w + 10, h + 10, -10, h + 10);
                p.CloseFigure();
                using (var b = new SolidBrush(Color.FromArgb(0, 90, 112))) g.FillPath(b, p);
            }
            using (var p = new GraphicsPath())
            {
                p.AddBezier(-10, h - 80, w * 0.35f, h - 140, w * 0.6f, h - 30, w + 10, h - 100);
                p.AddLine(w + 10, h - 100, w + 10, h + 10);
                p.AddLine(w + 10, h + 10, -10, h + 10);
                p.CloseFigure();
                using (var b = new SolidBrush(Color.FromArgb(0, 104, 127))) g.FillPath(b, p);
            }

            // Đường bay nét đứt + máy bay
            var start = new PointF(70, h * 0.62f);
            var end = new PointF(w - 120, 150);
            using (var pen = new Pen(AppTheme.Accent, 2f) { DashPattern = new[] { 3f, 5f }, DashCap = DashCap.Round })
                g.DrawBezier(pen, start, new PointF(w * 0.35f, h * 0.55f), new PointF(w * 0.55f, 260), end);
            var state = g.Save();
            g.TranslateTransform(end.X + 14, end.Y - 8);
            g.RotateTransform(-32);
            FlightCard.DrawPlane(g, PointF.Empty, 26f, AppTheme.Accent);
            g.Restore(state);

            // Logo + tên ứng dụng
            var logo = new Rectangle(48, 44, 46, 46);
            using (var path = AppTheme.RoundedRect(logo, 12))
            using (var b = new SolidBrush(AppTheme.Accent))
                g.FillPath(b, path);
            FlightCard.DrawPlane(g, new PointF(logo.X + 23, logo.Y + 23), 14f, AppTheme.AccentText);
            TextRenderer.DrawText(g, "Quản lý bán vé máy bay", FontApp, new Point(logo.Right + 14, logo.Y + 10), Color.White);

            // Khẩu hiệu
            int y = (int)(h * 0.44f);
            TextRenderer.DrawText(g, "HỆ THỐNG DÀNH CHO NHÂN VIÊN", FontTag, new Point(50, y), Color.FromArgb(226, 199, 126));
            TextRenderer.DrawText(g, "Mỗi tấm vé,\nmột hành trình trọn vẹn.", FontHeadline,
                new Rectangle(46, y + 24, w - 90, 100), Color.White, TextFormatFlags.WordBreak);
            TextRenderer.DrawText(g, "Đặt vé · Sơ đồ ghế · Thanh toán · Hủy vé\nKhách hàng thành viên · Báo cáo doanh thu", FontBody,
                new Rectangle(50, y + 128, w - 90, 60), AppTheme.SidebarText, TextFormatFlags.WordBreak);
        }
    }
}
