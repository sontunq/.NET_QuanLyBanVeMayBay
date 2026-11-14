using QuanLyBanVeMayBay.BLL;

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
            Cursor = Cursors.WaitCursor;
            btnDangNhap.Enabled = false;
            try
            {
                TaiKhoanBLL.DangNhap(txtMayChu.Text, txtTaiKhoan.Text, txtMatKhau.Text);
                if (chkGhiNho.Checked) LuuMayChu(txtMayChu.Text.Trim());
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (LoiNghiepVu ex)
            {
                lblLoi.Text = ex.Message;
                txtMatKhau.SelectAll();
                txtMatKhau.Focus();
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
