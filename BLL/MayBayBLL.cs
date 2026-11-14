using System.Data;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.BLL
{
    public static class MayBayBLL
    {
        public static readonly string[] CacTrangThai = { "Hoạt động", "Bảo trì", "Ngừng hoạt động" };

        // Theo sp_TAOMAYBAYVAGHE: hàng Thương gia bố trí 2-2 (4 ghế), các hạng còn lại 3-3 (6 ghế)
        public const int GheHangThuongGia = 4;
        public const int GheHangThuong = 6;

        public static int TongSoGhe(int hangTG, int hangPTDB, int hangPT)
            => hangTG * GheHangThuongGia + (hangPTDB + hangPT) * GheHangThuong;

        public static string MoTaSoGhe(int hangTG, int hangPTDB, int hangPT)
        {
            return $"= {TongSoGhe(hangTG, hangPTDB, hangPT)} ghế  " +
                   $"({hangTG * GheHangThuongGia} TG · {hangPTDB * GheHangThuong} PTĐB · {hangPT * GheHangThuong} PT)";
        }

        public static DataTable DanhSach() => MayBayDAL.DanhSach();

        public static int Tao(string soHieu, string hangSanXuat, string loai, int hangTG, int hangPTDB, int hangPT)
        {
            if (string.IsNullOrWhiteSpace(soHieu) || string.IsNullOrWhiteSpace(hangSanXuat) || string.IsNullOrWhiteSpace(loai))
                throw new LoiNghiepVu("Vui lòng nhập đủ số hiệu, hãng sản xuất và loại máy bay.");
            if (hangTG < 0 || hangPTDB < 0 || hangPT < 1)
                throw new LoiNghiepVu("Cần ít nhất 1 hàng Phổ thông; số hàng các hạng khác không được âm.");
            if (hangTG + hangPTDB + hangPT > 60)
                throw new LoiNghiepVu("Tổng số hàng ghế không được vượt quá 60.");

            return MayBayDAL.Tao(soHieu.Trim(), hangSanXuat.Trim(), loai.Trim(), hangTG, hangPTDB, hangPT);
        }

        public static void DoiTrangThai(int maMayBay, string trangThai)
        {
            if (!CacTrangThai.Contains(trangThai))
                throw new LoiNghiepVu("Trạng thái máy bay không hợp lệ.");
            MayBayDAL.DoiTrangThai(maMayBay, trangThai);
        }
    }
}
