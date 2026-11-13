using System.Globalization;
using QuanLyBanVeMayBay.GUI;

namespace QuanLyBanVeMayBay
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var vi = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentCulture = vi;
            CultureInfo.DefaultThreadCurrentUICulture = vi;
            Thread.CurrentThread.CurrentCulture = vi;
            Thread.CurrentThread.CurrentUICulture = vi;

            ApplicationConfiguration.Initialize();

            // Đăng xuất thì quay lại màn hình đăng nhập
            while (true)
            {
                using (var dangNhap = new frmDangNhap())
                {
                    if (dangNhap.ShowDialog() != DialogResult.OK) return;
                }

                var main = new frmMain();
                Application.Run(main);
                if (!main.DaDangXuat) return;
            }
        }
    }
}
