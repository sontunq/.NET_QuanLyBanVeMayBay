using Microsoft.Data.SqlClient;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmDangNhap : Form
    {
        private static readonly string FileCauHinh = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuanLyBanVeMayBay", "server.txt");

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMayChu.Text = DocMayChu();
            txtTaiKhoan.Text = "admin";
            txtMatKhau.Text = "admin123";
            ActiveControl = txtTaiKhoan;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblLoi.Text = "";
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                lblLoi.Text = "Vui lòng nhập tên đăng nhập và mật khẩu.";
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnDangNhap.Enabled = false;
            try
            {
                DataProvider.ChuoiKetNoi = DataProvider.TaoChuoiKetNoi(txtMayChu.Text);
                TaiKhoanDTO tk = TaiKhoanDAL.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text);
                if (tk == null)
                {
                    lblLoi.Text = "Sai tên đăng nhập/mật khẩu hoặc tài khoản đã bị khóa.";
                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();
                    return;
                }
                PhienDangNhap.TaiKhoan = tk;
                if (chkGhiNho.Checked) LuuMayChu(txtMayChu.Text.Trim());
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number == 4060)
            {
                lblLoi.Text = "Không mở được CSDL " + DataProvider.TenCSDL + ". Hãy chạy file SQL trong thư mục Database trước.";
            }
            catch (SqlException ex) when (ex.Number == 2812)
            {
                lblLoi.Text = "Không tìm thấy sp_DANGNHAP — script SQL chưa chạy hết.";
            }
            catch (Exception ex)
            {
                lblLoi.Text = "Không kết nối được SQL Server: " + ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDangNhap.Enabled = true;
            }
        }

        private static string DocMayChu()
        {
            try
            {
                if (File.Exists(FileCauHinh)) return File.ReadAllText(FileCauHinh).Trim();
            }
            catch (IOException) { }
            return ".";
        }

        private static void LuuMayChu(string mayChu)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileCauHinh));
                File.WriteAllText(FileCauHinh, mayChu);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}
