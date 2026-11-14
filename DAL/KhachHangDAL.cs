using System.Data;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class KhachHangDAL
    {
        public static DataTable DanhSach(string tuKhoa)
        {
            return ExecuteQuery(@"
SELECT * FROM V_KHACHHANGTHANHVIEN
WHERE @q IS NULL OR HoTen LIKE N'%' + @q + N'%' OR SoGiayTo LIKE '%' + @q + '%' OR SoDienThoai LIKE '%' + @q + '%'
ORDER BY TongChiTieu DESC, MaKH", P("@q", tuKhoa));
        }

        public static DataRow Lay(int maKH)
        {
            DataTable dt = ExecuteQuery("SELECT * FROM KHACHHANG WHERE MaKH = @id", P("@id", maKH));
            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }

        public static int Them(string hoTen, string loaiGiayTo, string soGiayTo, DateTime ngaySinh, string gioiTinh,
                               string sdt, string email, string diaChi)
        {
            object id = ExecuteScalar(@"
INSERT INTO KHACHHANG(HoTen, LoaiGiayTo, SoGiayTo, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi)
VALUES(@HoTen, @Loai, @So, @NgaySinh, @GioiTinh, @SDT, @Email, @DiaChi);
SELECT CAST(SCOPE_IDENTITY() AS INT);",
                P("@HoTen", hoTen), P("@Loai", loaiGiayTo), P("@So", soGiayTo), P("@NgaySinh", ngaySinh.Date),
                P("@GioiTinh", gioiTinh), P("@SDT", sdt), P("@Email", email), P("@DiaChi", diaChi));
            return Convert.ToInt32(id);
        }

        public static void Sua(int maKH, string hoTen, string loaiGiayTo, string soGiayTo, DateTime ngaySinh, string gioiTinh,
                               string sdt, string email, string diaChi)
        {
            ExecuteNonQuery(@"
UPDATE KHACHHANG SET HoTen = @HoTen, LoaiGiayTo = @Loai, SoGiayTo = @So, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh,
       SoDienThoai = @SDT, Email = @Email, DiaChi = @DiaChi
WHERE MaKH = @MaKH",
                P("@HoTen", hoTen), P("@Loai", loaiGiayTo), P("@So", soGiayTo), P("@NgaySinh", ngaySinh.Date),
                P("@GioiTinh", gioiTinh), P("@SDT", sdt), P("@Email", email), P("@DiaChi", diaChi), P("@MaKH", maKH));
        }

        public static DataRow XetHang(int maKH)
        {
            return ExecuteProc("sp_XETHANGTHANHVIEN", P("@MaKH", maKH)).Rows[0];
        }
    }
}
