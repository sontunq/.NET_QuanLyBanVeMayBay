using System.Data;
using QuanLyBanVeMayBay.DAL;
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
                GanCombo(cboMayBay, DanhMucDAL.MayBay());
                GanCombo(cboSanBayDi, DanhMucDAL.SanBay());
                GanCombo(cboSanBayDen, DanhMucDAL.SanBay());
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
            if (cboMayBay.SelectedValue == null || cboSanBayDi.SelectedValue == null || cboSanBayDen.SelectedValue == null)
            {
                MsgBox.CanhBao("Vui lòng chọn máy bay và sân bay.");
                return;
            }
            if (Equals(cboSanBayDi.SelectedValue, cboSanBayDen.SelectedValue))
            {
                MsgBox.CanhBao("Sân bay đi và sân bay đến phải khác nhau.");
                return;
            }
            if (nudGiaPT.Value <= 0 || nudGiaPTDB.Value <= 0 || nudGiaTG.Value <= 0)
            {
                MsgBox.CanhBao("Giá vé các hạng phải lớn hơn 0.");
                return;
            }
            try
            {
                int ma = ChuyenBayDAL.Tao(Convert.ToInt32(cboMayBay.SelectedValue), cboSanBayDi.SelectedValue.ToString(),
                    cboSanBayDen.SelectedValue.ToString(), dtpKhoiHanh.Value, (int)nudThoiGianBay.Value,
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
