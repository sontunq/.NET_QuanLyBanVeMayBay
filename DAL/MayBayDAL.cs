using System.Data;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class MayBayDAL
    {
        public static DataTable DanhSach()
        {
            return ExecuteQuery(@"
SELECT mb.MaMayBay, mb.SoHieu, mb.HangSanXuat, mb.LoaiMayBay, mb.TrangThai,
       COUNT(g.MaGhe) AS SoLuongGhe,
       SUM(CASE WHEN g.MaHangVe = 1 THEN 1 ELSE 0 END) AS GhePhoThong,
       SUM(CASE WHEN g.MaHangVe = 2 THEN 1 ELSE 0 END) AS GhePTDB,
       SUM(CASE WHEN g.MaHangVe = 3 THEN 1 ELSE 0 END) AS GheThuongGia,
       (SELECT COUNT(*) FROM CHUYENBAY c WHERE c.MaMayBay = mb.MaMayBay) AS SoChuyen
FROM MAYBAY mb
LEFT JOIN GHE g ON g.MaMayBay = mb.MaMayBay
GROUP BY mb.MaMayBay, mb.SoHieu, mb.HangSanXuat, mb.LoaiMayBay, mb.TrangThai
ORDER BY mb.MaMayBay");
        }

        public static int Tao(string soHieu, string hangSanXuat, string loai, int hangTG, int hangPTDB, int hangPT)
        {
            DataTable dt = ExecuteProc("sp_TAOMAYBAYVAGHE",
                P("@SoHieu", soHieu), P("@HangSanXuat", hangSanXuat), P("@LoaiMayBay", loai),
                P("@SoHangThuongGia", hangTG), P("@SoHangPTDB", hangPTDB), P("@SoHangPhoThong", hangPT));
            return Convert.ToInt32(dt.Rows[0]["MaMayBay"]);
        }

        public static void DoiTrangThai(int maMayBay, string trangThai)
        {
            ExecuteNonQuery("UPDATE MAYBAY SET TrangThai = @tt WHERE MaMayBay = @id", P("@tt", trangThai), P("@id", maMayBay));
        }
    }
}
