using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmMayBay : Form
    {
        public frmMayBay()
        {
            InitializeComponent();
            nudSoHang_ValueChanged(this, EventArgs.Empty);
        }

        private void nudSoHang_ValueChanged(object sender, EventArgs e)
        {
            lblTongGhe.Text = MayBayBLL.MoTaSoGhe((int)nudSoHang.Value);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                int soHang = (int)nudSoHang.Value;
                int ma = MayBayBLL.Tao(txtSoHieu.Text, txtHangSanXuat.Text, txtLoai.Text, soHang);
                MsgBox.ThanhCong($"Đã tạo máy bay #{ma} với {soHang * MayBayBLL.GheMoiHang} ghế.");
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
