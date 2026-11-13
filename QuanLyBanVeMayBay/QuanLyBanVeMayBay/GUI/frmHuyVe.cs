using System.Data;
using QuanLyBanVeMayBay.DAL;
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

            // Xem trước theo đúng quy tắc của sp_HUYVE (DATEDIFF theo giờ)
            TimeSpan conLai = khoiHanh - DateTime.Now;
            int gio = (int)Math.Floor(conLai.TotalHours);
            decimal tyLe = gio < 24 ? 0.30m : gio < 72 ? 0.20m : 0.10m;
            string thoiGian = conLai.TotalDays >= 1 ? $"{(int)conLai.TotalDays} ngày {conLai.Hours} giờ" : $"{Math.Max(0, gio)} giờ {Math.Max(0, conLai.Minutes)} phút";
            lblConLai.Text = $"Còn {thoiGian} trước giờ bay  →  phí hủy {tyLe:P0}";

            if (trangThaiDon == "Đã thanh toán")
            {
                decimal phi = Math.Round(gia * tyLe, 0);
                lblPhiHuy.Text = "Phí hủy dự kiến: " + DinhDang.Tien(phi);
                lblTienHoan.Text = "Tiền hoàn dự kiến: " + DinhDang.Tien(Math.Max(0, gia - phi));
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
                DataRow ve = DatVeDAL.ThongTinVe(maVe);
                if (ve == null)
                {
                    MsgBox.CanhBao("Không tìm thấy vé #" + maVe + ".");
                    return false;
                }
                if (ve["TrangThai"].ToString() == "Đã hủy")
                {
                    MsgBox.CanhBao("Vé #" + maVe + " đã được hủy trước đó.");
                    return false;
                }
                if (Convert.ToDateTime(ve["NgayGioKhoiHanh"]) <= DateTime.Now)
                {
                    MsgBox.CanhBao("Chuyến bay của vé này đã khởi hành nên không thể hủy.");
                    return false;
                }
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
            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MsgBox.CanhBao("Vui lòng nhập lý do hủy vé.");
                txtLyDo.Focus();
                return;
            }
            if (!MsgBox.XacNhan($"Xác nhận hủy vé #{_maVe}? Ghế sẽ được trả lại cho chuyến bay.", "Hủy vé", "Hủy vé", "Không")) return;

            try
            {
                DataRow kq = DatVeDAL.HuyVe(_maVe, txtLyDo.Text.Trim());
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
