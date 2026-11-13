using Microsoft.Data.SqlClient;
using QuanLyBanVeMayBay.BLL;
using QuanLyBanVeMayBay.GUI;

namespace QuanLyBanVeMayBay.Utils
{
    public static class MsgBox
    {
        private static DialogResult Show(LoaiThongBao loai, string tieuDe, string noiDung, string ok, string huy)
        {
            using (var f = new frmThongBao(loai, tieuDe, noiDung, ok, huy))
            {
                Form owner = Form.ActiveForm;
                if (owner == null || owner.IsDisposed)
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    return f.ShowDialog();
                }
                return f.ShowDialog(owner);
            }
        }

        public static void ThanhCong(string noiDung, string tieuDe = "Thành công")
        {
            Show(LoaiThongBao.ThanhCong, tieuDe, noiDung, "Đóng", null);
        }

        public static void ThongTin(string noiDung, string tieuDe = "Thông báo")
        {
            Show(LoaiThongBao.ThongTin, tieuDe, noiDung, "Đóng", null);
        }

        public static void CanhBao(string noiDung, string tieuDe = "Chưa thể thực hiện")
        {
            Show(LoaiThongBao.CanhBao, tieuDe, noiDung, "Đã hiểu", null);
        }

        public static void Loi(Exception ex)
        {
            // Lỗi nghiệp vụ: do BLL kiểm tra, hoặc do THROW trong stored procedure (mã >= 50000)
            if (ex is LoiNghiepVu)
            {
                CanhBao(ex.Message);
                return;
            }
            var se = ex as SqlException;
            if (se != null && se.Number >= 50000)
                Show(LoaiThongBao.CanhBao, "Không thể thực hiện", se.Message, "Đã hiểu", null);
            else
                Show(LoaiThongBao.Loi, "Đã xảy ra lỗi", ex.Message, "Đóng", null);
        }

        public static bool XacNhan(string noiDung, string tieuDe = "Xác nhận", string nutDongY = "Đồng ý", string nutHuy = "Không")
        {
            return Show(LoaiThongBao.XacNhan, tieuDe, noiDung, nutDongY, nutHuy) == DialogResult.OK;
        }
    }
}
