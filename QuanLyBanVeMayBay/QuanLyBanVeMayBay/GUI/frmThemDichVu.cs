using System.Data;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmThemDichVu : Form
    {
        private readonly int _maDon, _maVe;

        public frmThemDichVu()
        {
            InitializeComponent();
        }

        public frmThemDichVu(int maDon, int maVe, string hanhKhach) : this()
        {
            _maDon = maDon;
            _maVe = maVe;
            lblMoTa.Text = $"Vé #{maVe} · {hanhKhach} · Đơn #{maDon}";
        }

        private void frmThemDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DanhMucDAL.DichVu();
                dt.Columns.Add("Hien", typeof(string));
                foreach (DataRow r in dt.Rows)
                    r["Hien"] = $"{r["Ten"]}  ·  {DinhDang.Tien(r["GiaTri"])}";
                cboDichVu.DisplayMember = "Hien";
                cboDichVu.ValueMember = "Ma";
                cboDichVu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private decimal DonGia
        {
            get
            {
                var row = (cboDichVu.SelectedItem as DataRowView)?.Row;
                return row == null ? 0 : Convert.ToDecimal(row["GiaTri"]);
            }
        }

        private void TinhThanhTien(object sender, EventArgs e)
        {
            lblThanhTien.Text = DinhDang.Tien(DonGia * nudSoLuong.Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!(cboDichVu.SelectedValue is int))
            {
                MsgBox.CanhBao("Vui lòng chọn dịch vụ.");
                return;
            }
            try
            {
                DatVeDAL.ThemDichVu(_maDon, _maVe, (int)cboDichVu.SelectedValue, (int)nudSoLuong.Value, DonGia);
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
