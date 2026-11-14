using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;

namespace QuanLyBanVeMayBay.BLL
{
    public static class ChuyenBayBLL
    {
        public static readonly string[] CacTrangThai = { "Đang mở bán", "Đã đóng", "Đã bay", "Đã hủy" };

        /// <summary>
        /// Tìm chuyến: nếu chưa chọn đủ điểm đi/đến thì trả lịch bay sắp tới theo phần đã chọn,
        /// còn chọn đủ cả hai thì tìm đúng theo ngày bay.
        /// </summary>
        public static List<ChuyenBayDTO> TimKiem(string di, string den, DateTime ngay)
        {
            if (di == null || den == null)
                return ChuyenBayDAL.LichBaySapToi(di, den);
            if (di == den)
                throw new LoiNghiepVu("Điểm đi và điểm đến phải khác nhau.");
            return ChuyenBayDAL.TimKiem(di, den, ngay.Date);
        }

        public static List<ChuyenBayDTO> LichBaySapToi(string di, string den) => ChuyenBayDAL.LichBaySapToi(di, den);

        public static List<GheDTO> SoDoGhe(int maChuyenBay) => ChuyenBayDAL.SoDoGhe(maChuyenBay);

        public static DataTable DanhSach(bool chiSapKhoiHanh) => ChuyenBayDAL.DanhSach(chiSapKhoiHanh);

        public static DataTable SapKhoiHanh(int soLuong) => ChuyenBayDAL.SapKhoiHanh(soLuong);

        public static DataTable HanhKhach(int maChuyenBay) => ChuyenBayDAL.HanhKhach(maChuyenBay);

        public static int Tao(int? maMayBay, string di, string den, DateTime khoiHanh, int phut,
                              decimal giaPT, decimal giaPTDB, decimal giaTG)
        {
            if (maMayBay == null || string.IsNullOrEmpty(di) || string.IsNullOrEmpty(den))
                throw new LoiNghiepVu("Vui lòng chọn máy bay và sân bay.");
            if (di == den)
                throw new LoiNghiepVu("Sân bay đi và sân bay đến phải khác nhau.");
            if (khoiHanh <= DateTime.Now)
                throw new LoiNghiepVu("Giờ khởi hành phải ở tương lai.");
            if (phut <= 0)
                throw new LoiNghiepVu("Thời gian bay phải lớn hơn 0.");
            if (giaPT <= 0 || giaPTDB <= 0 || giaTG <= 0)
                throw new LoiNghiepVu("Giá vé các hạng phải lớn hơn 0.");

            return ChuyenBayDAL.Tao(maMayBay.Value, di, den, khoiHanh, phut, PhienDangNhap.MaTK, giaPT, giaPTDB, giaTG);
        }

        public static void DoiTrangThai(int maChuyenBay, string trangThai)
        {
            if (!CacTrangThai.Contains(trangThai))
                throw new LoiNghiepVu("Trạng thái chuyến bay không hợp lệ.");
            ChuyenBayDAL.DoiTrangThai(maChuyenBay, trangThai, PhienDangNhap.MaTK);
        }
    }
}
