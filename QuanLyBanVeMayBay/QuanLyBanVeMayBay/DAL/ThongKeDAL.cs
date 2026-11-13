using System.Data;
using static QuanLyBanVeMayBay.DAL.DataProvider;

namespace QuanLyBanVeMayBay.DAL
{
    public static class ThongKeDAL
    {
        public static DataRow TongQuan(int? nam, int? thang)
        {
            return ExecuteProc("sp_THONGKEDASHBOARD", P("@Nam", nam), P("@Thang", thang)).Rows[0];
        }

        public static DataTable DoanhThuTheoThang(int? soThang)
        {
            if (soThang == null)
                return ExecuteQuery("SELECT * FROM V_DOANHTHUTHEOTHANG ORDER BY Nam, Thang");
            return ExecuteQuery(@"SELECT * FROM (SELECT TOP (@n) * FROM V_DOANHTHUTHEOTHANG ORDER BY Nam DESC, Thang DESC) t
                                  ORDER BY Nam, Thang", P("@n", soThang.Value));
        }

        public static DataTable DoanhThuTheoChuyenBay()
        {
            return ExecuteQuery(@"SELECT *, DoanhThuVe + DoanhThuDichVu AS DoanhThu
                                  FROM V_DOANHTHUTHEOCHUYENBAY WHERE SoVeConHieuLuc > 0
                                  ORDER BY DoanhThuVe DESC");
        }

        public static DataTable DoanhThuTheoNhanVien()
        {
            return ExecuteQuery(@"
SELECT tk.HoTen AS NhanVien, tk.VaiTro, COUNT(dd.MaDon) AS SoDon,
       SUM(CASE WHEN dd.TrangThai = N'Đã thanh toán' THEN dd.TongThanhToan ELSE 0 END) AS DoanhThu
FROM TAIKHOAN tk
LEFT JOIN DONDATVE dd ON dd.MaTKNhanVien = tk.MaTK
GROUP BY tk.HoTen, tk.VaiTro
ORDER BY DoanhThu DESC");
        }
    }
}
