using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;
using static QuanLyBanVeMayBay.BLL.LoiNghiepVu;

namespace QuanLyBanVeMayBay.BLL
{
    /// <summary>Kết quả xem trước phí hủy vé (cùng quy tắc với sp_HUYVE).</summary>
    public class PhiHuyDuKien
    {
        public TimeSpan ConLai { get; set; }
        public decimal TyLe { get; set; }
        public bool CoThuPhi { get; set; }
        public decimal Phi { get; set; }
        public decimal TienHoan { get; set; }
    }

    public static class DatVeBLL
    {
        public const int SoVeToiDaMoiDon = 2;
        public const string ChoThanhToan = "Chờ thanh toán";
        public const string DaThanhToan = "Đã thanh toán";
        public const string DaHuy = "Đã hủy";

        /// <summary>Ưu đãi Tết chỉ áp dụng trong tháng 1–3.</summary>
        public static bool DangMuaTet => DateTime.Today.Month <= 3;

        // =========================================================
        // Giỏ vé (đơn đang lập, chưa lưu CSDL)
        // =========================================================
        public static DataTable TaoGioVe()
        {
            var gio = new DataTable();
            gio.Columns.Add("MaChuyenBay", typeof(int));
            gio.Columns.Add("Tuyen", typeof(string));
            gio.Columns.Add("NgayGioKhoiHanh", typeof(DateTime));
            gio.Columns.Add("MaGhe", typeof(int));
            gio.Columns.Add("SoGhe", typeof(string));
            gio.Columns.Add("MaHangVe", typeof(int));
            gio.Columns.Add("HangVe", typeof(string));
            gio.Columns.Add("MaKH", typeof(int));
            gio.Columns.Add("HanhKhach", typeof(string));
            gio.Columns.Add("MaNguoiGiamHo", typeof(int));
            gio.Columns.Add("NguoiGiamHo", typeof(string));
            gio.Columns.Add("GiaGoc", typeof(decimal));
            gio.Columns.Add("PhanTramGiam", typeof(int));
            gio.Columns.Add("TienGiam", typeof(decimal));
            gio.Columns.Add("GiaThucTra", typeof(decimal));
            return gio;
        }

        /// <summary>Kiểm tra quy tắc rồi thêm một vé vào giỏ.</summary>
        public static void ThemVeVaoGio(DataTable gio, ChuyenBayDTO chuyenBay, GheDTO ghe,
                                        int? maKH, string tenHanhKhach, int? maGiamHo, string tenGiamHo)
        {
            if (chuyenBay == null || ghe == null)
                throw new LoiNghiepVu("Hãy bấm chọn một ghế trống trên sơ đồ trước.");
            if (maKH == null)
                throw new LoiNghiepVu("Vui lòng chọn hành khách.");
            if (gio.Rows.Count >= SoVeToiDaMoiDon)
                throw new LoiNghiepVu($"Mỗi đơn đặt tối đa {SoVeToiDaMoiDon} vé. Hãy tiếp tục sang bước xác nhận để tạo đơn này trước.");
            if (gio.AsEnumerable().Any(r => r.Field<int>("MaChuyenBay") == chuyenBay.MaChuyenBay && r.Field<int>("MaKH") == maKH.Value))
                throw new LoiNghiepVu("Hành khách này đã có vé trên chuyến bay này trong đơn.");
            if (gio.AsEnumerable().Any(r => r.Field<int>("MaChuyenBay") == chuyenBay.MaChuyenBay && r.Field<int>("MaGhe") == ghe.MaGhe))
                throw new LoiNghiepVu("Ghế này đã có trong đơn.");
            if (maGiamHo != null && maGiamHo == maKH)
                throw new LoiNghiepVu("Người giám hộ phải khác hành khách.");

            decimal gia;
            chuyenBay.BangGia.TryGetValue(ghe.MaHangVe, out gia);

            DataRow r = gio.NewRow();
            r["MaChuyenBay"] = chuyenBay.MaChuyenBay;
            r["Tuyen"] = chuyenBay.TuyenBay;
            r["NgayGioKhoiHanh"] = chuyenBay.NgayGioKhoiHanh;
            r["MaGhe"] = ghe.MaGhe;
            r["SoGhe"] = ghe.SoGhe;
            r["MaHangVe"] = ghe.MaHangVe;
            r["HangVe"] = ghe.TenHangVe;
            r["MaKH"] = maKH.Value;
            r["HanhKhach"] = tenHanhKhach;
            r["MaNguoiGiamHo"] = (object)maGiamHo ?? DBNull.Value;
            r["NguoiGiamHo"] = maGiamHo != null ? tenGiamHo : "";
            r["GiaGoc"] = gia;
            r["PhanTramGiam"] = 0;
            r["TienGiam"] = 0m;
            r["GiaThucTra"] = gia;
            gio.Rows.Add(r);
        }

        /// <summary>Hai vé cùng một hành khách, chiều đi và chiều về ngược nhau.</summary>
        public static bool LaCapKhuHoi(DataTable gio)
        {
            if (gio.Rows.Count != 2) return false;
            DataRow a = gio.Rows[0], b = gio.Rows[1];
            string[] ta = a.Field<string>("Tuyen").Split(new[] { " → " }, StringSplitOptions.None);
            string[] tb = b.Field<string>("Tuyen").Split(new[] { " → " }, StringSplitOptions.None);
            return a.Field<int>("MaKH") == b.Field<int>("MaKH") && ta[0] == tb[1] && ta[1] == tb[0];
        }

        /// <summary>Tính lại giá từng vé trong giỏ bằng sp_TINHTHUGIAVE.</summary>
        public static void TinhGiaGioVe(DataTable gio, bool tet, bool khuHoi, int? maKM)
        {
            if (gio.Rows.Count == 0) return;
            if (tet && !DangMuaTet)
                throw new LoiNghiepVu("Ưu đãi Tết chỉ áp dụng trong tháng 1–3.");
            if (khuHoi && gio.Rows.Count < 2)
                throw new LoiNghiepVu("Ưu đãi khứ hồi cần 2 vé trong đơn.");

            foreach (DataRow r in gio.Rows)
            {
                int? maCBKhuHoi = null;
                if (khuHoi)
                {
                    DataRow khac = gio.AsEnumerable().FirstOrDefault(x => x != r);
                    if (khac != null) maCBKhuHoi = khac.Field<int>("MaChuyenBay");
                }
                int soVeTet = gio.AsEnumerable().Count(x => x.Field<int>("MaKH") == r.Field<int>("MaKH"));

                DataRow g = DatVeDAL.TinhGia(r.Field<int>("MaChuyenBay"), r.Field<int>("MaHangVe"), r.Field<int>("MaKH"),
                    tet, khuHoi, maKM, maCBKhuHoi, soVeTet);
                r["GiaGoc"] = g["GiaGoc"];
                r["PhanTramGiam"] = g["PhanTramGiam"];
                r["TienGiam"] = g["TienGiam"];
                r["GiaThucTra"] = g["GiaThucTra"];
            }
        }

        public static decimal TongGiaGoc(DataTable gio) => gio.AsEnumerable().Sum(r => r.Field<decimal>("GiaGoc"));
        public static decimal TongThucTra(DataTable gio) => gio.AsEnumerable().Sum(r => r.Field<decimal>("GiaThucTra"));

        /// <summary>Lưu đơn vào CSDL. Khách liên hệ mặc định là hành khách vé thứ nhất.</summary>
        public static DataRow DatVe(int? maKHLienHe, DataTable gio, bool tet, bool khuHoi, int? maKM)
        {
            if (gio.Rows.Count == 0)
                throw new LoiNghiepVu("Đơn chưa có vé nào.");
            if (gio.Rows.Count > SoVeToiDaMoiDon)
                throw new LoiNghiepVu($"Mỗi đơn đặt tối đa {SoVeToiDaMoiDon} vé.");

            int lienHe = maKHLienHe ?? gio.Rows[0].Field<int>("MaKH");
            return DatVeDAL.DatVe(lienHe, gio.Rows.Cast<DataRow>().ToList(), tet, khuHoi, maKM, PhienDangNhap.MaTK);
        }

        // =========================================================
        // Thanh toán
        // =========================================================
        /// <summary>Lấy đơn và kiểm tra còn thanh toán được không.</summary>
        public static DataRow LayDonDeThanhToan(int maDon)
        {
            DataRow don = DatVeDAL.ThongTinDon(maDon);
            if (don == null)
                throw new LoiNghiepVu("Không tìm thấy đơn #" + maDon + ".");
            string trangThai = don["TrangThai"].ToString();
            if (trangThai != ChoThanhToan)
                throw new LoiNghiepVu($"Đơn #{maDon} đang ở trạng thái \"{trangThai}\" nên không thể thanh toán.");
            return don;
        }

        public static void ThanhToan(int maDon, decimal soTien, string phuongThuc, string ghiChu)
        {
            if (soTien < 0)
                throw new LoiNghiepVu("Số tiền thanh toán không hợp lệ.");
            if (string.IsNullOrWhiteSpace(phuongThuc))
                throw new LoiNghiepVu("Vui lòng chọn phương thức thanh toán.");
            DatVeDAL.ThanhToan(maDon, soTien, phuongThuc, RongThanhNull(ghiChu), PhienDangNhap.MaTK);
        }

        // =========================================================
        // Hủy vé
        // =========================================================
        /// <summary>Lấy vé và kiểm tra còn hủy được không.</summary>
        public static DataRow LayVeDeHuy(int maVe)
        {
            DataRow ve = DatVeDAL.ThongTinVe(maVe);
            if (ve == null)
                throw new LoiNghiepVu("Không tìm thấy vé #" + maVe + ".");
            if (ve["TrangThai"].ToString() == DaHuy)
                throw new LoiNghiepVu("Vé #" + maVe + " đã được hủy trước đó.");
            if (Convert.ToDateTime(ve["NgayGioKhoiHanh"]) <= DateTime.Now)
                throw new LoiNghiepVu("Chuyến bay của vé này đã khởi hành nên không thể hủy.");
            return ve;
        }

        /// <summary>Xem trước phí hủy theo đúng quy tắc của sp_HUYVE (DATEDIFF theo giờ).</summary>
        public static PhiHuyDuKien TinhPhiHuy(DateTime khoiHanh, decimal giaThucTra, string trangThaiDon)
        {
            TimeSpan conLai = khoiHanh - DateTime.Now;
            int gio = (int)Math.Floor(conLai.TotalHours);
            decimal tyLe = gio < 24 ? 0.30m : gio < 72 ? 0.20m : 0.10m;

            var kq = new PhiHuyDuKien { ConLai = conLai, TyLe = tyLe, CoThuPhi = trangThaiDon == DaThanhToan };
            if (kq.CoThuPhi)
            {
                kq.Phi = Math.Round(giaThucTra * tyLe, 0);
                kq.TienHoan = Math.Max(0, giaThucTra - kq.Phi);
            }
            return kq;
        }

        public static DataRow HuyVe(int maVe, string lyDo)
        {
            if (string.IsNullOrWhiteSpace(lyDo))
                throw new LoiNghiepVu("Vui lòng nhập lý do hủy vé.");
            return DatVeDAL.HuyVe(maVe, lyDo.Trim(), PhienDangNhap.MaTK);
        }

        // =========================================================
        // Dịch vụ, tra cứu
        // =========================================================
        public static void ThemDichVu(int maDon, int maVe, int? maDichVu, int soLuong, decimal donGia)
        {
            if (maDichVu == null)
                throw new LoiNghiepVu("Vui lòng chọn dịch vụ.");
            if (soLuong <= 0)
                throw new LoiNghiepVu("Số lượng phải lớn hơn 0.");
            DatVeDAL.ThemDichVu(maDon, maVe, maDichVu.Value, soLuong, donGia, PhienDangNhap.MaTK);
        }

        public static DataTable DanhSachDon(string trangThai, string tuKhoa) => DatVeDAL.DanhSachDon(trangThai, RongThanhNull(tuKhoa));
        public static DataTable VeTrongDon(int maDon) => DatVeDAL.VeTrongDon(maDon);
        public static DataTable DichVuTrongDon(int maDon) => DatVeDAL.DichVuTrongDon(maDon);
        public static DataTable VeCuaKhach(int maKH) => DatVeDAL.VeCuaKhach(maKH);

        /// <summary>Tra cứu vé; mã vé và mã chuyến bay (nếu nhập) phải là số.</summary>
        public static DataTable TraCuuVe(string maVe, string maChuyenBay, string soGiayTo)
        {
            int? ve = DocSo(maVe), cb = DocSo(maChuyenBay);
            if ((RongThanhNull(maVe) != null && ve == null) || (RongThanhNull(maChuyenBay) != null && cb == null))
                throw new LoiNghiepVu("Mã vé và mã chuyến bay phải là số.");
            return DatVeDAL.TraCuuVe(ve, cb, RongThanhNull(soGiayTo));
        }

        private static int? DocSo(string s)
        {
            int v;
            return int.TryParse((s ?? "").Trim(), out v) ? v : (int?)null;
        }
    }
}
