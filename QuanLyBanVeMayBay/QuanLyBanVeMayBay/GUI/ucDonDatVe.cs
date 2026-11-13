using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucDonDatVe : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucDonDatVe()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvDon);
                GridHelper.Apply(dgvVe);
                GridHelper.Apply(dgvDichVu);
                cboTrangThai.SelectedIndex = 0;
                _daCauHinh = true;
            }
            NapDon();
        }

        private int? MaDonDangChon => GridHelper.SelectedRow(dgvDon)?.Field<int>("MaDon");

        private void NapDon()
        {
            int? giu = MaDonDangChon;
            try
            {
                string tt = cboTrangThai.SelectedIndex > 0 ? cboTrangThai.Text : null;
                DataTable dt = DatVeBLL.DanhSachDon(tt, txtTim.Text);
                GridHelper.Bind(dgvDon, dt, "MaKHLienHe");
                cardDon.Subtitle = "· " + dt.Rows.Count + " đơn";
                GridHelper.SelectRow(dgvDon, "MaDon", giu);
                NapChiTiet();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void NapChiTiet()
        {
            int? maDon = MaDonDangChon;
            if (maDon == null)
            {
                dgvVe.DataSource = null;
                dgvDichVu.DataSource = null;
                cardVe.Subtitle = "";
                return;
            }
            try
            {
                GridHelper.Bind(dgvVe, DatVeBLL.VeTrongDon(maDon.Value), "MaChuyenBay", "GiaGoc");
                GridHelper.Bind(dgvDichVu, DatVeBLL.DichVuTrongDon(maDon.Value));
                cardVe.Subtitle = "· đơn #" + maDon;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void dgvDon_SelectionChanged(object sender, EventArgs e) => NapChiTiet();
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { if (_daCauHinh) NapDon(); }
        private void btnLoc_Click(object sender, EventArgs e) => NapDon();

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            NapDon();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            int? maDon = MaDonDangChon;
            DataRow ve = GridHelper.SelectedRow(dgvVe);
            if (maDon == null || ve == null)
            {
                MsgBox.CanhBao("Chọn một đơn, sau đó chọn vé cần thêm dịch vụ ở bảng \"Vé trong đơn\".");
                return;
            }
            using (var f = new frmThemDichVu(maDon.Value, ve.Field<int>("MaVe"), ve["TenHanhKhach"].ToString()))
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) NapDon();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int? maDon = MaDonDangChon;
            if (maDon == null)
            {
                MsgBox.CanhBao("Chọn đơn cần thanh toán.");
                return;
            }
            if (frmThanhToan.ThanhToan(FindForm(), maDon.Value)) NapDon();
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            DataRow ve = GridHelper.SelectedRow(dgvVe);
            if (ve == null)
            {
                MsgBox.CanhBao("Chọn vé cần hủy ở bảng \"Vé trong đơn\".");
                return;
            }
            if (frmHuyVe.HuyVe(FindForm(), ve.Field<int>("MaVe"))) NapDon();
        }
    }
}
