using Microsoft.Data.SqlClient;

namespace QuanLyBanVeMayBay.DAL
{
    /// <summary>
    /// Lớp kết nối CSDL: chỉ giữ chuỗi kết nối và tạo đối tượng SqlConnection.
    /// Việc chạy câu lệnh SQL nằm ở DataProvider.
    /// </summary>
    public static class KetNoiCSDL
    {
        public const string TenCSDL = "QuanLyBanVeMayBay2";

        public static string ChuoiKetNoi { get; private set; } = "";

        /// <summary>Thiết lập chuỗi kết nối từ tên máy chủ (vd "." hoặc ".\SQLEXPRESS") hoặc một chuỗi kết nối đầy đủ.</summary>
        public static void ThietLap(string mayChu)
        {
            string s = (mayChu ?? "").Trim();
            if (s.Contains("="))
            {
                ChuoiKetNoi = s;
                return;
            }
            if (s.Length == 0) s = ".";
            ChuoiKetNoi = $"Server={s};Database={TenCSDL};Integrated Security=True;TrustServerCertificate=True;Encrypt=False";
        }

        /// <summary>Tạo một kết nối mới (chưa mở). Nơi gọi tự Open và Dispose bằng using.</summary>
        public static SqlConnection TaoKetNoi()
        {
            if (string.IsNullOrEmpty(ChuoiKetNoi))
                throw new InvalidOperationException("Chưa thiết lập kết nối CSDL.");
            return new SqlConnection(ChuoiKetNoi);
        }
    }
}
