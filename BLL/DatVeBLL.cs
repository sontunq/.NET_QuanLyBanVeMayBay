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
        /// <summary>Tiền dịch vụ của vé, được hoàn đủ khi đơn đã thanh toán đủ.</summary>
        public decimal TienDichVu { get; set; }
        public decimal TienHoan { get; set; }
    }

    public static class DatVeBLL
    {
        public const string ChoThanhToan = "Chờ thanh toán";
        public const string DaThanhToan = "Đã thanh toán";
        public const string DaHuy = "Đã hủy";

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
            if (gio.AsEnumerable().Any(r => r.Field<int>("MaChuyenBay") == chuyenBay.MaChuyenBay && r.Field<int>("MaKH") == maKH.Value))
                throw new LoiNghiepVu("Hành khách này đã có vé trên chuyến bay này trong đơn (mỗi hành khách chỉ 1 ghế trên một chuyến).\nĐể thêm vé, hãy chọn hành khách khác, hoặc quay lại bước 1 chọn chuyến khác (ví dụ chiều về).");
            if (gio.AsEnumerable().Any(r => r.Field<int>("MaChuyenBay") == chuyenBay.MaChuyenBay && r.Field<int>("MaGhe") == ghe.MaGhe))
                throw new LoiNghiepVu("Ghế này đã có trong đơn.");
            if (maGiamHo != null && maGiamHo == maKH)
                throw new LoiNghiepVu("Người giám hộ phải khác hành khách.");

            // Người giám hộ: chỉ áp dụng cho hành khách dưới 16 tuổi (tính đến ngày bay),
            // và người giám hộ phải từ 18 tuổi, đã có vé trên CÙNG chuyến trong đơn này.
            if (CanGiamHo(maKH.Value, chuyenBay.NgayGioKhoiHanh))
            {
                if (maGiamHo == null)
                    throw new LoiNghiepVu($"{tenHanhKhach} dưới {TuoiCanGiamHo} tuổi nên cần người giám hộ đi cùng chuyến.\n" +
                                          "Hãy thêm vé cho người giám hộ (từ 18 tuổi) trên chuyến này trước, rồi chọn người đó ở ô \"Người giám hộ\".");
                if (!DuTuoiGiamHo(maGiamHo.Value, chuyenBay.NgayGioKhoiHanh))
                    throw new LoiNghiepVu($"Người giám hộ phải từ {TuoiGiamHoToiThieu} tuổi trở lên.");
                if (!CoVeTrenChuyen(gio, maGiamHo.Value, chuyenBay.MaChuyenBay))
                    throw new LoiNghiepVu("Người giám hộ phải có vé trên cùng chuyến bay trong đơn này.\n" +
                                          "Hãy thêm vé cho người giám hộ trên chuyến này trước.");
            }
            else
            {
                maGiamHo = null;   // Từ 16 tuổi không cần giám hộ
            }

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

        // ---------------------------------------------------------
        // Người giám hộ (cùng quy tắc với sp_THEMVEDON)
        // ---------------------------------------------------------
        public const int TuoiCanGiamHo = 16;
        public const int TuoiGiamHoToiThieu = 18;

        /// <summary>Tuổi tròn tại một ngày (giống cách tính trong SQL).</summary>
        public static int Tuoi(DateTime ngaySinh, DateTime taiNgay)
        {
            int tuoi = taiNgay.Year - ngaySinh.Year;
            if (ngaySinh.Date > taiNgay.Date.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

        /// <summary>Hành khách dưới 16 tuổi tính đến ngày bay thì cần người giám hộ.</summary>
        public static bool CanGiamHo(int maKH, DateTime ngayBay)
        {
            DateTime? ns = DanhMucDAL.NgaySinh(maKH);
            return ns != null && Tuoi(ns.Value, ngayBay) < TuoiCanGiamHo;
        }

        public static bool DuTuoiGiamHo(int maKH, DateTime ngayBay)
        {
            DateTime? ns = DanhMucDAL.NgaySinh(maKH);
            return ns != null && Tuoi(ns.Value, ngayBay) >= TuoiGiamHoToiThieu;
        }

        private static bool CoVeTrenChuyen(DataTable gio, int maKH, int maChuyenBay) =>
            gio.AsEnumerable().Any(r => r.Field<int>("MaKH") == maKH && r.Field<int>("MaChuyenBay") == maChuyenBay);

        /// <summary>Những người có thể làm giám hộ trên một chuyến: đã có vé trên chuyến đó trong giỏ và từ 18 tuổi.
        /// Trả về bảng (Ma, Ten) để gắn vào combobox.</summary>
        public static DataTable NguoiGiamHoHopLe(DataTable gio, int maChuyenBay, DateTime ngayBay)
        {
            var dt = new DataTable();
            dt.Columns.Add("Ma", typeof(int));
            dt.Columns.Add("Ten", typeof(string));
            foreach (DataRow r in gio.AsEnumerable().Where(x => x.Field<int>("MaChuyenBay") == maChuyenBay))
            {
                int ma = r.Field<int>("MaKH");
                if (DuTuoiGiamHo(ma, ngayBay)) dt.Rows.Add(ma, r.Field<string>("HanhKhach"));
            }
            return dt;
        }

        /// <summary>Xóa một vé khỏi giỏ. Không cho xóa vé của người giám hộ khi trẻ cùng chuyến vẫn còn trong giỏ.</summary>
        public static void XoaVeKhoiGio(DataTable gio, DataRow ve)
        {
            int maKH = ve.Field<int>("MaKH"), maCB = ve.Field<int>("MaChuyenBay");
            DataRow tre = gio.AsEnumerable().FirstOrDefault(r => r != ve && r.Field<int>("MaChuyenBay") == maCB
                                                                 && r.Field<int?>("MaNguoiGiamHo") == maKH);
            if (tre != null)
                throw new LoiNghiepVu($"{ve["HanhKhach"]} đang là người giám hộ của {tre["HanhKhach"]} trên chuyến này.\n" +
                                      "Hãy xóa vé của hành khách dưới 16 tuổi trước.");
            gio.Rows.Remove(ve);
        }

        /// <summary>
        /// Chuyến chiều về của một vé trong giỏ: vé khác của CÙNG hành khách có tuyến ngược lại.
        /// Cùng quy tắc với sp_THEMVEDON (SQL tự nhận diện khứ hồi, giảm 10% cho cả hai vé).
        /// </summary>
        public static int? ChuyenKhuHoiCua(DataTable gio, DataRow ve)
        {
            string[] t = ve.Field<string>("Tuyen").Split(new[] { " → " }, StringSplitOptions.None);
            DataRow cap = gio.AsEnumerable().FirstOrDefault(x =>
            {
                if (x == ve || x.Field<int>("MaKH") != ve.Field<int>("MaKH")) return false;
                string[] k = x.Field<string>("Tuyen").Split(new[] { " → " }, StringSplitOptions.None);
                return t[0] == k[1] && t[1] == k[0];
            });
            return cap?.Field<int>("MaChuyenBay");
        }

        /// <summary>Giỏ có ít nhất một cặp vé khứ hồi.</summary>
        public static bool CoKhuHoi(DataTable gio) =>
            gio.AsEnumerable().Any(r => ChuyenKhuHoiCua(gio, r) != null);

        /// <summary>Tính lại giá từng vé trong giỏ bằng sp_TINHTHUGIAVE (khứ hồi tự nhận diện theo từng vé).
        /// Khách liên hệ mặc định là hành khách vé thứ nhất (dùng để xét ưu đãi khách hàng mới).</summary>
        public static void TinhGiaGioVe(DataTable gio, int? maKM, int? maKHLienHe = null)
        {
            if (gio.Rows.Count == 0) return;
            int lienHe = maKHLienHe ?? gio.Rows[0].Field<int>("MaKH");
            foreach (DataRow r in gio.Rows)
            {
                DataRow g = DatVeDAL.TinhGia(r.Field<int>("MaChuyenBay"), r.Field<int>("MaHangVe"), r.Field<int>("MaKH"),
                    maKM, ChuyenKhuHoiCua(gio, r), lienHe);
                r["GiaGoc"] = g["GiaGoc"];
                r["PhanTramGiam"] = g["PhanTramGiam"];
                r["TienGiam"] = g["TienGiam"];
                r["GiaThucTra"] = g["GiaThucTra"];
            }
        }

        public static decimal TongGiaGoc(DataTable gio) => gio.AsEnumerable().Sum(r => r.Field<decimal>("GiaGoc"));
        public static decimal TongThucTra(DataTable gio) => gio.AsEnumerable().Sum(r => r.Field<decimal>("GiaThucTra"));

        /// <summary>Lưu đơn nhiều vé vào CSDL. Khách liên hệ mặc định là hành khách vé thứ nhất.
        /// Trả về dòng đầu của kết quả (MaDon, TongThanhToan, TrangThaiDon...).</summary>
        public static DataRow DatVe(int? maKHLienHe, DataTable gio, int? maKM)
        {
            if (gio.Rows.Count == 0)
                throw new LoiNghiepVu("Đơn chưa có vé nào.");

            int lienHe = maKHLienHe ?? gio.Rows[0].Field<int>("MaKH");
            // Lưu vé không có giám hộ trước, để vé của người giám hộ đã có trong đơn khi lưu vé của trẻ (sp_THEMVEDON kiểm tra)
            var dsVe = gio.Rows.Cast<DataRow>().OrderBy(r => r.IsNull("MaNguoiGiamHo") ? 0 : 1).ToList();
            return DatVeDAL.DatVe(lienHe, dsVe, maKM, PhienDangNhap.MaTK).Rows[0];
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
            if (trangThai == DaHuy)
                throw new LoiNghiepVu($"Đơn #{maDon} đã hủy nên không thể thanh toán.");
            // Đơn đã thanh toán vẫn thu tiếp được nếu có dịch vụ thêm sau (sp_THANHTOANDON thu đúng phần còn thiếu)
            if (Convert.ToDecimal(don["ConPhaiThu"]) <= 0)
                throw new LoiNghiepVu($"Đơn #{maDon} đã thanh toán đủ, không còn khoản nào cần thu.");
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
            if (DatVeDAL.LaVeGiamHoConHieuLuc(maVe))
                throw new LoiNghiepVu("Vé #" + maVe + " là vé của người giám hộ cho hành khách dưới 16 tuổi trên cùng chuyến.\n" +
                                      "Hãy hủy vé của hành khách đó trước.");
            return ve;
        }

        /// <summary>
        /// Xem trước phí hủy theo đúng quy tắc của sp_HUYVE:
        /// chỉ đơn "Đã thanh toán" mới tính phí (10% / 20% / 30% giá vé theo số giờ còn lại);
        /// tiền hoàn = phần khách đã trả dư khi bỏ vé (và dịch vụ của vé) khỏi đơn, trừ phí hủy.
        /// Nếu đơn còn nợ tiền dịch vụ thêm sau, khoản nợ được trừ vào tiền hoàn.
        /// </summary>
        public static PhiHuyDuKien TinhPhiHuy(DataRow ve)
        {
            DateTime khoiHanh = Convert.ToDateTime(ve["NgayGioKhoiHanh"]);
            decimal giaThucTra = Convert.ToDecimal(ve["GiaThucTra"]);
            DataRow don = DatVeDAL.ThongTinDon(Convert.ToInt32(ve["MaDon"]));
            decimal tienDichVu = DatVeDAL.TienDichVuCuaVe(Convert.ToInt32(ve["MaVe"]));
            // Phần khách đã trả dư nếu bỏ vé này khỏi đơn = giá vé + dịch vụ của vé − số đơn còn nợ
            decimal duSauHuy = don == null ? 0 : giaThucTra + tienDichVu - Convert.ToDecimal(don["ConPhaiThu"]);
            bool coThuPhi = don != null && don["TrangThai"].ToString() == DaThanhToan && duSauHuy > 0;

            TimeSpan conLai = khoiHanh - DateTime.Now;
            int gio = (int)Math.Floor(conLai.TotalHours);
            decimal tyLe = gio < 24 ? 0.30m : gio < 72 ? 0.20m : 0.10m;

            var kq = new PhiHuyDuKien { ConLai = conLai, TyLe = tyLe, CoThuPhi = coThuPhi };
            if (kq.CoThuPhi)
            {
                // ROUND của SQL làm tròn .5 ra xa số 0
                kq.Phi = Math.Min(Math.Round(giaThucTra * tyLe, 0, MidpointRounding.AwayFromZero), duSauHuy);
                kq.TienDichVu = tienDichVu;
                kq.TienHoan = duSauHuy - kq.Phi;
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
        /// <summary>
        /// Thêm các dịch vụ được tick cho vé (mỗi dịch vụ 1 lần), kể cả khi đơn đã thanh toán.
        /// Chạy chung một giao dịch. Trả về số tiền đơn còn phải thu sau khi thêm.
        /// </summary>
        public static decimal ThemDichVu(int maDon, int maVe, IList<int> dsMaDichVu)
        {
            if (dsMaDichVu == null || dsMaDichVu.Count == 0)
                throw new LoiNghiepVu("Vui lòng tick ít nhất một dịch vụ mới.");
            HashSet<int> daCo = DatVeDAL.DichVuCuaVe(maVe);
            if (dsMaDichVu.Any(daCo.Contains))
                throw new LoiNghiepVu("Có dịch vụ vé này đã đăng ký rồi.");
            DatVeDAL.ThemDichVu(maVe, dsMaDichVu, PhienDangNhap.MaTK);
            return Convert.ToDecimal(DatVeDAL.ThongTinDon(maDon)["ConPhaiThu"]);
        }

        public static HashSet<int> DichVuCuaVe(int maVe) => DatVeDAL.DichVuCuaVe(maVe);

        public static string TrangThaiDon(int maDon) => DatVeDAL.ThongTinDon(maDon)?["TrangThai"].ToString();

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
