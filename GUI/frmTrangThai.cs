namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmTrangThai : Form
    {
        public frmTrangThai()
        {
            InitializeComponent();
        }

        public static string Chon(IWin32Window owner, string tieuDe, string hienTai, params string[] luaChon)
        {
            using (var f = new frmTrangThai())
            {
                f.lblTieuDe.Text = tieuDe;
                f.cboTrangThai.Items.AddRange(luaChon);
                f.cboTrangThai.SelectedItem = hienTai;
                if (f.cboTrangThai.SelectedIndex < 0) f.cboTrangThai.SelectedIndex = 0;
                return f.ShowDialog(owner) == DialogResult.OK ? f.cboTrangThai.Text : null;
            }
        }
    }
}
