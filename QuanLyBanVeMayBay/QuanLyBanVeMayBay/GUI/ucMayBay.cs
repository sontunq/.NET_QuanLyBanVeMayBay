using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucMayBay : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucMayBay()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvMayBay);
                _daCauHinh = true;
            }
            try
            {
                GridHelper.Bind(dgvMayBay, MayBayDAL.DanhSach());
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new frmMayBay())
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) TaiLai();
            }
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            DataRow r = GridHelper.SelectedRow(dgvMayBay);
            if (r == null)
            {
                MsgBox.CanhBao("Chọn máy bay cần đổi trạng thái.");
                return;
            }
            string moi = frmTrangThai.Chon(FindForm(), "Máy bay " + r["SoHieu"], r["TrangThai"].ToString(),
                "Hoạt động", "Bảo trì", "Ngừng hoạt động");
            if (moi == null) return;
            try
            {
                MayBayDAL.DoiTrangThai(r.Field<int>("MaMayBay"), moi);
                TaiLai();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
