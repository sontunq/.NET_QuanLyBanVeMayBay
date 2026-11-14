using System.Data;
using QuanLyBanVeMayBay.DTO;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class TaiKhoanDAL
    {
        public static TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            DataTable dt = ExecuteProc("sp_DANGNHAP", P("@TenDangNhap", tenDangNhap), P("@MatKhau", matKhau));
            return dt.Rows.Count == 0 ? null : new TaiKhoanDTO(dt.Rows[0]);
        }

        public static DataTable LayDanhSach()
        {
            return ExecuteQuery("SELECT MaTK, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro, TrangThai, NgayTao FROM TAIKHOAN ORDER BY MaTK");
        }

        public static void Them(string tenDangNhap, string matKhau, string hoTen, string email, string sdt, string vaiTro)
        {
            ExecuteNonQuery(@"INSERT INTO TAIKHOAN(TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro)
                              VALUES(@u, @p, @t, @e, @s, @v)",
                P("@u", tenDangNhap), P("@p", matKhau), P("@t", hoTen), P("@e", email), P("@s", sdt), P("@v", vaiTro));
        }

        public static void DoiTrangThai(int maTK, string trangThai)
        {
            ExecuteNonQuery("UPDATE TAIKHOAN SET TrangThai = @tt WHERE MaTK = @id", P("@tt", trangThai), P("@id", maTK));
        }

        public static DataTable LayNhatKy()
        {
            return ExecuteQuery(@"
SELECT TOP 500 nk.MaNK, nk.ThoiGian, ISNULL(tk.HoTen, N'(hệ thống)') AS NguoiThucHien,
       nk.HanhDong, nk.DoiTuong, nk.NoiDung
FROM NHATKYHOATDONG nk
LEFT JOIN TAIKHOAN tk ON tk.MaTK = nk.MaTK
ORDER BY nk.ThoiGian DESC, nk.MaNK DESC");
        }
    }
}
