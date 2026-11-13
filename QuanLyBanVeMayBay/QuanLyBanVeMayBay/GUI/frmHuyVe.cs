using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmHuyVe : Form
    {
        private readonly int _maVe;

        public frmHuyVe()
        {
            InitializeComponent();
        }

        private frmHuyVe(int maVe, DataRow ve) : this()
        {
            _maVe = maVe;
            DateTime khoiHanh = Convert.ToDateTime(ve["NgayGioKhoiHanh"]);
            decimal gia = Convert.ToDecimal(ve["GiaThucTra"]);
            string trangThaiDon = ve["TrangThaiDon"].ToString();

            lblNhan.Text = "HỦY VÉ #" + maVe;
            lblHanhKhach.Text = ve["TenHanhKhach"].ToString();
            lblChuyen.Text = $"{ve["MaSanBayDi"]} → {ve["MaSanBayDen"]}  ·  {khoiHanh:dd/MM/yyyy HH:mm}  ·  Chuyến #{ve["MaChuyenBay"]}";
            lblHangGiaTri.Text = $"{ve["SoGhe"]} · {ve["TenHangVe"]}";
            lblGiaGiaTri.Text = DinhDang.Tien(gia);
            lblDonGiaTri.Text = $"#{ve["MaDon"]} · {trangThaiDon}";

            // Xem trước phí hủy (quy tắc nằm ở BLL, giống sp_HUYVE)
            PhiHuyDuKien phiHuy = DatVeBLL.TinhPhiHuy(khoiHanh, gia, trangThaiDon);
            TimeSpan conLai = phiHuy.ConLai;
            int gio = (int)Math.Floor(conLai.TotalHours);
            string thoiGian = conLai.TotalDays >= 1 ? $"{(int)conLai.TotalDays} ngày {conLai.Hours} giờ" : $"{Math.Max(0, gio)} giờ {Math.Max(0, conLai.Minutes)} phút";
            lblConLai.Text = $"Còn {thoiGian} trước giờ bay  →  phí hủy {phiHuy.TyLe:P0}";

            if (phiHuy.CoThuPhi)
            {
                lblPhiHuy.Text = "Phí hủy dự kiến: " + DinhDang.Tien(phiHuy.Phi);
                lblTienHoan.Text = "Tiền hoàn dự kiến: " + DinhDang.Tien(phiHuy.TienHoan);
            }
            else
            {
                lblPhiHuy.Text = "Đơn chưa thanh toán — không thu phí hủy.";
                lblTienHoan.Text = "Không hoàn tiền. Đơn có vé đã hủy sẽ không thanh toán được nữa.";
                lblTienHoan.ForeColor = AppTheme.TextSecondary;
                lblTienHoan.Font = AppTheme.FontSmall;
            }
        }

        public static bool HuyVe(IWin32Window owner, int maVe)
        {
            try
            {
                DataRow ve = DatVeBLL.LayVeDeHuy(maVe);
                using (var f = new frmHuyVe(maVe, ve))
                    return f.ShowDialog(owner) == DialogResult.OK;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
                return false;
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            // BLL cũng kiểm tra lý do; kiểm tra sớm ở đây để không hỏi xác nhận vô ích
            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MsgBox.CanhBao("Vui lòng nhập lý do hủy vé.");
                txtLyDo.Focus();
                return;
            }
            if (!MsgBox.XacNhan($"Xác nhận hủy vé #{_maVe}? Ghế sẽ được trả lại cho chuyến bay.", "Hủy vé", "Hủy vé", "Không")) return;

            try
            {
                DataRow kq = DatVeBLL.HuyVe(_maVe, txtLyDo.Text);
                MsgBox.ThanhCong($"Đã hủy vé #{_maVe}.\nPhí hủy: {DinhDang.Tien(kq["PhiHuy"])}\nTiền hoàn: {DinhDang.Tien(kq["TienHoan"])}", "Hủy vé thành công");
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
