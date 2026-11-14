using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyBanVeMayBay.DAL;
using QuanLyBanVeMayBay.DTO;
using static QuanLyBanVeMayBay.BLL.LoiNghiepVu;

namespace QuanLyBanVeMayBay.BLL
{
    public static class TaiKhoanBLL
    {
        public const string HoatDong = "Hoạt động";
        public const string BiKhoa = "Bị khóa";

        /// <summary>Thiết lập kết nối tới máy chủ, kiểm tra tài khoản và lưu phiên đăng nhập.</summary>
        public static TaiKhoanDTO DangNhap(string mayChu, string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                throw new LoiNghiepVu("Vui lòng nhập tên đăng nhập và mật khẩu.");

            KetNoiCSDL.ThietLap(mayChu);
            TaiKhoanDTO tk;
            try
            {
                tk = TaiKhoanDAL.DangNhap(tenDangNhap.Trim(), matKhau);
            }
            catch (SqlException ex) when (ex.Number == 4060)
            {
                throw new LoiNghiepVu("Không mở được CSDL " + KetNoiCSDL.TenCSDL + ". Hãy chạy file SQL trong thư mục Database trước.");
            }
            catch (SqlException ex) when (ex.Number == 2812)
            {
                throw new LoiNghiepVu("Cơ sở dữ liệu chưa được tạo đầy đủ. Hãy chạy lại file script SQL.");
            }
            catch (SqlException ex)
            {
                throw new LoiNghiepVu("Không kết nối được SQL Server: " + ex.Message);
            }

            if (tk == null)
                throw new LoiNghiepVu("Sai tên đăng nhập/mật khẩu hoặc tài khoản đã bị khóa.");

            PhienDangNhap.TaiKhoan = tk;
            return tk;
        }

        public static void DangXuat()
        {
            PhienDangNhap.TaiKhoan = null;
        }

        public static DataTable LayDanhSach() => TaiKhoanDAL.LayDanhSach();

        public static DataTable LayNhatKy() => TaiKhoanDAL.LayNhatKy();

        public static void Them(string tenDangNhap, string matKhau, string hoTen, string email, string sdt, string vaiTro)
        {
            if (new[] { tenDangNhap, matKhau, hoTen, email }.Any(string.IsNullOrWhiteSpace))
                throw new LoiNghiepVu("Vui lòng nhập đủ các trường bắt buộc (*).");

            TaiKhoanDAL.Them(tenDangNhap.Trim(), matKhau, KiemTraDuLieu.ChuanHoaHoTen(hoTen),
                KiemTraDuLieu.ChuanHoaEmail(email), KiemTraDuLieu.ChuanHoaSoDienThoai(sdt), vaiTro);
        }

        /// <summary>Trạng thái mới khi bấm Khóa/Mở khóa.</summary>
        public static string TrangThaiKeTiep(string trangThaiHienTai)
        {
            return trangThaiHienTai == HoatDong ? BiKhoa : HoatDong;
        }

        /// <summary>Kiểm tra trước khi hỏi xác nhận (không cho tự khóa chính mình).</summary>
        public static void KiemTraCoTheDoiTrangThai(int maTK)
        {
            if (maTK == PhienDangNhap.MaTK)
                throw new LoiNghiepVu("Không thể tự khóa tài khoản đang đăng nhập.");
        }

        public static void DoiTrangThai(int maTK, string trangThaiMoi)
        {
            KiemTraCoTheDoiTrangThai(maTK);
            TaiKhoanDAL.DoiTrangThai(maTK, trangThaiMoi);
        }
    }
}
