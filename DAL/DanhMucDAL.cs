using System.Data;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class DanhMucDAL
    {
        public static DataTable SanBay() => ExecuteProc("sp_LAYDULIEUCOMBOBOX", P("@LoaiData", "SANBAY"));
        public static DataTable MayBay() => ExecuteProc("sp_LAYDULIEUCOMBOBOX", P("@LoaiData", "MAYBAY"));
        public static DataTable KhuyenMai() => ExecuteProc("sp_LAYDULIEUCOMBOBOX", P("@LoaiData", "KHUYENMAI"));
        public static DataTable DichVu() => ExecuteProc("sp_LAYDULIEUCOMBOBOX", P("@LoaiData", "DICHVU"));

        public static DataTable KhachHang()
        {
            return ExecuteQuery("SELECT MaKH AS Ma, CONCAT(HoTen, N' — ', SoGiayTo) AS Ten, NgaySinh FROM KHACHHANG ORDER BY HoTen");
        }

        public static DateTime? NgaySinh(int maKH)
        {
            object kq = ExecuteScalar("SELECT NgaySinh FROM KHACHHANG WHERE MaKH = @id", P("@id", maKH));
            return kq == null || kq == DBNull.Value ? null : Convert.ToDateTime(kq);
        }
    }
}
