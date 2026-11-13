# Quản lý bán vé máy bay

Ứng dụng WinForms (C#, .NET 8) + SQL Server.

## Cách chạy

1. Mở SQL Server Management Studio, chạy file `Database/QuanLyBanVeMayBay.sql`.
2. Mở `QuanLyBanVeMayBay.slnx` bằng Visual Studio 2022, nhấn F5.
3. Ở màn hình đăng nhập nhập tên máy chủ SQL (ví dụ `.` hoặc `.\SQLEXPRESS`).

## Tài khoản

- admin / admin123 (quản trị)
- nv01 / 123456 (nhân viên)

## Thư mục

- `Database`: script tạo CSDL
- `DAL`: truy cập dữ liệu
- `DTO`: đối tượng dữ liệu
- `GUI`: các form và user control
- `Controls`: control tự vẽ
- `Utils`: hàm dùng chung
