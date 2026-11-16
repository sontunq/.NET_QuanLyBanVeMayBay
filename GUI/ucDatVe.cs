using System.Data;
using QuanLyBanVeMayBay.Controls;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucDatVe : UserControl, ITaiLai
    {
        private int _buoc = 1;
        private bool _daNap;
        private bool _dangTinhGia;
        private ChuyenBayDTO _chuyenBay;
        private DataTable _gioVe;
        private readonly List<FlightCard> _the = new List<FlightCard>();

        public ucDatVe()
        {
            InitializeComponent();
            if (!DesignMode) _gioVe = DatVeBLL.TaoGioVe();
        }

        // =========================================================
        // Nạp dữ liệu
        // =========================================================
        public void TaiLai()
        {
            try
            {
                if (!_daNap)
                {
                    GridHelper.Apply(dgvGioVe);
                    GridHelper.Apply(dgvXacNhan);
                    GridHelper.Bind(dgvGioVe, _gioVe, "MaChuyenBay", "NgayGioKhoiHanh", "MaGhe", "MaHangVe", "MaKH", "MaNguoiGiamHo",
                        "PhanTramGiam", "TienGiam", "GiaThucTra");
                    GridHelper.Bind(dgvXacNhan, _gioVe, "MaChuyenBay", "MaGhe", "MaHangVe", "MaKH", "MaNguoiGiamHo");

                    GanCombo(cboDiemDi, DanhMucBLL.SanBay(), "Tất cả điểm đi");
                    GanCombo(cboDiemDen, DanhMucBLL.SanBay(), "Tất cả điểm đến");
                    dtpNgayBay.MinDate = DateTime.Today;
                    dtpNgayBay.Value = DateTime.Today.AddDays(1);

                    // Đã bỏ ưu đãi Tết
                    chkTet.Checked = false;
                    chkTet.Visible = false;
                    // Khứ hồi được tự động áp dụng khi đơn là cặp vé đi/về
                    chkKhuHoi.Enabled = false;
                    // Đổi khách liên hệ thì tính lại giá (ưu đãi khách hàng mới xét theo khách liên hệ)
                    cboLienHe.SelectedIndexChanged += TuyChonGia_Changed;

                    HienChuyenBay(ChuyenBayBLL.LichBaySapToi(null, null), "Lịch bay sắp tới");
                    _daNap = true;
                }

                NapKhachHang(null);
                int? km = cboKhuyenMai.SelectedValue as int?;
                GanCombo(cboKhuyenMai, DanhMucBLL.KhuyenMai(), "Không dùng mã khuyến mãi");
                if (km != null) cboKhuyenMai.SelectedValue = km.Value;
                ChuyenBuoc(_buoc);
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private static void GanCombo(ComboBox cbo, DataTable dt, string dongTrong)
        {
            if (dongTrong != null)
            {
                DataRow r = dt.NewRow();
                r["Ten"] = dongTrong;
                r["Ma"] = DBNull.Value;
                dt.Rows.InsertAt(r, 0);
            }
            cbo.DataSource = null;
            cbo.DisplayMember = "Ten";
            cbo.ValueMember = "Ma";
            cbo.DataSource = dt;
            if (dt.Rows.Count > 0) cbo.SelectedIndex = 0;
        }

        private void NapKhachHang(int? chonMaKH)
        {
            int? giu = chonMaKH ?? (cboHanhKhach.SelectedValue as int?);
            int? giuLienHe = cboLienHe.SelectedValue as int?;
            GanCombo(cboHanhKhach, DanhMucBLL.KhachHang(), null);
            GanCombo(cboGiamHo, DanhMucBLL.KhachHang(), "Không cần giám hộ");
            GanCombo(cboLienHe, DanhMucBLL.KhachHang(), "Hành khách của vé thứ nhất");
            if (giu != null) cboHanhKhach.SelectedValue = giu.Value;
            if (giuLienHe != null) cboLienHe.SelectedValue = giuLienHe.Value;
        }

        // =========================================================
        // Bước 1: chọn chuyến bay
        // =========================================================
        private void btnTimChuyen_Click(object sender, EventArgs e)
        {
            string di = cboDiemDi.SelectedValue as string, den = cboDiemDen.SelectedValue as string;
            try
            {
                // Chưa chọn đủ tuyến thì BLL trả lịch bay sắp tới theo phần đã chọn
                DateTime ngay = dtpNgayBay.Value.Date;
                var ds = ChuyenBayBLL.TimKiem(di, den, ngay);
                HienChuyenBay(ds, di == null || den == null ? "Lịch bay sắp tới" : $"{di} → {den} · {ngay:dd/MM/yyyy}");
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnLichBay_Click(object sender, EventArgs e)
        {
            try
            {
                HienChuyenBay(ChuyenBayBLL.LichBaySapToi(cboDiemDi.SelectedValue as string, cboDiemDen.SelectedValue as string), "Lịch bay sắp tới");
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnDoiChieu_Click(object sender, EventArgs e)
        {
            int a = cboDiemDi.SelectedIndex;
            cboDiemDi.SelectedIndex = cboDiemDen.SelectedIndex;
            cboDiemDen.SelectedIndex = a;
        }

        private void HienChuyenBay(List<ChuyenBayDTO> ds, string tieuDe)
        {
            int? giu = _chuyenBay?.MaChuyenBay;
            flpChuyenBay.SuspendLayout();
            foreach (var t in _the) t.Dispose();
            _the.Clear();
            flpChuyenBay.Controls.Clear();

            foreach (var cb in ds)
            {
                var the = new FlightCard { ChuyenBay = cb, Width = Math.Max(400, flpChuyenBay.ClientSize.Width - 24) };
                the.Click += (s, e) => ChonChuyen(((FlightCard)s).ChuyenBay);
                _the.Add(the);
                flpChuyenBay.Controls.Add(the);
            }
            flpChuyenBay.ResumeLayout();

            cardChuyenBay.Title = "Chuyến bay";
            cardChuyenBay.Subtitle = ds.Count > 0 ? $"· {tieuDe} · {ds.Count} chuyến" : "· " + tieuDe;
            lblKhongCo.Text = "Không có chuyến bay phù hợp.\nThử đổi ngày bay hoặc bấm \"Lịch bay sắp tới\" để xem các ngày còn chuyến.";
            lblKhongCo.Visible = ds.Count == 0;
            flpChuyenBay.Visible = ds.Count > 0;

            var cu = ds.FirstOrDefault(c => c.MaChuyenBay == giu);
            ChonChuyen(cu);
        }

        private void ChonChuyen(ChuyenBayDTO cb)
        {
            _chuyenBay = cb;
            foreach (var t in _the) t.Selected = cb != null && t.ChuyenBay.MaChuyenBay == cb.MaChuyenBay;
            CapNhatThanhDuoi();
        }

        private void flpChuyenBay_Resize(object sender, EventArgs e)
        {
            int w = Math.Max(400, flpChuyenBay.ClientSize.Width - 24);
            foreach (var t in _the) t.Width = w;
        }

        // =========================================================
        // Bước 2: sơ đồ ghế + hành khách
        // =========================================================
        private void NapSoDoGhe()
        {
            if (_chuyenBay == null) return;
            try
            {
                var dsGhe = ChuyenBayBLL.SoDoGhe(_chuyenBay.MaChuyenBay);
                seatMap.SetData(dsGhe, _chuyenBay.BangGia);
                seatLegend.SetHangVe(dsGhe.GroupBy(g => g.MaHangVe).Select(n => (n.Key, n.First().TenHangVe)));
                CapNhatGheTrongDon();
                lblChuyenSoDo.Text = $"Chuyến #{_chuyenBay.MaChuyenBay} · {_chuyenBay.TuyenBay} · " +
                                     $"{_chuyenBay.NgayGioKhoiHanh:dd/MM/yyyy HH:mm} · {_chuyenBay.SoHieu}";
                pnlSoDo_Resize(this, EventArgs.Empty);
                HienGheDangChon();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void CapNhatGheTrongDon()
        {
            if (_chuyenBay == null) return;
            seatMap.SetInCart(_gioVe.AsEnumerable()
                .Where(r => r.Field<int>("MaChuyenBay") == _chuyenBay.MaChuyenBay)
                .Select(r => r.Field<int>("MaGhe")));
        }

        private void pnlSoDo_Resize(object sender, EventArgs e)
        {
            // Căn giữa hình máy bay theo chiều ngang
            int x = Math.Max(0, (pnlSoDo.ClientSize.Width - seatMap.Width) / 2);
            seatMap.Location = new Point(x + pnlSoDo.AutoScrollPosition.X, seatMap.Top);
        }

        private void seatMap_SeatSelected(object sender, EventArgs e)
        {
            HienGheDangChon();
        }

        private void HienGheDangChon()
        {
            GheDTO ghe = seatMap.SelectedSeat;
            if (ghe == null)
            {
                lblGheChon.Text = "Bấm vào một ghế trống trên sơ đồ";
                lblGheGia.Text = "";
            }
            else
            {
                lblGheChon.Text = $"Ghế {ghe.SoGhe}  ·  {ghe.TenHangVe}";
                decimal? gia = seatMap.GiaCuaHang(ghe.MaHangVe);
                lblGheGia.Text = gia == null ? "" : DinhDang.Tien(gia.Value);
            }
            CapNhatThanhDuoi();
        }

        private void btnKhachMoi_Click(object sender, EventArgs e)
        {
            using (var f = new frmKhachHang())
            {
                if (f.ShowDialog(FindForm()) != DialogResult.OK) return;
                try { NapKhachHang(f.MaKHKetQua); }
                catch (Exception ex) { MsgBox.Loi(ex); }
            }
        }

        private void btnThemVe_Click(object sender, EventArgs e)
        {
            try
            {
                DatVeBLL.ThemVeVaoGio(_gioVe, _chuyenBay, seatMap.SelectedSeat,
                    cboHanhKhach.SelectedValue as int?, cboHanhKhach.Text,
                    cboGiamHo.SelectedValue as int?, cboGiamHo.Text);
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
                return;
            }

            cboGiamHo.SelectedIndex = 0;
            seatMap.SelectedMaGhe = null;
            CapNhatGheTrongDon();
            HienGheDangChon();
            TuDongKhuHoi();
        }

        private void TuDongKhuHoi()
        {
            chkKhuHoi.Checked = DatVeBLL.CoKhuHoi(_gioVe);
        }

        private void btnXoaVe_Click(object sender, EventArgs e)
        {
            DataRow r = GridHelper.SelectedRow(dgvGioVe);
            if (r == null)
            {
                MsgBox.CanhBao("Chọn vé cần xóa trong danh sách \"Vé trong đơn\".");
                return;
            }
            _gioVe.Rows.Remove(r);
            TuDongKhuHoi();
            CapNhatGheTrongDon();
            CapNhatThanhDuoi();
        }

        // =========================================================
        // Bước 3: ưu đãi, tính giá, đặt vé
        // =========================================================
        private void TuyChonGia_Changed(object sender, EventArgs e)
        {
            if (_buoc == 3 && _gioVe != null && _gioVe.Rows.Count > 0) TinhGia(true);
        }

        private bool TinhGia(bool imLang)
        {
            if (_dangTinhGia || _gioVe.Rows.Count == 0) return false;
            _dangTinhGia = true;
            try
            {
                DatVeBLL.TinhGiaGioVe(_gioVe, cboKhuyenMai.SelectedValue as int?, cboLienHe.SelectedValue as int?);
                lblLoiGia.ForeColor = AppTheme.Muted;
                lblLoiGia.Text = "Giá đã gồm ưu đãi hạng thành viên, khuyến mãi và khứ hồi (cộng dồn, tối đa 30%).";
                return true;
            }
            catch (Exception ex)
            {
                lblLoiGia.ForeColor = AppTheme.BadText;
                lblLoiGia.Text = "Chưa tính được giá: " + ex.Message;
                if (!imLang) MsgBox.Loi(ex);
                return false;
            }
            finally
            {
                _dangTinhGia = false;
                CapNhatThanhDuoi();
            }
        }

        private void DatVe()
        {
            if (!TinhGia(false)) return;

            if (!MsgBox.XacNhan(NoiDungXacNhan(), "Xác nhận đặt vé", "Đặt vé", "Xem lại")) return;

            try
            {
                DataRow kq = DatVeBLL.DatVe(cboLienHe.SelectedValue as int?, _gioVe, cboKhuyenMai.SelectedValue as int?);
                int maDon = Convert.ToInt32(kq["MaDon"]);

                stepBar.StepsDone = 2;
                bool daTra = MsgBox.XacNhan($"Đã tạo đơn #{maDon} — tổng {DinhDang.Tien(kq["TongThanhToan"])}.\n" +
                                            "Đơn đang ở trạng thái Chờ thanh toán. Thanh toán ngay?", "Đặt vé thành công", "Thanh toán", "Để sau")
                             && frmThanhToan.ThanhToan(FindForm(), maDon);
                if (!daTra)
                    MsgBox.ThongTin($"Có thể thêm dịch vụ (hành lý, suất ăn...) và thanh toán đơn #{maDon} sau ở mục \"Đơn đặt vé\".");

                // Làm mới cho lần đặt tiếp theo
                _gioVe.Rows.Clear();
                chkKhuHoi.Checked = false;
                cboKhuyenMai.SelectedIndex = 0;
                _buoc = 1;
                HienChuyenBay(ChuyenBayBLL.LichBaySapToi(null, null), "Lịch bay sắp tới");
                TaiLai();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        /// <summary>Nội dung hộp xác nhận: thông tin từng vé + ưu đãi + tổng tiền.</summary>
        private string NoiDungXacNhan()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Tạo đơn gồm {_gioVe.Rows.Count} vé:");
            int i = 1;
            foreach (DataRow r in _gioVe.Rows)
            {
                sb.AppendLine();
                sb.AppendLine($"Vé {i++}: {r["Tuyen"]}  ·  {r.Field<DateTime>("NgayGioKhoiHanh"):dd/MM HH:mm}  ·  Ghế {r["SoGhe"]} ({r["HangVe"]})");
                sb.AppendLine($"   {r["HanhKhach"]}" +
                              (string.IsNullOrEmpty(r["NguoiGiamHo"] as string) ? "" : $"  (giám hộ: {r["NguoiGiamHo"]})"));
                sb.AppendLine($"   {DinhDang.Tien(r["GiaGoc"])}  −{r["PhanTramGiam"]}%  →  {DinhDang.Tien(r["GiaThucTra"])}");
            }
            sb.AppendLine();
            sb.AppendLine("Khách liên hệ: " + cboLienHe.Text);
            if (cboKhuyenMai.SelectedValue is int) sb.AppendLine("Khuyến mãi: " + cboKhuyenMai.Text);
            if (chkKhuHoi.Checked) sb.AppendLine("Ưu đãi khứ hồi: giảm 10% cho các cặp vé đi/về cùng hành khách");
            sb.Append("Tổng số tiền phải thanh toán: " + DinhDang.Tien(DatVeBLL.TongThucTra(_gioVe)));
            return sb.ToString();
        }

        private void tlpGia_Paint(object sender, PaintEventArgs e)
        {
            // Đường kẻ trước dòng tổng
            int y = tlpGia.GetRowHeights().Take(2).Sum() + 4;
            using (var p = new Pen(AppTheme.Border) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                e.Graphics.DrawLine(p, 0, y, tlpGia.Width, y);
        }

        // =========================================================
        // Điều hướng giữa các bước + thanh tổng tiền
        // =========================================================
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            if (_buoc == 1)
            {
                if (_chuyenBay == null)
                {
                    MsgBox.CanhBao("Vui lòng chọn một chuyến bay.");
                    return;
                }
                ChuyenBuoc(2);
            }
            else if (_buoc == 2)
            {
                if (_gioVe.Rows.Count == 0)
                {
                    MsgBox.CanhBao("Đơn chưa có vé nào. Chọn ghế, chọn hành khách rồi bấm \"Thêm vé vào đơn\".");
                    return;
                }
                ChuyenBuoc(3);
            }
            else
            {
                DatVe();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (_buoc > 1) ChuyenBuoc(_buoc - 1);
        }

        private void ChuyenBuoc(int buoc)
        {
            _buoc = buoc;
            pnlBuoc1.Visible = buoc == 1;
            pnlBuoc2.Visible = buoc == 2;
            pnlBuoc3.Visible = buoc == 3;
            stepBar.StepsDone = buoc - 1;
            btnQuayLai.Visible = buoc > 1;

            if (buoc == 1) btnTiepTuc.Text = "Tiếp tục: Chọn ghế";
            else if (buoc == 2) btnTiepTuc.Text = "Tiếp tục: Xác nhận";
            else btnTiepTuc.Text = "Đặt vé";
            btnTiepTuc.Kind = buoc == 3 ? ButtonKind.Accent : ButtonKind.Primary;

            if (buoc == 2) NapSoDoGhe();
            if (buoc == 3) TinhGia(true);
            CapNhatThanhDuoi();
        }

        private void CapNhatThanhDuoi()
        {
            if (_gioVe == null) return;
            decimal giaGoc = DatVeBLL.TongGiaGoc(_gioVe);
            decimal thucTra = DatVeBLL.TongThucTra(_gioVe);
            decimal giam = giaGoc - thucTra;

            lblTong.Text = DinhDang.Tien(thucTra);
            lblGiaGoc.Text = DinhDang.Tien(giaGoc);
            lblGiam.Text = giam > 0 ? "−" + DinhDang.Tien(giam) : "0 đ";
            lblTongCong.Text = DinhDang.Tien(thucTra);

            string ve = $"Đơn: {_gioVe.Rows.Count} vé";
            if (_buoc == 1)
            {
                lblTomTat.Text = _chuyenBay == null
                    ? "Chọn một chuyến bay để bắt đầu  ·  " + ve
                    : $"Đã chọn chuyến #{_chuyenBay.MaChuyenBay}  {_chuyenBay.TuyenBay}  ·  {_chuyenBay.NgayGioKhoiHanh:dd/MM HH:mm}  ·  {ve}";
            }
            else if (_buoc == 2)
            {
                GheDTO ghe = seatMap.SelectedSeat;
                lblTomTat.Text = (ghe == null ? "Chưa chọn ghế" : $"Ghế {ghe.SoGhe} · {ghe.TenHangVe}") + "  ·  " + ve +
                                 (_gioVe.Rows.Count >= 1 ? "  ·  Có thể quay lại bước 1 để thêm vé (chiều về, chuyến khác)" : "");
            }
            else
            {
                lblTomTat.Text = string.Join("   |   ", _gioVe.AsEnumerable().Select(r => $"{r["Tuyen"]} · {r["SoGhe"]}"));
            }
        }
    }
}
