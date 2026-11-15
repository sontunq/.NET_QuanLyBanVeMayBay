using System.Data;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.GUI
{
    public partial class frmThemDichVu : Form
    {
        private readonly int _maDon, _maVe;

        /// <summary>Một dòng trong danh sách dịch vụ.</summary>
        private class DongDichVu
        {
            public int Ma;
            public string Ten;
            public decimal DonGia;
            public bool DaCo;   // vé đã đăng ký dịch vụ này trước đó

            public override string ToString() =>
                $"{Ten}  ·  {DinhDang.Tien(DonGia)}" + (DaCo ? "   (đã có)" : "");
        }

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
                HashSet<int> daCo = DatVeBLL.DichVuCuaVe(_maVe);
                clbDichVu.Items.Clear();
                foreach (DataRow r in DanhMucBLL.DichVu().Rows)
                {
                    int ma = Convert.ToInt32(r["Ma"]);
                    var dong = new DongDichVu
                    {
                        Ma = ma, Ten = r["Ten"].ToString(), DonGia = Convert.ToDecimal(r["GiaTri"]), DaCo = daCo.Contains(ma),
                    };
                    clbDichVu.Items.Add(dong, dong.DaCo);
                }
                TinhThanhTien();
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }

        /// <summary>Dịch vụ mới được tick (bỏ qua các dịch vụ vé đã có).</summary>
        private List<DongDichVu> DichVuMoiDaChon(int? dangDoi = null, CheckState? trangThaiMoi = null)
        {
            var ds = new List<DongDichVu>();
            for (int i = 0; i < clbDichVu.Items.Count; i++)
            {
                var d = (DongDichVu)clbDichVu.Items[i];
                bool tick = i == dangDoi ? trangThaiMoi == CheckState.Checked : clbDichVu.GetItemChecked(i);
                if (tick && !d.DaCo) ds.Add(d);
            }
            return ds;
        }

        private void TinhThanhTien(int? dangDoi = null, CheckState? trangThaiMoi = null)
        {
            var ds = DichVuMoiDaChon(dangDoi, trangThaiMoi);
            lblThanhTien.Text = DinhDang.Tien(ds.Sum(d => d.DonGia));
            btnThem.Text = ds.Count > 0 ? $"Thêm ({ds.Count})" : "Thêm";
        }

        private void clbDichVu_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Dịch vụ vé đã có: giữ nguyên dấu tick, không cho bỏ
            if (((DongDichVu)clbDichVu.Items[e.Index]).DaCo)
            {
                e.NewValue = CheckState.Checked;
                return;
            }
            TinhThanhTien(e.Index, e.NewValue);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = DichVuMoiDaChon();
                bool donDaThanhToan = DatVeBLL.TrangThaiDon(_maDon) == DatVeBLL.DaThanhToan;
                decimal conPhaiThu = DatVeBLL.ThemDichVu(_maDon, _maVe, ds.Select(d => d.Ma).ToList());
                DialogResult = DialogResult.OK;
                Close();

                // Đơn đã thanh toán: dịch vụ vẫn thêm được, phần tiền phát sinh thu tiếp qua màn thanh toán.
                if (donDaThanhToan && conPhaiThu > 0 &&
                    MsgBox.XacNhan($"Đã thêm {ds.Count} dịch vụ cho vé #{_maVe}.\nĐơn #{_maDon} đã thanh toán trước đó, còn phải thu thêm {DinhDang.Tien(conPhaiThu)}.\nThu tiền ngay?",
                                   "Thu thêm tiền dịch vụ", "Thu tiền", "Để sau"))
                    frmThanhToan.ThanhToan(Owner, _maDon);
            }
            catch (Exception ex)
            {
                MsgBox.Loi(ex);
            }
        }
    }
}
