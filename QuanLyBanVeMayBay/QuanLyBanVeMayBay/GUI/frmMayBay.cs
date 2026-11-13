using QuanLyBanVeMayBay.DAL;
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
            int h = (int)nudSoHang.Value;
            lblTongGhe.Text = $"= {h * 5} ghế  ({h * 3} PT · {h} PTĐB · {h} TG)";
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoHieu.Text) || string.IsNullOrWhiteSpace(txtHangSanXuat.Text) || string.IsNullOrWhiteSpace(txtLoai.Text))
            {
                MsgBox.CanhBao("Vui lòng nhập đủ số hiệu, hãng sản xuất và loại máy bay.");
                return;
            }
            try
            {
                int ma = MayBayDAL.Tao(txtSoHieu.Text.Trim(), txtHangSanXuat.Text.Trim(), txtLoai.Text.Trim(), (int)nudSoHang.Value);
                MsgBox.ThanhCong($"Đã tạo máy bay #{ma} với {(int)nudSoHang.Value * 5} ghế.");
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
