using System.Data;
using QuanLyBanVeMayBay.DTO;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class ChuyenBayDAL
    {
        public static List<ChuyenBayDTO> TimKiem(string di, string den, DateTime ngay)
        {
            DataTable dt = ExecuteProc("sp_TIMKIEMCHUYENBAY", P("@MaSanBayDi", di), P("@MaSanBayDen", den), P("@NgayDi", ngay.Date));
            return GanBangGia(dt);
        }

        public static List<ChuyenBayDTO> LichBaySapToi(string di, string den)
        {
            DataTable dt = ExecuteQuery(@"
SELECT * FROM V_CHUYENBAYCHITIET
WHERE TrangThai = N'Đang mở bán' AND NgayGioKhoiHanh > SYSDATETIME() AND SoGheTrong > 0
  AND (@di IS NULL OR MaSanBayDi = @di) AND (@den IS NULL OR MaSanBayDen = @den)
ORDER BY NgayGioKhoiHanh", P("@di", di), P("@den", den));
            return GanBangGia(dt);
        }

        private static List<ChuyenBayDTO> GanBangGia(DataTable dt)
        {
            var ds = dt.Rows.Cast<DataRow>().Select(r => new ChuyenBayDTO(r)).ToList();
            if (ds.Count == 0) return ds;

            string ids = string.Join(",", ds.Select(c => c.MaChuyenBay)); // toàn số nguyên, không nhận từ người dùng
            DataTable gia = ExecuteQuery($@"
SELECT gv.MaChuyenBay, gv.MaHangVe, gv.DonGia, hv.TenHangVe
FROM GIAVE gv JOIN HANGVE hv ON hv.MaHangVe = gv.MaHangVe
WHERE gv.MaChuyenBay IN ({ids})
ORDER BY gv.MaChuyenBay, gv.MaHangVe");
            var theoMa = ds.ToDictionary(c => c.MaChuyenBay);
            foreach (DataRow r in gia.Rows)
            {
                var cb = theoMa[Convert.ToInt32(r["MaChuyenBay"])];
                int maHang = Convert.ToInt32(r["MaHangVe"]);
                cb.BangGia[maHang] = Convert.ToDecimal(r["DonGia"]);
                cb.TenHangVe[maHang] = r["TenHangVe"].ToString();
            }
            return ds;
        }

        public static List<GheDTO> SoDoGhe(int maChuyenBay)
        {
            DataTable dt = ExecuteQuery(@"
SELECT MaGhe, SoGhe, SoHang, CotGhe, MaHangVe, TenHangVe, TrangThaiGhe
FROM V_SODOGHECHUYENBAY WHERE MaChuyenBay = @id ORDER BY SoHang, CotGhe", P("@id", maChuyenBay));
            return dt.Rows.Cast<DataRow>().Select(r => new GheDTO(r)).ToList();
        }

        public static DataTable DanhSach(bool chiSapKhoiHanh)
        {
            string sql = chiSapKhoiHanh
                ? "SELECT * FROM V_CHUYENBAYCHITIET WHERE NgayGioKhoiHanh > SYSDATETIME() AND TrangThai = N'Đang mở bán' ORDER BY NgayGioKhoiHanh"
                : "SELECT * FROM V_CHUYENBAYCHITIET ORDER BY NgayGioKhoiHanh DESC";
            return ExecuteQuery(sql);
        }

        public static DataTable SapKhoiHanh(int soLuong)
        {
            return ExecuteQuery(@"
SELECT TOP (@n) MaChuyenBay, CONCAT(MaSanBayDi, N' → ', MaSanBayDen) AS Tuyen, NgayGioKhoiHanh, SoHieu, SoGheTrong
FROM V_CHUYENBAYCHITIET
WHERE NgayGioKhoiHanh > SYSDATETIME() AND TrangThai = N'Đang mở bán'
ORDER BY NgayGioKhoiHanh", P("@n", soLuong));
        }

        public static DataTable HanhKhach(int maChuyenBay)
        {
            return ExecuteQuery(@"SELECT MaVe, MaDon, TenHanhKhach, SoGhe, TenHangVe, GiaThucTra, TrangThai, TrangThaiDon
                                  FROM V_VECHITIET WHERE MaChuyenBay = @id ORDER BY SoGhe", P("@id", maChuyenBay));
        }

        public static int Tao(int maMayBay, string di, string den, DateTime khoiHanh, int phut, int maTK,
                              decimal giaPT, decimal giaPTDB, decimal giaTG)
        {
            DataTable dt = ExecuteProc("sp_TAOCHUYENBAY",
                P("@MaMayBay", maMayBay), P("@MaSanBayDi", di), P("@MaSanBayDen", den),
                P("@NgayGioKhoiHanh", khoiHanh), P("@ThoiGianBayPhut", phut), P("@NguoiTao", maTK),
                P("@GiaPhoThong", giaPT), P("@GiaPhoThongDacBiet", giaPTDB), P("@GiaThuongGia", giaTG));
            return Convert.ToInt32(dt.Rows[0]["MaChuyenBay"]);
        }

        public static void DoiTrangThai(int maChuyenBay, string trangThai, int maTK)
        {
            ExecuteNonQuery(@"
UPDATE CHUYENBAY SET TrangThai = @tt WHERE MaChuyenBay = @id;
INSERT INTO NHATKYHOATDONG(MaTK, HanhDong, DoiTuong, NoiDung)
VALUES(@tk, N'Cập nhật', N'CHUYENBAY', CONCAT(N'Chuyến #', @id, N' -> ', @tt));",
                P("@tt", trangThai), P("@id", maChuyenBay), P("@tk", maTK));
        }
    }
}
