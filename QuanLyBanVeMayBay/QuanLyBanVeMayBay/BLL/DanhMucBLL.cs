using System.Data;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.BLL
{
    /// <summary>Dữ liệu cho các combobox (cột Ma, Ten).</summary>
    public static class DanhMucBLL
    {
        public static DataTable SanBay() => DanhMucDAL.SanBay();
        public static DataTable MayBay() => DanhMucDAL.MayBay();
        public static DataTable KhuyenMai() => DanhMucDAL.KhuyenMai();
        public static DataTable DichVu() => DanhMucDAL.DichVu();
        public static DataTable KhachHang() => DanhMucDAL.KhachHang();
    }
}
