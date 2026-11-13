using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucKhachHang : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucKhachHang()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvKhachHang);
                GridHelper.Apply(dgvLichSu);
                _daCauHinh = true;
            }
            NapKhachHang();
        }

        private int? MaKHDangChon => GridHelper.SelectedRow(dgvKhachHang)?.Field<int>("MaKH");

        private void NapKhachHang(int? chon = null)
        {
            int? giu = chon ?? MaKHDangChon;
            try
            {
                DataTable dt = KhachHangBLL.DanhSach(txtTim.Text);
                GridHelper.Bind(dgvKhachHang, dt, "Email", "NgayGiaoDichDauTien");
                GridHelper.SelectRow(dgvKhachHang, "MaKH", giu);
                NapLichSu();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void NapLichSu()
        {
            DataRow kh = GridHelper.SelectedRow(dgvKhachHang);
            if (kh == null)
            {
                dgvLichSu.DataSource = null;
                cardLichSu.Subtitle = "";
                return;
            }
            try
            {
                DataTable dt = DatVeBLL.VeCuaKhach(kh.Field<int>("MaKH"));
                GridHelper.Bind(dgvLichSu, dt);
                cardLichSu.Subtitle = $"· {kh["HoTen"]} · {dt.Rows.Count} vé";
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e) => NapLichSu();
        private void btnTim_Click(object sender, EventArgs e) => NapKhachHang();

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            NapKhachHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new frmKhachHang())
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) NapKhachHang(f.MaKHKetQua);
            }
        }

        private void Sua()
        {
            int? ma = MaKHDangChon;
            if (ma == null)
            {
                MsgBox.CanhBao("Chọn khách hàng cần sửa.");
                return;
            }
            using (var f = new frmKhachHang(ma))
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) NapKhachHang(ma);
            }
        }

        private void btnSua_Click(object sender, EventArgs e) => Sua();

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Sua();
        }

        private void btnXetHang_Click(object sender, EventArgs e)
        {
            int? ma = MaKHDangChon;
            if (ma == null)
            {
                MsgBox.CanhBao("Chọn khách hàng cần xét hạng.");
                return;
            }
            try
            {
                DataRow r = KhachHangBLL.XetHang(ma.Value);
                MsgBox.ThongTin($"Hạng hiện tại: {r["TenHang"]} (giảm {r["PhanTramGiam"]}%)\nTổng chi tiêu: {DinhDang.Tien(r["TongChiTieu"])}",
                    r["HoTen"].ToString());
                NapKhachHang(ma);
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
