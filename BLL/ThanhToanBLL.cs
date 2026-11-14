using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyBanVeMayBay.BLL
{
    /// <summary>
    /// Tài khoản nhận tiền chuyển khoản.
    /// ĐANG LÀ TÀI KHOẢN MẪU ĐỂ DEMO: đổi 4 giá trị dưới đây thành tài khoản thật khi triển khai.
    /// Mã BIN ngân hàng tra tại https://api.vietqr.io/v2/banks (vd Vietcombank 970436, BIDV 970418, Techcombank 970407).
    /// </summary>
    public static class TaiKhoanNhanTien
    {
        public const string MaBinNganHang = "970436";
        public const string TenNganHang = "Vietcombank";
        public const string SoTaiKhoan = "0123456789";
        public const string ChuTaiKhoan = "CONG TY BAN VE MAY BAY (DEMO)";
        public const bool LaTaiKhoanMau = true;
    }

    public class ThongTinThe
    {
        public string LoaiThe { get; set; }
        public string BonSoCuoi { get; set; }
        public string ChuThe { get; set; }
    }

    public static class ThanhToanBLL
    {
        public const string TienMat = "Tiền mặt", ChuyenKhoan = "Chuyển khoản", The = "Thẻ";

        // ------------------------------------------------------------ chuyển khoản

        /// <summary>Nội dung chuyển khoản để đối soát, vd "DH12".</summary>
        public static string NoiDungChuyenKhoan(int maDon) => "DH" + maDon;

        /// <summary>
        /// Chuỗi VietQR (chuẩn EMVCo của NAPAS). App ngân hàng quét sẽ tự điền
        /// ngân hàng, số tài khoản, số tiền và nội dung chuyển khoản.
        /// </summary>
        public static string ChuoiVietQR(decimal soTien, string noiDung)
        {
            string nguoiNhan = Tlv("00", "A000000727")
                             + Tlv("01", Tlv("00", TaiKhoanNhanTien.MaBinNganHang) + Tlv("01", TaiKhoanNhanTien.SoTaiKhoan))
                             + Tlv("02", "QRIBFTTA");
            var sb = new StringBuilder()
                .Append(Tlv("00", "01"))
                .Append(Tlv("01", "12"))                     // QR động: dùng một lần, có số tiền
                .Append(Tlv("38", nguoiNhan))
                .Append(Tlv("53", "704"))                    // VND
                .Append(Tlv("54", decimal.Round(soTien, 0).ToString("0", CultureInfo.InvariantCulture)))
                .Append(Tlv("58", "VN"))
                .Append(Tlv("62", Tlv("08", noiDung)))
                .Append("6304");
            string s = sb.ToString();
            return s + Crc16(s).ToString("X4");
        }

        private static string Tlv(string id, string giaTri) => id + giaTri.Length.ToString("00") + giaTri;

        private static ushort Crc16(string s)
        {
            ushort crc = 0xFFFF;
            foreach (byte b in Encoding.UTF8.GetBytes(s))
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                    crc = (crc & 0x8000) != 0 ? (ushort)((crc << 1) ^ 0x1021) : (ushort)(crc << 1);
            }
            return crc;
        }

        public static void KiemTraChuyenKhoan(bool daXacNhanNhanTien)
        {
            if (!daXacNhanNhanTien)
                throw new LoiNghiepVu("Hãy kiểm tra tài khoản ngân hàng và tích \"Đã nhận được tiền\" trước khi xác nhận.");
        }

        // ------------------------------------------------------------ thẻ

        /// <summary>Kiểm tra thông tin thẻ. Chỉ trả về loại thẻ + 4 số cuối; KHÔNG lưu số thẻ, hạn hay CVV.</summary>
        public static ThongTinThe KiemTraThe(string soThe, string chuThe, string hetHan, string cvv)
        {
            string so = Regex.Replace(soThe ?? "", @"[\s-]", "");
            if (!Regex.IsMatch(so, @"^\d{12,19}$"))
                throw new LoiNghiepVu("Số thẻ phải gồm 12–19 chữ số.");
            string loai = LoaiThe(so);
            if (loai == null)
                throw new LoiNghiepVu("Không nhận dạng được loại thẻ. Chấp nhận Visa, Mastercard, JCB, American Express và thẻ nội địa NAPAS.");
            if (loai != "NAPAS" && !Luhn(so))
                throw new LoiNghiepVu("Số thẻ không hợp lệ (sai số kiểm tra). Vui lòng nhập lại.");

            string ten = Regex.Replace((chuThe ?? "").Trim(), @"\s+", " ").ToUpperInvariant();
            if (!Regex.IsMatch(ten, @"^[A-Z]+(?: [A-Z]+)+$") || ten.Length > 26)
                throw new LoiNghiepVu("Tên chủ thẻ ghi như trên thẻ: chữ in hoa không dấu, ít nhất 2 từ (VD: NGUYEN VAN AN).");

            var m = Regex.Match((hetHan ?? "").Trim(), @"^(0[1-9]|1[0-2])\s*/\s*(\d{2})$");
            if (!m.Success)
                throw new LoiNghiepVu("Ngày hết hạn có dạng MM/YY (VD: 08/28).");
            int thang = int.Parse(m.Groups[1].Value), nam = 2000 + int.Parse(m.Groups[2].Value);
            var cuoiThangHetHan = new DateTime(nam, thang, 1).AddMonths(1);
            if (cuoiThangHetHan <= DateTime.Today)
                throw new LoiNghiepVu("Thẻ đã hết hạn.");
            if (nam > DateTime.Today.Year + 20)
                throw new LoiNghiepVu("Ngày hết hạn không hợp lệ.");

            int doDaiCvv = loai == "American Express" ? 4 : 3;
            if (!Regex.IsMatch((cvv ?? "").Trim(), @"^\d{" + doDaiCvv + "}$"))
                throw new LoiNghiepVu($"Mã CVV/CVC gồm {doDaiCvv} chữ số ở mặt sau thẻ.");

            return new ThongTinThe { LoaiThe = loai, BonSoCuoi = so.Substring(so.Length - 4), ChuThe = ten };
        }

        /// <summary>Nhận dạng loại thẻ theo đầu số (IIN). Trả null nếu không hỗ trợ.</summary>
        public static string LoaiThe(string so)
        {
            so = Regex.Replace(so ?? "", @"\D", "");
            if (so.Length < 2) return null;
            if (so.StartsWith("9704")) return "NAPAS";
            if (so[0] == '4') return "Visa";
            int d2 = int.Parse(so.Substring(0, 2));
            if (d2 >= 51 && d2 <= 55) return "Mastercard";
            if (so.Length >= 4)
            {
                int d4 = int.Parse(so.Substring(0, 4));
                if (d4 >= 2221 && d4 <= 2720) return "Mastercard";
                if (d4 >= 3528 && d4 <= 3589) return "JCB";
            }
            if (d2 == 34 || d2 == 37) return "American Express";
            return null;
        }

        private static bool Luhn(string so)
        {
            int tong = 0;
            bool nhanDoi = false;
            for (int i = so.Length - 1; i >= 0; i--)
            {
                int d = so[i] - '0';
                if (nhanDoi) { d *= 2; if (d > 9) d -= 9; }
                tong += d;
                nhanDoi = !nhanDoi;
            }
            return tong % 10 == 0;
        }

        // ------------------------------------------------------------ tiền mặt

        public static decimal TienThoi(decimal tongTien, decimal? khachDua)
        {
            if (khachDua == null)
                throw new LoiNghiepVu("Vui lòng nhập số tiền khách đưa.");
            if (khachDua.Value < tongTien)
                throw new LoiNghiepVu("Số tiền khách đưa chưa đủ.");
            return khachDua.Value - tongTien;
        }

        // ------------------------------------------------------------ ghi chú lưu vào THANHTOAN.GhiChu

        public static string GhepGhiChu(string chiTiet, string ghiChuNguoiDung)
        {
            string s = string.IsNullOrWhiteSpace(ghiChuNguoiDung) ? chiTiet : chiTiet + " | " + ghiChuNguoiDung.Trim();
            return s.Length > 250 ? s.Substring(0, 250) : s;
        }
    }
}
