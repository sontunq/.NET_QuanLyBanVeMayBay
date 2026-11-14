namespace QuanLyBanVeMayBay.BLL
{
    /// <summary>
    /// Lỗi do dữ liệu nhập hoặc quy tắc nghiệp vụ không thỏa (không phải lỗi hệ thống).
    /// BLL ném ra, GUI bắt và hiện dạng cảnh báo.
    /// </summary>
    public class LoiNghiepVu : Exception
    {
        public LoiNghiepVu(string thongBao) : base(thongBao) { }

        internal static string RongThanhNull(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}
