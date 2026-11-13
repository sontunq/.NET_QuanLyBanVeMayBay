using QuanLyBanVeMayBay.DAL;
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
            if (new[] { txtTenDangNhap.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text }.Any(string.IsNullOrWhiteSpace))
            {
                MsgBox.CanhBao("Vui lòng nhập đủ các trường bắt buộc (*).");
                return;
            }
            try
            {
                TaiKhoanDAL.Them(txtTenDangNhap.Text.Trim(), txtMatKhau.Text, txtHoTen.Text.Trim(), txtEmail.Text.Trim(),
                    DinhDang.RongThanhNull(txtSoDienThoai.Text), cboVaiTro.Text);
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
