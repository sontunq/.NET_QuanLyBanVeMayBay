using System.Data;

namespace QuanLyBanVeMayBay.DTO
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }

        public bool LaAdmin => VaiTro == "Admin";

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(DataRow row)
        {
            MaTK = Convert.ToInt32(row["MaTK"]);
            TenDangNhap = row["TenDangNhap"].ToString();
            HoTen = row["HoTen"].ToString();
            VaiTro = row["VaiTro"].ToString();
        }
    }

    public static class PhienDangNhap
    {
        public static TaiKhoanDTO TaiKhoan { get; set; }

        public static int MaTK => TaiKhoan?.MaTK ?? 0;
        public static bool LaAdmin => TaiKhoan != null && TaiKhoan.LaAdmin;
    }
}
