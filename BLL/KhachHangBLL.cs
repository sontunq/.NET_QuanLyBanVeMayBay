using System.Data;
using QuanLyBanVeMayBay.DAL;
using static QuanLyBanVeMayBay.BLL.LoiNghiepVu;

namespace QuanLyBanVeMayBay.BLL
{
    public static class KhachHangBLL
    {
        public static DataTable DanhSach(string tuKhoa) => KhachHangDAL.DanhSach(RongThanhNull(tuKhoa));

        public static DataRow Lay(int maKH) => KhachHangDAL.Lay(maKH);

        /// <summary>Thêm mới (maKH = null) hoặc cập nhật khách hàng. Trả về mã khách hàng.</summary>
        public static int Luu(int? maKH, string hoTen, string loaiGiayTo, string soGiayTo, DateTime ngaySinh, string gioiTinh,
                              string sdt, string email, string diaChi)
        {
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(soGiayTo))
                throw new LoiNghiepVu("Họ tên và số giấy tờ là bắt buộc.");
            if (ngaySinh.Date > DateTime.Today)
                throw new LoiNghiepVu("Ngày sinh không được lớn hơn ngày hiện tại.");
            if (ngaySinh.Date < DateTime.Today.AddYears(-120))
                throw new LoiNghiepVu("Ngày sinh không hợp lệ.");

            hoTen = KiemTraDuLieu.ChuanHoaHoTen(hoTen);
            soGiayTo = KiemTraDuLieu.ChuanHoaSoGiayTo(loaiGiayTo, soGiayTo, ngaySinh);
            sdt = KiemTraDuLieu.ChuanHoaSoDienThoai(sdt);
            email = KiemTraDuLieu.ChuanHoaEmail(email);
            diaChi = RongThanhNull(diaChi);

            if (maKH == null)
                return KhachHangDAL.Them(hoTen, loaiGiayTo, soGiayTo, ngaySinh, gioiTinh, sdt, email, diaChi);

            KhachHangDAL.Sua(maKH.Value, hoTen, loaiGiayTo, soGiayTo, ngaySinh, gioiTinh, sdt, email, diaChi);
            return maKH.Value;
        }

        public static DataRow XetHang(int maKH) => KhachHangDAL.XetHang(maKH);
    }
}
