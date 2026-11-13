using System.Data;

namespace QuanLyBanVeMayBay.DTO
{
    public class GheDTO
    {
        public int MaGhe { get; set; }
        public string SoGhe { get; set; }
        public int SoHang { get; set; }
        public string CotGhe { get; set; }
        public int MaHangVe { get; set; }
        public string TenHangVe { get; set; }
        public bool Trong { get; set; }

        public GheDTO() { }

        public GheDTO(DataRow row)
        {
            MaGhe = Convert.ToInt32(row["MaGhe"]);
            SoGhe = row["SoGhe"].ToString();
            SoHang = Convert.ToInt32(row["SoHang"]);
            CotGhe = row["CotGhe"].ToString();
            MaHangVe = Convert.ToInt32(row["MaHangVe"]);
            TenHangVe = row["TenHangVe"].ToString();
            Trong = row["TrangThaiGhe"].ToString() == "Trống";
        }
    }
}
