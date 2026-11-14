using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmKhachHang : Form
    {
        private readonly int? _maKH;

        public int MaKHKetQua { get; private set; }

        public frmKhachHang() : this(null) { }

        public frmKhachHang(int? maKH)
        {
            InitializeComponent();
            _maKH = maKH;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            cboLoaiGiayTo.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.MaxDate = DateTime.Today;
            dtpNgaySinh.Value = new DateTime(1995, 1, 1);

            if (_maKH == null) return;

            lblTieuDe.Text = "Sửa khách hàng #" + _maKH;
            try
            {
                DataRow r = KhachHangBLL.Lay(_maKH.Value);
                if (r == null) return;
                txtHoTen.Text = r["HoTen"].ToString();
                cboLoaiGiayTo.SelectedItem = r["LoaiGiayTo"].ToString();
                txtSoGiayTo.Text = r["SoGiayTo"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
                cboGioiTinh.SelectedItem = r["GioiTinh"].ToString();
                txtSoDienThoai.Text = r["SoDienThoai"].ToString();
                txtEmail.Text = r["Email"].ToString();
                txtDiaChi.Text = r["DiaChi"].ToString();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                MaKHKetQua = KhachHangBLL.Luu(_maKH, txtHoTen.Text, cboLoaiGiayTo.Text, txtSoGiayTo.Text, dtpNgaySinh.Value,
                    cboGioiTinh.Text, txtSoDienThoai.Text, txtEmail.Text, txtDiaChi.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
