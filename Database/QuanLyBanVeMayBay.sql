-- Cơ sở dữ liệu quản lý bán vé máy bay
-- CREATE DATABASE QuanLyBanVeMayBay2;
USE QuanLyBanVeMayBay2;


-- Bảng tài khoản
CREATE TABLE TAIKHOAN
(
    MaTK INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(20) NULL,
    VaiTro NVARCHAR(20) NOT NULL
        CHECK (VaiTro IN (N'Admin', N'NhanVien')),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa')),
    NgayTao DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);


-- Bảng nhật ký hoạt động
CREATE TABLE NHATKYHOATDONG
(
    MaNK INT IDENTITY(1,1) PRIMARY KEY,
    MaTK INT NULL REFERENCES TAIKHOAN(MaTK),
    HanhDong NVARCHAR(50) NOT NULL,
    DoiTuong NVARCHAR(50) NULL,
    NoiDung NVARCHAR(300) NULL,
    ThoiGian DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);


-- Bảng sân bay
CREATE TABLE SANBAY
(
    MaSanBay CHAR(3) PRIMARY KEY,
    TenSanBay NVARCHAR(120) NOT NULL,
    ThanhPho NVARCHAR(80) NOT NULL,
    QuocGia NVARCHAR(80) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);


-- Bảng hạng vé
CREATE TABLE HANGVE
(
    MaHangVe INT IDENTITY(1,1) PRIMARY KEY,
    TenHangVe NVARCHAR(50) NOT NULL UNIQUE,
    HanhLyXachTayKg INT NOT NULL DEFAULT 7
        CHECK (HanhLyXachTayKg >= 0),
    HanhLyKyGuiKg INT NOT NULL DEFAULT 0
        CHECK (HanhLyKyGuiKg >= 0),
    ChoPhepHuy BIT NOT NULL DEFAULT 1,
    MoTa NVARCHAR(250) NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);


-- Bảng máy bay
CREATE TABLE MAYBAY
(
    MaMayBay INT IDENTITY(1,1) PRIMARY KEY,
    SoHieu VARCHAR(20) NOT NULL UNIQUE,
    HangSanXuat NVARCHAR(60) NOT NULL,
    LoaiMayBay NVARCHAR(60) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Bảo trì', N'Ngừng hoạt động'))
);


-- Bảng ghế
CREATE TABLE GHE
(
    MaGhe INT IDENTITY(1,1) PRIMARY KEY,
    MaMayBay INT NOT NULL REFERENCES MAYBAY(MaMayBay),
    SoGhe VARCHAR(5) NOT NULL,
    SoHang INT NOT NULL CHECK (SoHang > 0),
    CotGhe CHAR(1) NOT NULL,
    MaHangVe INT NOT NULL REFERENCES HANGVE(MaHangVe),
    UNIQUE (MaMayBay, SoGhe),
    UNIQUE (MaMayBay, SoHang, CotGhe)
);


-- Bảng dịch vụ
CREATE TABLE DICHVU
(
    MaDichVu INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL UNIQUE,
    LoaiDichVu NVARCHAR(30) NOT NULL
        CHECK (LoaiDichVu IN (N'Hành lý', N'Suất ăn', N'Khác')),
    DonGia MONEY NOT NULL CHECK (DonGia >= 0),
    MoTa NVARCHAR(250) NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);


-- Bảng chuyến bay
CREATE TABLE CHUYENBAY
(
    MaChuyenBay INT IDENTITY(1,1) PRIMARY KEY,
    MaMayBay INT NOT NULL REFERENCES MAYBAY(MaMayBay),
    MaSanBayDi CHAR(3) NOT NULL REFERENCES SANBAY(MaSanBay),
    MaSanBayDen CHAR(3) NOT NULL REFERENCES SANBAY(MaSanBay),
    NgayGioKhoiHanh DATETIME2 NOT NULL,
    ThoiGianBayPhut INT NOT NULL CHECK (ThoiGianBayPhut > 0),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đang mở bán'
        CHECK (TrangThai IN (N'Đang mở bán', N'Đã đóng', N'Đã bay', N'Đã hủy')),
    NguoiTao INT NULL REFERENCES TAIKHOAN(MaTK),
    NgayTao DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CHECK (MaSanBayDi <> MaSanBayDen)
);


-- Bảng giá vé
CREATE TABLE GIAVE
(
    MaChuyenBay INT NOT NULL REFERENCES CHUYENBAY(MaChuyenBay),
    MaHangVe INT NOT NULL REFERENCES HANGVE(MaHangVe),
    DonGia MONEY NOT NULL CHECK (DonGia > 0),
    PRIMARY KEY (MaChuyenBay, MaHangVe)
);


-- Bảng ghế chuyến bay
CREATE TABLE GHECHUYENBAY
(
    MaChuyenBay INT NOT NULL REFERENCES CHUYENBAY(MaChuyenBay),
    MaGhe INT NOT NULL REFERENCES GHE(MaGhe),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Trống'
        CHECK (TrangThai IN (N'Trống', N'Đã đặt', N'Khóa')),
    PRIMARY KEY (MaChuyenBay, MaGhe)
);


-- Bảng hạng thành viên
CREATE TABLE HANGTHANHVIEN
(
    MaHangTV INT IDENTITY(1,1) PRIMARY KEY,
    TenHang NVARCHAR(40) NOT NULL UNIQUE,
    DiemChiTieuToiThieu MONEY NOT NULL UNIQUE CHECK (DiemChiTieuToiThieu >= 0),
    PhanTramGiam INT NOT NULL CHECK (PhanTramGiam BETWEEN 0 AND 30),
    MoTa NVARCHAR(200) NULL
);


-- Bảng khách hàng
CREATE TABLE KHACHHANG
(
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    LoaiGiayTo NVARCHAR(30) NOT NULL
        CHECK (LoaiGiayTo IN (N'CCCD', N'Hộ chiếu', N'Giấy khai sinh')),
    SoGiayTo VARCHAR(30) NOT NULL UNIQUE,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    SoDienThoai VARCHAR(20) NULL,
    Email VARCHAR(100) NULL,
    DiaChi NVARCHAR(200) NULL,
    MaHangTV INT NOT NULL DEFAULT 1 REFERENCES HANGTHANHVIEN(MaHangTV),
    TongChiTieu MONEY NOT NULL DEFAULT 0 CHECK (TongChiTieu >= 0),
    NgayGiaoDichDauTien DATETIME2 NULL,
    NgayKetThucThanhVien DATETIME2 NULL,
    NgayTao DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);


-- Bảng khuyến mãi
CREATE TABLE KHUYENMAI
(
    MaKM INT IDENTITY(1,1) PRIMARY KEY,
    TenKM NVARCHAR(100) NOT NULL,
    PhanTramGiam INT NOT NULL CHECK (PhanTramGiam BETWEEN 0 AND 30),
    GiamToiDa MONEY NULL CHECK (GiamToiDa IS NULL OR GiamToiDa >= 0),
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    SoLuotToiDa INT NULL CHECK (SoLuotToiDa IS NULL OR SoLuotToiDa > 0),
    SoLuotDaDung INT NOT NULL DEFAULT 0 CHECK (SoLuotDaDung >= 0),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Tạm dừng')),
    CHECK (NgayKetThuc >= NgayBatDau)
);


-- Bảng đơn đặt vé
CREATE TABLE DONDATVE
(
    MaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaKHLienHe INT NOT NULL REFERENCES KHACHHANG(MaKH),
    MaTKNhanVien INT NOT NULL REFERENCES TAIKHOAN(MaTK),
    MaKM INT NULL REFERENCES KHUYENMAI(MaKM),
    NgayDat DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    TongTienVe MONEY NOT NULL DEFAULT 0 CHECK (TongTienVe >= 0),
    TongTienDichVu MONEY NOT NULL DEFAULT 0 CHECK (TongTienDichVu >= 0),
    TienGiamKM MONEY NOT NULL DEFAULT 0 CHECK (TienGiamKM >= 0),
    TongThanhToan MONEY NOT NULL DEFAULT 0 CHECK (TongThanhToan >= 0),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Chờ thanh toán'
        CHECK (TrangThai IN (N'Chờ thanh toán', N'Đã thanh toán', N'Đã hủy'))
);


-- Bảng vé
CREATE TABLE VE
(
    MaVe INT IDENTITY(1,1) PRIMARY KEY,
    MaDon INT NOT NULL REFERENCES DONDATVE(MaDon),
    MaChuyenBay INT NOT NULL REFERENCES CHUYENBAY(MaChuyenBay),
    MaGhe INT NOT NULL REFERENCES GHE(MaGhe),
    MaHangVe INT NOT NULL REFERENCES HANGVE(MaHangVe),
    MaKH INT NOT NULL REFERENCES KHACHHANG(MaKH),
    MaNguoiGiamHo INT NULL REFERENCES KHACHHANG(MaKH),
    GiaGoc MONEY NOT NULL CHECK (GiaGoc > 0),
    PhanTramGiamHang INT NOT NULL DEFAULT 0 CHECK (PhanTramGiamHang BETWEEN 0 AND 30),
    PhanTramGiamTet INT NOT NULL DEFAULT 0 CHECK (PhanTramGiamTet BETWEEN 0 AND 30),
    PhanTramGiamKhuHoi INT NOT NULL DEFAULT 0 CHECK (PhanTramGiamKhuHoi BETWEEN 0 AND 30),
    PhanTramGiamKM INT NOT NULL DEFAULT 0 CHECK (PhanTramGiamKM BETWEEN 0 AND 30),
    TongPhanTramGiam INT NOT NULL DEFAULT 0 CHECK (TongPhanTramGiam BETWEEN 0 AND 30),
    TienGiam MONEY NOT NULL DEFAULT 0 CHECK (TienGiam >= 0),
    GiaThucTra MONEY NOT NULL CHECK (GiaThucTra >= 0),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đã đặt'
        CHECK (TrangThai IN (N'Đã đặt', N'Đã hủy', N'Đã bay'))
);


CREATE UNIQUE INDEX UX_Ve_ChuyenBay_Ghe_Active
ON VE(MaChuyenBay, MaGhe)
WHERE TrangThai <> N'Đã hủy';

CREATE UNIQUE INDEX UX_Ve_ChuyenBay_Khach_Active
ON VE(MaChuyenBay, MaKH)
WHERE TrangThai <> N'Đã hủy';


-- Bảng dịch vụ của vé
CREATE TABLE VEDICHVU
(
    MaVe INT NOT NULL REFERENCES VE(MaVe),
    MaDichVu INT NOT NULL REFERENCES DICHVU(MaDichVu),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia MONEY NOT NULL CHECK (DonGia >= 0),
    ThanhTien AS (SoLuong * DonGia),
    PRIMARY KEY (MaVe, MaDichVu)
);


-- Bảng thanh toán
CREATE TABLE THANHTOAN
(
    MaThanhToan INT IDENTITY(1,1) PRIMARY KEY,
    MaDon INT NOT NULL REFERENCES DONDATVE(MaDon),
    SoTien MONEY NOT NULL CHECK (SoTien > 0),
    PhuongThuc NVARCHAR(30) NOT NULL
        CHECK (PhuongThuc IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ')),
    NgayThanhToan DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    MaTKNhanVien INT NOT NULL REFERENCES TAIKHOAN(MaTK),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Thành công'
        CHECK (TrangThai IN (N'Thành công', N'Đã hoàn', N'Thất bại')),
    GhiChu NVARCHAR(250) NULL
);


-- Bảng hủy vé
CREATE TABLE HUYVE
(
    MaHuy INT IDENTITY(1,1) PRIMARY KEY,
    MaVe INT NOT NULL UNIQUE REFERENCES VE(MaVe),
    NgayHuy DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    LyDo NVARCHAR(250) NOT NULL,
    PhiHuy MONEY NOT NULL CHECK (PhiHuy >= 0),
    TienHoan MONEY NOT NULL CHECK (TienHoan >= 0),
    MaTKNhanVien INT NOT NULL REFERENCES TAIKHOAN(MaTK)
);


INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro)
VALUES
('admin','admin123',N'Quản trị hệ thống','admin@gmail.com','0900000001',N'Admin'),
('nv01','123456',N'Phạm Sơn Tùng','pst@gmail.com','0900000002',N'NhanVien'),
('nv02','123456',N'Vũ Quang Thái','vqt@gmail.com','0900000003',N'NhanVien'),
('nv03','123456',N'Đoàn Thị Kim Ngân','dtkn@gmail.com','0900000004',N'NhanVien'),
('nv04','123456',N'Trịnh Thị Thanh Xuân','tttx@gmail.com','0900000005',N'NhanVien');


INSERT INTO SANBAY (MaSanBay, TenSanBay, ThanhPho, QuocGia)
VALUES
('HAN',N'Sân bay quốc tế Nội Bài',N'Hà Nội',N'Việt Nam'),
('SGN',N'Sân bay quốc tế Tân Sơn Nhất',N'TP. Hồ Chí Minh',N'Việt Nam'),
('DAD',N'Sân bay quốc tế Đà Nẵng',N'Đà Nẵng',N'Việt Nam'),
('PQC',N'Sân bay quốc tế Phú Quốc',N'Phú Quốc',N'Việt Nam'),
('CXR',N'Sân bay quốc tế Cam Ranh',N'Nha Trang',N'Việt Nam'),
('DLI',N'Sân bay Liên Khương',N'Đà Lạt',N'Việt Nam'),
('VCA',N'Sân bay quốc tế Cần Thơ',N'Cần Thơ',N'Việt Nam'),
('HPH',N'Sân bay quốc tế Cát Bi',N'Hải Phòng',N'Việt Nam'),
('NRT',N'Sân bay quốc tế Narita',N'Tokyo',N'Nhật Bản'),
('ICN',N'Sân bay quốc tế Incheon',N'Seoul',N'Hàn Quốc'),
('HKG',N'Sân bay quốc tế Hong Kong',N'Hong Kong',N'Hong Kong'),
('SIN',N'Sân bay Changi',N'Singapore',N'Singapore'),
('SYD',N'Sân bay Sydney',N'Sydney',N'Úc'),
('SVO',N'Sân bay quốc tế Sheremetyevo',N'Moscow',N'Nga'),
('MAN',N'Sân bay Manchester',N'Manchester',N'Vương quốc Anh');


INSERT INTO HANGVE (TenHangVe, HanhLyXachTayKg, HanhLyKyGuiKg, ChoPhepHuy, MoTa)
VALUES
(N'Phổ thông',7,23,1,N'Hạng phổ thông tiêu chuẩn'),
(N'Phổ thông đặc biệt',10,32,1,N'Tiện ích và hành lý cao hơn'),
(N'Thương gia',18,32,1,N'Hạng thương gia'),
(N'Không hoàn hủy',7,0,0,N'Giá tiết kiệm, không hoàn hủy');


INSERT INTO MAYBAY (SoHieu, HangSanXuat, LoaiMayBay)
VALUES
('VN-A321-01',N'Airbus',N'A321'),
('VN-A321-02',N'Airbus',N'A321'),
('VN-A350-01',N'Airbus',N'A350-900'),
('VN-B787-01',N'Boeing',N'787-9');


-- Ghế mẫu: hàng 1-2 thương gia, 3-4 phổ thông đặc biệt, 5-10 phổ thông
INSERT INTO GHE (MaMayBay, SoGhe, SoHang, CotGhe, MaHangVe)
VALUES
    (1,'1A',1,'A',3),
    (1,'1C',1,'C',3),
    (1,'1D',1,'D',3),
    (1,'1F',1,'F',3),
    (1,'2A',2,'A',3),
    (1,'2C',2,'C',3),
    (1,'2D',2,'D',3),
    (1,'2F',2,'F',3),
    (1,'3A',3,'A',2),
    (1,'3B',3,'B',2),
    (1,'3C',3,'C',2),
    (1,'3D',3,'D',2),
    (1,'3E',3,'E',2),
    (1,'3F',3,'F',2),
    (1,'4A',4,'A',2),
    (1,'4B',4,'B',2),
    (1,'4C',4,'C',2),
    (1,'4D',4,'D',2),
    (1,'4E',4,'E',2),
    (1,'4F',4,'F',2),
    (1,'5A',5,'A',1),
    (1,'5B',5,'B',1),
    (1,'5C',5,'C',1),
    (1,'5D',5,'D',1),
    (1,'5E',5,'E',1),
    (1,'5F',5,'F',1),
    (1,'6A',6,'A',1),
    (1,'6B',6,'B',1),
    (1,'6C',6,'C',1),
    (1,'6D',6,'D',1),
    (1,'6E',6,'E',1),
    (1,'6F',6,'F',1),
    (1,'7A',7,'A',1),
    (1,'7B',7,'B',1),
    (1,'7C',7,'C',1),
    (1,'7D',7,'D',1),
    (1,'7E',7,'E',1),
    (1,'7F',7,'F',1),
    (1,'8A',8,'A',1),
    (1,'8B',8,'B',1),
    (1,'8C',8,'C',1),
    (1,'8D',8,'D',1),
    (1,'8E',8,'E',1),
    (1,'8F',8,'F',1),
    (1,'9A',9,'A',1),
    (1,'9B',9,'B',1),
    (1,'9C',9,'C',1),
    (1,'9D',9,'D',1),
    (1,'9E',9,'E',1),
    (1,'9F',9,'F',1),
    (1,'10A',10,'A',1),
    (1,'10B',10,'B',1),
    (1,'10C',10,'C',1),
    (1,'10D',10,'D',1),
    (1,'10E',10,'E',1),
    (1,'10F',10,'F',1),
    (2,'1A',1,'A',3),
    (2,'1C',1,'C',3),
    (2,'1D',1,'D',3),
    (2,'1F',1,'F',3),
    (2,'2A',2,'A',3),
    (2,'2C',2,'C',3),
    (2,'2D',2,'D',3),
    (2,'2F',2,'F',3),
    (2,'3A',3,'A',2),
    (2,'3B',3,'B',2),
    (2,'3C',3,'C',2),
    (2,'3D',3,'D',2),
    (2,'3E',3,'E',2),
    (2,'3F',3,'F',2),
    (2,'4A',4,'A',2),
    (2,'4B',4,'B',2),
    (2,'4C',4,'C',2),
    (2,'4D',4,'D',2),
    (2,'4E',4,'E',2),
    (2,'4F',4,'F',2),
    (2,'5A',5,'A',1),
    (2,'5B',5,'B',1),
    (2,'5C',5,'C',1),
    (2,'5D',5,'D',1),
    (2,'5E',5,'E',1),
    (2,'5F',5,'F',1),
    (2,'6A',6,'A',1),
    (2,'6B',6,'B',1),
    (2,'6C',6,'C',1),
    (2,'6D',6,'D',1),
    (2,'6E',6,'E',1),
    (2,'6F',6,'F',1),
    (2,'7A',7,'A',1),
    (2,'7B',7,'B',1),
    (2,'7C',7,'C',1),
    (2,'7D',7,'D',1),
    (2,'7E',7,'E',1),
    (2,'7F',7,'F',1),
    (2,'8A',8,'A',1),
    (2,'8B',8,'B',1),
    (2,'8C',8,'C',1),
    (2,'8D',8,'D',1),
    (2,'8E',8,'E',1),
    (2,'8F',8,'F',1),
    (2,'9A',9,'A',1),
    (2,'9B',9,'B',1),
    (2,'9C',9,'C',1),
    (2,'9D',9,'D',1),
    (2,'9E',9,'E',1),
    (2,'9F',9,'F',1),
    (2,'10A',10,'A',1),
    (2,'10B',10,'B',1),
    (2,'10C',10,'C',1),
    (2,'10D',10,'D',1),
    (2,'10E',10,'E',1),
    (2,'10F',10,'F',1),
    (3,'1A',1,'A',3),
    (3,'1C',1,'C',3),
    (3,'1D',1,'D',3),
    (3,'1F',1,'F',3),
    (3,'2A',2,'A',3),
    (3,'2C',2,'C',3),
    (3,'2D',2,'D',3),
    (3,'2F',2,'F',3),
    (3,'3A',3,'A',2),
    (3,'3B',3,'B',2),
    (3,'3C',3,'C',2),
    (3,'3D',3,'D',2),
    (3,'3E',3,'E',2),
    (3,'3F',3,'F',2),
    (3,'4A',4,'A',2),
    (3,'4B',4,'B',2),
    (3,'4C',4,'C',2),
    (3,'4D',4,'D',2),
    (3,'4E',4,'E',2),
    (3,'4F',4,'F',2),
    (3,'5A',5,'A',1),
    (3,'5B',5,'B',1),
    (3,'5C',5,'C',1),
    (3,'5D',5,'D',1),
    (3,'5E',5,'E',1),
    (3,'5F',5,'F',1),
    (3,'6A',6,'A',1),
    (3,'6B',6,'B',1),
    (3,'6C',6,'C',1),
    (3,'6D',6,'D',1),
    (3,'6E',6,'E',1),
    (3,'6F',6,'F',1),
    (3,'7A',7,'A',1),
    (3,'7B',7,'B',1),
    (3,'7C',7,'C',1),
    (3,'7D',7,'D',1),
    (3,'7E',7,'E',1),
    (3,'7F',7,'F',1),
    (3,'8A',8,'A',1),
    (3,'8B',8,'B',1),
    (3,'8C',8,'C',1),
    (3,'8D',8,'D',1),
    (3,'8E',8,'E',1),
    (3,'8F',8,'F',1),
    (3,'9A',9,'A',1),
    (3,'9B',9,'B',1),
    (3,'9C',9,'C',1),
    (3,'9D',9,'D',1),
    (3,'9E',9,'E',1),
    (3,'9F',9,'F',1),
    (3,'10A',10,'A',1),
    (3,'10B',10,'B',1),
    (3,'10C',10,'C',1),
    (3,'10D',10,'D',1),
    (3,'10E',10,'E',1),
    (3,'10F',10,'F',1),
    (4,'1A',1,'A',3),
    (4,'1C',1,'C',3),
    (4,'1D',1,'D',3),
    (4,'1F',1,'F',3),
    (4,'2A',2,'A',3),
    (4,'2C',2,'C',3),
    (4,'2D',2,'D',3),
    (4,'2F',2,'F',3),
    (4,'3A',3,'A',2),
    (4,'3B',3,'B',2),
    (4,'3C',3,'C',2),
    (4,'3D',3,'D',2),
    (4,'3E',3,'E',2),
    (4,'3F',3,'F',2),
    (4,'4A',4,'A',2),
    (4,'4B',4,'B',2),
    (4,'4C',4,'C',2),
    (4,'4D',4,'D',2),
    (4,'4E',4,'E',2),
    (4,'4F',4,'F',2),
    (4,'5A',5,'A',1),
    (4,'5B',5,'B',1),
    (4,'5C',5,'C',1),
    (4,'5D',5,'D',1),
    (4,'5E',5,'E',1),
    (4,'5F',5,'F',1),
    (4,'6A',6,'A',1),
    (4,'6B',6,'B',1),
    (4,'6C',6,'C',1),
    (4,'6D',6,'D',1),
    (4,'6E',6,'E',1),
    (4,'6F',6,'F',1),
    (4,'7A',7,'A',1),
    (4,'7B',7,'B',1),
    (4,'7C',7,'C',1),
    (4,'7D',7,'D',1),
    (4,'7E',7,'E',1),
    (4,'7F',7,'F',1),
    (4,'8A',8,'A',1),
    (4,'8B',8,'B',1),
    (4,'8C',8,'C',1),
    (4,'8D',8,'D',1),
    (4,'8E',8,'E',1),
    (4,'8F',8,'F',1),
    (4,'9A',9,'A',1),
    (4,'9B',9,'B',1),
    (4,'9C',9,'C',1),
    (4,'9D',9,'D',1),
    (4,'9E',9,'E',1),
    (4,'9F',9,'F',1),
    (4,'10A',10,'A',1),
    (4,'10B',10,'B',1),
    (4,'10C',10,'C',1),
    (4,'10D',10,'D',1),
    (4,'10E',10,'E',1),
    (4,'10F',10,'F',1);

INSERT INTO DICHVU (TenDichVu, LoaiDichVu, DonGia, MoTa)
VALUES
(N'Hành lý ký gửi thêm 10kg',N'Hành lý',350000,N'Gói hành lý thêm 10kg'),
(N'Hành lý ký gửi thêm 20kg',N'Hành lý',600000,N'Gói hành lý thêm 20kg'),
(N'Suất ăn tiêu chuẩn',N'Suất ăn',120000,N'Suất ăn trên chuyến bay'),
(N'Suất ăn đặc biệt',N'Suất ăn',220000,N'Suất ăn đặc biệt'),
(N'Nước uống',N'Suất ăn',40000,N'Nước uống'),
(N'Chọn chỗ ngồi ưu tiên',N'Khác',150000,N'Phí chọn chỗ ưu tiên'),
(N'Ưu tiên làm thủ tục',N'Khác',180000,N'Dịch vụ ưu tiên'),
(N'Gói tiện ích chuyến bay',N'Khác',250000,N'Gói dịch vụ bổ sung');


INSERT INTO HANGTHANHVIEN (TenHang, DiemChiTieuToiThieu, PhanTramGiam, MoTa)
VALUES
(N'Thành viên',0,0,N'Dưới 20 triệu đồng'),
(N'Bạc',20000000,8,N'Từ 20 triệu đồng'),
(N'Vàng',40000000,10,N'Từ 40 triệu đồng'),
(N'Bạch Kim',50000000,12,N'Từ 50 triệu đồng'),
(N'Kim Cương',100000000,15,N'Từ 100 triệu đồng');


INSERT INTO KHUYENMAI (TenKM, PhanTramGiam, GiamToiDa, NgayBatDau, NgayKetThuc, SoLuotToiDa)
VALUES
(N'Ưu đãi Tết',10,1000000,'2026-01-01','2027-03-31',NULL),
(N'Ưu đãi mùa hè',5,500000,'2026-05-01','2026-08-31',100),
(N'Ưu đãi khách hàng mới',3,300000,'2026-01-01','2027-12-31',200);

-- Không còn áp dụng ưu đãi Tết
UPDATE KHUYENMAI SET TrangThai=N'Tạm dừng' WHERE TenKM=N'Ưu đãi Tết';


-- 40 khách hàng mẫu viết tay
INSERT INTO KHACHHANG
(HoTen, LoaiGiayTo, SoGiayTo, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, MaHangTV, TongChiTieu)
VALUES
    (N'Trần Văn Long',N'CCCD','079079000001','1979-01-01',N'Nam','+84910000001','khachhang001@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Lê Ngọc Trang',N'CCCD','048178000002','1978-01-01',N'Nữ','+84910000002','khachhang002@gmail.com',N'Đà Nẵng',1,0),
    (N'Phạm Minh Khang',N'CCCD','001077000003','1977-01-01',N'Nam','+84910000003','khachhang003@gmail.com',N'Hà Nội',1,0),
    (N'Hoàng Thu Thảo',N'CCCD','079176000004','1976-01-01',N'Nữ','+84910000004','khachhang004@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Huỳnh Đức Hùng',N'Hộ chiếu','C0000005','1975-01-01',N'Nam','+84910000005','khachhang005@gmail.com',N'Đà Nẵng',1,0),
    (N'Phan Minh Phương',N'CCCD','001174000006','1974-01-01',N'Nữ','+84910000006','khachhang006@gmail.com',N'Hà Nội',1,0),
    (N'Vũ Quốc Hải',N'CCCD','079073000007','1973-01-01',N'Nam','+84910000007','khachhang007@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Võ Thanh Ngân',N'CCCD','048172000008','1972-01-01',N'Nữ','+84910000008','khachhang008@gmail.com',N'Đà Nẵng',1,0),
    (N'Đặng Hữu Dũng',N'CCCD','001071000009','1971-01-01',N'Nam','+84910000009','khachhang009@gmail.com',N'Hà Nội',1,0),
    (N'Nguyễn Thị My',N'Hộ chiếu','C0000010','1970-01-01',N'Nữ','+84910000010','khachhang010@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Trần Văn Cường',N'CCCD','048069000011','1969-01-01',N'Nam','+84910000011','khachhang011@gmail.com',N'Đà Nẵng',1,0),
    (N'Lê Ngọc Mai',N'CCCD','001168000012','1968-01-01',N'Nữ','+84910000012','khachhang012@gmail.com',N'Hà Nội',1,0),
    (N'Phạm Minh Bảo',N'CCCD','079067000013','1967-01-01',N'Nam','+84910000013','khachhang013@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Hoàng Thu Linh',N'CCCD','048166000014','1966-01-01',N'Nữ','+84910000014','khachhang014@gmail.com',N'Đà Nẵng',1,0),
    (N'Huỳnh Đức An',N'Hộ chiếu','C0000015','1965-01-01',N'Nam','+84910000015','khachhang015@gmail.com',N'Hà Nội',1,0),
    (N'Phan Minh Lan',N'CCCD','079164000016','1964-01-01',N'Nữ','+84910000016','khachhang016@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Vũ Quốc Việt',N'CCCD','048063000017','1963-01-01',N'Nam','+84910000017','khachhang017@gmail.com',N'Đà Nẵng',1,0),
    (N'Võ Thanh Hoa',N'CCCD','001162000018','1962-01-01',N'Nữ','+84910000018','khachhang018@gmail.com',N'Hà Nội',1,0),
    (N'Đặng Hữu Tuấn',N'CCCD','079061000019','1961-01-01',N'Nam','+84910000019','khachhang019@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Nguyễn Thị Hạnh',N'Hộ chiếu','C0000020','1960-01-01',N'Nữ','+84910000020','khachhang020@gmail.com',N'Đà Nẵng',1,0),
    (N'Trần Văn Thành',N'CCCD','001059000021','1959-01-01',N'Nam','+84910000021','khachhang021@gmail.com',N'Hà Nội',1,0),
    (N'Lê Ngọc Hà',N'CCCD','079158000022','1958-01-01',N'Nữ','+84910000022','khachhang022@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Phạm Minh Sơn',N'CCCD','048057000023','1957-01-01',N'Nam','+84910000023','khachhang023@gmail.com',N'Đà Nẵng',1,0),
    (N'Hoàng Thu Giang',N'CCCD','001156000024','1956-01-01',N'Nữ','+84910000024','khachhang024@gmail.com',N'Hà Nội',1,0),
    (N'Huỳnh Đức Quân',N'Hộ chiếu','C0000025','1955-01-01',N'Nam','+84910000025','khachhang025@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Phan Minh Dung',N'CCCD','048154000026','1954-01-01',N'Nữ','+84910000026','khachhang026@gmail.com',N'Đà Nẵng',1,0),
    (N'Vũ Quốc Phúc',N'CCCD','001053000027','1953-01-01',N'Nam','+84910000027','khachhang027@gmail.com',N'Hà Nội',1,0),
    (N'Võ Thanh Chi',N'CCCD','079152000028','1952-01-01',N'Nữ','+84910000028','khachhang028@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Đặng Hữu Nam',N'CCCD','048051000029','1951-01-01',N'Nam','+84910000029','khachhang029@gmail.com',N'Đà Nẵng',1,0),
    (N'Nguyễn Thị Anh',N'Hộ chiếu','C0000030','1950-01-01',N'Nữ','+84910000030','khachhang030@gmail.com',N'Hà Nội',1,0),
    (N'Trần Văn Long',N'CCCD','079049000031','1949-01-01',N'Nam','+84910000031','khachhang031@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Lê Ngọc Trang',N'CCCD','048148000032','1948-01-01',N'Nữ','+84910000032','khachhang032@gmail.com',N'Đà Nẵng',1,0),
    (N'Phạm Minh Khang',N'CCCD','001047000033','1947-01-01',N'Nam','+84910000033','khachhang033@gmail.com',N'Hà Nội',1,0),
    (N'Hoàng Thu Thảo',N'CCCD','079146000034','1946-01-01',N'Nữ','+84910000034','khachhang034@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Huỳnh Đức Hùng',N'Hộ chiếu','C0000035','1980-01-01',N'Nam','+84910000035','khachhang035@gmail.com',N'Đà Nẵng',1,0),
    (N'Phan Minh Phương',N'CCCD','001179000036','1979-01-01',N'Nữ','+84910000036','khachhang036@gmail.com',N'Hà Nội',1,0),
    (N'Vũ Quốc Hải',N'CCCD','079078000037','1978-01-01',N'Nam','+84910000037','khachhang037@gmail.com',N'TP. Hồ Chí Minh',1,0),
    (N'Võ Thanh Ngân',N'CCCD','048177000038','1977-01-01',N'Nữ','+84910000038','khachhang038@gmail.com',N'Đà Nẵng',1,0),
    (N'Đặng Hữu Dũng',N'CCCD','001076000039','1976-01-01',N'Nam','+84910000039','khachhang039@gmail.com',N'Hà Nội',1,0),
    (N'Nguyễn Thị My',N'Hộ chiếu','C0000040','1975-01-01',N'Nữ','+84910000040','khachhang040@gmail.com',N'TP. Hồ Chí Minh',1,0);

-- 46 chuyến bay mẫu viết tay
INSERT INTO CHUYENBAY
(MaMayBay, MaSanBayDi, MaSanBayDen, NgayGioKhoiHanh, ThoiGianBayPhut, TrangThai, NguoiTao)
VALUES
    (4,'HAN','SGN','2026-11-16T09:00:00',125,N'Đang mở bán',1),
    (3,'SGN','HAN','2026-11-17T12:00:00',125,N'Đang mở bán',1),
    (2,'HAN','DAD','2026-11-18T15:00:00',80,N'Đang mở bán',1),
    (1,'DAD','HAN','2026-11-19T06:00:00',80,N'Đang mở bán',1),
    (4,'HAN','PQC','2026-11-20T09:00:00',130,N'Đang mở bán',1),
    (3,'PQC','HAN','2026-11-21T12:00:00',130,N'Đang mở bán',1),
    (2,'SGN','DAD','2026-11-22T15:00:00',85,N'Đang mở bán',1),
    (1,'DAD','SGN','2026-11-23T06:00:00',85,N'Đang mở bán',1),
    (4,'SGN','PQC','2026-11-24T09:00:00',60,N'Đang mở bán',1),
    (3,'PQC','SGN','2026-11-25T12:00:00',60,N'Đang mở bán',1),
    (2,'HAN','CXR','2026-11-26T15:00:00',115,N'Đang mở bán',1),
    (1,'CXR','HAN','2026-11-27T06:00:00',115,N'Đang mở bán',1),
    (4,'SGN','DLI','2026-11-28T09:00:00',55,N'Đang mở bán',1),
    (3,'DLI','SGN','2026-11-29T12:00:00',55,N'Đang mở bán',1),
    (2,'HAN','VCA','2026-11-30T15:00:00',130,N'Đang mở bán',1),
    (1,'VCA','HAN','2026-12-01T06:00:00',130,N'Đang mở bán',1),
    (4,'HPH','VCA','2026-12-02T09:00:00',110,N'Đang mở bán',1),
    (3,'VCA','HPH','2026-12-03T12:00:00',110,N'Đang mở bán',1),
    (2,'HAN','NRT','2026-12-04T15:00:00',300,N'Đang mở bán',1),
    (1,'NRT','HAN','2026-12-05T06:00:00',300,N'Đang mở bán',1),
    (4,'SGN','NRT','2026-12-06T09:00:00',330,N'Đang mở bán',1),
    (3,'NRT','SGN','2026-12-07T12:00:00',330,N'Đang mở bán',1),
    (2,'HAN','ICN','2026-12-08T15:00:00',270,N'Đang mở bán',1),
    (1,'ICN','HAN','2026-12-09T06:00:00',270,N'Đang mở bán',1),
    (4,'SGN','ICN','2026-12-10T09:00:00',300,N'Đang mở bán',1),
    (3,'ICN','SGN','2026-12-11T12:00:00',300,N'Đang mở bán',1),
    (2,'HAN','HKG','2026-12-12T15:00:00',150,N'Đang mở bán',1),
    (1,'HKG','HAN','2026-12-13T06:00:00',150,N'Đang mở bán',1),
    (4,'SGN','HKG','2026-11-16T09:00:00',170,N'Đang mở bán',1),
    (3,'HKG','SGN','2026-11-17T12:00:00',170,N'Đang mở bán',1),
    (2,'HAN','SIN','2026-11-18T15:00:00',190,N'Đang mở bán',1),
    (1,'SIN','HAN','2026-11-19T06:00:00',190,N'Đang mở bán',1),
    (4,'SGN','SIN','2026-11-20T09:00:00',150,N'Đang mở bán',1),
    (3,'SIN','SGN','2026-11-21T12:00:00',150,N'Đang mở bán',1),
    (2,'HAN','SYD','2026-11-22T15:00:00',570,N'Đang mở bán',1),
    (1,'SYD','HAN','2026-11-23T06:00:00',570,N'Đang mở bán',1),
    (4,'SGN','SYD','2026-11-24T09:00:00',510,N'Đang mở bán',1),
    (3,'SYD','SGN','2026-11-25T12:00:00',510,N'Đang mở bán',1),
    (2,'HAN','SVO','2026-11-26T15:00:00',600,N'Đang mở bán',1),
    (1,'SVO','HAN','2026-11-27T06:00:00',600,N'Đang mở bán',1),
    (4,'SGN','SVO','2026-11-28T09:00:00',620,N'Đang mở bán',1),
    (3,'SVO','SGN','2026-11-29T12:00:00',620,N'Đang mở bán',1),
    (2,'HAN','MAN','2026-11-30T15:00:00',780,N'Đang mở bán',1),
    (1,'MAN','HAN','2026-12-01T06:00:00',780,N'Đang mở bán',1),
    (4,'SGN','MAN','2026-12-02T09:00:00',800,N'Đang mở bán',1),
    (3,'MAN','SGN','2026-12-03T12:00:00',800,N'Đang mở bán',1);
GO

-- Giá vé mẫu viết tay
INSERT INTO GIAVE (MaChuyenBay, MaHangVe, DonGia)
VALUES
    (1,1,900000),
    (1,2,1500000),
    (1,3,2800000),
    (2,1,900000),
    (2,2,1500000),
    (2,3,2800000),
    (3,1,900000),
    (3,2,1500000),
    (3,3,2800000),
    (4,1,900000),
    (4,2,1500000),
    (4,3,2800000),
    (5,1,900000),
    (5,2,1500000),
    (5,3,2800000),
    (6,1,900000),
    (6,2,1500000),
    (6,3,2800000),
    (7,1,900000),
    (7,2,1500000),
    (7,3,2800000),
    (8,1,900000),
    (8,2,1500000),
    (8,3,2800000),
    (9,1,900000),
    (9,2,1500000),
    (9,3,2800000),
    (10,1,900000),
    (10,2,1500000),
    (10,3,2800000),
    (11,1,900000),
    (11,2,1500000),
    (11,3,2800000),
    (12,1,900000),
    (12,2,1500000),
    (12,3,2800000),
    (13,1,900000),
    (13,2,1500000),
    (13,3,2800000),
    (14,1,900000),
    (14,2,1500000),
    (14,3,2800000),
    (15,1,900000),
    (15,2,1500000),
    (15,3,2800000),
    (16,1,900000),
    (16,2,1500000),
    (16,3,2800000),
    (17,1,900000),
    (17,2,1500000),
    (17,3,2800000),
    (18,1,900000),
    (18,2,1500000),
    (18,3,2800000),
    (19,1,2500000),
    (19,2,4200000),
    (19,3,8500000),
    (20,1,2500000),
    (20,2,4200000),
    (20,3,8500000),
    (21,1,2500000),
    (21,2,4200000),
    (21,3,8500000),
    (22,1,2500000),
    (22,2,4200000),
    (22,3,8500000),
    (23,1,2500000),
    (23,2,4200000),
    (23,3,8500000),
    (24,1,2500000),
    (24,2,4200000),
    (24,3,8500000),
    (25,1,2500000),
    (25,2,4200000),
    (25,3,8500000),
    (26,1,2500000),
    (26,2,4200000),
    (26,3,8500000),
    (27,1,2500000),
    (27,2,4200000),
    (27,3,8500000),
    (28,1,2500000),
    (28,2,4200000),
    (28,3,8500000),
    (29,1,2500000),
    (29,2,4200000),
    (29,3,8500000),
    (30,1,2500000),
    (30,2,4200000),
    (30,3,8500000),
    (31,1,2500000),
    (31,2,4200000),
    (31,3,8500000),
    (32,1,2500000),
    (32,2,4200000),
    (32,3,8500000),
    (33,1,2500000),
    (33,2,4200000),
    (33,3,8500000),
    (34,1,2500000),
    (34,2,4200000),
    (34,3,8500000),
    (35,1,6500000),
    (35,2,9500000),
    (35,3,18000000),
    (36,1,6500000),
    (36,2,9500000),
    (36,3,18000000),
    (37,1,6500000),
    (37,2,9500000),
    (37,3,18000000),
    (38,1,6500000),
    (38,2,9500000),
    (38,3,18000000),
    (39,1,6500000),
    (39,2,9500000),
    (39,3,18000000),
    (40,1,6500000),
    (40,2,9500000),
    (40,3,18000000),
    (41,1,6500000),
    (41,2,9500000),
    (41,3,18000000),
    (42,1,6500000),
    (42,2,9500000),
    (42,3,18000000),
    (43,1,6500000),
    (43,2,9500000),
    (43,3,18000000),
    (44,1,6500000),
    (44,2,9500000),
    (44,3,18000000),
    (45,1,6500000),
    (45,2,9500000),
    (45,3,18000000),
    (46,1,6500000),
    (46,2,9500000),
    (46,3,18000000);
GO

INSERT INTO GHECHUYENBAY (MaChuyenBay, MaGhe, TrangThai)
SELECT cb.MaChuyenBay, g.MaGhe, N'Trống'
FROM CHUYENBAY cb
JOIN GHE g ON g.MaMayBay = cb.MaMayBay;
GO

-- 10 đơn và 12 vé mẫu
INSERT INTO DONDATVE
(MaKHLienHe,MaTKNhanVien,MaKM,NgayDat,TongTienVe,TongTienDichVu,TienGiamKM,TongThanhToan,TrangThai)
VALUES
(1,2,NULL,DATEADD(DAY,-12,SYSDATETIME()),900000,0,0,900000,N'Đã thanh toán'),
(2,2,NULL,DATEADD(DAY,-11,SYSDATETIME()),900000,0,0,900000,N'Đã thanh toán'),
(3,3,NULL,DATEADD(DAY,-10,SYSDATETIME()),900000,0,0,900000,N'Đã thanh toán'),
(4,3,NULL,DATEADD(DAY,-9,SYSDATETIME()),900000,0,0,900000,N'Đã thanh toán'),
(5,2,NULL,DATEADD(DAY,-8,SYSDATETIME()),1620000,0,180000,1620000,N'Đã thanh toán'),
(6,4,NULL,DATEADD(DAY,-7,SYSDATETIME()),4500000,0,500000,4500000,N'Đã thanh toán'),
(7,2,NULL,DATEADD(DAY,-2,SYSDATETIME()),900000,0,0,900000,N'Chờ thanh toán'),
(8,3,NULL,DATEADD(DAY,-6,SYSDATETIME()),900000,470000,0,1370000,N'Đã thanh toán'),
(9,4,NULL,DATEADD(DAY,-5,SYSDATETIME()),900000,0,0,900000,N'Đã hủy'),
(10,2,3,DATEADD(DAY,-4,SYSDATETIME()),873000,0,27000,873000,N'Đã thanh toán');
GO

-- 12 vé mẫu viết tay
INSERT INTO VE
(MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,
 PhanTramGiamHang,PhanTramGiamTet,PhanTramGiamKhuHoi,PhanTramGiamKM,
 TongPhanTramGiam,TienGiam,GiaThucTra,TrangThai)
VALUES
    (1,1,189,1,1,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (2,2,133,1,2,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (3,3,77,1,3,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (4,4,21,1,4,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (5,5,189,1,5,NULL,900000,0,0,10,0,10,90000,810000,N'Đã đặt'),
    (5,6,133,1,5,NULL,900000,0,0,10,0,10,90000,810000,N'Đã đặt'),
    (6,19,77,1,6,NULL,2500000,0,0,10,0,10,250000,2250000,N'Đã đặt'),
    (6,20,21,1,6,NULL,2500000,0,0,10,0,10,250000,2250000,N'Đã đặt'),
    (7,7,77,1,7,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (8,8,21,1,8,NULL,900000,0,0,0,0,0,0,900000,N'Đã đặt'),
    (9,9,189,1,9,NULL,900000,0,0,0,0,0,0,900000,N'Đã hủy'),
    (10,10,133,1,10,NULL,900000,0,0,0,3,3,27000,873000,N'Đã đặt');
GO

INSERT INTO VEDICHVU(MaVe,MaDichVu,SoLuong,DonGia)
SELECT v.MaVe,dv.MaDichVu,1,dv.DonGia
FROM VE v
JOIN DICHVU dv ON dv.TenDichVu IN (N'Hành lý ký gửi thêm 10kg',N'Suất ăn tiêu chuẩn')
WHERE v.MaDon=8;
GO

INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,NgayThanhToan,MaTKNhanVien,TrangThai,GhiChu)
VALUES
(1,900000,N'Tiền mặt',DATEADD(DAY,-12,SYSDATETIME()),2,N'Thành công',N'Thanh toán trong nước'),
(2,900000,N'Chuyển khoản',DATEADD(DAY,-11,SYSDATETIME()),2,N'Thành công',N'Thanh toán trong nước'),
(3,900000,N'Thẻ',DATEADD(DAY,-10,SYSDATETIME()),3,N'Thành công',N'Thanh toán trong nước'),
(4,900000,N'Tiền mặt',DATEADD(DAY,-9,SYSDATETIME()),3,N'Thành công',N'Thanh toán trong nước'),
(5,1620000,N'Chuyển khoản',DATEADD(DAY,-8,SYSDATETIME()),2,N'Thành công',N'Thanh toán khứ hồi'),
(6,4500000,N'Thẻ',DATEADD(DAY,-7,SYSDATETIME()),4,N'Thành công',N'Thanh toán khứ hồi quốc tế'),
(8,1370000,N'Tiền mặt',DATEADD(DAY,-6,SYSDATETIME()),3,N'Thành công',N'Đã gồm dịch vụ'),
(9,900000,N'Thẻ',DATEADD(DAY,-5,SYSDATETIME()),4,N'Thành công',N'Vé đã mua trước khi hủy'),
(10,873000,N'Chuyển khoản',DATEADD(DAY,-4,SYSDATETIME()),2,N'Thành công',N'Áp dụng mã khuyến mãi');
GO

INSERT INTO HUYVE(MaVe,NgayHuy,LyDo,PhiHuy,TienHoan,MaTKNhanVien)
SELECT MaVe,DATEADD(DAY,-3,SYSDATETIME()),N'Khách thay đổi kế hoạch',90000,810000,4
FROM VE WHERE MaDon=9;
INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,NgayThanhToan,MaTKNhanVien,TrangThai,GhiChu)
VALUES(9,810000,N'Tiền mặt',DATEADD(DAY,-3,SYSDATETIME()),4,N'Đã hoàn',N'Hoàn tiền vé đã hủy');
UPDATE GHECHUYENBAY
SET TrangThai=N'Đã đặt'
WHERE EXISTS
(
    SELECT 1 FROM VE v
    WHERE v.MaChuyenBay=GHECHUYENBAY.MaChuyenBay
      AND v.MaGhe=GHECHUYENBAY.MaGhe AND v.TrangThai<>N'Đã hủy'
);
UPDATE DONDATVE SET TrangThai=N'Đã hủy' WHERE MaDon=9;
UPDATE KHUYENMAI SET SoLuotDaDung=1 WHERE MaKM=3;


-- Cập nhật chi tiêu mẫu theo giao dịch
CREATE TABLE #ThanhToanDau
(
    MaDon INT PRIMARY KEY,
    NgayThanhToanDau DATETIME2
);
INSERT INTO #ThanhToanDau(MaDon,NgayThanhToanDau)
SELECT MaDon,MIN(NgayThanhToan)
FROM THANHTOAN
WHERE TrangThai=N'Thành công'
GROUP BY MaDon;

CREATE TABLE #ChiTieuMau
(
    MaKH INT PRIMARY KEY,
    TongChiTieu MONEY,
    NgayDauTien DATETIME2 NULL
);
INSERT INTO #ChiTieuMau(MaKH,TongChiTieu,NgayDauTien)
SELECT v.MaKH,
       SUM(CASE WHEN p.MaDon IS NOT NULL
                THEN v.GiaThucTra+ISNULL(dv.TienDV,0)-ISNULL(h.TienHoan,0)
                ELSE 0 END),
       MIN(p.NgayThanhToanDau)
FROM VE v
JOIN DONDATVE dd ON dd.MaDon=v.MaDon
LEFT JOIN #ThanhToanDau p ON p.MaDon=dd.MaDon
LEFT JOIN
(
    SELECT MaVe,SUM(ThanhTien) AS TienDV
    FROM VEDICHVU
    GROUP BY MaVe
) dv ON dv.MaVe=v.MaVe
LEFT JOIN
(
    SELECT MaVe,SUM(TienHoan) AS TienHoan
    FROM HUYVE
    GROUP BY MaVe
) h ON h.MaVe=v.MaVe
GROUP BY v.MaKH;

UPDATE kh
SET TongChiTieu=ISNULL(x.TongChiTieu,0),
    NgayGiaoDichDauTien=x.NgayDauTien,
    NgayKetThucThanhVien=CASE WHEN x.NgayDauTien IS NULL THEN NULL ELSE DATEADD(YEAR,1,x.NgayDauTien) END,
    MaHangTV=CASE WHEN x.NgayDauTien IS NULL OR DATEADD(YEAR,1,x.NgayDauTien)<SYSDATETIME() THEN 1
                  ELSE ISNULL((SELECT TOP 1 h.MaHangTV FROM HANGTHANHVIEN h
                               WHERE h.DiemChiTieuToiThieu<=ISNULL(x.TongChiTieu,0)
                               ORDER BY h.DiemChiTieuToiThieu DESC),1) END
FROM KHACHHANG kh
LEFT JOIN #ChiTieuMau x ON x.MaKH=kh.MaKH;

DROP TABLE #ChiTieuMau;
DROP TABLE #ThanhToanDau;
GO


/* TRIGGER: trg_GHINHATKY */
CREATE TRIGGER trg_GHINHATKY
ON TAIKHOAN
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO NHATKYHOATDONG (MaTK, HanhDong, DoiTuong, NoiDung)
    SELECT ISNULL(i.MaTK,d.MaTK),
           CASE WHEN i.MaTK IS NULL THEN N'DELETE'
                WHEN d.MaTK IS NULL THEN N'INSERT'
                ELSE N'UPDATE' END,
           N'TAIKHOAN',
           CONCAT(N'Tài khoản: ', ISNULL(i.TenDangNhap,d.TenDangNhap))
    FROM inserted i
    FULL JOIN deleted d ON i.MaTK = d.MaTK;
END;


INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung)
VALUES
(1,N'Khởi tạo',N'Hệ thống',N'Khởi tạo dữ liệu mẫu'),
(2,N'Đặt vé',N'DONDATVE',N'Tạo đơn đặt vé mẫu'),
(3,N'Thanh toán',N'DONDATVE',N'Thanh toán đơn mẫu'),
(4,N'Hủy vé',N'VE',N'Hủy vé mẫu');
GO


-- View chi tiết chuyến bay
CREATE VIEW V_CHUYENBAYCHITIET
AS
SELECT cb.MaChuyenBay, sb1.MaSanBay AS MaSanBayDi, sb1.TenSanBay AS SanBayDi,
       sb1.ThanhPho AS ThanhPhoDi, sb2.MaSanBay AS MaSanBayDen,
       sb2.TenSanBay AS SanBayDen, sb2.ThanhPho AS ThanhPhoDen,
       cb.NgayGioKhoiHanh, DATEADD(MINUTE,cb.ThoiGianBayPhut,cb.NgayGioKhoiHanh) AS NgayGioDenDuKien,
       cb.ThoiGianBayPhut, mb.SoHieu, cb.TrangThai,
       ISNULL(gv.GiaThapNhat,0) AS GiaThapNhat,
       ISNULL(gc.SoGheTrong,0) AS SoGheTrong
FROM CHUYENBAY cb
JOIN SANBAY sb1 ON cb.MaSanBayDi=sb1.MaSanBay
JOIN SANBAY sb2 ON cb.MaSanBayDen=sb2.MaSanBay
JOIN MAYBAY mb ON cb.MaMayBay=mb.MaMayBay
LEFT JOIN (SELECT MaChuyenBay,MIN(DonGia) AS GiaThapNhat FROM GIAVE GROUP BY MaChuyenBay) gv
       ON gv.MaChuyenBay=cb.MaChuyenBay
LEFT JOIN (SELECT MaChuyenBay,COUNT(*) AS SoGheTrong FROM GHECHUYENBAY WHERE TrangThai=N'Trống' GROUP BY MaChuyenBay) gc
       ON gc.MaChuyenBay=cb.MaChuyenBay;
GO

/* VIEW: V_VECHITIET */
CREATE VIEW V_VECHITIET
AS
SELECT v.MaVe, v.MaDon, v.MaKH, kh.HoTen AS TenHanhKhach,
       v.MaChuyenBay, cb.MaSanBayDi, sb1.ThanhPho AS ThanhPhoDi,
       cb.MaSanBayDen, sb2.ThanhPho AS ThanhPhoDen,
       cb.NgayGioKhoiHanh, g.SoGhe, hv.TenHangVe,
       v.GiaGoc, v.TongPhanTramGiam, v.TienGiam, v.GiaThucTra, v.TrangThai,
       dd.TrangThai AS TrangThaiDon
FROM VE v
JOIN KHACHHANG kh ON v.MaKH = kh.MaKH
JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay
JOIN SANBAY sb1 ON cb.MaSanBayDi = sb1.MaSanBay
JOIN SANBAY sb2 ON cb.MaSanBayDen = sb2.MaSanBay
JOIN GHE g ON v.MaGhe = g.MaGhe
JOIN HANGVE hv ON v.MaHangVe = hv.MaHangVe
JOIN DONDATVE dd ON v.MaDon = dd.MaDon;
GO

/* VIEW: V_DOANHTHUTHEOTHANG */
CREATE VIEW V_DOANHTHUTHEOTHANG
AS
SELECT YEAR(tt.NgayThanhToan) AS Nam,
       MONTH(tt.NgayThanhToan) AS Thang,
       SUM(CASE WHEN tt.TrangThai=N'Thành công' THEN tt.SoTien
                WHEN tt.TrangThai=N'Đã hoàn' THEN -tt.SoTien ELSE 0 END) AS DoanhThuThuan,
       SUM(CASE WHEN tt.TrangThai=N'Thành công' THEN tt.SoTien ELSE 0 END) AS TongTienThu,
       SUM(CASE WHEN tt.TrangThai=N'Đã hoàn' THEN tt.SoTien ELSE 0 END) AS TongTienHoan,
       COUNT(DISTINCT CASE WHEN tt.TrangThai=N'Thành công' THEN tt.MaDon END) AS SoDonThanhToan
FROM THANHTOAN tt
WHERE tt.TrangThai IN (N'Thành công',N'Đã hoàn')
GROUP BY YEAR(tt.NgayThanhToan), MONTH(tt.NgayThanhToan);
GO

-- View doanh thu theo chuyến bay
CREATE VIEW V_DOANHTHUTHEOCHUYENBAY
AS
SELECT cb.MaChuyenBay, sb1.ThanhPho AS ThanhPhoDi, sb2.ThanhPho AS ThanhPhoDen,
       cb.NgayGioKhoiHanh,
       COUNT(CASE WHEN v.TrangThai<>N'Đã hủy' THEN 1 END) AS SoVeConHieuLuc,
       SUM(CASE WHEN v.TrangThai<>N'Đã hủy' THEN v.GiaThucTra ELSE 0 END) AS DoanhThuVe,
       ISNULL(dv.TongTienDichVu,0) AS DoanhThuDichVu
FROM CHUYENBAY cb
JOIN SANBAY sb1 ON cb.MaSanBayDi=sb1.MaSanBay
JOIN SANBAY sb2 ON cb.MaSanBayDen=sb2.MaSanBay
LEFT JOIN VE v ON cb.MaChuyenBay=v.MaChuyenBay
LEFT JOIN
(
    SELECT v2.MaChuyenBay,SUM(vd.ThanhTien) AS TongTienDichVu
    FROM VE v2 JOIN VEDICHVU vd ON vd.MaVe=v2.MaVe
    WHERE v2.TrangThai<>N'Đã hủy'
    GROUP BY v2.MaChuyenBay
) dv ON dv.MaChuyenBay=cb.MaChuyenBay
GROUP BY cb.MaChuyenBay,sb1.ThanhPho,sb2.ThanhPho,cb.NgayGioKhoiHanh,dv.TongTienDichVu;
GO

/* VIEW: V_KHACHHANGTHANHVIEN */
CREATE VIEW V_KHACHHANGTHANHVIEN
AS
SELECT kh.MaKH, kh.HoTen, kh.SoGiayTo, kh.SoDienThoai, kh.Email,
       htv.TenHang, htv.PhanTramGiam, kh.TongChiTieu,
       kh.NgayGiaoDichDauTien, kh.NgayKetThucThanhVien,
       CASE WHEN kh.NgayKetThucThanhVien IS NOT NULL AND kh.NgayKetThucThanhVien < SYSDATETIME()
            THEN N'Hết hạn' ELSE N'Còn hiệu lực' END AS TrangThaiThanhVien
FROM KHACHHANG kh
JOIN HANGTHANHVIEN htv ON kh.MaHangTV = htv.MaHangTV;
GO

/* VIEW: V_SODOGHECHUYENBAY */
CREATE VIEW V_SODOGHECHUYENBAY
AS
SELECT 
    gcb.MaChuyenBay,
    gcb.MaGhe,
    g.SoGhe,
    g.SoHang,
    g.CotGhe,
    hv.MaHangVe,
    hv.TenHangVe,
    gcb.TrangThai AS TrangThaiGhe
FROM GHECHUYENBAY gcb
JOIN GHE g ON gcb.MaGhe = g.MaGhe
JOIN HANGVE hv ON g.MaHangVe = hv.MaHangVe;
GO

-- View lịch sử giao dịch
CREATE VIEW V_LICHSUGIAODICH
AS
SELECT dd.MaDon, dd.NgayDat, dd.MaKHLienHe, kh.HoTen AS KhachHangLienHe,
       dd.TrangThai, dd.TongTienVe, dd.TongTienDichVu, dd.TienGiamKM, dd.TongThanhToan,
       ISNULL(tt.TongDaThu,0) AS TongDaThu,
       ISNULL(hv.TongTienHoan,0) AS TongTienHoan
FROM DONDATVE dd
JOIN KHACHHANG kh ON dd.MaKHLienHe=kh.MaKH
LEFT JOIN (SELECT MaDon,SUM(SoTien) AS TongDaThu FROM THANHTOAN WHERE TrangThai=N'Thành công' GROUP BY MaDon) tt
       ON tt.MaDon=dd.MaDon
LEFT JOIN
(
    SELECT v.MaDon,SUM(h.TienHoan) AS TongTienHoan
    FROM HUYVE h JOIN VE v ON v.MaVe=h.MaVe
    GROUP BY v.MaDon
) hv ON hv.MaDon=dd.MaDon;
GO


-- Thủ tục đăng nhập

-- (4) thủ tục đơn giản: đăng nhập
CREATE PROCEDURE sp_DANGNHAP
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaTK, TenDangNhap, HoTen, Email, VaiTro, TrangThai
    FROM TAIKHOAN
    WHERE TenDangNhap = @TenDangNhap
      AND MatKhau = @MatKhau
      AND TrangThai = N'Hoạt động';
END;
GO

-- (4) thủ tục đơn giản: tìm chuyến bay
CREATE PROCEDURE sp_TIMKIEMCHUYENBAY
    @MaSanBayDi CHAR(3),
    @MaSanBayDen CHAR(3),
    @NgayDi DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM V_CHUYENBAYCHITIET
    WHERE MaSanBayDi = @MaSanBayDi
      AND MaSanBayDen = @MaSanBayDen
      AND NgayGioKhoiHanh >= @NgayDi
      AND NgayGioKhoiHanh < DATEADD(DAY,1,@NgayDi)
      AND TrangThai = N'Đang mở bán'
      AND NgayGioKhoiHanh > SYSDATETIME()
      AND SoGheTrong > 0
    ORDER BY NgayGioKhoiHanh;
END;
GO

-- (4) thủ tục đơn giản: tạo chuyến bay
CREATE PROCEDURE sp_TAOCHUYENBAY
    @MaMayBay INT,
    @MaSanBayDi CHAR(3),
    @MaSanBayDen CHAR(3),
    @NgayGioKhoiHanh DATETIME2,
    @ThoiGianBayPhut INT,
    @NguoiTao INT,
    @GiaPhoThong MONEY,
    @GiaPhoThongDacBiet MONEY,
    @GiaThuongGia MONEY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- bắt đầu giao dịch tạo chuyến bay
        BEGIN TRANSACTION;
        IF @NgayGioKhoiHanh <= SYSDATETIME()
            THROW 50010, N'Giờ khởi hành phải ở tương lai.', 1;
        IF @MaSanBayDi = @MaSanBayDen
            THROW 50011, N'Sân bay đi và đến phải khác nhau.', 1;
        IF NOT EXISTS (SELECT 1 FROM MAYBAY WHERE MaMayBay=@MaMayBay AND TrangThai=N'Hoạt động')
            THROW 50012, N'Máy bay không hoạt động hoặc không tồn tại.', 1;
        IF NOT EXISTS (SELECT 1 FROM SANBAY WHERE MaSanBay=@MaSanBayDi AND TrangThai=N'Hoạt động')
           OR NOT EXISTS (SELECT 1 FROM SANBAY WHERE MaSanBay=@MaSanBayDen AND TrangThai=N'Hoạt động')
            THROW 50013, N'Sân bay không hoạt động hoặc không tồn tại.', 1;

        INSERT INTO CHUYENBAY(MaMayBay,MaSanBayDi,MaSanBayDen,NgayGioKhoiHanh,ThoiGianBayPhut,TrangThai,NguoiTao)
        VALUES(@MaMayBay,@MaSanBayDi,@MaSanBayDen,@NgayGioKhoiHanh,@ThoiGianBayPhut,N'Đang mở bán',@NguoiTao);

        DECLARE @MaChuyenBay INT = SCOPE_IDENTITY();

        INSERT INTO GIAVE(MaChuyenBay,MaHangVe,DonGia)
        VALUES(@MaChuyenBay,1,@GiaPhoThong),
              (@MaChuyenBay,2,@GiaPhoThongDacBiet),
              (@MaChuyenBay,3,@GiaThuongGia);

        INSERT INTO GHECHUYENBAY(MaChuyenBay,MaGhe,TrangThai)
        SELECT @MaChuyenBay,MaGhe,N'Trống'
        FROM GHE WHERE MaMayBay=@MaMayBay;

        COMMIT TRANSACTION;
        SELECT @MaChuyenBay AS MaChuyenBay;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- (4) thủ tục đơn giản: tạo máy bay và ghế
CREATE PROCEDURE sp_TAOMAYBAYVAGHE
    @SoHieu VARCHAR(20),
    @HangSanXuat NVARCHAR(60),
    @LoaiMayBay NVARCHAR(60),
    @SoHangThuongGia INT = 2,
    @SoHangPTDB INT = 2,
    @SoHangPhoThong INT = 6
AS
BEGIN
    SET NOCOUNT ON;
    /* Hạng chia theo hàng từ mũi về đuôi: Thương gia (2-2: A C | D F),
       Phổ thông đặc biệt rồi Phổ thông (3-3: A B C | D E F). */
    IF @SoHangThuongGia < 0 OR @SoHangPTDB < 0 OR @SoHangPhoThong < 1
        THROW 50020, N'Số hàng không hợp lệ (cần ít nhất 1 hàng Phổ thông).', 1;
    DECLARE @SoHang INT = @SoHangThuongGia + @SoHangPTDB + @SoHangPhoThong;
    IF @SoHang > 60
        THROW 50020, N'Tổng số hàng ghế không được vượt quá 60.', 1;
    IF EXISTS (SELECT 1 FROM MAYBAY WHERE SoHieu=@SoHieu)
        THROW 50021, N'Số hiệu máy bay đã tồn tại.', 1;

    BEGIN TRY
        -- bắt đầu giao dịch tạo máy bay
        BEGIN TRANSACTION;
        INSERT INTO MAYBAY(SoHieu,HangSanXuat,LoaiMayBay)
        VALUES(@SoHieu,@HangSanXuat,@LoaiMayBay);
        DECLARE @MaMayBay INT = SCOPE_IDENTITY();

        DECLARE @Hang INT = 1, @MaHangVe INT;
        WHILE @Hang <= @SoHang
        BEGIN
            SET @MaHangVe =
                CASE WHEN @Hang <= @SoHangThuongGia THEN 3
                     WHEN @Hang <= @SoHangThuongGia + @SoHangPTDB THEN 2
                     ELSE 1 END;
            IF @MaHangVe=3
                INSERT INTO GHE(MaMayBay,SoGhe,SoHang,CotGhe,MaHangVe)
                VALUES (@MaMayBay,CONCAT(@Hang,'A'),@Hang,'A',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'C'),@Hang,'C',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'D'),@Hang,'D',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'F'),@Hang,'F',@MaHangVe);
            ELSE
                INSERT INTO GHE(MaMayBay,SoGhe,SoHang,CotGhe,MaHangVe)
                VALUES (@MaMayBay,CONCAT(@Hang,'A'),@Hang,'A',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'B'),@Hang,'B',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'C'),@Hang,'C',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'D'),@Hang,'D',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'E'),@Hang,'E',@MaHangVe),
                       (@MaMayBay,CONCAT(@Hang,'F'),@Hang,'F',@MaHangVe);

            SET @Hang = @Hang + 1;
        END;
        COMMIT TRANSACTION;
        SELECT @MaMayBay AS MaMayBay;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- (5) tính thử giá vé
CREATE PROCEDURE sp_TINHTHUGIAVE
    @MaChuyenBay INT,
    @MaHangVe INT,
    @MaKH INT,
    @ApDungTet BIT = 0,
    @ApDungKhuHoi BIT = 0,
    @MaKM INT = NULL,
    @MaChuyenBayKhuHoi INT = NULL,
    @SoVeTetTrongDon INT = 1,
    @MaKHLienHe INT = NULL   -- khách liên hệ của đơn; NULL thì coi hành khách là khách liên hệ
AS
BEGIN
    SET NOCOUNT ON;

    -- Bước 1: khai báo biến
    DECLARE @NgayHienTai DATE=CONVERT(DATE,GETDATE());
    DECLARE @GiaGoc MONEY,@TienGiam MONEY=0,@GiaThucTra MONEY=0;
    DECLARE @GiamHang INT=0,@GiamTet INT=0,@GiamKhuHoi INT=0,@GiamKM INT=0,@TongGiam INT=0;
    DECLARE @PhanTramKM INT=0,@GiamToiDa MONEY=NULL,@TenKM NVARCHAR(100)=NULL;

    -- Bước 2: kiểm tra dữ liệu chính
    IF NOT EXISTS(SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKH)
        THROW 50071, N'Khách hàng không tồn tại.', 1;
    IF NOT EXISTS(SELECT 1 FROM CHUYENBAY WHERE MaChuyenBay=@MaChuyenBay AND TrangThai=N'Đang mở bán' AND NgayGioKhoiHanh>SYSDATETIME())
        THROW 50072, N'Chuyến bay không tồn tại, đã đóng hoặc đã khởi hành.', 1;

    SELECT @GiaGoc=gv.DonGia
    FROM GIAVE gv JOIN HANGVE hv ON hv.MaHangVe=gv.MaHangVe
    WHERE gv.MaChuyenBay=@MaChuyenBay AND gv.MaHangVe=@MaHangVe AND hv.TrangThai=N'Hoạt động';
    IF @GiaGoc IS NULL
        THROW 50073, N'Không tìm thấy giá cho hạng vé đã chọn.', 1;

    -- Bước 3: giảm theo hạng thành viên
    SELECT @GiamHang=CASE WHEN kh.NgayKetThucThanhVien IS NOT NULL AND kh.NgayKetThucThanhVien<SYSDATETIME()
                          THEN 0 ELSE ISNULL(htv.PhanTramGiam,0) END
    FROM KHACHHANG kh JOIN HANGTHANHVIEN htv ON htv.MaHangTV=kh.MaHangTV
    WHERE kh.MaKH=@MaKH;

    -- Bước 4: ưu đãi Tết đã bỏ, giữ tham số để không làm hỏng C# cũ
    SET @GiamTet=0;

    -- Bước 5: SQL tự nhận diện khứ hồi nếu có chuyến chiều về
    IF @MaChuyenBayKhuHoi IS NOT NULL AND EXISTS
    (
        SELECT 1 FROM CHUYENBAY a JOIN CHUYENBAY b ON b.MaChuyenBay=@MaChuyenBayKhuHoi
        WHERE a.MaChuyenBay=@MaChuyenBay
          AND a.MaSanBayDi=b.MaSanBayDen AND a.MaSanBayDen=b.MaSanBayDi
          AND b.TrangThai=N'Đang mở bán' AND b.NgayGioKhoiHanh>SYSDATETIME()
    )
        SET @GiamKhuHoi=10;

    -- Bước 6: kiểm tra khuyến mãi
    IF @MaKM IS NOT NULL
    BEGIN
        SELECT @TenKM=TenKM,@PhanTramKM=PhanTramGiam,@GiamToiDa=GiamToiDa
        FROM KHUYENMAI
        WHERE MaKM=@MaKM AND TrangThai=N'Hoạt động'
          AND @NgayHienTai BETWEEN NgayBatDau AND NgayKetThuc
          AND (SoLuotToiDa IS NULL OR SoLuotDaDung<SoLuotToiDa);

        IF @TenKM IS NULL
            THROW 50079, N'Mã khuyến mãi không hợp lệ, hết hạn hoặc hết lượt.', 1;
        IF @TenKM=N'Ưu đãi Tết'
            THROW 50080, N'Ưu đãi Tết được áp dụng riêng, không chọn trong danh sách khuyến mãi.', 1;
        -- Cùng quy tắc với sp_TAODONNHIEUVE: xét theo khách liên hệ của đơn
        IF @TenKM=N'Ưu đãi khách hàng mới' AND EXISTS(SELECT 1 FROM DONDATVE WHERE MaKHLienHe=ISNULL(@MaKHLienHe,@MaKH))
            THROW 50081, N'Ưu đãi khách hàng mới chỉ áp dụng cho lần đặt vé đầu tiên.', 1;

        IF @GiamToiDa IS NULL SET @GiamKM=@PhanTramKM;
        ELSE IF @GiaGoc*@PhanTramKM/100.0>@GiamToiDa SET @GiamKM=CONVERT(INT,@GiamToiDa*100.0/@GiaGoc);
        ELSE SET @GiamKM=@PhanTramKM;
    END;

    -- Bước 7: tổng giảm tối đa 30%
    SET @TongGiam=@GiamHang+@GiamKhuHoi+@GiamKM;
    IF @TongGiam>30 SET @TongGiam=30;
    IF @TongGiam<0 SET @TongGiam=0;
    SET @TienGiam=ROUND(@GiaGoc*@TongGiam/100.0,2);
    SET @GiaThucTra=@GiaGoc-@TienGiam;

    SELECT @GiaGoc AS GiaGoc,
           @GiamHang AS PhanTramGiamHang,
           @GiamTet AS PhanTramGiamTet,
           @GiamKhuHoi AS PhanTramGiamKhuHoi,
           @GiamKM AS PhanTramGiamKM,
           @TongGiam AS PhanTramGiam,
           @TienGiam AS TienGiam,
           @GiaThucTra AS GiaThucTra;
END;
GO

-- (6) đặt vé, giữ giao diện cũ
CREATE PROCEDURE sp_DATVE
    @MaKHLienHe INT,
    @MaTKNhanVien INT,
    @MaKH1 INT,
    @MaChuyenBay1 INT,
    @MaGhe1 INT,
    @MaHangVe1 INT,
    @MaNguoiGiamHo1 INT = NULL,
    @MaKH2 INT = NULL,
    @MaChuyenBay2 INT = NULL,
    @MaGhe2 INT = NULL,
    @MaHangVe2 INT = NULL,
    @MaNguoiGiamHo2 INT = NULL,
    @ApDungTet BIT = 0,
    @ApDungKhuHoi BIT = 0,
    @MaKM INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Bước 1: gom vé vào bảng tạm
    CREATE TABLE #DanhSachVe
    (
        STT INT PRIMARY KEY, MaChuyenBay INT, MaGhe INT, MaHangVe INT, MaKH INT, MaNguoiGiamHo INT NULL
    );
    INSERT INTO #DanhSachVe VALUES(1,@MaChuyenBay1,@MaGhe1,@MaHangVe1,@MaKH1,@MaNguoiGiamHo1);
    IF @MaKH2 IS NOT NULL OR @MaChuyenBay2 IS NOT NULL OR @MaGhe2 IS NOT NULL OR @MaHangVe2 IS NOT NULL OR @MaNguoiGiamHo2 IS NOT NULL
    BEGIN
        IF @MaKH2 IS NULL OR @MaChuyenBay2 IS NULL OR @MaGhe2 IS NULL OR @MaHangVe2 IS NULL
            THROW 50030, N'Thông tin vé thứ hai chưa đầy đủ.', 1;
        INSERT INTO #DanhSachVe VALUES(2,@MaChuyenBay2,@MaGhe2,@MaHangVe2,@MaKH2,@MaNguoiGiamHo2);
    END;

    -- Bước 2: kiểm tra khách hàng, nhân viên, chuyến bay, ghế
    IF NOT EXISTS(SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKHLienHe)
        THROW 50030, N'Khách hàng liên hệ không tồn tại.', 1;
    IF NOT EXISTS(SELECT 1 FROM TAIKHOAN WHERE MaTK=@MaTKNhanVien AND TrangThai=N'Hoạt động')
        THROW 50030, N'Tài khoản nhân viên không hợp lệ hoặc đã bị khóa.', 1;
    IF EXISTS(SELECT 1 FROM #DanhSachVe d LEFT JOIN KHACHHANG kh ON kh.MaKH=d.MaKH LEFT JOIN KHACHHANG ng ON ng.MaKH=d.MaNguoiGiamHo WHERE kh.MaKH IS NULL OR (d.MaNguoiGiamHo IS NOT NULL AND ng.MaKH IS NULL))
        THROW 50030, N'Hành khách hoặc người giám hộ không tồn tại.', 1;
    IF EXISTS(SELECT 1 FROM #DanhSachVe d JOIN HANGVE hv ON hv.MaHangVe=d.MaHangVe WHERE hv.TrangThai<>N'Hoạt động')
        THROW 50030, N'Hạng vé đã ngừng hoạt động.', 1;
    IF EXISTS(SELECT 1 FROM #DanhSachVe d LEFT JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay WHERE cb.MaChuyenBay IS NULL OR cb.TrangThai<>N'Đang mở bán' OR cb.NgayGioKhoiHanh<=SYSDATETIME())
        THROW 50031, N'Chuyến bay không tồn tại, không còn mở bán hoặc đã khởi hành.', 1;
    IF EXISTS(SELECT 1 FROM #DanhSachVe d LEFT JOIN GHE g ON g.MaGhe=d.MaGhe LEFT JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay LEFT JOIN GIAVE gv ON gv.MaChuyenBay=d.MaChuyenBay AND gv.MaHangVe=d.MaHangVe WHERE g.MaGhe IS NULL OR cb.MaChuyenBay IS NULL OR gv.MaChuyenBay IS NULL OR g.MaMayBay<>cb.MaMayBay OR g.MaHangVe<>d.MaHangVe)
        THROW 50032, N'Ghế, máy bay hoặc hạng vé không hợp lệ.', 1;

    -- Bước 3: kiểm tra tuổi và người giám hộ
    IF EXISTS
    (
        SELECT 1 FROM #DanhSachVe d JOIN KHACHHANG kh ON kh.MaKH=d.MaKH JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay
        WHERE DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
              - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),kh.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END < 16
          AND (d.MaNguoiGiamHo IS NULL OR d.MaNguoiGiamHo=d.MaKH OR NOT EXISTS
               (SELECT 1 FROM KHACHHANG ng WHERE ng.MaKH=d.MaNguoiGiamHo
                  AND DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
                    - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),ng.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END >=18))
    )
        THROW 50033, N'Hành khách dưới 16 tuổi cần người giám hộ từ 18 tuổi.', 1;
    -- Người giám hộ phải có vé trên cùng chuyến bay trong đơn
    IF EXISTS
    (
        SELECT 1 FROM #DanhSachVe d JOIN KHACHHANG kh ON kh.MaKH=d.MaKH JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay
        WHERE DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
              - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),kh.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END < 16
          AND NOT EXISTS(SELECT 1 FROM #DanhSachVe g WHERE g.MaKH=d.MaNguoiGiamHo AND g.MaChuyenBay=d.MaChuyenBay)
    )
        THROW 50039, N'Người giám hộ phải có vé trên cùng chuyến bay trong đơn này.', 1;
    IF EXISTS(SELECT MaChuyenBay,MaGhe FROM #DanhSachVe GROUP BY MaChuyenBay,MaGhe HAVING COUNT(*)>1)
        THROW 50034, N'Đơn có ghế bị chọn trùng.', 1;
    IF EXISTS(SELECT MaChuyenBay,MaKH FROM #DanhSachVe GROUP BY MaChuyenBay,MaKH HAVING COUNT(*)>1)
        THROW 50035, N'Một hành khách không thể có hai vé cùng chuyến bay.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Bước 4: khóa và kiểm tra ghế
        IF EXISTS(SELECT 1 FROM #DanhSachVe d LEFT JOIN GHECHUYENBAY gc WITH(UPDLOCK,HOLDLOCK) ON gc.MaChuyenBay=d.MaChuyenBay AND gc.MaGhe=d.MaGhe WHERE gc.MaGhe IS NULL OR gc.TrangThai<>N'Trống')
            THROW 50036, N'Có ghế không còn trống hoặc bị khóa.', 1;

        -- Bước 5: bỏ ưu đãi Tết; tự nhận diện khứ hồi
        DECLARE @CoKhuHoi BIT=0;
        IF EXISTS
        (
            SELECT 1 FROM #DanhSachVe a JOIN CHUYENBAY ca ON ca.MaChuyenBay=a.MaChuyenBay
            JOIN #DanhSachVe b ON b.STT<>a.STT AND b.MaKH=a.MaKH
            JOIN CHUYENBAY cb ON cb.MaChuyenBay=b.MaChuyenBay
            WHERE ca.MaSanBayDi=cb.MaSanBayDen AND ca.MaSanBayDen=cb.MaSanBayDi
        ) SET @CoKhuHoi=1;

        -- Bước 6: kiểm tra khuyến mãi
        DECLARE @NgayHienTai DATE=CONVERT(DATE,GETDATE()),@TenKM NVARCHAR(100)=NULL,@PhanTramKM INT=0,@GiamToiDa MONEY=NULL;
        IF @MaKM IS NOT NULL
        BEGIN
            SELECT @TenKM=TenKM,@PhanTramKM=PhanTramGiam,@GiamToiDa=GiamToiDa
            FROM KHUYENMAI WITH(UPDLOCK,HOLDLOCK)
            WHERE MaKM=@MaKM AND TrangThai=N'Hoạt động' AND @NgayHienTai BETWEEN NgayBatDau AND NgayKetThuc
              AND (SoLuotToiDa IS NULL OR SoLuotDaDung<SoLuotToiDa);
            IF @TenKM IS NULL
                THROW 50040, N'Mã khuyến mãi không hợp lệ, hết hạn hoặc hết lượt.', 1;
            IF @TenKM=N'Ưu đãi Tết'
                THROW 50041, N'Ưu đãi Tết được áp dụng riêng, không chọn trong danh sách khuyến mãi.', 1;
            IF @TenKM=N'Ưu đãi khách hàng mới' AND EXISTS(SELECT 1 FROM DONDATVE WHERE MaKHLienHe=@MaKHLienHe)
                THROW 50042, N'Ưu đãi khách hàng mới chỉ áp dụng cho lần đặt vé đầu tiên.', 1;
        END;

        -- Bước 7: tạo đơn
        INSERT INTO DONDATVE(MaKHLienHe,MaTKNhanVien,MaKM,TrangThai)
        VALUES(@MaKHLienHe,@MaTKNhanVien,@MaKM,N'Chờ thanh toán');
        DECLARE @MaDon INT=SCOPE_IDENTITY();

        -- Bước 8: tính giá từng vé
        CREATE TABLE #VeGia
        (
            STT INT PRIMARY KEY,MaChuyenBay INT,MaGhe INT,MaHangVe INT,MaKH INT,MaNguoiGiamHo INT NULL,
            GiaGoc MONEY,GiamHang INT,GiamTet INT,GiamKhuHoi INT,GiamKM INT,TongGiam INT,TienGiam MONEY,GiaThucTra MONEY
        );
        DECLARE @STT INT=1,@SoVe INT; SELECT @SoVe=COUNT(*) FROM #DanhSachVe;
        DECLARE @CB INT,@Ghe INT,@HV INT,@KH INT,@NGH INT,@Gia MONEY,@GH INT,@GKH INT,@GKM INT,@TG INT,@Tien MONEY;
        WHILE @STT<=@SoVe
        BEGIN
            SELECT @CB=MaChuyenBay,@Ghe=MaGhe,@HV=MaHangVe,@KH=MaKH,@NGH=MaNguoiGiamHo FROM #DanhSachVe WHERE STT=@STT;
            SELECT @Gia=DonGia FROM GIAVE WHERE MaChuyenBay=@CB AND MaHangVe=@HV;
            SELECT @GH=CASE WHEN kh.NgayKetThucThanhVien IS NOT NULL AND kh.NgayKetThucThanhVien<SYSDATETIME() THEN 0 ELSE ISNULL(htv.PhanTramGiam,0) END
            FROM KHACHHANG kh JOIN HANGTHANHVIEN htv ON htv.MaHangTV=kh.MaHangTV WHERE kh.MaKH=@KH;
            SET @GKH=CASE WHEN @CoKhuHoi=1 THEN 10 ELSE 0 END; SET @GKM=0;
            IF @MaKM IS NOT NULL
            BEGIN
                IF @GiamToiDa IS NULL SET @GKM=@PhanTramKM;
                ELSE IF @Gia*@PhanTramKM/100.0>@GiamToiDa SET @GKM=CONVERT(INT,@GiamToiDa*100.0/@Gia);
                ELSE SET @GKM=@PhanTramKM;
            END;
            SET @TG=@GH+@GKH+@GKM; IF @TG>30 SET @TG=30;
            SET @Tien=ROUND(@Gia*@TG/100.0,2);
            INSERT INTO #VeGia VALUES(@STT,@CB,@Ghe,@HV,@KH,@NGH,@Gia,@GH,0,@GKH,@GKM,@TG,@Tien,@Gia-@Tien);
            SET @STT=@STT+1;
        END;

        -- Bước 9: lưu vé, giữ ghế, tính tổng
        INSERT INTO VE(MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,PhanTramGiamHang,PhanTramGiamTet,PhanTramGiamKhuHoi,PhanTramGiamKM,TongPhanTramGiam,TienGiam,GiaThucTra,TrangThai)
        SELECT @MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,GiamHang,0,GiamKhuHoi,GiamKM,TongGiam,TienGiam,GiaThucTra,N'Đã đặt' FROM #VeGia;
        UPDATE gc SET TrangThai=N'Đã đặt' FROM GHECHUYENBAY gc JOIN #DanhSachVe d ON d.MaChuyenBay=gc.MaChuyenBay AND d.MaGhe=gc.MaGhe;

        DECLARE @TongTienVe MONEY,@TongGiam MONEY;
        SELECT @TongTienVe=SUM(GiaThucTra),@TongGiam=SUM(TienGiam) FROM VE WHERE MaDon=@MaDon;
        UPDATE DONDATVE SET TongTienVe=@TongTienVe,TongTienDichVu=0,TienGiamKM=ISNULL(@TongGiam,0),TongThanhToan=@TongTienVe WHERE MaDon=@MaDon;
        IF @MaKM IS NOT NULL UPDATE KHUYENMAI SET SoLuotDaDung=SoLuotDaDung+1 WHERE MaKM=@MaKM;
        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung) VALUES(@MaTKNhanVien,N'Đặt vé',N'DONDATVE',CONCAT(N'Tạo đơn đặt vé #',@MaDon));
        COMMIT TRANSACTION;

        -- Bước 10: trả đúng result set cũ
        SELECT v.MaDon,v.MaVe,v.MaChuyenBay,v.MaGhe,v.MaHangVe,v.MaKH,
               v.GiaGoc,v.TongPhanTramGiam,v.TienGiam,v.GiaThucTra,
               dd.TongTienVe,dd.TongTienDichVu,dd.TienGiamKM,dd.TongThanhToan,dd.TrangThai AS TrangThaiDon
        FROM VE v JOIN DONDATVE dd ON dd.MaDon=v.MaDon WHERE v.MaDon=@MaDon ORDER BY v.MaVe;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- (7) thanh toán đơn
CREATE PROCEDURE sp_THANHTOANDON
    @MaDon INT,
    @SoTien MONEY,
    @PhuongThuc NVARCHAR(30),
    @MaTKNhanVien INT,
    @GhiChu NVARCHAR(250)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Bước 1: lấy tổng đơn và số tiền đã thu
        DECLARE @TongThanhToan MONEY,@TrangThai NVARCHAR(30),@TongDaThu MONEY=0,@TongDaHoan MONEY=0,@TongPhiHuy MONEY=0,@ConPhaiThu MONEY;
        SELECT @TongThanhToan=TongThanhToan,@TrangThai=TrangThai FROM DONDATVE WITH(UPDLOCK,HOLDLOCK) WHERE MaDon=@MaDon;
        IF @TongThanhToan IS NULL THROW 50050, N'Không tìm thấy đơn đặt vé.', 1;
        IF @TrangThai=N'Đã hủy' THROW 50051, N'Đơn không ở trạng thái chờ thanh toán.', 1;
        SELECT @TongDaThu=ISNULL(SUM(CASE WHEN TrangThai=N'Thành công' THEN SoTien ELSE 0 END),0),
               @TongDaHoan=ISNULL(SUM(CASE WHEN TrangThai=N'Đã hoàn' THEN SoTien ELSE 0 END),0)
        FROM THANHTOAN WHERE MaDon=@MaDon;
        -- Phí hủy đã giữ lại là tiền của vé đã hủy, không được tính như tiền khách trả dư
        SELECT @TongPhiHuy=ISNULL(SUM(h.PhiHuy),0) FROM HUYVE h JOIN VE v ON v.MaVe=h.MaVe WHERE v.MaDon=@MaDon;
        SET @ConPhaiThu=@TongThanhToan-(@TongDaThu-@TongDaHoan-@TongPhiHuy);
        IF @ConPhaiThu<=0 THROW 50051, N'Đơn không ở trạng thái chờ thanh toán.', 1;
        IF @SoTien<>@ConPhaiThu THROW 50052, N'Số tiền thanh toán phải bằng tổng thanh toán.', 1;
        IF @PhuongThuc NOT IN(N'Tiền mặt',N'Chuyển khoản',N'Thẻ') THROW 50053, N'Phương thức thanh toán không hợp lệ.', 1;
        IF NOT EXISTS(SELECT 1 FROM TAIKHOAN WHERE MaTK=@MaTKNhanVien AND TrangThai=N'Hoạt động') THROW 50053, N'Tài khoản nhân viên không hợp lệ hoặc đã bị khóa.', 1;
        -- Vé đã hủy được loại khỏi tổng đơn (sp_HUYVE tính lại), nên đơn vẫn thanh toán được phần còn lại

        -- Bước 2: ghi nhận khoản thu
        INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,MaTKNhanVien,TrangThai,GhiChu)
        VALUES(@MaDon,@SoTien,@PhuongThuc,@MaTKNhanVien,N'Thành công',@GhiChu);
        UPDATE DONDATVE SET TrangThai=N'Đã thanh toán' WHERE MaDon=@MaDon;

        -- Bước 3: cộng chi tiêu; lần đầu tính vé+dich vụ, lần sau là dịch vụ phát sinh
        CREATE TABLE #ChiTieu(MaKH INT PRIMARY KEY,SoTien MONEY);
        IF @TongDaThu=0
        BEGIN
            INSERT INTO #ChiTieu
            SELECT v.MaKH,SUM(v.GiaThucTra+ISNULL(dv.TienDV,0))
            FROM VE v
            LEFT JOIN (SELECT MaVe,SUM(ThanhTien) AS TienDV FROM VEDICHVU GROUP BY MaVe) dv ON dv.MaVe=v.MaVe
            WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy' GROUP BY v.MaKH;
        END
        ELSE
        BEGIN
            -- Khoản thanh toán bổ sung là dịch vụ mới; phân theo dịch vụ hiện có của hành khách
            DECLARE @TongDV MONEY; SELECT @TongDV=SUM(vd.ThanhTien) FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
            INSERT INTO #ChiTieu
            SELECT v.MaKH,CASE WHEN @TongDV>0 THEN ROUND(@SoTien*SUM(vd.ThanhTien)/@TongDV,2) ELSE 0 END
            FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe
            WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy' GROUP BY v.MaKH;
        END;

        -- Bước 4: cập nhật hạng thành viên
        UPDATE kh SET NgayGiaoDichDauTien=ISNULL(kh.NgayGiaoDichDauTien,SYSDATETIME()),
                      NgayKetThucThanhVien=CASE WHEN kh.NgayGiaoDichDauTien IS NULL THEN DATEADD(YEAR,1,SYSDATETIME()) ELSE kh.NgayKetThucThanhVien END,
                      TongChiTieu=kh.TongChiTieu+c.SoTien
        FROM KHACHHANG kh JOIN #ChiTieu c ON c.MaKH=kh.MaKH;
        UPDATE kh SET MaHangTV=CASE WHEN kh.NgayKetThucThanhVien IS NULL OR kh.NgayKetThucThanhVien<SYSDATETIME() THEN 1
                                    ELSE ISNULL((SELECT TOP 1 h.MaHangTV FROM HANGTHANHVIEN h WHERE h.DiemChiTieuToiThieu<=kh.TongChiTieu ORDER BY h.DiemChiTieuToiThieu DESC),1) END
        FROM KHACHHANG kh JOIN #ChiTieu c ON c.MaKH=kh.MaKH;

        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung) VALUES(@MaTKNhanVien,N'Thanh toán',N'DONDATVE',CONCAT(N'Thanh toán đơn #',@MaDon));
        COMMIT TRANSACTION;
        SELECT N'Thanh toán thành công' AS KetQua,@MaDon AS MaDon;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- (8) hủy vé
CREATE PROCEDURE sp_HUYVE
    @MaVe INT,
    @LyDo NVARCHAR(250),
    @MaTKNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Bước 1: lấy thông tin vé
        DECLARE @MaDon INT,@MaKH INT,@MaChuyenBay INT,@MaGhe INT,@GiaThucTra MONEY,@TrangThaiVe NVARCHAR(20),
                @NgayKhoiHanh DATETIME2,@ChoPhepHuy BIT,@PhiHuy MONEY=0,@TienHoanVe MONEY=0,@TienDichVu MONEY=0,
                @TienHoan MONEY=0,@TrangThaiDon NVARCHAR(30),@TongDaThu MONEY=0,@TongDaHoan MONEY=0,@TongDon MONEY=0;
        SELECT @MaDon=v.MaDon,@MaKH=v.MaKH,@MaChuyenBay=v.MaChuyenBay,@MaGhe=v.MaGhe,@GiaThucTra=v.GiaThucTra,
               @TrangThaiVe=v.TrangThai,@NgayKhoiHanh=cb.NgayGioKhoiHanh,@ChoPhepHuy=hv.ChoPhepHuy,
               @TrangThaiDon=dd.TrangThai,@TongDon=dd.TongThanhToan
        FROM VE v WITH(UPDLOCK,HOLDLOCK) JOIN CHUYENBAY cb ON cb.MaChuyenBay=v.MaChuyenBay
        JOIN HANGVE hv ON hv.MaHangVe=v.MaHangVe JOIN DONDATVE dd ON dd.MaDon=v.MaDon WHERE v.MaVe=@MaVe;
        IF @MaDon IS NULL THROW 50060, N'Không tìm thấy vé.', 1;
        IF @TrangThaiVe=N'Đã hủy' OR EXISTS(SELECT 1 FROM HUYVE WHERE MaVe=@MaVe) THROW 50061, N'Vé đã được hủy trước đó.', 1;
        IF @TrangThaiVe=N'Đã bay' OR @NgayKhoiHanh<=SYSDATETIME() THROW 50062, N'Không thể hủy vé đã khởi hành hoặc đã bay.', 1;
        IF @ChoPhepHuy=0 THROW 50063, N'Hạng vé này không cho phép hủy.', 1;
        -- Không để trẻ dưới 16 tuổi bay một mình: phải hủy vé của trẻ trước vé của người giám hộ
        IF EXISTS(SELECT 1 FROM VE WHERE MaDon=@MaDon AND MaChuyenBay=@MaChuyenBay AND MaNguoiGiamHo=@MaKH
                                     AND MaVe<>@MaVe AND TrangThai<>N'Đã hủy')
            THROW 50064, N'Đây là vé của người giám hộ cho hành khách dưới 16 tuổi trên cùng chuyến. Hãy hủy vé của hành khách đó trước.', 1;

        -- Bước 2: số tiền khách thực trả cho các vé/dịch vụ còn hiệu lực
        --         = đã thu − đã hoàn − phí hủy đã giữ của các vé hủy trước
        DECLARE @TongPhiHuyCu MONEY=0,@DaTraThuc MONEY=0,@DuSauHuy MONEY=0;
        SELECT @TongDaThu=ISNULL(SUM(CASE WHEN TrangThai=N'Thành công' THEN SoTien ELSE 0 END),0),
               @TongDaHoan=ISNULL(SUM(CASE WHEN TrangThai=N'Đã hoàn' THEN SoTien ELSE 0 END),0)
        FROM THANHTOAN WHERE MaDon=@MaDon;
        SELECT @TongPhiHuyCu=ISNULL(SUM(h.PhiHuy),0) FROM HUYVE h JOIN VE v ON v.MaVe=h.MaVe WHERE v.MaDon=@MaDon;
        SELECT @TienDichVu=ISNULL(SUM(ThanhTien),0) FROM VEDICHVU WHERE MaVe=@MaVe;
        SET @DaTraThuc=@TongDaThu-@TongDaHoan-@TongPhiHuyCu;
        -- Phần khách đã trả dư nếu bỏ vé này (và dịch vụ của vé) ra khỏi đơn
        SET @DuSauHuy=@DaTraThuc-(@TongDon-@GiaThucTra-@TienDichVu);

        -- Bước 3: đơn đã thanh toán thì tính phí hủy trên giá vé; hoàn phần khách đã trả dư sau khi trừ phí.
        --         Đơn đã thanh toán nhưng còn nợ tiền dịch vụ thêm sau: khoản nợ được trừ vào tiền hoàn.
        IF @TrangThaiDon=N'Đã thanh toán' AND @DuSauHuy>0
        BEGIN
            DECLARE @GioConLai INT=DATEDIFF(HOUR,SYSDATETIME(),@NgayKhoiHanh);
            IF @GioConLai<24 SET @PhiHuy=ROUND(@GiaThucTra*0.30,0);
            ELSE IF @GioConLai<72 SET @PhiHuy=ROUND(@GiaThucTra*0.20,0);
            ELSE SET @PhiHuy=ROUND(@GiaThucTra*0.10,0);
            IF @PhiHuy>@DuSauHuy SET @PhiHuy=@DuSauHuy;
            SET @TienHoan=@DuSauHuy-@PhiHuy;
            SET @TienHoanVe=@TienHoan;
        END
        ELSE
        BEGIN
            SET @PhiHuy=0; SET @TienHoanVe=0; SET @TienHoan=0;
        END;

        -- Bước 4: ghi hủy và hoàn tiền
        INSERT INTO HUYVE(MaVe,LyDo,PhiHuy,TienHoan,MaTKNhanVien) VALUES(@MaVe,@LyDo,@PhiHuy,@TienHoan,@MaTKNhanVien);
        IF @TienHoan>0
            INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,MaTKNhanVien,TrangThai,GhiChu)
            VALUES(@MaDon,@TienHoan,N'Tiền mặt',@MaTKNhanVien,N'Đã hoàn',CONCAT(N'Hoàn tiền vé #',@MaVe));

        -- Bước 5: xóa dịch vụ của vé, hủy vé, trả ghế
        DELETE FROM VEDICHVU WHERE MaVe=@MaVe;
        UPDATE VE SET TrangThai=N'Đã hủy' WHERE MaVe=@MaVe;
        UPDATE GHECHUYENBAY SET TrangThai=N'Trống' WHERE MaChuyenBay=@MaChuyenBay AND MaGhe=@MaGhe;

        -- Bước 5b: đơn chưa thanh toán thì tính lại khứ hồi cho các vé còn lại
        --          (hủy một chiều thì chiều kia không còn là khứ hồi), giống sp_XOAVEDON
        IF @TrangThaiDon<>N'Đã thanh toán'
        BEGIN
            UPDATE v SET PhanTramGiamKhuHoi=CASE WHEN EXISTS(SELECT 1 FROM VE v2 JOIN CHUYENBAY c2 ON c2.MaChuyenBay=v2.MaChuyenBay JOIN CHUYENBAY c1 ON c1.MaChuyenBay=v.MaChuyenBay WHERE v2.MaDon=@MaDon AND v2.MaKH=v.MaKH AND v2.MaVe<>v.MaVe AND v2.TrangThai<>N'Đã hủy' AND c1.MaSanBayDi=c2.MaSanBayDen AND c1.MaSanBayDen=c2.MaSanBayDi) THEN 10 ELSE 0 END
            FROM VE v WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
            UPDATE VE SET TongPhanTramGiam=CASE WHEN PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM>30 THEN 30 ELSE PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM END
            WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
            UPDATE VE SET TienGiam=ROUND(GiaGoc*TongPhanTramGiam/100.0,2),GiaThucTra=GiaGoc-ROUND(GiaGoc*TongPhanTramGiam/100.0,2)
            WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        END;

        -- Bước 6: tính lại tổng đơn
        DECLARE @TongVe MONEY=0,@TongDV MONEY=0;
        SELECT @TongVe=ISNULL(SUM(GiaThucTra),0) FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        SELECT @TongDV=ISNULL(SUM(vd.ThanhTien),0) FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
        DECLARE @TongGiamConLai MONEY; SELECT @TongGiamConLai=ISNULL(SUM(TienGiam),0) FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        UPDATE DONDATVE SET TongTienVe=@TongVe,TongTienDichVu=@TongDV,TienGiamKM=@TongGiamConLai,TongThanhToan=@TongVe+@TongDV WHERE MaDon=@MaDon;

        -- Bước 7: trừ chi tiêu đã hoàn và xét lại hạng
        IF @TienHoan>0
        BEGIN
            UPDATE KHACHHANG SET TongChiTieu=CASE WHEN TongChiTieu>=@TienHoan THEN TongChiTieu-@TienHoan ELSE 0 END WHERE MaKH=@MaKH;
            UPDATE kh SET MaHangTV=CASE WHEN kh.NgayKetThucThanhVien IS NULL OR kh.NgayKetThucThanhVien<SYSDATETIME() THEN 1
                                        ELSE ISNULL((SELECT TOP 1 MaHangTV FROM HANGTHANHVIEN WHERE DiemChiTieuToiThieu<=kh.TongChiTieu ORDER BY DiemChiTieuToiThieu DESC),1) END
            FROM KHACHHANG kh WHERE kh.MaKH=@MaKH;
        END;
        IF NOT EXISTS(SELECT 1 FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy') UPDATE DONDATVE SET TrangThai=N'Đã hủy' WHERE MaDon=@MaDon;

        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung) VALUES(@MaTKNhanVien,N'Hủy vé',N'VE',CONCAT(N'Hủy vé #',@MaVe));
        COMMIT TRANSACTION;
        SELECT @MaVe AS MaVe,@PhiHuy AS PhiHuy,@TienHoan AS TienHoan,N'Hủy vé thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- (9) tra cứu vé
CREATE PROCEDURE sp_TRACUUVE
    @MaVe INT=NULL,
    @MaChuyenBay INT=NULL,
    @SoGiayTo VARCHAR(30)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM V_VECHITIET
    WHERE (@MaVe IS NULL OR MaVe=@MaVe)
      AND (@MaChuyenBay IS NULL OR MaChuyenBay=@MaChuyenBay)
      AND (@SoGiayTo IS NULL OR EXISTS
          (SELECT 1 FROM KHACHHANG kh
           WHERE kh.MaKH=V_VECHITIET.MaKH AND kh.SoGiayTo=@SoGiayTo))
    ORDER BY NgayGioKhoiHanh DESC;
END;
GO

-- (9) thống kê tổng quan
CREATE PROCEDURE sp_THONGKEDASHBOARD
    @Nam INT=NULL,
    @Thang INT=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
      (SELECT COUNT(*) FROM CHUYENBAY
       WHERE (@Nam IS NULL OR YEAR(NgayGioKhoiHanh)=@Nam)
         AND (@Thang IS NULL OR MONTH(NgayGioKhoiHanh)=@Thang)) AS TongChuyenBay,
      (SELECT COUNT(*) FROM VE
       WHERE TrangThai<>N'Đã hủy'
         AND (@Nam IS NULL OR YEAR((SELECT NgayDat FROM DONDATVE d WHERE d.MaDon=VE.MaDon))=@Nam)
         AND (@Thang IS NULL OR MONTH((SELECT NgayDat FROM DONDATVE d WHERE d.MaDon=VE.MaDon))=@Thang)) AS TongVeConHieuLuc,
      (SELECT COUNT(*) FROM VE WHERE TrangThai=N'Đã hủy') AS TongVeDaHuy,
      (SELECT ISNULL(SUM(SoTien),0) FROM THANHTOAN
       WHERE TrangThai=N'Thành công'
         AND (@Nam IS NULL OR YEAR(NgayThanhToan)=@Nam)
         AND (@Thang IS NULL OR MONTH(NgayThanhToan)=@Thang)) AS TongTienThu;
END;
GO

-- (9) xét hạng thành viên
CREATE PROCEDURE sp_XETHANGTHANHVIEN
    @MaKH INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE kh
    SET MaHangTV=CASE
        WHEN kh.NgayKetThucThanhVien IS NULL OR kh.NgayKetThucThanhVien<SYSDATETIME() THEN 1
        ELSE ISNULL((SELECT TOP 1 h.MaHangTV FROM HANGTHANHVIEN h
                     WHERE h.DiemChiTieuToiThieu<=kh.TongChiTieu
                     ORDER BY h.DiemChiTieuToiThieu DESC),1)
        END
    FROM KHACHHANG kh
    WHERE kh.MaKH=@MaKH;

    SELECT kh.MaKH,kh.HoTen,kh.TongChiTieu,htv.TenHang,htv.PhanTramGiam,
           kh.NgayGiaoDichDauTien,kh.NgayKetThucThanhVien
    FROM KHACHHANG kh
    JOIN HANGTHANHVIEN htv ON htv.MaHangTV=kh.MaHangTV
    WHERE kh.MaKH=@MaKH;
END;
GO

-- (9) dữ liệu hộp chọn
CREATE PROCEDURE sp_LAYDULIEUCOMBOBOX
    @LoaiData VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    IF @LoaiData = 'SANBAY'
        SELECT MaSanBay AS Ma, TenSanBay AS Ten,
               CONCAT(ThanhPho, N' - ', QuocGia) AS MoTa,
               CAST(NULL AS MONEY) AS GiaTri
        FROM SANBAY WHERE TrangThai=N'Hoạt động'
        ORDER BY TenSanBay;
    ELSE IF @LoaiData = 'HANGVE'
        SELECT MaHangVe AS Ma, TenHangVe AS Ten, MoTa,
               CAST(NULL AS MONEY) AS GiaTri
        FROM HANGVE
        WHERE TrangThai=N'Hoạt động'
        ORDER BY MaHangVe;
    ELSE IF @LoaiData = 'KHUYENMAI'
        SELECT MaKM AS Ma, TenKM AS Ten,
               CONCAT(N'Áp dụng từ ', CONVERT(VARCHAR(10),NgayBatDau,103),
                      N' đến ', CONVERT(VARCHAR(10),NgayKetThuc,103)) AS MoTa,
               PhanTramGiam AS GiaTri
        FROM KHUYENMAI
        WHERE TrangThai=N'Hoạt động'
          AND CONVERT(DATE,GETDATE()) BETWEEN NgayBatDau AND NgayKetThuc
          AND TenKM<>N'Ưu đãi Tết'
          AND (SoLuotToiDa IS NULL OR SoLuotDaDung<SoLuotToiDa)
        ORDER BY TenKM;
    ELSE IF @LoaiData = 'MAYBAY'
        SELECT MaMayBay AS Ma, SoHieu AS Ten,
               CONCAT(HangSanXuat, N' - ', LoaiMayBay) AS MoTa,
               CAST(NULL AS MONEY) AS GiaTri
        FROM MAYBAY
        WHERE TrangThai=N'Hoạt động'
        ORDER BY SoHieu;
    ELSE IF @LoaiData = 'DICHVU'
        SELECT MaDichVu AS Ma, TenDichVu AS Ten, LoaiDichVu AS MoTa,
               DonGia AS GiaTri
        FROM DICHVU
        WHERE TrangThai=N'Hoạt động'
        ORDER BY TenDichVu;
    ELSE IF @LoaiData = 'KHACHHANG'
        SELECT MaKH AS Ma, HoTen AS Ten,
               CONCAT(ISNULL(SoDienThoai,''),
                      CASE WHEN Email IS NULL THEN '' ELSE CONCAT(N' - ',Email) END) AS MoTa,
               CAST(NULL AS MONEY) AS GiaTri
        FROM KHACHHANG
        ORDER BY HoTen;
    ELSE IF @LoaiData = 'TAIKHOAN'
        SELECT MaTK AS Ma, HoTen AS Ten,
               CONCAT(VaiTro,N' - ',TenDangNhap) AS MoTa,
               CAST(NULL AS MONEY) AS GiaTri
        FROM TAIKHOAN
        WHERE TrangThai=N'Hoạt động'
        ORDER BY HoTen;
    ELSE IF @LoaiData = 'HANGTHANHVIEN'
        SELECT MaHangTV AS Ma, TenHang AS Ten, MoTa,
               PhanTramGiam AS GiaTri
        FROM HANGTHANHVIEN
        ORDER BY DiemChiTieuToiThieu;
    ELSE
        THROW 50070, N'Loại dữ liệu ComboBox không được hỗ trợ.', 1;
END;
GO

-- (9) phụ: tạo đơn nhiều vé
CREATE PROCEDURE sp_TAODONNHIEUVE
    @MaKHLienHe INT,
    @MaTKNhanVien INT,
    @MaKM INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKHLienHe) THROW 50100, N'Khách hàng liên hệ không tồn tại.', 1;
    IF NOT EXISTS(SELECT 1 FROM TAIKHOAN WHERE MaTK=@MaTKNhanVien AND TrangThai=N'Hoạt động') THROW 50101, N'Tài khoản nhân viên không hợp lệ hoặc đã bị khóa.', 1;
    IF @MaKM IS NOT NULL
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM KHUYENMAI WHERE MaKM=@MaKM AND TrangThai=N'Hoạt động' AND CONVERT(DATE,GETDATE()) BETWEEN NgayBatDau AND NgayKetThuc AND (SoLuotToiDa IS NULL OR SoLuotDaDung<SoLuotToiDa))
            THROW 50102, N'Mã khuyến mãi không hợp lệ, hết hạn hoặc hết lượt.', 1;
        IF EXISTS(SELECT 1 FROM KHUYENMAI WHERE MaKM=@MaKM AND TenKM=N'Ưu đãi Tết') THROW 50103, N'Ưu đãi Tết đã ngừng áp dụng.', 1;
        IF EXISTS(SELECT 1 FROM KHUYENMAI WHERE MaKM=@MaKM AND TenKM=N'Ưu đãi khách hàng mới') AND EXISTS(SELECT 1 FROM DONDATVE WHERE MaKHLienHe=@MaKHLienHe)
            THROW 50104, N'Ưu đãi khách hàng mới chỉ áp dụng cho lần đặt vé đầu tiên.', 1;
    END;
    INSERT INTO DONDATVE(MaKHLienHe,MaTKNhanVien,MaKM,TrangThai) VALUES(@MaKHLienHe,@MaTKNhanVien,@MaKM,N'Chờ thanh toán');
    DECLARE @MaDon INT=SCOPE_IDENTITY();
    IF @MaKM IS NOT NULL UPDATE KHUYENMAI SET SoLuotDaDung=SoLuotDaDung+1 WHERE MaKM=@MaKM;
    SELECT @MaDon AS MaDon;
END;
GO

-- (9) phụ: thêm vé vào đơn
CREATE PROCEDURE sp_THEMVEDON
    @MaDon INT,
    @MaKH INT,
    @MaChuyenBay INT,
    @MaGhe INT,
    @MaHangVe INT,
    @MaNguoiGiamHo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @MaKM INT,@TrangThaiDon NVARCHAR(30),@GiaGoc MONEY,@GiamHang INT=0,@GiamKM INT=0,@TongGiam INT=0,@TienGiam MONEY=0,@GiaThucTra MONEY=0;
        SELECT @MaKM=MaKM,@TrangThaiDon=TrangThai FROM DONDATVE WITH(UPDLOCK,HOLDLOCK) WHERE MaDon=@MaDon;
        IF @TrangThaiDon IS NULL THROW 50110, N'Không tìm thấy đơn đặt vé.', 1;
        IF @TrangThaiDon<>N'Chờ thanh toán' THROW 50111, N'Chỉ được thêm vé khi đơn đang chờ thanh toán.', 1;
        IF NOT EXISTS(SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKH) THROW 50112, N'Hành khách không tồn tại.', 1;
        IF NOT EXISTS(SELECT 1 FROM HANGVE WHERE MaHangVe=@MaHangVe AND TrangThai=N'Hoạt động') THROW 50112, N'Hạng vé đã ngừng hoạt động.', 1;
        IF NOT EXISTS(SELECT 1 FROM CHUYENBAY WHERE MaChuyenBay=@MaChuyenBay AND TrangThai=N'Đang mở bán' AND NgayGioKhoiHanh>SYSDATETIME()) THROW 50113, N'Chuyến bay không còn mở bán hoặc đã khởi hành.', 1;
        IF EXISTS
        (
            SELECT 1 FROM KHACHHANG kh JOIN CHUYENBAY cb ON cb.MaChuyenBay=@MaChuyenBay
            WHERE kh.MaKH=@MaKH
              AND DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
                  - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),kh.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END < 16
              AND (@MaNguoiGiamHo IS NULL OR @MaNguoiGiamHo=@MaKH OR NOT EXISTS
                  (SELECT 1 FROM KHACHHANG ng WHERE ng.MaKH=@MaNguoiGiamHo
                   AND DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
                       - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),ng.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END >=18))
        ) THROW 50117, N'Hành khách dưới 16 tuổi cần người giám hộ từ 18 tuổi.', 1;
        -- Người giám hộ phải đi cùng: có vé chưa hủy trên CÙNG chuyến bay, trong CÙNG đơn.
        -- Hành khách từ 16 tuổi không cần giám hộ: bỏ giá trị giám hộ để dữ liệu sạch.
        DECLARE @TuoiHK INT;
        SELECT @TuoiHK = DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
                       - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),kh.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END
        FROM KHACHHANG kh JOIN CHUYENBAY cb ON cb.MaChuyenBay=@MaChuyenBay WHERE kh.MaKH=@MaKH;
        IF @TuoiHK>=16
            SET @MaNguoiGiamHo=NULL;
        ELSE IF NOT EXISTS(SELECT 1 FROM VE WHERE MaDon=@MaDon AND MaChuyenBay=@MaChuyenBay AND MaKH=@MaNguoiGiamHo AND TrangThai<>N'Đã hủy')
            THROW 50118, N'Người giám hộ phải có vé trên cùng chuyến bay trong đơn này. Hãy thêm vé cho người giám hộ trước.', 1;
        IF NOT EXISTS(SELECT 1 FROM GHE g JOIN CHUYENBAY cb ON cb.MaChuyenBay=@MaChuyenBay JOIN GHECHUYENBAY gc ON gc.MaChuyenBay=@MaChuyenBay AND gc.MaGhe=g.MaGhe WHERE g.MaGhe=@MaGhe AND g.MaMayBay=cb.MaMayBay AND g.MaHangVe=@MaHangVe AND gc.TrangThai=N'Trống') THROW 50114, N'Ghế không còn trống hoặc không đúng hạng vé.', 1;
        IF EXISTS(SELECT 1 FROM VE WHERE MaChuyenBay=@MaChuyenBay AND MaGhe=@MaGhe AND TrangThai<>N'Đã hủy') THROW 50115, N'Ghế đã có người đặt.', 1;
        IF EXISTS(SELECT 1 FROM VE WHERE MaChuyenBay=@MaChuyenBay AND MaKH=@MaKH AND TrangThai<>N'Đã hủy') THROW 50116, N'Hành khách đã có vé trên chuyến bay này.', 1;
        SELECT @GiaGoc=DonGia FROM GIAVE WHERE MaChuyenBay=@MaChuyenBay AND MaHangVe=@MaHangVe;
        SELECT @GiamHang=CASE WHEN kh.NgayKetThucThanhVien IS NOT NULL AND kh.NgayKetThucThanhVien<SYSDATETIME() THEN 0 ELSE h.PhanTramGiam END FROM KHACHHANG kh JOIN HANGTHANHVIEN h ON h.MaHangTV=kh.MaHangTV WHERE kh.MaKH=@MaKH;
        IF @MaKM IS NOT NULL
        BEGIN
            DECLARE @PT INT,@Max MONEY; SELECT @PT=PhanTramGiam,@Max=GiamToiDa FROM KHUYENMAI WHERE MaKM=@MaKM;
            IF @Max IS NULL SET @GiamKM=@PT; ELSE IF @GiaGoc*@PT/100.0>@Max SET @GiamKM=CONVERT(INT,@Max*100.0/@GiaGoc); ELSE SET @GiamKM=@PT;
        END;
        SET @TongGiam=@GiamHang+@GiamKM; IF @TongGiam>30 SET @TongGiam=30;
        SET @TienGiam=ROUND(@GiaGoc*@TongGiam/100.0,2); SET @GiaThucTra=@GiaGoc-@TienGiam;
        INSERT INTO VE(MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,PhanTramGiamHang,PhanTramGiamTet,PhanTramGiamKhuHoi,PhanTramGiamKM,TongPhanTramGiam,TienGiam,GiaThucTra,TrangThai)
        VALUES(@MaDon,@MaChuyenBay,@MaGhe,@MaHangVe,@MaKH,@MaNguoiGiamHo,@GiaGoc,@GiamHang,0,0,@GiamKM,@TongGiam,@TienGiam,@GiaThucTra,N'Đã đặt');
        DECLARE @MaVe INT=SCOPE_IDENTITY();
        UPDATE GHECHUYENBAY SET TrangThai=N'Đã đặt' WHERE MaChuyenBay=@MaChuyenBay AND MaGhe=@MaGhe;

        -- Tự nhận diện các cặp khứ hồi cùng hành khách và tính lại giá
        UPDATE v SET PhanTramGiamKhuHoi=CASE WHEN EXISTS(SELECT 1 FROM VE v2 JOIN CHUYENBAY c2 ON c2.MaChuyenBay=v2.MaChuyenBay JOIN CHUYENBAY c1 ON c1.MaChuyenBay=v.MaChuyenBay WHERE v2.MaDon=@MaDon AND v2.MaKH=v.MaKH AND v2.MaVe<>v.MaVe AND v2.TrangThai<>N'Đã hủy' AND c1.MaSanBayDi=c2.MaSanBayDen AND c1.MaSanBayDen=c2.MaSanBayDi) THEN 10 ELSE 0 END
        FROM VE v WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
        UPDATE v SET TongPhanTramGiam=CASE WHEN PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM>30 THEN 30 ELSE PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM END,
                     TienGiam=ROUND(GiaGoc*CASE WHEN PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM>30 THEN 30 ELSE PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM END/100.0,2)
        FROM VE v WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
        UPDATE VE SET GiaThucTra=GiaGoc-TienGiam WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        DECLARE @TongVe MONEY,@TongDV MONEY; SELECT @TongVe=ISNULL(SUM(GiaThucTra),0) FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy'; SELECT @TongDV=ISNULL(SUM(vd.ThanhTien),0) FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
        DECLARE @TongGiamDon MONEY; SELECT @TongGiamDon=ISNULL(SUM(TienGiam),0) FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        UPDATE DONDATVE SET TongTienVe=@TongVe,TongTienDichVu=@TongDV,TienGiamKM=@TongGiamDon,TongThanhToan=@TongVe+@TongDV WHERE MaDon=@MaDon;
        COMMIT TRANSACTION;
        SELECT @MaVe AS MaVe,@MaDon AS MaDon;
    END TRY
    BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; THROW; END CATCH
END;
GO

-- (9) phụ: xóa vé khỏi đơn
CREATE PROCEDURE sp_XOAVEDON
    @MaDon INT,
    @MaVe INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS(SELECT 1 FROM DONDATVE WHERE MaDon=@MaDon AND TrangThai=N'Chờ thanh toán') THROW 50120, N'Chỉ được xóa vé khi đơn đang chờ thanh toán.', 1;
        DECLARE @CB INT,@Ghe INT; SELECT @CB=MaChuyenBay,@Ghe=MaGhe FROM VE WHERE MaVe=@MaVe AND MaDon=@MaDon AND TrangThai<>N'Đã hủy';
        IF @CB IS NULL THROW 50121, N'Không tìm thấy vé trong đơn.', 1;
        DELETE FROM VEDICHVU WHERE MaVe=@MaVe; DELETE FROM VE WHERE MaVe=@MaVe; UPDATE GHECHUYENBAY SET TrangThai=N'Trống' WHERE MaChuyenBay=@CB AND MaGhe=@Ghe;
        UPDATE v SET PhanTramGiamKhuHoi=CASE WHEN EXISTS(SELECT 1 FROM VE v2 JOIN CHUYENBAY c2 ON c2.MaChuyenBay=v2.MaChuyenBay JOIN CHUYENBAY c1 ON c1.MaChuyenBay=v.MaChuyenBay WHERE v2.MaDon=@MaDon AND v2.MaKH=v.MaKH AND v2.MaVe<>v.MaVe AND c1.MaSanBayDi=c2.MaSanBayDen AND c1.MaSanBayDen=c2.MaSanBayDi) THEN 10 ELSE 0 END FROM VE v WHERE v.MaDon=@MaDon;
        UPDATE v SET TongPhanTramGiam=CASE WHEN PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM>30 THEN 30 ELSE PhanTramGiamHang+PhanTramGiamKhuHoi+PhanTramGiamKM END FROM VE v WHERE v.MaDon=@MaDon;
        UPDATE VE SET TienGiam=ROUND(GiaGoc*TongPhanTramGiam/100.0,2),GiaThucTra=GiaGoc-ROUND(GiaGoc*TongPhanTramGiam/100.0,2) WHERE MaDon=@MaDon;
        DECLARE @TongVe MONEY=0,@TongDV MONEY=0; SELECT @TongVe=ISNULL(SUM(GiaThucTra),0) FROM VE WHERE MaDon=@MaDon; SELECT @TongDV=ISNULL(SUM(vd.ThanhTien),0) FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe WHERE v.MaDon=@MaDon;
        DECLARE @TongGiamDon MONEY; SELECT @TongGiamDon=ISNULL(SUM(TienGiam),0) FROM VE WHERE MaDon=@MaDon;
        UPDATE DONDATVE SET TongTienVe=@TongVe,TongTienDichVu=@TongDV,TienGiamKM=@TongGiamDon,TongThanhToan=@TongVe+@TongDV WHERE MaDon=@MaDon;
        COMMIT TRANSACTION; SELECT @MaDon AS MaDon,@MaVe AS MaVe;
    END TRY
    BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; THROW; END CATCH
END;
GO

-- (9) phụ: xác nhận đơn nhiều vé
CREATE PROCEDURE sp_XACNHANDON
    @MaDon INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM DONDATVE WHERE MaDon=@MaDon) THROW 50130, N'Không tìm thấy đơn đặt vé.', 1;
    IF NOT EXISTS(SELECT 1 FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy') THROW 50131, N'Đơn chưa có vé.', 1;
    SELECT v.MaDon,v.MaVe,v.MaChuyenBay,v.MaGhe,v.MaHangVe,v.MaKH,v.GiaGoc,v.TongPhanTramGiam,v.TienGiam,v.GiaThucTra,
           dd.TongTienVe,dd.TongTienDichVu,dd.TienGiamKM,dd.TongThanhToan,dd.TrangThai AS TrangThaiDon
    FROM VE v JOIN DONDATVE dd ON dd.MaDon=v.MaDon WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy' ORDER BY v.MaVe;
END;
GO

-- (9) phụ: thêm dịch vụ kể cả sau thanh toán
CREATE PROCEDURE sp_THEMDICHVUVE
    @MaVe INT,
    @MaDichVu INT,
    @SoLuong INT,
    @MaTKNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @MaDon INT,@TrangThaiVe NVARCHAR(20),@DonGia MONEY;
        SELECT @MaDon=MaDon,@TrangThaiVe=TrangThai FROM VE WHERE MaVe=@MaVe;
        IF @MaDon IS NULL THROW 50140, N'Không tìm thấy vé.', 1;
        IF @TrangThaiVe<>N'Đã đặt' THROW 50141, N'Chỉ được thêm dịch vụ cho vé còn hiệu lực.', 1;
        IF @SoLuong<=0 THROW 50142, N'Số lượng dịch vụ phải lớn hơn 0.', 1;
        SELECT @DonGia=DonGia FROM DICHVU WHERE MaDichVu=@MaDichVu AND TrangThai=N'Hoạt động';
        IF @DonGia IS NULL THROW 50143, N'Dịch vụ không tồn tại hoặc đã ngừng hoạt động.', 1;
        IF EXISTS(SELECT 1 FROM VEDICHVU WHERE MaVe=@MaVe AND MaDichVu=@MaDichVu)
            UPDATE VEDICHVU SET SoLuong=SoLuong+@SoLuong WHERE MaVe=@MaVe AND MaDichVu=@MaDichVu;
        ELSE INSERT INTO VEDICHVU(MaVe,MaDichVu,SoLuong,DonGia) VALUES(@MaVe,@MaDichVu,@SoLuong,@DonGia);
        DECLARE @TongDV MONEY=0; SELECT @TongDV=ISNULL(SUM(vd.ThanhTien),0) FROM VE v JOIN VEDICHVU vd ON vd.MaVe=v.MaVe WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy';
        UPDATE DONDATVE SET TongTienDichVu=@TongDV,TongThanhToan=TongTienVe+@TongDV WHERE MaDon=@MaDon;
        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung) VALUES(@MaTKNhanVien,N'Thêm dịch vụ',N'VEDICHVU',CONCAT(N'Thêm dịch vụ cho vé #',@MaVe));
        COMMIT TRANSACTION;
        SELECT @MaVe AS MaVe,@MaDon AS MaDon,@TongDV AS TongTienDichVu;
    END TRY
    BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; THROW; END CATCH
END;
GO
