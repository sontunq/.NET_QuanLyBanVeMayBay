using System.Drawing.Drawing2D;

namespace QuanLyBanVeMayBay.Utils
{
    public static class AppTheme
    {
        // Màu chủ đạo
        public static readonly Color Primary = Color.FromArgb(0, 104, 133);        // #006885
        public static readonly Color PrimaryDark = Color.FromArgb(0, 75, 95);      // #004B5F
        public static readonly Color PrimaryHover = Color.FromArgb(0, 90, 115);
        public static readonly Color PrimarySoft = Color.FromArgb(230, 242, 244);  // #E6F2F4
        public static readonly Color SidebarActive = Color.FromArgb(11, 98, 120);  // #0B6278
        public static readonly Color SidebarHover = Color.FromArgb(7, 86, 107);
        public static readonly Color SidebarText = Color.FromArgb(211, 230, 234);
        public static readonly Color SidebarMuted = Color.FromArgb(169, 204, 212);

        // Màu nhấn vàng
        public static readonly Color Accent = Color.FromArgb(200, 162, 74);        // #C8A24A
        public static readonly Color AccentHover = Color.FromArgb(184, 146, 60);
        public static readonly Color AccentDown = Color.FromArgb(166, 131, 47);
        public static readonly Color AccentText = Color.FromArgb(31, 26, 14);
        public static readonly Color Price = Color.FromArgb(138, 106, 31);         // giá tiền trên nền trắng

        // Nền, chữ, viền
        public static readonly Color Background = Color.FromArgb(245, 247, 248);
        public static readonly Color Surface = Color.White;
        public static readonly Color Border = Color.FromArgb(225, 232, 235);
        public static readonly Color InputBorder = Color.FromArgb(201, 214, 218);
        public static readonly Color Heading = Color.FromArgb(15, 42, 51);
        public static readonly Color Text = Color.FromArgb(30, 42, 48);
        public static readonly Color TextSecondary = Color.FromArgb(61, 74, 82);
        public static readonly Color Muted = Color.FromArgb(91, 102, 112);
        public static readonly Color Disabled = Color.FromArgb(228, 232, 235);
        public static readonly Color DisabledText = Color.FromArgb(126, 137, 144);

        public static readonly Color Danger = Color.FromArgb(198, 40, 40);
        public static readonly Color DangerHover = Color.FromArgb(176, 30, 30);

        // Hạng ghế: 1 = Phổ thông, 2 = Phổ thông đặc biệt, 3 = Thương gia
        public static readonly Color SeatEconomy = Color.FromArgb(37, 99, 168);
        public static readonly Color SeatPremium = Color.FromArgb(0, 121, 110);
        public static readonly Color SeatBusiness = Color.FromArgb(168, 132, 47);
        public static readonly Color SeatTaken = Color.FromArgb(228, 232, 235);

        // Badge trạng thái (nền, chữ)
        public static readonly Color GoodBack = Color.FromArgb(229, 243, 234), GoodText = Color.FromArgb(31, 110, 67);
        public static readonly Color WarnBack = Color.FromArgb(253, 240, 225), WarnText = Color.FromArgb(154, 74, 0);
        public static readonly Color BadBack = Color.FromArgb(251, 234, 234), BadText = Color.FromArgb(180, 35, 24);
        public static readonly Color InfoBack = Color.FromArgb(232, 240, 250), InfoText = Color.FromArgb(31, 85, 144);

        // Font
        public static readonly Font FontBase = new Font("Segoe UI", 10F);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.75F);
        public static readonly Font FontLabel = new Font("Segoe UI Semibold", 8.25F);
        public static readonly Font FontBold = new Font("Segoe UI Semibold", 10F);
        public static readonly Font FontCardTitle = new Font("Segoe UI Semibold", 12.5F);
        public static readonly Font FontTitle = new Font("Segoe UI Semibold", 18F);
        public static readonly Font FontBig = new Font("Segoe UI Semibold", 20F);

        public static Color HangVeColor(int maHangVe)
        {
            return maHangVe == 3 ? SeatBusiness : maHangVe == 2 ? SeatPremium : SeatEconomy;
        }

        public static Color HangVeSoft(int maHangVe)
        {
            return maHangVe == 3 ? Color.FromArgb(247, 240, 222)
                 : maHangVe == 2 ? Color.FromArgb(226, 243, 241)
                 : Color.FromArgb(232, 240, 250);
        }

        public static Color HangVeText(int maHangVe)
        {
            return maHangVe == 3 ? Color.FromArgb(122, 92, 20)
                 : maHangVe == 2 ? Color.FromArgb(0, 102, 93)
                 : Color.FromArgb(31, 85, 144);
        }

        public static void StatusColors(string trangThai, out Color back, out Color fore)
        {
            switch (trangThai)
            {
                case "Đã thanh toán":
                case "Thành công":
                case "Đang mở bán":
                case "Hoạt động":
                case "Còn hiệu lực":
                case "Đã đặt":
                case "Trống":
                    back = GoodBack; fore = GoodText; break;
                case "Chờ thanh toán":
                case "Bảo trì":
                case "Đã hoàn":
                case "Đã đóng":
                    back = WarnBack; fore = WarnText; break;
                case "Đã hủy":
                case "Bị khóa":
                case "Thất bại":
                case "Hết hạn":
                case "Ngừng hoạt động":
                    back = BadBack; fore = BadText; break;
                case "Đã bay":
                    back = InfoBack; fore = InfoText; break;
                default:
                    back = Color.FromArgb(238, 241, 243); fore = TextSecondary; break;
            }
        }

        public static Color BackgroundOf(Control c)
        {
            Control p = c?.Parent;
            while (p != null)
            {
                var card = p as Controls.CardPanel;
                if (card != null) return card.FillColor;
                if (p.BackColor.A == 255) return p.BackColor;
                p = p.Parent;
            }
            return Background;
        }

        public static GraphicsPath RoundedRect(RectangleF r, float radius)
        {
            var path = new GraphicsPath();
            float d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
            if (d <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void DrawShadow(Graphics g, Rectangle card, float radius, int size)
        {
            for (int i = size; i >= 1; i--)
            {
                int alpha = (int)(14f * (size - i + 1) / size);
                var r = new RectangleF(card.X - i + 1, card.Y - i + 3, card.Width + 2 * i - 2, card.Height + 2 * i - 2);
                using (var path = RoundedRect(r, radius + i))
                using (var b = new SolidBrush(Color.FromArgb(alpha, 15, 42, 51)))
                    g.FillPath(b, path);
            }
        }
    }
}
