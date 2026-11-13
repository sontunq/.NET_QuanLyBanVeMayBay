using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucChuyenBay : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucChuyenBay()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvChuyenBay);
                GridHelper.Apply(dgvHanhKhach);
                cboHienThi.SelectedIndex = 0;
                btnTao.Visible = PhienDangNhap.LaAdmin;
                btnTrangThai.Visible = PhienDangNhap.LaAdmin;
                _daCauHinh = true;
            }
            NapChuyenBay();
        }

        private int? MaCBDangChon => GridHelper.SelectedRow(dgvChuyenBay)?.Field<int>("MaChuyenBay");

        private void NapChuyenBay()
        {
            int? giu = MaCBDangChon;
            try
            {
                DataTable dt = ChuyenBayDAL.DanhSach(cboHienThi.SelectedIndex == 0);
                GridHelper.Bind(dgvChuyenBay, dt, "SanBayDi", "SanBayDen");
                cardChuyenBay.Subtitle = "· " + dt.Rows.Count + " chuyến";
                GridHelper.SelectRow(dgvChuyenBay, "MaChuyenBay", giu);
                NapHanhKhach();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void NapHanhKhach()
        {
            int? ma = MaCBDangChon;
            if (ma == null)
            {
                dgvHanhKhach.DataSource = null;
                cardHanhKhach.Subtitle = "";
                return;
            }
            try
            {
                DataTable dt = ChuyenBayDAL.HanhKhach(ma.Value);
                GridHelper.Bind(dgvHanhKhach, dt);
                cardHanhKhach.Subtitle = $"· chuyến #{ma} · {dt.Rows.Count} vé";
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void dgvChuyenBay_SelectionChanged(object sender, EventArgs e) => NapHanhKhach();
        private void cboHienThi_SelectedIndexChanged(object sender, EventArgs e) { if (_daCauHinh) NapChuyenBay(); }
        private void btnLamMoi_Click(object sender, EventArgs e) => NapChuyenBay();

        private void btnTao_Click(object sender, EventArgs e)
        {
            using (var f = new frmChuyenBay())
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) NapChuyenBay();
            }
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            DataRow r = GridHelper.SelectedRow(dgvChuyenBay);
            if (r == null)
            {
                MsgBox.CanhBao("Chọn chuyến bay cần đổi trạng thái.");
                return;
            }
            string moi = frmTrangThai.Chon(FindForm(), "Chuyến bay #" + r["MaChuyenBay"], r["TrangThai"].ToString(),
                "Đang mở bán", "Đã đóng", "Đã bay", "Đã hủy");
            if (moi == null) return;
            try
            {
                ChuyenBayDAL.DoiTrangThai(r.Field<int>("MaChuyenBay"), moi);
                NapChuyenBay();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
