using System.Data;
using System.Globalization;
using QRCoder;
using QuanLyBanVeMayBay.Controls;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmThanhToan : Form
    {
        private const int Left0 = 28, W = 424, TopChiTiet = 340, CotPhaiX = 480;

        private readonly int _maDon;
        private decimal _tongTien;
        private string _phuongThuc = ThanhToanBLL.TienMat;

        // Khung chi tiết cho từng phương thức (tạo trong code)
        private Panel pnlTienMat, pnlChuyenKhoan, pnlThe;
        private TextBox txtKhachDua, txtSoThe, txtChuThe, txtHetHan, txtCvv;
        private Label lblTienThoi, lblLoaiThe;
        private CheckBox chkDaNhanTien;
        private PictureBox picQR, picThe;

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private frmThanhToan(int maDon, DataRow don) : this()
        {
            _maDon = maDon;
            // Số tiền cần thu = tổng đơn − (đã thu − đã hoàn). Đơn đã thanh toán chỉ còn phần dịch vụ thêm sau.
            _tongTien = Convert.ToDecimal(don["ConPhaiThu"]);
            bool thuThem = don["TrangThai"].ToString() == DatVeBLL.DaThanhToan;
            lblNhan.Text = (thuThem ? "THU THÊM DỊCH VỤ · ĐƠN #" : "THANH TOÁN ĐƠN #") + maDon;
            lblSoTien.Text = DinhDang.Tien(_tongTien);
            lblMoTa.Text = $"{don["SoVe"]} vé  ·  Khách liên hệ: {don["KhachHangLienHe"]}" +
                           (thuThem ? $"  ·  Đã thu {DinhDang.Tien(Convert.ToDecimal(don["DaThu"]) - Convert.ToDecimal(don["DaHoan"]))}" : "");
            lblTienVeGiaTri.Text = DinhDang.Tien(don["TongTienVe"]);
            lblDichVuGiaTri.Text = DinhDang.Tien(don["TongTienDichVu"]);
            decimal giam = don["TienGiamKM"] == DBNull.Value ? 0 : Convert.ToDecimal(don["TienGiamKM"]);
            lblGiamGiaTri.Text = giam > 0 ? "−" + DinhDang.Tien(giam) : "0 đ";

            TaoKhungTienMat();
            TaoKhungChuyenKhoan();
            TaoKhungThe();
            BoTri();
        }

        public static bool ThanhToan(IWin32Window owner, int maDon)
        {
            try
            {
                DataRow don = DatVeBLL.LayDonDeThanhToan(maDon);
                using (var f = new frmThanhToan(maDon, don))
                    return f.ShowDialog(owner) == DialogResult.OK;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
                return false;
            }
        }

        private void PhuongThuc_Click(object sender, EventArgs e)
        {
            foreach (RoundedButton b in flpPhuongThuc.Controls)
                b.Kind = b == sender ? ButtonKind.Primary : ButtonKind.Outline;
            _phuongThuc = ((Button)sender).Text;
            BoTri();
        }

        // =========================================================
        // Bố trí: chỉ hiện khung của phương thức đang chọn, đẩy phần dưới xuống theo chiều cao khung
        // =========================================================
        private void BoTri()
        {
            if (pnlTienMat == null) return;
            Panel hien = _phuongThuc == ThanhToanBLL.ChuyenKhoan ? pnlChuyenKhoan
                       : _phuongThuc == ThanhToanBLL.The ? pnlThe : pnlTienMat;
            foreach (var p in new[] { pnlTienMat, pnlChuyenKhoan, pnlThe }) p.Visible = p == hien;

            // Chuyển khoản và thẻ: khung chi tiết nằm ở cột bên phải (form rộng ra) để cửa sổ không quá cao
            bool ben = hien == pnlChuyenKhoan || hien == pnlThe;
            int y = ben ? TopChiTiet : TopChiTiet + hien.Height + 12;
            hien.Location = ben ? new Point(CotPhaiX + 24, 24) : new Point(Left0, TopChiTiet);
            lblGhiChu.Top = y;
            ipGhiChu.Top = y + 22;
            lblLuuY.Top = y + 76;
            btnHuy.Top = btnXacNhan.Top = y + 126;
            int cao = Math.Max(y + 126 + 44 + 22, ben ? hien.Bottom + 22 : 0);
            ClientSize = new Size(ben ? CotPhaiX + 24 + hien.Width + 24 : CotPhaiX, cao);
            pnlHeader.Width = CotPhaiX;
            pnlHeader.Dock = ben ? DockStyle.None : DockStyle.Top;

            btnXacNhan.Text = _phuongThuc == ThanhToanBLL.ChuyenKhoan ? "Xác nhận đã nhận tiền"
                            : _phuongThuc == ThanhToanBLL.The ? "Thanh toán bằng thẻ"
                            : "Xác nhận đã thu tiền";
            if (_phuongThuc == ThanhToanBLL.TienMat) txtKhachDua.Focus();
            else if (_phuongThuc == ThanhToanBLL.The) txtSoThe.Focus();
        }

        // =========================================================
        // Tiền mặt: nhập tiền khách đưa, tự tính tiền thối
        // =========================================================
        private void TaoKhungTienMat()
        {
            pnlTienMat = TaoKhung(76);
            pnlTienMat.Controls.Add(TaoNhan("TIỀN KHÁCH ĐƯA", 0, 0));
            var ip = TaoO(0, 20, 200, out txtKhachDua, 14);
            txtKhachDua.PlaceholderText = DinhDang.Tien(_tongTien);
            txtKhachDua.TextAlign = HorizontalAlignment.Right;
            txtKhachDua.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };
            txtKhachDua.TextChanged += (s, e) => { DinhDangSoTien(txtKhachDua); CapNhatTienThoi(); };
            pnlTienMat.Controls.Add(ip);

            lblTienThoi = new Label
            {
                Location = new Point(216, 20), Size = new Size(W - 216, 42),
                TextAlign = ContentAlignment.MiddleRight, Font = AppTheme.FontBold, ForeColor = AppTheme.Muted,
            };
            pnlTienMat.Controls.Add(lblTienThoi);
            CapNhatTienThoi();
        }

        private decimal? TienKhachDua()
        {
            string so = new string(txtKhachDua.Text.Where(char.IsDigit).ToArray());
            return decimal.TryParse(so, out decimal v) ? v : (decimal?)null;
        }

        private void CapNhatTienThoi()
        {
            decimal? dua = TienKhachDua();
            if (dua == null) { lblTienThoi.Text = "Tiền thối: —"; lblTienThoi.ForeColor = AppTheme.Muted; }
            else if (dua < _tongTien) { lblTienThoi.Text = "Còn thiếu " + DinhDang.Tien(_tongTien - dua.Value); lblTienThoi.ForeColor = AppTheme.Danger; }
            else { lblTienThoi.Text = "Tiền thối: " + DinhDang.Tien(dua.Value - _tongTien); lblTienThoi.ForeColor = AppTheme.GoodText; }
        }

        private static void DinhDangSoTien(TextBox t)
        {
            string so = new string(t.Text.Where(char.IsDigit).ToArray()).TrimStart('0');
            string moi = so.Length == 0 ? "" : decimal.Parse(so).ToString("N0", new CultureInfo("vi-VN"));
            if (moi != t.Text) { t.Text = moi; t.SelectionStart = t.Text.Length; }
        }

        // =========================================================
        // Chuyển khoản: mã VietQR + thông tin tài khoản nhận
        // =========================================================
        private void TaoKhungChuyenKhoan()
        {
            const int rong = 260, qr = 220;
            pnlChuyenKhoan = TaoKhung(0);
            pnlChuyenKhoan.Width = rong;
            pnlChuyenKhoan.BackColor = AppTheme.Background;
            string noiDung = ThanhToanBLL.NoiDungChuyenKhoan(_maDon);

            var tieuDe = TaoNhan("QUÉT MÃ BẰNG APP NGÂN HÀNG", 0, 12);
            tieuDe.AutoSize = false;
            tieuDe.Size = new Size(rong, 16);
            tieuDe.TextAlign = ContentAlignment.MiddleCenter;
            pnlChuyenKhoan.Controls.Add(tieuDe);

            picQR = new PictureBox
            {
                Location = new Point((rong - qr) / 2, 36), Size = new Size(qr, qr),
                SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.White,
            };
            try
            {
                string payload = ThanhToanBLL.ChuoiVietQR(_tongTien, noiDung);
                using (var gen = new QRCodeGenerator())
                using (QRCodeData data = gen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.M))
                {
                    byte[] png = new PngByteQRCode(data).GetGraphic(8);
                    using (var ms = new MemoryStream(png))
                        picQR.Image = new Bitmap(Image.FromStream(ms));
                }
            }
            catch (Exception ex)
            {
                picQR.Image = null;
                pnlChuyenKhoan.Controls.Add(new Label { Text = "Không tạo được mã QR: " + ex.Message, Location = new Point(30, 120), Size = new Size(200, 60) });
            }
            pnlChuyenKhoan.Controls.Add(picQR);

            int x = 16, y = 36 + qr + 14;
            void Dong(string nhan, string giaTri, bool noiBat = false)
            {
                pnlChuyenKhoan.Controls.Add(TaoNhan(nhan, x, y));
                pnlChuyenKhoan.Controls.Add(new Label
                {
                    Text = giaTri, Location = new Point(x, y + 15), Size = new Size(rong - 2 * x, 20), AutoEllipsis = true,
                    Font = noiBat ? AppTheme.FontBold : AppTheme.FontBase,
                    ForeColor = noiBat ? AppTheme.Primary : AppTheme.Text,
                });
                y += 38;
            }
            Dong("NGÂN HÀNG", TaiKhoanNhanTien.TenNganHang);
            Dong("SỐ TÀI KHOẢN", TaiKhoanNhanTien.SoTaiKhoan, true);
            Dong("CHỦ TÀI KHOẢN", TaiKhoanNhanTien.ChuTaiKhoan);
            Dong("SỐ TIỀN", DinhDang.Tien(_tongTien), true);
            Dong("NỘI DUNG CHUYỂN KHOẢN", noiDung, true);

            if (TaiKhoanNhanTien.LaTaiKhoanMau)
            {
                pnlChuyenKhoan.Controls.Add(new Label
                {
                    Text = "Tài khoản mẫu (demo), không chuyển tiền thật.",
                    Location = new Point(x, y), Size = new Size(rong - 2 * x, 18), AutoEllipsis = true,
                    Font = AppTheme.FontSmall, ForeColor = AppTheme.WarnText,
                });
                y += 22;
            }

            chkDaNhanTien = new CheckBox
            {
                Text = $"Đã kiểm tra: tài khoản đã nhận đủ {DinhDang.Tien(_tongTien)}, nội dung {noiDung}",
                Location = new Point(x, y), Size = new Size(rong - 2 * x, 40), AutoSize = false,
                Font = AppTheme.FontSmall, ForeColor = AppTheme.Text, CheckAlign = ContentAlignment.TopLeft,
                TextAlign = ContentAlignment.TopLeft,
            };
            pnlChuyenKhoan.Controls.Add(chkDaNhanTien);
            pnlChuyenKhoan.Height = y + 40 + 12;
        }

        // =========================================================
        // Thẻ: số thẻ, chủ thẻ, hạn, CVV (chỉ lưu loại thẻ + 4 số cuối)
        // =========================================================
        private void TaoKhungThe()
        {
            const int rong = 260, x = 16, w = rong - 2 * x;
            pnlThe = TaoKhung(0);
            pnlThe.Width = rong;
            pnlThe.BackColor = AppTheme.Background;

            var tieuDe = TaoNhan("THÔNG TIN THẺ", 0, 12);
            tieuDe.AutoSize = false;
            tieuDe.Size = new Size(rong, 16);
            tieuDe.TextAlign = ContentAlignment.MiddleCenter;
            pnlThe.Controls.Add(tieuDe);

            // Hình thẻ xem trước, cập nhật theo nội dung đang nhập
            picThe = new PictureBox { Location = new Point(x, 36), Size = new Size(w, 140), BackColor = AppTheme.Background };
            picThe.Paint += VeTheXemTruoc;
            pnlThe.Controls.Add(picThe);

            int y = 190;
            pnlThe.Controls.Add(TaoNhan("SỐ THẺ", x, y));
            lblLoaiThe = new Label
            {
                Location = new Point(x + w - 120, y), Size = new Size(120, 16), TextAlign = ContentAlignment.MiddleRight,
                Font = AppTheme.FontLabel, ForeColor = AppTheme.Primary,
            };
            pnlThe.Controls.Add(lblLoaiThe);
            pnlThe.Controls.Add(TaoO(x, y + 18, w, out txtSoThe, 23));
            txtSoThe.PlaceholderText = "1234 5678 9012 3456";
            txtSoThe.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ') e.Handled = true; };
            txtSoThe.TextChanged += (s, e) =>
            {
                string so = new string(txtSoThe.Text.Where(char.IsDigit).ToArray());
                string moi = string.Join(" ", Enumerable.Range(0, (so.Length + 3) / 4).Select(i => so.Substring(i * 4, Math.Min(4, so.Length - i * 4))));
                if (moi != txtSoThe.Text) { txtSoThe.Text = moi; txtSoThe.SelectionStart = moi.Length; }
                lblLoaiThe.Text = so.Length >= 2 ? (ThanhToanBLL.LoaiThe(so) ?? "Không hỗ trợ") : "";
                picThe.Invalidate();
            };

            y += 68;
            pnlThe.Controls.Add(TaoNhan("TÊN CHỦ THẺ (IN HOA, KHÔNG DẤU)", x, y));
            pnlThe.Controls.Add(TaoO(x, y + 18, w, out txtChuThe, 26));
            txtChuThe.CharacterCasing = CharacterCasing.Upper;
            txtChuThe.PlaceholderText = "NGUYEN VAN AN";
            txtChuThe.TextChanged += (s, e) => picThe.Invalidate();

            y += 68;
            int nua = (w - 12) / 2;
            pnlThe.Controls.Add(TaoNhan("HẾT HẠN (MM/YY)", x, y));
            pnlThe.Controls.Add(TaoO(x, y + 18, nua, out txtHetHan, 5));
            txtHetHan.PlaceholderText = "08/28";
            txtHetHan.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };
            txtHetHan.TextChanged += (s, e) =>
            {
                string so = new string(txtHetHan.Text.Where(char.IsDigit).ToArray());
                string moi = so.Length > 2 ? so.Substring(0, 2) + "/" + so.Substring(2, Math.Min(2, so.Length - 2)) : so;
                if (moi != txtHetHan.Text) { txtHetHan.Text = moi; txtHetHan.SelectionStart = moi.Length; }
                picThe.Invalidate();
            };

            pnlThe.Controls.Add(TaoNhan("CVV / CVC", x + nua + 12, y));
            pnlThe.Controls.Add(TaoO(x + nua + 12, y + 18, nua, out txtCvv, 4));
            txtCvv.UseSystemPasswordChar = true;
            txtCvv.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };

            y += 70;
            pnlThe.Controls.Add(new Label
            {
                Text = "Chỉ lưu loại thẻ và 4 số cuối, không lưu CVV.",
                Location = new Point(x, y), Size = new Size(w, 34),
                Font = AppTheme.FontSmall, ForeColor = AppTheme.Muted,
            });
            pnlThe.Height = y + 34 + 12;
        }

        private void VeTheXemTruoc(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var r = new Rectangle(0, 0, picThe.Width - 1, picThe.Height - 1);
            using (var path = AppTheme.RoundedRect(r, 12))
            using (var b = new System.Drawing.Drawing2D.LinearGradientBrush(r, AppTheme.Primary, AppTheme.PrimaryDark, 35f))
                g.FillPath(b, path);

            // Chip
            using (var path = AppTheme.RoundedRect(new Rectangle(16, 40, 34, 26), 5))
            using (var b = new SolidBrush(AppTheme.Accent))
                g.FillPath(b, path);

            string so = new string((txtSoThe?.Text ?? "").Where(char.IsDigit).ToArray());
            string loai = so.Length >= 2 ? ThanhToanBLL.LoaiThe(so) : null;
            string hien = (so + new string('•', Math.Max(0, 16 - so.Length)));
            hien = string.Join(" ", Enumerable.Range(0, (hien.Length + 3) / 4).Select(i => hien.Substring(i * 4, Math.Min(4, hien.Length - i * 4))));

            var trang = Color.White;
            var mo = Color.FromArgb(190, 225, 232);
            TextRenderer.DrawText(g, loai ?? "", AppTheme.FontBold, new Rectangle(0, 12, r.Width - 16, 20), trang,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            using (var f = new Font("Consolas", 12F, FontStyle.Bold))
                TextRenderer.DrawText(g, hien, f, new Rectangle(16, 74, r.Width - 24, 24), trang,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            string ten = string.IsNullOrWhiteSpace(txtChuThe?.Text) ? "TÊN CHỦ THẺ" : txtChuThe.Text.Trim();
            string han = string.IsNullOrWhiteSpace(txtHetHan?.Text) ? "MM/YY" : txtHetHan.Text;
            TextRenderer.DrawText(g, ten, AppTheme.FontSmall, new Rectangle(16, 106, r.Width - 90, 20), trang,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            TextRenderer.DrawText(g, han, AppTheme.FontSmall, new Rectangle(r.Width - 70, 106, 54, 20), mo,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
        }

        // =========================================================
        // Xác nhận
        // =========================================================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string chiTiet, thongBao;
                if (_phuongThuc == ThanhToanBLL.ChuyenKhoan)
                {
                    ThanhToanBLL.KiemTraChuyenKhoan(chkDaNhanTien.Checked);
                    string nd = ThanhToanBLL.NoiDungChuyenKhoan(_maDon);
                    chiTiet = $"CK {TaiKhoanNhanTien.TenNganHang} {TaiKhoanNhanTien.SoTaiKhoan}, nội dung {nd}";
                    thongBao = $"Đã ghi nhận chuyển khoản {DinhDang.Tien(_tongTien)} (nội dung {nd}) cho đơn #{_maDon}.";
                }
                else if (_phuongThuc == ThanhToanBLL.The)
                {
                    ThongTinThe the = ThanhToanBLL.KiemTraThe(txtSoThe.Text, txtChuThe.Text, txtHetHan.Text, txtCvv.Text);
                    chiTiet = $"Thẻ {the.LoaiThe} ****{the.BonSoCuoi}, chủ thẻ {the.ChuThe}";
                    thongBao = $"Đã thanh toán {DinhDang.Tien(_tongTien)} bằng thẻ {the.LoaiThe} ****{the.BonSoCuoi} cho đơn #{_maDon}.";
                }
                else
                {
                    decimal thoi = ThanhToanBLL.TienThoi(_tongTien, TienKhachDua());
                    chiTiet = $"Khách đưa {DinhDang.Tien(TienKhachDua().Value)}, thối {DinhDang.Tien(thoi)}";
                    thongBao = $"Đã thu {DinhDang.Tien(_tongTien)} tiền mặt cho đơn #{_maDon}." +
                               (thoi > 0 ? $"\nTiền thối lại cho khách: {DinhDang.Tien(thoi)}" : "");
                }

                if (_phuongThuc == ThanhToanBLL.The &&
                    !MsgBox.XacNhan($"Trừ {DinhDang.Tien(_tongTien)} từ thẻ này?", "Xác nhận thanh toán thẻ", "Thanh toán", "Không"))
                    return;

                DatVeBLL.ThanhToan(_maDon, _tongTien, _phuongThuc, ThanhToanBLL.GhepGhiChu(chiTiet, txtGhiChu.Text));
                MsgBox.ThanhCong(thongBao, "Thanh toán thành công");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            picQR?.Image?.Dispose();
            base.OnFormClosed(e);
        }

        // =========================================================
        // Tiện ích tạo control
        // =========================================================
        private Panel TaoKhung(int cao)
        {
            var p = new Panel { Size = new Size(W, cao), BackColor = Color.White, Visible = false };
            Controls.Add(p);
            return p;
        }

        private static Label TaoNhan(string text, int x, int y) => new Label
        {
            Text = text, Location = new Point(x, y), AutoSize = true,
            Font = AppTheme.FontLabel, ForeColor = AppTheme.Muted,
        };

        private static InputBox TaoO(int x, int y, int w, out TextBox txt, int maxLength)
        {
            var ip = new InputBox { Location = new Point(x, y), Size = new Size(w, 42) };
            txt = new TextBox { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill, MaxLength = maxLength };
            ip.Controls.Add(txt);
            return ip;
        }
    }
}
