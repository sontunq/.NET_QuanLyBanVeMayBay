using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucNhatKy : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucNhatKy()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvNhatKy);
                _daCauHinh = true;
            }
            try
            {
                GridHelper.Bind(dgvNhatKy, TaiKhoanBLL.LayNhatKy());
                if (dgvNhatKy.Columns.Contains("NoiDung")) dgvNhatKy.Columns["NoiDung"].FillWeight = 260;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => TaiLai();
    }
}
