using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmChuyenBay : Form
    {
        public frmChuyenBay()
        {
            InitializeComponent();
        }

        private void frmChuyenBay_Load(object sender, EventArgs e)
        {
            try
            {
                GanCombo(cboMayBay, DanhMucBLL.MayBay());
                GanCombo(cboSanBayDi, DanhMucBLL.SanBay());
                GanCombo(cboSanBayDen, DanhMucBLL.SanBay());
                if (cboSanBayDen.Items.Count > 1) cboSanBayDen.SelectedIndex = 1;
                dtpKhoiHanh.Value = DateTime.Today.AddDays(7).AddHours(8);
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private static void GanCombo(ComboBox cbo, DataTable dt)
        {
            cbo.DisplayMember = "Ten";
            cbo.ValueMember = "Ma";
            cbo.DataSource = dt;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                int? maMayBay = cboMayBay.SelectedValue == null ? (int?)null : Convert.ToInt32(cboMayBay.SelectedValue);
                int ma = ChuyenBayBLL.Tao(maMayBay, cboSanBayDi.SelectedValue?.ToString(),
                    cboSanBayDen.SelectedValue?.ToString(), dtpKhoiHanh.Value, (int)nudThoiGianBay.Value,
                    nudGiaPT.Value, nudGiaPTDB.Value, nudGiaTG.Value);
                MsgBox.ThanhCong("Đã tạo chuyến bay #" + ma + ".");
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
