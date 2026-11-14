using System.Text.RegularExpressions;

namespace QuanLyBanVeMayBay.BLL
{
    /// <summary>
    /// Kiểm tra và chuẩn hóa dữ liệu nhập (họ tên, số điện thoại, email, giấy tờ).
    /// Mỗi hàm trả về giá trị đã chuẩn hóa để lưu, hoặc ném LoiNghiepVu kèm hướng dẫn nhập đúng.
    /// </summary>
    public static class KiemTraDuLieu
    {
        // Di động VN: 03x, 05x, 07x, 08x, 09x (10 số); cố định: 02x (11 số)
        private static readonly Regex SoVietNam = new Regex(@"^(?:[35789]\d{8}|2\d{9})$");
        // Chuẩn quốc tế E.164: + mã quốc gia (không bắt đầu bằng 0), tổng 8–15 chữ số
        private static readonly Regex SoQuocTe = new Regex(@"^\+[1-9]\d{7,14}$");
        private static readonly Regex Email = new Regex(
            @"^[A-Za-z0-9](?:[A-Za-z0-9._%+-]*[A-Za-z0-9])?@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z]{2,}$");
        private static readonly Regex HoTen = new Regex(@"^\p{L}+(?:[ '\-]\p{L}+)*$");
        private static readonly Regex Cccd = new Regex(@"^\d{12}$");
        private static readonly Regex HoChieu = new Regex(@"^(?=.*\d)[A-Z0-9]{6,9}$");
        private static readonly Regex KhaiSinh = new Regex(@"^[A-Z0-9][A-Z0-9/.-]{2,19}$");

        public const string ViDuSdt = "VD: 0912345678, +84912345678 hoặc +14155552671";

        public static string ChuanHoaHoTen(string hoTen)
        {
            string s = Regex.Replace((hoTen ?? "").Trim(), @"\s+", " ");
            if (s.Length < 2 || s.Length > 100 || !HoTen.IsMatch(s))
                throw new LoiNghiepVu("Họ tên chỉ gồm chữ cái và khoảng trắng (cho phép dấu ' hoặc - như O'Neil, Jean-Paul), dài 2–100 ký tự, không chứa số.");
            return s;
        }

        /// <summary>
        /// Số Việt Nam (0xxxxxxxxx hoặc +84xxxxxxxxx) được lưu thống nhất dạng +84xxxxxxxxx.
        /// Số nước ngoài phải có dấu + và mã quốc gia. Trả về null nếu để trống.
        /// </summary>
        public static string ChuanHoaSoDienThoai(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return null;
            string s = Regex.Replace(sdt.Trim(), @"[\s.\-()]", "");
            if (s.StartsWith("00")) s = "+" + s.Substring(2);

            string trongNuoc = null;
            if (s.StartsWith("+84")) trongNuoc = s.Substring(3);
            else if (s.StartsWith("0")) trongNuoc = s.Substring(1);

            if (trongNuoc != null)
            {
                if (!SoVietNam.IsMatch(trongNuoc))
                    throw new LoiNghiepVu("Số điện thoại Việt Nam không hợp lệ: di động phải có 10 số, bắt đầu bằng 03, 05, 07, 08 hoặc 09 " +
                                          "(hoặc +84 rồi 9 số).\n" + ViDuSdt);
                return "+84" + trongNuoc;
            }
            if (!SoQuocTe.IsMatch(s))
                throw new LoiNghiepVu("Số điện thoại không hợp lệ. Số nước ngoài phải bắt đầu bằng dấu + và mã quốc gia, tổng 8–15 chữ số.\n" + ViDuSdt);
            return s;
        }

        /// <summary>Email dạng ten@tenmien.duoi, lưu chữ thường. Trả về null nếu để trống.</summary>
        public static string ChuanHoaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;
            string s = email.Trim().ToLowerInvariant();
            if (s.Length > 100 || s.Contains("..") || !Email.IsMatch(s))
                throw new LoiNghiepVu("Email không hợp lệ. Email phải có dạng ten@tenmien.duoi, ví dụ nguyenvana@gmail.com.");
            return s;
        }

        /// <summary>Kiểm tra số giấy tờ theo loại; trả về số đã chuẩn hóa (bỏ khoảng trắng, chữ in hoa).</summary>
        public static string ChuanHoaSoGiayTo(string loaiGiayTo, string soGiayTo, DateTime ngaySinh)
        {
            string s = Regex.Replace((soGiayTo ?? "").Trim(), @"\s+", "").ToUpperInvariant();
            if (s.Length == 0) throw new LoiNghiepVu("Vui lòng nhập số giấy tờ.");

            switch (loaiGiayTo)
            {
                case "CCCD":
                    if (!Cccd.IsMatch(s))
                        throw new LoiNghiepVu("Số CCCD phải gồm đúng 12 chữ số.");
                    break;
                case "Hộ chiếu":
                    if (!HoChieu.IsMatch(s))
                        throw new LoiNghiepVu("Số hộ chiếu gồm 6–9 ký tự chữ in hoa hoặc số, có ít nhất một chữ số (VD: C1234567).");
                    break;
                case "Giấy khai sinh":
                    if (!KhaiSinh.IsMatch(s))
                        throw new LoiNghiepVu("Số giấy khai sinh gồm 3–20 ký tự chữ, số, dấu / . - (VD: 125/2018).");
                    if (Tuoi(ngaySinh) >= 14)
                        throw new LoiNghiepVu("Giấy khai sinh chỉ dùng cho hành khách dưới 14 tuổi. Người từ 14 tuổi dùng CCCD hoặc hộ chiếu.");
                    break;
                default:
                    throw new LoiNghiepVu("Loại giấy tờ không hợp lệ.");
            }
            return s;
        }

        private static int Tuoi(DateTime ngaySinh)
        {
            DateTime hom = DateTime.Today;
            int t = hom.Year - ngaySinh.Year;
            if (ngaySinh.Date > hom.AddYears(-t)) t--;
            return t;
        }
    }
}
