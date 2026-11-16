using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace BaoCao
{
    /// <summary>Cửa sổ xem báo cáo: CrystalReportViewer có sẵn nút in, xuất PDF/Excel/Word, phóng to.</summary>
    public class frmXemBaoCao : Form
    {
        private readonly CrystalReportViewer _viewer;
        private readonly ReportDocument _rpt = new ReportDocument();

        public frmXemBaoCao(string chuoiKetNoi, string loai, int? ma)
        {
            Text = "Báo cáo";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 800);
            Font = new System.Drawing.Font("Segoe UI", 9F);

            _viewer = new CrystalReportViewer
            {
                Dock = DockStyle.Fill,
                ToolPanelView = ToolPanelViewType.None,
                ShowGroupTreeButton = false,
                ShowParameterPanelButton = false,
                ShowLogo = false
            };
            Controls.Add(_viewer);

            NapBaoCao(chuoiKetNoi, loai, ma);
        }

        public static string ThuMucMau => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mau");

        /// <summary>Nạp mẫu .rpt và đổ dữ liệu. Dùng chung cho cửa sổ xem và chế độ xuất PDF.</summary>
        public static ReportDocument TaoBaoCao(ReportDocument rpt, string chuoiKetNoi, string loai, int? ma, out string tieuDe)
        {
            DataTable dt;
            string mau;
            if (loai == "hoadon")
            {
                if (ma == null) throw new ArgumentException("Thiếu mã đơn cần in hóa đơn.");
                dt = DuLieuBaoCao.HoaDon(chuoiKetNoi, ma.Value);
                if (dt.Rows.Count == 0) throw new InvalidOperationException($"Không tìm thấy đơn #{ma} hoặc đơn chưa có vé.");
                mau = "rptHoaDon.rpt";
                tieuDe = $"Hóa đơn đơn đặt vé #{ma}";
            }
            else if (loai == "doanhthu")
            {
                dt = DuLieuBaoCao.DoanhThu(chuoiKetNoi);
                mau = "rptDoanhThu.rpt";
                tieuDe = "Báo cáo doanh thu theo tháng";
            }
            else
            {
                throw new ArgumentException("Loại báo cáo không hợp lệ: " + loai);
            }

            string duongDan = Path.Combine(ThuMucMau, mau);
            if (!File.Exists(duongDan)) throw new FileNotFoundException("Không tìm thấy mẫu báo cáo " + mau, duongDan);
            rpt.Load(duongDan);
            rpt.SetDataSource(dt);
            return rpt;
        }

        private void NapBaoCao(string chuoiKetNoi, string loai, int? ma)
        {
            try
            {
                TaoBaoCao(_rpt, chuoiKetNoi, loai, ma, out string tieuDe);
                Text = tieuDe;
                _viewer.ReportSource = _rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được báo cáo.\n\n" + ex.Message, "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load += (s, e) => Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _rpt.Close();
            _rpt.Dispose();
            base.OnFormClosed(e);
        }
    }
}
