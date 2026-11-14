using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucTongQuan : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucTongQuan()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvSapBay);
                cboNam.Items.Add("Tất cả các năm");
                for (int y = DateTime.Today.Year - 2; y <= DateTime.Today.Year + 1; y++) cboNam.Items.Add(y.ToString());
                cboNam.SelectedIndex = 0;
                cboThang.Items.Add("Cả năm");
                for (int m = 1; m <= 12; m++) cboThang.Items.Add("Tháng " + m);
                cboThang.SelectedIndex = 0;
                _daCauHinh = true;
            }
            NapThongKe();
        }

        private void NapThongKe()
        {
            try
            {
                int? nam = cboNam.SelectedIndex > 0 ? int.Parse(cboNam.Text) : (int?)null;
                int? thang = cboThang.SelectedIndex > 0 ? cboThang.SelectedIndex : (int?)null;

                DataRow r = ThongKeBLL.TongQuan(nam, thang);
                statChuyenBay.Value = Convert.ToInt32(r["TongChuyenBay"]).ToString("N0");
                statVe.Value = Convert.ToInt32(r["TongVeConHieuLuc"]).ToString("N0");
                statVeHuy.Value = Convert.ToInt32(r["TongVeDaHuy"]).ToString("N0");
                statDoanhThu.Value = DinhDang.Tien(r["TongTienThu"]);

                DataTable dt = ThongKeBLL.DoanhThuTheoThang(12);
                chartDoanhThu.SetData(dt.AsEnumerable().Select(x =>
                    new KeyValuePair<string, decimal>($"T{x["Thang"]}/{x["Nam"]}", Convert.ToDecimal(x["DoanhThuThuan"]))));

                GridHelper.Bind(dgvSapBay, ChuyenBayBLL.SapKhoiHanh(15));
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void btnXem_Click(object sender, EventArgs e) => NapThongKe();

        private void btnDatVeNhanh_Click(object sender, EventArgs e)
        {
            (FindForm() as frmMain)?.ChuyenDenDatVe();
        }
    }
}
