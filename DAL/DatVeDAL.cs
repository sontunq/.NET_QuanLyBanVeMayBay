using System.Data;
using Microsoft.Data.SqlClient;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class DatVeDAL
    {
        public static DataRow TinhGia(int maChuyenBay, int maHangVe, int maKH, bool tet, bool khuHoi,
                                      int? maKM, int? maChuyenBayKhuHoi, int soVeTet)
        {
            return ExecuteProc("sp_TINHTHUGIAVE",
                P("@MaChuyenBay", maChuyenBay), P("@MaHangVe", maHangVe), P("@MaKH", maKH),
                P("@ApDungTet", tet), P("@ApDungKhuHoi", khuHoi), P("@MaKM", maKM),
                P("@MaChuyenBayKhuHoi", maChuyenBayKhuHoi), P("@SoVeTetTrongDon", soVeTet)).Rows[0];
        }

        public static DataRow DatVe(int maKHLienHe, IList<DataRow> gioVe, bool tet, bool khuHoi, int? maKM, int maTK)
        {
            var ps = new List<SqlParameter>
            {
                P("@MaKHLienHe", maKHLienHe), P("@MaTKNhanVien", maTK),
                P("@ApDungTet", tet), P("@ApDungKhuHoi", khuHoi), P("@MaKM", maKM),
            };
            for (int i = 0; i < gioVe.Count && i < 2; i++)
            {
                DataRow r = gioVe[i];
                string n = (i + 1).ToString();
                ps.Add(P("@MaKH" + n, r["MaKH"]));
                ps.Add(P("@MaChuyenBay" + n, r["MaChuyenBay"]));
                ps.Add(P("@MaGhe" + n, r["MaGhe"]));
                ps.Add(P("@MaHangVe" + n, r["MaHangVe"]));
                ps.Add(P("@MaNguoiGiamHo" + n, r["MaNguoiGiamHo"]));
            }
            return ExecuteProc("sp_DATVE", ps.ToArray()).Rows[0];
        }

        public static DataRow ThongTinDon(int maDon)
        {
            DataTable dt = ExecuteQuery(@"
SELECT dd.MaDon, dd.TrangThai, dd.TongTienVe, dd.TongTienDichVu, dd.TienGiamKM, dd.TongThanhToan,
       kh.HoTen AS KhachHangLienHe,
       (SELECT COUNT(*) FROM VE WHERE MaDon = dd.MaDon AND TrangThai <> N'Đã hủy') AS SoVe
FROM DONDATVE dd JOIN KHACHHANG kh ON kh.MaKH = dd.MaKHLienHe
WHERE dd.MaDon = @id", P("@id", maDon));
            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }

        public static void ThanhToan(int maDon, decimal soTien, string phuongThuc, string ghiChu, int maTK)
        {
            ExecuteProc("sp_THANHTOANDON",
                P("@MaDon", maDon), P("@SoTien", soTien), P("@PhuongThuc", phuongThuc),
                P("@MaTKNhanVien", maTK), P("@GhiChu", ghiChu));
        }

        public static DataRow ThongTinVe(int maVe)
        {
            DataTable dt = ExecuteQuery("SELECT * FROM V_VECHITIET WHERE MaVe = @id", P("@id", maVe));
            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }

        public static DataRow HuyVe(int maVe, string lyDo, int maTK)
        {
            return ExecuteProc("sp_HUYVE", P("@MaVe", maVe), P("@LyDo", lyDo), P("@MaTKNhanVien", maTK)).Rows[0];
        }

        // Thêm dịch vụ: theo ghi chú trong script, phần này làm bằng câu lệnh có tham số từ ứng dụng.
        private const string SqlThemDichVu = @"
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM DONDATVE WITH (UPDLOCK, HOLDLOCK)
               WHERE MaDon = @MaDon AND TrangThai = N'Chờ thanh toán')
    THROW 50090, N'Chỉ thêm dịch vụ cho đơn đang chờ thanh toán.', 1;

IF NOT EXISTS (SELECT 1 FROM VE WHERE MaVe = @MaVe AND MaDon = @MaDon AND TrangThai <> N'Đã hủy')
    THROW 50091, N'Vé không thuộc đơn hoặc đã bị hủy.', 1;

IF EXISTS (SELECT 1 FROM VEDICHVU WHERE MaVe = @MaVe AND MaDichVu = @MaDichVu)
    UPDATE VEDICHVU SET SoLuong = SoLuong + @SoLuong WHERE MaVe = @MaVe AND MaDichVu = @MaDichVu;
ELSE
    INSERT INTO VEDICHVU(MaVe, MaDichVu, SoLuong, DonGia) VALUES(@MaVe, @MaDichVu, @SoLuong, @DonGia);

UPDATE DONDATVE
SET TongTienDichVu = ISNULL((SELECT SUM(vd.ThanhTien) FROM VEDICHVU vd JOIN VE v ON v.MaVe = vd.MaVe
                             WHERE v.MaDon = @MaDon AND v.TrangThai <> N'Đã hủy'), 0)
WHERE MaDon = @MaDon;

UPDATE DONDATVE SET TongThanhToan = TongTienVe + TongTienDichVu WHERE MaDon = @MaDon;

INSERT INTO NHATKYHOATDONG(MaTK, HanhDong, DoiTuong, NoiDung)
VALUES(@MaTK, N'Thêm dịch vụ', N'VEDICHVU', CONCAT(N'Thêm dịch vụ #', @MaDichVu, N' cho vé #', @MaVe));

COMMIT TRANSACTION;";

        public static void ThemDichVu(int maDon, int maVe, int maDichVu, int soLuong, decimal donGia, int maTK)
        {
            ExecuteNonQuery(SqlThemDichVu,
                P("@MaDon", maDon), P("@MaVe", maVe), P("@MaDichVu", maDichVu),
                P("@SoLuong", soLuong), P("@DonGia", donGia), P("@MaTK", maTK));
        }

        public static DataTable DanhSachDon(string trangThai, string tuKhoa)
        {
            return ExecuteQuery(@"
SELECT * FROM V_LICHSUGIAODICH
WHERE (@tt IS NULL OR TrangThai = @tt)
  AND (@q IS NULL OR CAST(MaDon AS NVARCHAR(20)) = @q OR KhachHangLienHe LIKE N'%' + @q + N'%')
ORDER BY NgayDat DESC", P("@tt", trangThai), P("@q", tuKhoa));
        }

        public static DataTable VeTrongDon(int maDon)
        {
            return ExecuteQuery(@"
SELECT MaVe, TenHanhKhach, MaChuyenBay, MaSanBayDi, MaSanBayDen, NgayGioKhoiHanh, SoGhe, TenHangVe,
       GiaGoc, TongPhanTramGiam, GiaThucTra, TrangThai
FROM V_VECHITIET WHERE MaDon = @id ORDER BY MaVe", P("@id", maDon));
        }

        public static DataTable DichVuTrongDon(int maDon)
        {
            return ExecuteQuery(@"
SELECT vd.MaVe, dv.TenDichVu, vd.SoLuong, vd.DonGia, vd.ThanhTien
FROM VEDICHVU vd
JOIN DICHVU dv ON dv.MaDichVu = vd.MaDichVu
JOIN VE v ON v.MaVe = vd.MaVe
WHERE v.MaDon = @id ORDER BY vd.MaVe", P("@id", maDon));
        }

        public static DataTable TraCuuVe(int? maVe, int? maChuyenBay, string soGiayTo)
        {
            return ExecuteProc("sp_TRACUUVE", P("@MaVe", maVe), P("@MaChuyenBay", maChuyenBay), P("@SoGiayTo", soGiayTo));
        }

        public static DataTable VeCuaKhach(int maKH)
        {
            return ExecuteQuery(@"
SELECT MaVe, MaDon, MaChuyenBay, MaSanBayDi, MaSanBayDen, NgayGioKhoiHanh, SoGhe, TenHangVe, GiaGoc,
       TongPhanTramGiam, GiaThucTra, TrangThai, TrangThaiDon
FROM V_VECHITIET WHERE MaKH = @id ORDER BY NgayGioKhoiHanh DESC", P("@id", maKH));
        }
    }
}
