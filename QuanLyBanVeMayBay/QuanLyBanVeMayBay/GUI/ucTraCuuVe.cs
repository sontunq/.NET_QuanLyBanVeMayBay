using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucTraCuuVe : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucTraCuuVe()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvKetQua);
                _daCauHinh = true;
            }
            TraCuu();
        }

        private void TraCuu()
        {
            int? maVe = DinhDang.SoNguyen(txtMaVe.Text);
            int? maCB = DinhDang.SoNguyen(txtMaChuyenBay.Text);
            if ((txtMaVe.Text.Trim().Length > 0 && maVe == null) || (txtMaChuyenBay.Text.Trim().Length > 0 && maCB == null))
            {
                MsgBox.CanhBao("Mã vé và mã chuyến bay phải là số.");
                return;
            }
            try
            {
                DataTable dt = DatVeDAL.TraCuuVe(maVe, maCB, DinhDang.RongThanhNull(txtSoGiayTo.Text));
                GridHelper.Bind(dgvKetQua, dt, "MaKH", "ThanhPhoDi", "ThanhPhoDen");
                cardKetQua.Subtitle = "· " + dt.Rows.Count + " vé" + (dt.Rows.Count > 0 ? " · nhấp đúp vào một vé để hủy" : "");
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e) => TraCuu();

        private void btnXoaLoc_Click(object sender, EventArgs e)
        {
            txtMaVe.Clear();
            txtMaChuyenBay.Clear();
            txtSoGiayTo.Clear();
            TraCuu();
        }

        private void O_Tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TraCuu();
        }

        private void HuyVeDangChon()
        {
            DataRow r = GridHelper.SelectedRow(dgvKetQua);
            if (r == null)
            {
                MsgBox.CanhBao("Chọn vé cần hủy trong danh sách.");
                return;
            }
            if (frmHuyVe.HuyVe(FindForm(), Convert.ToInt32(r["MaVe"]))) TraCuu();
        }

        private void btnHuyVe_Click(object sender, EventArgs e) => HuyVeDangChon();

        private void dgvKetQua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) HuyVeDangChon();
        }
    }
}
