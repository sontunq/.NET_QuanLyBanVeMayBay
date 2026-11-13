using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;
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
                GridHelper.Bind(dgvTaiKhoan, TaiKhoanDAL.LayDanhSach());
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
            if (maTK == PhienDangNhap.MaTK)
            {
                MsgBox.CanhBao("Không thể tự khóa tài khoản đang đăng nhập.");
                return;
            }
            string moi = r["TrangThai"].ToString() == "Hoạt động" ? "Bị khóa" : "Hoạt động";
            if (!MsgBox.XacNhan($"Chuyển tài khoản {r["TenDangNhap"]} sang \"{moi}\"?")) return;
            try
            {
                TaiKhoanDAL.DoiTrangThai(maTK, moi);
                TaiLai();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
