using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace QuanLyBanVeMayBay.Utils
{
    public static class GridHelper
    {
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");

        private static readonly Dictionary<string, string> TieuDe = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["MaChuyenBay"] = "Mã CB", ["MaSanBayDi"] = "Đi", ["SanBayDi"] = "Sân bay đi", ["ThanhPhoDi"] = "Thành phố đi",
            ["MaSanBayDen"] = "Đến", ["SanBayDen"] = "Sân bay đến", ["ThanhPhoDen"] = "Thành phố đến",
            ["NgayGioKhoiHanh"] = "Khởi hành", ["NgayGioDenDuKien"] = "Đến dự kiến", ["ThoiGianBayPhut"] = "Phút bay",
            ["SoHieu"] = "Máy bay", ["TrangThai"] = "Trạng thái", ["GiaThapNhat"] = "Giá từ", ["SoGheTrong"] = "Ghế trống",
            ["MaVe"] = "Mã vé", ["MaDon"] = "Mã đơn", ["MaKH"] = "Mã KH", ["TenHanhKhach"] = "Hành khách",
            ["SoGhe"] = "Ghế", ["TenHangVe"] = "Hạng vé", ["GiaGoc"] = "Giá gốc", ["TongPhanTramGiam"] = "% giảm",
            ["PhanTramGiam"] = "% giảm", ["TienGiam"] = "Tiền giảm", ["GiaThucTra"] = "Thực trả", ["TrangThaiDon"] = "Đơn",
            ["NgayDat"] = "Ngày đặt", ["MaKHLienHe"] = "Mã KH", ["KhachHangLienHe"] = "Khách liên hệ",
            ["TongTienVe"] = "Tiền vé", ["TongTienDichVu"] = "Dịch vụ", ["TienGiamKM"] = "Giảm",
            ["TongThanhToan"] = "Tổng thanh toán", ["TongDaThu"] = "Đã thu", ["TongTienHoan"] = "Đã hoàn",
            ["HoTen"] = "Họ tên", ["SoGiayTo"] = "Số giấy tờ", ["LoaiGiayTo"] = "Loại giấy tờ", ["NgaySinh"] = "Ngày sinh",
            ["GioiTinh"] = "Giới tính", ["SoDienThoai"] = "Điện thoại", ["DiaChi"] = "Địa chỉ", ["TenHang"] = "Hạng TV",
            ["TongChiTieu"] = "Tổng chi tiêu", ["NgayGiaoDichDauTien"] = "GD đầu tiên", ["NgayKetThucThanhVien"] = "Hết hạn TV",
            ["TrangThaiThanhVien"] = "Thành viên", ["Nam"] = "Năm", ["Thang"] = "Tháng",
            ["DoanhThuThuan"] = "Doanh thu thuần", ["TongTienThu"] = "Tiền thu", ["SoDonThanhToan"] = "Số đơn",
            ["SoVeConHieuLuc"] = "Vé hiệu lực", ["DoanhThuVe"] = "Doanh thu vé", ["DoanhThuDichVu"] = "Doanh thu DV",
            ["MaMayBay"] = "Mã MB", ["HangSanXuat"] = "Hãng SX", ["LoaiMayBay"] = "Loại", ["SoLuongGhe"] = "Tổng ghế",
            ["GhePhoThong"] = "Phổ thông", ["GhePTDB"] = "PT đặc biệt", ["GheThuongGia"] = "Thương gia", ["SoChuyen"] = "Số chuyến",
            ["MaNK"] = "#", ["HanhDong"] = "Hành động", ["DoiTuong"] = "Đối tượng", ["NoiDung"] = "Nội dung",
            ["ThoiGian"] = "Thời gian", ["NguoiThucHien"] = "Người thực hiện", ["TenDichVu"] = "Dịch vụ",
            ["SoLuong"] = "SL", ["DonGia"] = "Đơn giá", ["ThanhTien"] = "Thành tiền", ["Tuyen"] = "Tuyến",
            ["HanhKhach"] = "Hành khách", ["NguoiGiamHo"] = "Giám hộ", ["HangVe"] = "Hạng vé",
            ["MaTK"] = "Mã TK", ["TenDangNhap"] = "Tên đăng nhập", ["VaiTro"] = "Vai trò", ["NgayTao"] = "Ngày tạo",
            ["NhanVien"] = "Nhân viên", ["SoDon"] = "Số đơn", ["DoanhThu"] = "Doanh thu", ["Email"] = "Email",
        };

        private static readonly Color HeaderBack = Color.White;
        private static readonly Color RowHover = Color.FromArgb(243, 248, 249);
        private static readonly Color RowSelected = Color.FromArgb(219, 236, 240);

        public static void Apply(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.RowHeadersVisible = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(237, 241, 243);
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40;
            g.RowTemplate.Height = 40;
            g.Font = AppTheme.FontBase;

            var h = g.ColumnHeadersDefaultCellStyle;
            h.BackColor = HeaderBack;
            h.ForeColor = AppTheme.Muted;
            h.SelectionBackColor = HeaderBack;
            h.SelectionForeColor = AppTheme.Muted;
            h.Font = AppTheme.FontLabel;
            h.Padding = new Padding(6, 0, 6, 0);

            var c = g.DefaultCellStyle;
            c.BackColor = Color.White;
            c.ForeColor = AppTheme.Text;
            c.SelectionBackColor = RowSelected;
            c.SelectionForeColor = AppTheme.Text;
            c.Padding = new Padding(6, 0, 6, 0);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(g, true);

            g.DataBindingComplete += (s, e) => FormatColumns(g);
            g.CellPainting += Grid_CellPainting;
            g.CellMouseEnter += (s, e) => SetHover(g, e.RowIndex, true);
            g.CellMouseLeave += (s, e) => SetHover(g, e.RowIndex, false);
            g.DataError += (s, e) => e.ThrowException = false;
            g.Paint += Grid_PaintEmpty;
        }

        public static void Bind(DataGridView g, DataTable dt, params string[] cotAn)
        {
            g.Tag = new HashSet<string>(cotAn, StringComparer.OrdinalIgnoreCase);
            g.DataSource = dt;
            FormatColumns(g);
        }

        public static DataRow SelectedRow(DataGridView g)
        {
            return (g.CurrentRow?.DataBoundItem as DataRowView)?.Row;
        }

        public static void SelectRow(DataGridView g, string cot, object giaTri)
        {
            if (giaTri == null || !g.Columns.Contains(cot)) return;
            var cotHien = g.Columns.Cast<DataGridViewColumn>().FirstOrDefault(x => x.Visible);
            if (cotHien == null) return;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (Equals(row.Cells[cot].Value, giaTri))
                {
                    g.CurrentCell = row.Cells[cotHien.Index];
                    return;
                }
            }
        }

        private static void FormatColumns(DataGridView g)
        {
            var an = g.Tag as HashSet<string>;
            foreach (DataGridViewColumn col in g.Columns)
            {
                string key = string.IsNullOrEmpty(col.DataPropertyName) ? col.Name : col.DataPropertyName;
                string tieuDe;
                col.HeaderText = (TieuDe.TryGetValue(key, out tieuDe) ? tieuDe : col.HeaderText).ToUpper(Vi);
                col.MinimumWidth = 60;
                if (an != null && an.Contains(key)) col.Visible = false;

                if (col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.FormatProvider = Vi;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Font = AppTheme.FontBold;
                }
                else if (col.ValueType == typeof(DateTime))
                {
                    col.DefaultCellStyle.Format = key.IndexOf("NgaySinh", StringComparison.OrdinalIgnoreCase) >= 0 ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                }
                else if (col.ValueType == typeof(int) && key.StartsWith("Ma", StringComparison.OrdinalIgnoreCase))
                {
                    col.FillWeight = 55;
                }
            }
        }

        private static bool IsStatusColumn(DataGridView g, int col)
        {
            if (col < 0) return false;
            string name = g.Columns[col].DataPropertyName ?? "";
            return name.StartsWith("TrangThai", StringComparison.OrdinalIgnoreCase);
        }

        private static void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var g = (DataGridView)sender;
            if (e.RowIndex < 0 || !IsStatusColumn(g, e.ColumnIndex) || e.Value == null || e.Value == DBNull.Value) return;

            e.PaintBackground(e.CellBounds, true);
            string text = e.Value.ToString();
            Color back, fore;
            AppTheme.StatusColors(text, out back, out fore);

            var font = AppTheme.FontLabel;
            Size sz = TextRenderer.MeasureText(text, font);
            var pill = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                                     Math.Min(sz.Width + 16, e.CellBounds.Width - 12), 24);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = AppTheme.RoundedRect(pill, 12))
            using (var b = new SolidBrush(back))
                e.Graphics.FillPath(b, path);
            TextRenderer.DrawText(e.Graphics, text, font, pill, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private static void SetHover(DataGridView g, int row, bool on)
        {
            if (row < 0 || row >= g.Rows.Count) return;
            g.Rows[row].DefaultCellStyle.BackColor = on ? RowHover : Color.White;
        }

        private static void Grid_PaintEmpty(object sender, PaintEventArgs e)
        {
            var g = (DataGridView)sender;
            if (g.Rows.Count > 0 || g.Columns.Count == 0) return;
            var r = new Rectangle(0, g.ColumnHeadersHeight, g.Width, Math.Max(60, g.Height - g.ColumnHeadersHeight));
            TextRenderer.DrawText(e.Graphics, "Không có dữ liệu", AppTheme.FontBase, r, AppTheme.Muted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
