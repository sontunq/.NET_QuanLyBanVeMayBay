using System.Data;
using QuanLyBanVeMayBay.Controls;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmThanhToan : Form
    {
        private readonly int _maDon;
        private decimal _tongTien;
        private string _phuongThuc = "Tiền mặt";

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private frmThanhToan(int maDon, DataRow don) : this()
        {
            _maDon = maDon;
            _tongTien = Convert.ToDecimal(don["TongThanhToan"]);
            lblNhan.Text = "THANH TOÁN ĐƠN #" + maDon;
            lblSoTien.Text = DinhDang.Tien(_tongTien);
            lblMoTa.Text = $"{don["SoVe"]} vé  ·  Khách liên hệ: {don["KhachHangLienHe"]}";
            lblTienVeGiaTri.Text = DinhDang.Tien(don["TongTienVe"]);
            lblDichVuGiaTri.Text = DinhDang.Tien(don["TongTienDichVu"]);
            decimal giam = don["TienGiamKM"] == DBNull.Value ? 0 : Convert.ToDecimal(don["TienGiamKM"]);
            lblGiamGiaTri.Text = giam > 0 ? "−" + DinhDang.Tien(giam) : "0 đ";
        }

        public static bool ThanhToan(IWin32Window owner, int maDon)
        {
            try
            {
                DataRow don = DatVeBLL.LayDonDeThanhToan(maDon);
                using (var f = new frmThanhToan(maDon, don))
                    return f.ShowDialog(owner) == DialogResult.OK;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
                return false;
            }
        }

        private void PhuongThuc_Click(object sender, EventArgs e)
        {
            foreach (RoundedButton b in flpPhuongThuc.Controls)
                b.Kind = b == sender ? ButtonKind.Primary : ButtonKind.Outline;
            _phuongThuc = ((Button)sender).Text;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                DatVeBLL.ThanhToan(_maDon, _tongTien, _phuongThuc, txtGhiChu.Text);
                MsgBox.ThanhCong($"Đã thu {DinhDang.Tien(_tongTien)} ({_phuongThuc.ToLower()}) cho đơn #{_maDon}.", "Thanh toán thành công");
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
