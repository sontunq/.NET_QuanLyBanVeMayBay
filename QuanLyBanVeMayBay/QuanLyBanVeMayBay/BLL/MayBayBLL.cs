using System.Data;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.BLL
{
    public static class MayBayBLL
    {
        public static readonly string[] CacTrangThai = { "Hoạt động", "Bảo trì", "Ngừng hoạt động" };

        // Mỗi hàng 5 ghế: 3 phổ thông, 1 phổ thông đặc biệt, 1 thương gia (theo sp_TAOMAYBAYVAGHE)
        public const int GheMoiHang = 5;

        public static string MoTaSoGhe(int soHang)
        {
            return $"= {soHang * GheMoiHang} ghế  ({soHang * 3} PT · {soHang} PTĐB · {soHang} TG)";
        }

        public static DataTable DanhSach() => MayBayDAL.DanhSach();

        public static int Tao(string soHieu, string hangSanXuat, string loai, int soHang)
        {
            if (string.IsNullOrWhiteSpace(soHieu) || string.IsNullOrWhiteSpace(hangSanXuat) || string.IsNullOrWhiteSpace(loai))
                throw new LoiNghiepVu("Vui lòng nhập đủ số hiệu, hãng sản xuất và loại máy bay.");
            if (soHang <= 0)
                throw new LoiNghiepVu("Số hàng ghế phải lớn hơn 0.");

            return MayBayDAL.Tao(soHieu.Trim(), hangSanXuat.Trim(), loai.Trim(), soHang);
        }

        public static void DoiTrangThai(int maMayBay, string trangThai)
        {
            if (!CacTrangThai.Contains(trangThai))
                throw new LoiNghiepVu("Trạng thái máy bay không hợp lệ.");
            MayBayDAL.DoiTrangThai(maMayBay, trangThai);
        }
    }
}
