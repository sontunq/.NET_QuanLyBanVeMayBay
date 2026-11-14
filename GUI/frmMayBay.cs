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
            lblTongGhe.Text = MayBayBLL.MoTaSoGhe((int)nudHangTG.Value, (int)nudHangPTDB.Value, (int)nudHangPT.Value);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                int tg = (int)nudHangTG.Value, ptdb = (int)nudHangPTDB.Value, pt = (int)nudHangPT.Value;
                int ma = MayBayBLL.Tao(txtSoHieu.Text, txtHangSanXuat.Text, txtLoai.Text, tg, ptdb, pt);
                MsgBox.ThanhCong($"Đã tạo máy bay #{ma} với {MayBayBLL.TongSoGhe(tg, ptdb, pt)} ghế.");
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
