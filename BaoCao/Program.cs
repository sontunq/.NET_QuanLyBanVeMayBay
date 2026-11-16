using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BaoCao
{
    internal static class Program
    {
        /// <summary>
        /// Cách gọi:
        ///   BaoCao.exe "&lt;chuỗi kết nối&gt;" hoadon &lt;mã đơn&gt;     xem hóa đơn của một đơn
        ///   BaoCao.exe "&lt;chuỗi kết nối&gt;" doanhthu                 xem báo cáo doanh thu theo tháng
        ///   BaoCao.exe --tao-mau "&lt;mẫu trắng .rpt&gt;" "&lt;thư mục&gt;"  sinh lại các mẫu .rpt (dành cho lập trình viên)
        ///   BaoCao.exe --pdf "&lt;chuỗi kết nối&gt;" &lt;loại&gt; [mã] "&lt;file.pdf&gt;"  xuất thẳng ra PDF (dùng để kiểm thử)
        /// Ứng dụng chính (QuanLyBanVeMayBay.exe) gọi hai dạng đầu qua Utils/MoBaoCao.cs.
        /// </summary>
        [STAThread]
        private static int Main(string[] args)
        {
            try
            {
                if (args.Length >= 3 && args[0] == "--tao-mau")
                {
                    MauBaoCao.TaoTatCa(args[1], args[2]);
                    return 0;
                }

                if (args.Length >= 4 && args[0] == "--pdf")
                {
                    int? maPdf = args.Length >= 5 ? int.Parse(args[3]) : (int?)null;
                    string file = args[args.Length - 1];
                    using (var rpt = new ReportDocument())
                    {
                        frmXemBaoCao.TaoBaoCao(rpt, args[1], args[2], maPdf, out _);
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, file);
                    }
                    Console.WriteLine("Đã xuất " + file);
                    return 0;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (args.Length < 2)
                {
                    MessageBox.Show("Hãy mở báo cáo từ chương trình Quản lý bán vé máy bay.", "Báo cáo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                }

                int? ma = args.Length > 2 && int.TryParse(args[2], out int m) ? m : (int?)null;
                Application.Run(new frmXemBaoCao(args[0], args[1], ma));
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                if (Environment.UserInteractive && !Console.IsErrorRedirected)
                    MessageBox.Show(ex.Message, "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 2;
            }
        }
    }
}
