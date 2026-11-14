using System.Data;

namespace QuanLyBanVeMayBay.DTO
{
    public class ChuyenBayDTO
    {
        public int MaChuyenBay { get; set; }
        public string MaSanBayDi { get; set; }
        public string ThanhPhoDi { get; set; }
        public string MaSanBayDen { get; set; }
        public string ThanhPhoDen { get; set; }
        public DateTime NgayGioKhoiHanh { get; set; }
        public DateTime NgayGioDen { get; set; }
        public int ThoiGianBayPhut { get; set; }
        public string SoHieu { get; set; }
        public string TrangThai { get; set; }
        public decimal GiaThapNhat { get; set; }
        public int SoGheTrong { get; set; }

        public Dictionary<int, decimal> BangGia { get; } = new Dictionary<int, decimal>();
        /// <summary>Tên hạng vé lấy từ bảng HANGVE (theo MaHangVe).</summary>
        public Dictionary<int, string> TenHangVe { get; } = new Dictionary<int, string>();

        public string TuyenBay => MaSanBayDi + " → " + MaSanBayDen;

        public ChuyenBayDTO() { }

        public ChuyenBayDTO(DataRow row)
        {
            MaChuyenBay = Convert.ToInt32(row["MaChuyenBay"]);
            MaSanBayDi = row["MaSanBayDi"].ToString();
            ThanhPhoDi = row["ThanhPhoDi"].ToString();
            MaSanBayDen = row["MaSanBayDen"].ToString();
            ThanhPhoDen = row["ThanhPhoDen"].ToString();
            NgayGioKhoiHanh = Convert.ToDateTime(row["NgayGioKhoiHanh"]);
            NgayGioDen = Convert.ToDateTime(row["NgayGioDenDuKien"]);
            ThoiGianBayPhut = Convert.ToInt32(row["ThoiGianBayPhut"]);
            SoHieu = row["SoHieu"].ToString();
            TrangThai = row["TrangThai"].ToString();
            GiaThapNhat = Convert.ToDecimal(row["GiaThapNhat"]);
            SoGheTrong = Convert.ToInt32(row["SoGheTrong"]);
        }
    }
}
