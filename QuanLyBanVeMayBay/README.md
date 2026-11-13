# Quản lý bán vé máy bay

Ứng dụng WinForms (C#, .NET 8) + SQL Server.

## Cách chạy

1. Mở SQL Server Management Studio, chạy file `Database/QuanLyBanVeMayBay.sql`.
2. Mở `QuanLyBanVeMayBay.slnx` bằng Visual Studio 2022, nhấn F5.
3. Ở màn hình đăng nhập nhập tên máy chủ SQL (ví dụ `.` hoặc `.\SQLEXPRESS`).

## Tài khoản

- admin / admin123 (quản trị)
- nv01 / 123456 (nhân viên)

## Kiến trúc 3 lớp

```
GUI (form, user control)
  │  chỉ gọi BLL, hiển thị kết quả / thông báo
  ▼
BLL (kiểm tra dữ liệu, quy tắc nghiệp vụ)
  │  ném LoiNghiepVu khi dữ liệu không hợp lệ → GUI hiện cảnh báo
  ▼
DAL (câu lệnh SQL, gọi stored procedure)
  │  dùng DataProvider để chạy lệnh
  ▼
KetNoiCSDL (chuỗi kết nối, tạo SqlConnection)  →  SQL Server
```

DTO là các đối tượng dữ liệu được truyền giữa các lớp.

## Thư mục

- `Database`: script tạo CSDL
- `DAL/KetNoiCSDL.cs`: kết nối CSDL
- `DAL/DataProvider.cs`: hàm chạy SQL dùng chung (ExecuteQuery, ExecuteProc, ...)
- `DAL`: truy cập dữ liệu theo từng bảng/nghiệp vụ
- `BLL`: xử lý nghiệp vụ
- `DTO`: đối tượng dữ liệu
- `GUI`: các form và user control
- `Controls`: control tự vẽ
- `Utils`: hàm dùng chung
