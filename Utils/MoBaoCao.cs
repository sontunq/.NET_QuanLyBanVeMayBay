using System.Diagnostics;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.Utils
{
    /// <summary>
    /// Mở chương trình báo cáo Crystal Reports (BaoCao.exe, .NET Framework 4.8).
    /// Crystal Reports không chạy trên .NET 8 nên báo cáo là một chương trình riêng,
    /// nằm trong thư mục con BaoCao\ cạnh QuanLyBanVeMayBay.exe (csproj tự build và chép vào).
    /// Truyền qua tham số dòng lệnh: chuỗi kết nối CSDL đang dùng, loại báo cáo, mã (nếu có).
    /// </summary>
    public static class MoBaoCao
    {
        public const string HoaDon = "hoadon";
        public const string DoanhThu = "doanhthu";

        public static void Mo(string loai, int? ma = null)
        {
            string exe = Path.Combine(AppContext.BaseDirectory, "BaoCao", "BaoCao.exe");
            if (!File.Exists(exe))
            {
                MsgBox.CanhBao("Không tìm thấy chương trình báo cáo (BaoCao\\BaoCao.exe).\n" +
                               "Hãy build lại solution bằng Visual Studio để tạo chương trình báo cáo.");
                return;
            }

            var psi = new ProcessStartInfo(exe)
            {
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(exe)
            };
            psi.ArgumentList.Add(KetNoiCSDL.ChuoiKetNoi);
            psi.ArgumentList.Add(loai);
            if (ma != null) psi.ArgumentList.Add(ma.Value.ToString());

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MsgBox.CanhBao("Không mở được chương trình báo cáo.\n" + ex.Message +
                               "\n\nMáy cần cài SAP Crystal Reports runtime (64-bit).");
            }
        }
    }
}
