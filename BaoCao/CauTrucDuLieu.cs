using System.Data;

namespace BaoCao
{
    /// <summary>
    /// Cấu trúc bảng dữ liệu của từng báo cáo. Dùng chung cho:
    ///  - lúc tạo mẫu .rpt (MauBaoCao) để Crystal biết có những trường nào;
    ///  - lúc chạy (DuLieuBaoCao) để đổ dữ liệu thật vào đúng các trường đó.
    /// Mọi cột đều là chuỗi đã định dạng sẵn (tiền "2.800.000 đ", ngày "dd/MM/yyyy")
    /// để báo cáo hiển thị đúng kiểu Việt Nam, không phụ thuộc cài đặt vùng của máy.
    /// </summary>
    public static class CauTrucDuLieu
    {
        public const string BangHoaDon = "HoaDon";
        public const string BangDoanhThu = "DoanhThu";

        public static readonly string[] CotHoaDon =
        {
            // Thông tin đơn (lặp lại trên mỗi dòng, hiển thị ở đầu và cuối báo cáo)
            "MaDon", "NgayDat", "KhachLienHe", "SoDienThoai", "NhanVien", "TrangThaiDon",
            "TongTienVe", "TongTienDichVu", "GiamKhuyenMai", "TongThanhToan", "DaThu", "NgayIn",
            // Từng vé
            "MaVe", "HanhKhach", "Tuyen", "KhoiHanh", "SoGhe", "HangVe", "GiaGoc", "Giam", "GiaThucTra", "TrangThaiVe"
        };

        public static readonly string[] CotDoanhThu =
        {
            "Thang", "SoDon", "TienThu", "TienHoan", "DoanhThu",
            "TongSoDon", "TongTienThu", "TongTienHoan", "TongDoanhThu", "NgayIn"
        };

        public static DataTable TaoBang(string ten)
        {
            var dt = new DataTable(ten);
            foreach (string c in ten == BangHoaDon ? CotHoaDon : CotDoanhThu)
                dt.Columns.Add(c, typeof(string));
            return dt;
        }
    }
}
