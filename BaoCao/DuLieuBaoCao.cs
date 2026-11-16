using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BaoCao
{
    /// <summary>Đọc dữ liệu từ CSDL QuanLyBanVeMayBay2 (chỉ đọc) và chuyển thành bảng đúng cấu trúc báo cáo.</summary>
    public static class DuLieuBaoCao
    {
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");

        private static string Tien(object v) =>
            v == null || v == DBNull.Value ? "0 đ" : Convert.ToDecimal(v).ToString("N0", Vi) + " đ";

        private static string Ngay(object v, string dinhDang = "dd/MM/yyyy HH:mm") =>
            v == null || v == DBNull.Value ? "" : Convert.ToDateTime(v).ToString(dinhDang, Vi);

        private static DataTable Doc(string chuoiKetNoi, string sql, int? ma = null)
        {
            using (var cn = new SqlConnection(chuoiKetNoi))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                if (ma != null) da.SelectCommand.Parameters.AddWithValue("@ma", ma.Value);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Hóa đơn của một đơn đặt vé: mỗi dòng là một vé, kèm thông tin chung của đơn.</summary>
        public static DataTable HoaDon(string chuoiKetNoi, int maDon)
        {
            DataTable goc = Doc(chuoiKetNoi, @"
SELECT dd.MaDon, dd.NgayDat, kh.HoTen AS KhachLienHe, kh.SoDienThoai, tk.HoTen AS NhanVien, dd.TrangThai AS TrangThaiDon,
       dd.TongTienVe, dd.TongTienDichVu, dd.TongThanhToan,
       ISNULL((SELECT SUM(TienGiam) FROM VE WHERE MaDon = dd.MaDon AND TrangThai <> N'Đã hủy'), 0) AS TienDaGiam,
       ISNULL((SELECT SUM(CASE WHEN TrangThai = N'Thành công' THEN SoTien WHEN TrangThai = N'Đã hoàn' THEN -SoTien ELSE 0 END)
               FROM THANHTOAN WHERE MaDon = dd.MaDon), 0) AS DaThu,
       v.MaVe, hk.HoTen AS HanhKhach, cb.MaSanBayDi, cb.MaSanBayDen, cb.NgayGioKhoiHanh,
       g.SoGhe, hv.TenHangVe, v.GiaGoc, v.TongPhanTramGiam, v.GiaThucTra, v.TrangThai AS TrangThaiVe
FROM DONDATVE dd
JOIN KHACHHANG kh ON kh.MaKH = dd.MaKHLienHe
JOIN TAIKHOAN tk ON tk.MaTK = dd.MaTKNhanVien
JOIN VE v ON v.MaDon = dd.MaDon
JOIN KHACHHANG hk ON hk.MaKH = v.MaKH
JOIN CHUYENBAY cb ON cb.MaChuyenBay = v.MaChuyenBay
JOIN GHE g ON g.MaGhe = v.MaGhe
JOIN HANGVE hv ON hv.MaHangVe = v.MaHangVe
WHERE dd.MaDon = @ma
ORDER BY v.MaVe", maDon);

            DataTable kq = CauTrucDuLieu.TaoBang(CauTrucDuLieu.BangHoaDon);
            string ngayIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm", Vi);
            foreach (DataRow r in goc.Rows)
            {
                kq.Rows.Add(
                    "#" + r["MaDon"], Ngay(r["NgayDat"]), r["KhachLienHe"], r["SoDienThoai"], r["NhanVien"], r["TrangThaiDon"],
                    Tien(r["TongTienVe"]), Tien(r["TongTienDichVu"]), Tien(r["TienDaGiam"]), Tien(r["TongThanhToan"]), Tien(r["DaThu"]), ngayIn,
                    "#" + r["MaVe"], r["HanhKhach"] + (r["TrangThaiVe"].ToString() == "Đã hủy" ? " (đã hủy)" : ""), r["MaSanBayDi"] + " → " + r["MaSanBayDen"], Ngay(r["NgayGioKhoiHanh"]),
                    r["SoGhe"], r["TenHangVe"], Tien(r["GiaGoc"]), r["TongPhanTramGiam"] + "%", Tien(r["GiaThucTra"]), r["TrangThaiVe"]);
            }
            return kq;
        }

        /// <summary>Doanh thu theo tháng (từ view V_DOANHTHUTHEOTHANG), kèm dòng tổng cộng.</summary>
        public static DataTable DoanhThu(string chuoiKetNoi)
        {
            DataTable goc = Doc(chuoiKetNoi, "SELECT * FROM V_DOANHTHUTHEOTHANG ORDER BY Nam, Thang");

            decimal tongThu = 0, tongHoan = 0, tongDT = 0;
            int tongDon = 0;
            foreach (DataRow r in goc.Rows)
            {
                tongThu += Convert.ToDecimal(r["TongTienThu"]);
                tongHoan += Convert.ToDecimal(r["TongTienHoan"]);
                tongDT += Convert.ToDecimal(r["DoanhThuThuan"]);
                tongDon += Convert.ToInt32(r["SoDonThanhToan"]);
            }

            DataTable kq = CauTrucDuLieu.TaoBang(CauTrucDuLieu.BangDoanhThu);
            string ngayIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm", Vi);
            foreach (DataRow r in goc.Rows)
            {
                kq.Rows.Add(
                    $"Tháng {Convert.ToInt32(r["Thang"]):00}/{r["Nam"]}", r["SoDonThanhToan"].ToString(),
                    Tien(r["TongTienThu"]), Tien(r["TongTienHoan"]), Tien(r["DoanhThuThuan"]),
                    tongDon.ToString(), Tien(tongThu), Tien(tongHoan), Tien(tongDT), ngayIn);
            }
            return kq;
        }
    }
}
