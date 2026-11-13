using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucTaiKhoan : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucTaiKhoan()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvTaiKhoan);
                _daCauHinh = true;
            }
            try
            {
                GridHelper.Bind(dgvTaiKhoan, TaiKhoanBLL.LayDanhSach());
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new frmTaiKhoan())
            {
                if (f.ShowDialog(FindForm()) == DialogResult.OK) TaiLai();
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            DataRow r = GridHelper.SelectedRow(dgvTaiKhoan);
            if (r == null)
            {
                MsgBox.CanhBao("Chọn tài khoản cần khóa hoặc mở khóa.");
                return;
            }
            int maTK = r.Field<int>("MaTK");
            try
            {
                TaiKhoanBLL.KiemTraCoTheDoiTrangThai(maTK);
                string moi = TaiKhoanBLL.TrangThaiKeTiep(r["TrangThai"].ToString());
                if (!MsgBox.XacNhan($"Chuyển tài khoản {r["TenDangNhap"]} sang \"{moi}\"?")) return;
                TaiKhoanBLL.DoiTrangThai(maTK, moi);
                TaiLai();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
