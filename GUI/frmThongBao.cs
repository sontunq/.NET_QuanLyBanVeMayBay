using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public enum LoaiThongBao { ThanhCong, ThongTin, CanhBao, Loi, XacNhan }

    public partial class frmThongBao : Form
    {
        private LoaiThongBao _loai = LoaiThongBao.ThongTin;

        public frmThongBao()
        {
            InitializeComponent();
        }

        public frmThongBao(LoaiThongBao loai, string tieuDe, string noiDung, string nutOK = null, string nutHuy = null) : this()
        {
            _loai = loai;
            lblTieuDe.Text = tieuDe;
            lblNoiDung.Text = noiDung;
            if (nutOK != null) btnOK.Text = nutOK;
            if (nutHuy != null)
            {
                btnHuy.Text = nutHuy;
                btnHuy.Visible = true;
            }
            if (loai == LoaiThongBao.Loi) btnOK.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Primary;
            if (loai == LoaiThongBao.XacNhan && nutOK != null && nutOK.StartsWith("Hủy")) btnOK.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Danger;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                var cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Rectangle manHinh = Screen.FromControl(Owner ?? (Control)this).WorkingArea;

            // Nội dung dài (nhiều dòng): nới rộng hộp để bớt xuống dòng
            if (lblNoiDung.Text.Split('\n').Length > 8)
            {
                int them = Math.Min(200, Math.Max(0, manHinh.Width - Width - 80));
                Width += them;
                lblNoiDung.Width += them;
            }

            // Tự co giãn chiều cao theo độ dài nội dung
            Size sz = TextRenderer.MeasureText(lblNoiDung.Text, lblNoiDung.Font, new Size(lblNoiDung.Width, 0), TextFormatFlags.WordBreak);
            lblNoiDung.Height = Math.Max(24, sz.Height + 4);
            foreach (Control c in flpNut.Controls) c.Width = Math.Max(110, c.GetPreferredSize(Size.Empty).Width);

            // Không cho hộp cao quá màn hình: phần nội dung vượt quá thì cuộn, nút luôn hiện
            Control vungNoiDung = lblNoiDung;
            int phanCoDinh = lblNoiDung.Top + 24 + flpNut.Height + 20;   // lề trên + khoảng cách + nút + lề dưới
            int caoToiDa = manHinh.Height - 80 - phanCoDinh;
            if (lblNoiDung.Height > caoToiDa)
            {
                var pnlCuon = new Panel
                {
                    Location = lblNoiDung.Location,
                    Size = new Size(lblNoiDung.Width + SystemInformation.VerticalScrollBarWidth, caoToiDa),
                    AutoScroll = true,
                    BackColor = BackColor
                };
                Controls.Remove(lblNoiDung);
                lblNoiDung.Location = Point.Empty;
                pnlCuon.Controls.Add(lblNoiDung);
                Controls.Add(pnlCuon);
                Width += SystemInformation.VerticalScrollBarWidth;
                vungNoiDung = pnlCuon;
            }

            int top = Math.Max(picIcon.Bottom, vungNoiDung.Bottom) + 24;
            ClientSize = new Size(ClientSize.Width, top + flpNut.Height + 20);
            flpNut.Location = new Point(ClientSize.Width - flpNut.Width - 24, top);

            // Căn giữa lại sau khi đổi kích thước và giữ trọn trong màn hình
            Rectangle goc = Owner != null ? Owner.Bounds : manHinh;
            int x = goc.Left + (goc.Width - Width) / 2;
            int y = goc.Top + (goc.Height - Height) / 2;
            x = Math.Max(manHinh.Left, Math.Min(x, manHinh.Right - Width));
            y = Math.Max(manHinh.Top, Math.Min(y, manHinh.Bottom - Height));
            Location = new Point(x, y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var p = new Pen(AppTheme.Border))
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
        }

        private void picIcon_Paint(object sender, PaintEventArgs e)
        {
            Color back, fore;
            string glyph, fallback;
            switch (_loai)
            {
                case LoaiThongBao.ThanhCong: back = AppTheme.GoodBack; fore = AppTheme.GoodText; glyph = IconFont.Check; fallback = "✓"; break;
                case LoaiThongBao.CanhBao: back = AppTheme.WarnBack; fore = AppTheme.WarnText; glyph = IconFont.Warning; fallback = "!"; break;
                case LoaiThongBao.Loi: back = AppTheme.BadBack; fore = AppTheme.BadText; glyph = IconFont.Error; fallback = "×"; break;
                case LoaiThongBao.XacNhan: back = AppTheme.PrimarySoft; fore = AppTheme.Primary; glyph = IconFont.Question; fallback = "?"; break;
                default: back = AppTheme.PrimarySoft; fore = AppTheme.Primary; glyph = IconFont.Info; fallback = "i"; break;
            }
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BackColor);
            using (var b = new SolidBrush(back)) g.FillEllipse(b, 0, 0, picIcon.Width - 1, picIcon.Height - 1);
            if (IconFont.Available)
                using (var f = IconFont.Get(16F))
                    TextRenderer.DrawText(g, glyph, f, picIcon.ClientRectangle, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            else
                using (var f = new Font("Segoe UI Semibold", 18F))
                    TextRenderer.DrawText(g, fallback, f, picIcon.ClientRectangle, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmThongBao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = btnHuy.Visible ? DialogResult.Cancel : DialogResult.OK;
                Close();
            }
        }
    }
}
