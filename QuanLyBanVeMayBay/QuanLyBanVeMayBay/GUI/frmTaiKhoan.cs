using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            cboVaiTro.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanBLL.Them(txtTenDangNhap.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text, txtSoDienThoai.Text, cboVaiTro.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
