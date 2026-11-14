using System.Data;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.BLL
{
    public static class ThongKeBLL
    {
        public static DataRow TongQuan(int? nam, int? thang)
        {
            if (thang != null && (thang < 1 || thang > 12))
                throw new LoiNghiepVu("Tháng không hợp lệ.");
            return ThongKeDAL.TongQuan(nam, thang);
        }

        public static DataTable DoanhThuTheoThang(int? soThang) => ThongKeDAL.DoanhThuTheoThang(soThang);
        public static DataTable DoanhThuTheoChuyenBay() => ThongKeDAL.DoanhThuTheoChuyenBay();
        public static DataTable DoanhThuTheoNhanVien() => ThongKeDAL.DoanhThuTheoNhanVien();
    }
}
