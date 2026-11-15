using System.Data;
using Microsoft.Data.SqlClient;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class DatVeDAL
    {
        /// <summary>Xem trước giá một vé (sp_TINHTHUGIAVE). Truyền chuyến chiều về nếu vé thuộc cặp khứ hồi.</summary>
        public static DataRow TinhGia(int maChuyenBay, int maHangVe, int maKH, int? maKM, int? maChuyenBayKhuHoi, int? maKHLienHe)
        {
            return ExecuteProc("sp_TINHTHUGIAVE",
                P("@MaChuyenBay", maChuyenBay), P("@MaHangVe", maHangVe), P("@MaKH", maKH),
                P("@MaKM", maKM), P("@MaChuyenBayKhuHoi", maChuyenBayKhuHoi), P("@MaKHLienHe", maKHLienHe)).Rows[0];
        }

        /// <summary>
        /// Đặt đơn nhiều vé: sp_TAODONNHIEUVE → sp_THEMVEDON (mỗi vé một lần) → sp_XACNHANDON.
        /// Chạy chung một giao dịch: một vé lỗi thì cả đơn không được tạo.
        /// Trả về các dòng vé của đơn (mỗi dòng có MaDon, TongThanhToan...).
        /// </summary>
        public static DataTable DatVe(int maKHLienHe, IList<DataRow> gioVe, int? maKM, int maTK)
        {
            return ChayTrongGiaoDich((cn, tx) =>
            {
                DataTable don = ExecuteProc(cn, tx, "sp_TAODONNHIEUVE",
                    P("@MaKHLienHe", maKHLienHe), P("@MaTKNhanVien", maTK), P("@MaKM", maKM));
                int maDon = Convert.ToInt32(don.Rows[0]["MaDon"]);

                foreach (DataRow r in gioVe)
                {
                    ExecuteProc(cn, tx, "sp_THEMVEDON",
                        P("@MaDon", maDon), P("@MaKH", r["MaKH"]), P("@MaChuyenBay", r["MaChuyenBay"]),
                        P("@MaGhe", r["MaGhe"]), P("@MaHangVe", r["MaHangVe"]), P("@MaNguoiGiamHo", r["MaNguoiGiamHo"]));
                }

                ExecuteNonQuery(cn, tx, @"INSERT INTO NHATKYHOATDONG(MaTK, HanhDong, DoiTuong, NoiDung)
VALUES(@MaTK, N'Đặt vé', N'DONDATVE', CONCAT(N'Tạo đơn đặt vé #', @MaDon, N' (', @SoVe, N' vé)'))",
                    P("@MaTK", maTK), P("@MaDon", maDon), P("@SoVe", gioVe.Count));

                return ExecuteProc(cn, tx, "sp_XACNHANDON", P("@MaDon", maDon));
            });
        }

        /// <summary>Thông tin đơn kèm số tiền đã thu, đã hoàn, phí hủy đã giữ và số tiền còn phải thu
        /// (cùng công thức với sp_THANHTOANDON).</summary>
        public static DataRow ThongTinDon(int maDon)
        {
            DataTable dt = ExecuteQuery(@"
SELECT dd.MaDon, dd.TrangThai, dd.TongTienVe, dd.TongTienDichVu, dd.TienGiamKM, dd.TongThanhToan,
       kh.HoTen AS KhachHangLienHe,
       (SELECT COUNT(*) FROM VE WHERE MaDon = dd.MaDon AND TrangThai <> N'Đã hủy') AS SoVe,
       tt.DaThu, tt.DaHoan, ph.PhiHuy,
       dd.TongThanhToan - (tt.DaThu - tt.DaHoan - ph.PhiHuy) AS ConPhaiThu
FROM DONDATVE dd
JOIN KHACHHANG kh ON kh.MaKH = dd.MaKHLienHe
CROSS APPLY (SELECT ISNULL(SUM(CASE WHEN TrangThai = N'Thành công' THEN SoTien END), 0) AS DaThu,
                    ISNULL(SUM(CASE WHEN TrangThai = N'Đã hoàn' THEN SoTien END), 0) AS DaHoan
             FROM THANHTOAN WHERE MaDon = dd.MaDon) tt
CROSS APPLY (SELECT ISNULL(SUM(h.PhiHuy), 0) AS PhiHuy
             FROM HUYVE h JOIN VE v ON v.MaVe = h.MaVe WHERE v.MaDon = dd.MaDon) ph
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

        /// <summary>Tổng tiền dịch vụ đã gắn vào một vé (sp_HUYVE hoàn cả phần này khi đơn đã thanh toán đủ).</summary>
        public static decimal TienDichVuCuaVe(int maVe)
        {
            object kq = ExecuteScalar("SELECT SUM(ThanhTien) FROM VEDICHVU WHERE MaVe = @id", P("@id", maVe));
            return kq == null ? 0 : Convert.ToDecimal(kq);
        }

        public static DataRow HuyVe(int maVe, string lyDo, int maTK)
        {
            return ExecuteProc("sp_HUYVE", P("@MaVe", maVe), P("@LyDo", lyDo), P("@MaTKNhanVien", maTK)).Rows[0];
        }

        /// <summary>Thêm dịch vụ cho vé (sp_THEMDICHVUVE, đơn giá lấy từ bảng DICHVU). Đơn đã thanh toán vẫn thêm được;
        /// tiền phát sinh được thu sau bằng sp_THANHTOANDON.</summary>
        public static void ThemDichVu(int maVe, IList<int> dsMaDichVu, int maTK)
        {
            ChayTrongGiaoDich((cn, tx) =>
            {
                foreach (int maDichVu in dsMaDichVu)
                    ExecuteProc(cn, tx, "sp_THEMDICHVUVE",
                        P("@MaVe", maVe), P("@MaDichVu", maDichVu), P("@SoLuong", 1), P("@MaTKNhanVien", maTK));
                return 0;
            });
        }

        /// <summary>Mã các dịch vụ vé đã đăng ký.</summary>
        public static HashSet<int> DichVuCuaVe(int maVe)
        {
            return new HashSet<int>(ExecuteQuery("SELECT MaDichVu FROM VEDICHVU WHERE MaVe = @id", P("@id", maVe))
                .AsEnumerable().Select(r => r.Field<int>("MaDichVu")));
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
