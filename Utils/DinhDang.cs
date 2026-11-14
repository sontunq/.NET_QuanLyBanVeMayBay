using System.Globalization;

namespace QuanLyBanVeMayBay.Utils
{
    public static class DinhDang
    {
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");

        public static string Tien(decimal soTien)
        {
            return soTien.ToString("N0", Vi) + " đ";
        }

        public static string Tien(object soTien)
        {
            return soTien == null || soTien == DBNull.Value ? "0 đ" : Tien(Convert.ToDecimal(soTien));
        }

        public static string TienNgan(decimal soTien)
        {
            if (soTien >= 1_000_000_000) return (soTien / 1_000_000_000).ToString("0.#", Vi) + " tỷ";
            if (soTien >= 1_000_000) return (soTien / 1_000_000).ToString("0.#", Vi) + " tr";
            if (soTien >= 1_000) return (soTien / 1_000).ToString("0", Vi) + "k";
            return soTien.ToString("0", Vi);
        }

        public static string ThoiGianBay(int phut)
        {
            int h = phut / 60, m = phut % 60;
            if (h == 0) return m + " phút";
            return m == 0 ? h + " giờ" : $"{h} giờ {m:00} phút";
        }

        public static string NgayDayDu(DateTime d)
        {
            string thu = d.DayOfWeek == DayOfWeek.Sunday ? "Chủ nhật" : "Thứ " + ((int)d.DayOfWeek + 1);
            return $"{thu}, {d:dd/MM/yyyy}";
        }

        public static int? SoNguyen(string s)
        {
            int v;
            return int.TryParse((s ?? "").Trim(), out v) ? v : (int?)null;
        }

        public static string RongThanhNull(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }
    }
}
