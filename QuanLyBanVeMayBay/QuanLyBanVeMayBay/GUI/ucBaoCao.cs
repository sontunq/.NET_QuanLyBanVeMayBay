using System.Data;
using QuanLyBanVeMayBay.Controls;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class ucBaoCao : UserControl, ITaiLai
    {
        private bool _daCauHinh;

        public ucBaoCao()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daCauHinh)
            {
                GridHelper.Apply(dgvThang);
                GridHelper.Apply(dgvTheoChuyen);
                GridHelper.Apply(dgvTheoNhanVien);
                _daCauHinh = true;
            }
            try
            {
                DataTable thang = ThongKeDAL.DoanhThuTheoThang(null);
                GridHelper.Bind(dgvThang, thang);
                chartThang.SetData(thang.AsEnumerable().Select(r =>
                    new KeyValuePair<string, decimal>($"T{r["Thang"]}/{r["Nam"]}", Convert.ToDecimal(r["DoanhThuThuan"]))));

                GridHelper.Bind(dgvTheoChuyen, ThongKeDAL.DoanhThuTheoChuyenBay());
                GridHelper.Bind(dgvTheoNhanVien, ThongKeDAL.DoanhThuTheoNhanVien());
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            foreach (var b in new[] { btnTheoThang, btnTheoChuyen, btnTheoNhanVien })
                b.Kind = b == sender ? ButtonKind.Primary : ButtonKind.Outline;
            pnlTheoThang.Visible = sender == btnTheoThang;
            cardTheoChuyen.Visible = sender == btnTheoChuyen;
            cardTheoNhanVien.Visible = sender == btnTheoNhanVien;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => TaiLai();
    }
}
