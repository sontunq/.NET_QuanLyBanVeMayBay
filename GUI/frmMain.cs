using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Controls;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmMain : Form
    {
        public bool DaDangXuat { get; private set; }

        private readonly Dictionary<SidebarButton, Func<UserControl>> _taoTrang = new Dictionary<SidebarButton, Func<UserControl>>();
        private readonly Dictionary<SidebarButton, UserControl> _trang = new Dictionary<SidebarButton, UserControl>();
        private SidebarButton _dangChon;

        public frmMain()
        {
            InitializeComponent();
            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(pnlContent, true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _taoTrang[btnTongQuan] = () => new ucTongQuan();
            _taoTrang[btnDatVe] = () => new ucDatVe();
            _taoTrang[btnDonDatVe] = () => new ucDonDatVe();
            _taoTrang[btnTraCuu] = () => new ucTraCuuVe();
            _taoTrang[btnKhachHang] = () => new ucKhachHang();
            _taoTrang[btnChuyenBay] = () => new ucChuyenBay();
            _taoTrang[btnMayBay] = () => new ucMayBay();
            _taoTrang[btnBaoCao] = () => new ucBaoCao();
            _taoTrang[btnTaiKhoan] = () => new ucTaiKhoan();
            _taoTrang[btnNhatKy] = () => new ucNhatKy();

            // Nhân viên không thấy các mục quản trị
            bool admin = PhienDangNhap.LaAdmin;
            btnMayBay.Visible = admin;
            btnTaiKhoan.Visible = admin;
            btnNhatKy.Visible = admin;

            lblHoTen.Text = PhienDangNhap.TaiKhoan?.HoTen ?? "";
            lblVaiTro.Text = (PhienDangNhap.TaiKhoan?.TenDangNhap ?? "") + " · " + (admin ? "Quản trị viên" : "Nhân viên");
            CapNhatGio();
            timerGio.Start();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            MoTrang(btnTongQuan);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            MoTrang((SidebarButton)sender);
        }

        public void ChuyenDenDatVe() => MoTrang(btnDatVe);
        public void ChuyenDenDonDatVe() => MoTrang(btnDonDatVe);

        private void MoTrang(SidebarButton nut)
        {
            if (_dangChon != null) _dangChon.Active = false;
            _dangChon = nut;
            nut.Active = true;

            bool laQuanLy = flpMenu.Controls.IndexOf(nut) > flpMenu.Controls.IndexOf(lblQuanLy);
            lblDuongDan.Text = (laQuanLy ? "Quản lý" : "Nghiệp vụ") + "  /  " + nut.Text;
            lblTieuDeTrang.Text = nut.Text;

            Cursor = Cursors.WaitCursor;
            try
            {
                UserControl trang;
                if (!_trang.TryGetValue(nut, out trang))
                {
                    trang = _taoTrang[nut]();
                    trang.Dock = DockStyle.Fill;
                    _trang[nut] = trang;
                    pnlContent.Controls.Add(trang);
                }
                foreach (var t in _trang.Values) t.Visible = t == trang;
                trang.BringToFront();
                (trang as ITaiLai)?.TaiLai();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (!MsgBox.XacNhan("Bạn muốn đăng xuất khỏi hệ thống?", "Đăng xuất", "Đăng xuất", "Ở lại")) return;
            DaDangXuat = true;
            TaiKhoanBLL.DangXuat();
            Close();
        }

        private void timerGio_Tick(object sender, EventArgs e) => CapNhatGio();

        private void CapNhatGio()
        {
            lblNgay.Text = DinhDang.NgayDayDu(DateTime.Now) + "  ·  " + DateTime.Now.ToString("HH:mm");
        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var logo = new Rectangle(22, 24, 42, 42);
            using (var path = AppTheme.RoundedRect(logo, 10))
            using (var b = new SolidBrush(AppTheme.Accent))
                g.FillPath(b, path);
            FlightCard.DrawPlane(g, new PointF(logo.X + 21, logo.Y + 21), 13f, AppTheme.AccentText);
            using (var f = new Font("Segoe UI Semibold", 11.5F))
                TextRenderer.DrawText(g, "Bán vé máy bay", f, new Point(76, 25), Color.White);
            TextRenderer.DrawText(g, "Hệ thống quản lý", AppTheme.FontSmall, new Point(77, 47), AppTheme.SidebarMuted);
        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var p = new Pen(AppTheme.SidebarActive)) g.DrawLine(p, 20, 0, pnlUser.Width - 20, 0);
            var avatar = new Rectangle(24, 14, 38, 38);
            using (var b = new SolidBrush(AppTheme.SidebarActive)) g.FillEllipse(b, avatar);
            string ten = (PhienDangNhap.TaiKhoan?.HoTen ?? "").Trim();
            string tenCuoi = ten.Split(' ').Last();
            string chu = tenCuoi.Length > 0 ? tenCuoi.Substring(0, 1).ToUpper() : "?";
            using (var f = new Font("Segoe UI Semibold", 11F))
                TextRenderer.DrawText(g, chu, f, avatar, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(AppTheme.Border))
                e.Graphics.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
        }
    }
}
