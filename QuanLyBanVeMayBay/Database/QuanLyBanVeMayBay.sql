/* PROJECT: QUAN LY BAN VE MAY BAY */
--CREATE DATABASE QuanLyBanVeMayBay2;
USE QuanLyBanVeMayBay2;


/* TABLE: TAIKHOAN */
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


/* TABLE: NHATKYHOATDONG */
CREATE TABLE NHATKYHOATDONG
(
    MaNK INT IDENTITY(1,1) PRIMARY KEY,
    MaTK INT NULL REFERENCES TAIKHOAN(MaTK),
    HanhDong NVARCHAR(50) NOT NULL,
    DoiTuong NVARCHAR(50) NULL,
    NoiDung NVARCHAR(300) NULL,
    ThoiGian DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);


/* TABLE: SANBAY */
CREATE TABLE SANBAY
(
    MaSanBay CHAR(3) PRIMARY KEY,
    TenSanBay NVARCHAR(120) NOT NULL,
    ThanhPho NVARCHAR(80) NOT NULL,
    QuocGia NVARCHAR(80) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);


/* TABLE: HANGVE */
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


/* TABLE: MAYBAY */
CREATE TABLE MAYBAY
(
    MaMayBay INT IDENTITY(1,1) PRIMARY KEY,
    SoHieu VARCHAR(20) NOT NULL UNIQUE,
    HangSanXuat NVARCHAR(60) NOT NULL,
    LoaiMayBay NVARCHAR(60) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CHECK (TrangThai IN (N'Hoạt động', N'Bảo trì', N'Ngừng hoạt động'))
);


/* TABLE: GHE */
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


/* TABLE: DICHVU */
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


/* TABLE: CHUYENBAY */
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


/* TABLE: GIAVE */
CREATE TABLE GIAVE
(
    MaChuyenBay INT NOT NULL REFERENCES CHUYENBAY(MaChuyenBay),
    MaHangVe INT NOT NULL REFERENCES HANGVE(MaHangVe),
    DonGia MONEY NOT NULL CHECK (DonGia > 0),
    PRIMARY KEY (MaChuyenBay, MaHangVe)
);


/* TABLE: GHECHUYENBAY */
CREATE TABLE GHECHUYENBAY
(
    MaChuyenBay INT NOT NULL REFERENCES CHUYENBAY(MaChuyenBay),
    MaGhe INT NOT NULL REFERENCES GHE(MaGhe),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Trống'
        CHECK (TrangThai IN (N'Trống', N'Đã đặt', N'Khóa')),
    PRIMARY KEY (MaChuyenBay, MaGhe)
);


/* TABLE: HANGTHANHVIEN */
CREATE TABLE HANGTHANHVIEN
(
    MaHangTV INT IDENTITY(1,1) PRIMARY KEY,
    TenHang NVARCHAR(40) NOT NULL UNIQUE,
    DiemChiTieuToiThieu MONEY NOT NULL UNIQUE CHECK (DiemChiTieuToiThieu >= 0),
    PhanTramGiam INT NOT NULL CHECK (PhanTramGiam BETWEEN 0 AND 30),
    MoTa NVARCHAR(200) NULL
);


/* TABLE: KHACHHANG */
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


/* TABLE: KHUYENMAI */
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


/* TABLE: DONDATVE */
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


/* TABLE: VE */
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


/* TABLE: VEDICHVU */
CREATE TABLE VEDICHVU
(
    MaVe INT NOT NULL REFERENCES VE(MaVe),
    MaDichVu INT NOT NULL REFERENCES DICHVU(MaDichVu),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia MONEY NOT NULL CHECK (DonGia >= 0),
    ThanhTien AS (SoLuong * DonGia),
    PRIMARY KEY (MaVe, MaDichVu)
);


/* TABLE: THANHTOAN */
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


/* TABLE: HUYVE */
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
('nv01','123456',N'Phạm Sơn Tùng','nv01@gmail.com','0900000002',N'NhanVien'),
('nv02','123456',N'Vũ Quang Thái','nv02@gmail.com','0900000003',N'NhanVien'),
('nv03','123456',N'Đoàn Thị Kim Ngân','nv03@gmail.com','0900000004',N'NhanVien'),
('nv04','123456',N'Trịnh Thị Thanh Xuân','nv04@gmail.com','0900000005',N'NhanVien');


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


/* Seat layout: each aircraft has 20 seats, rows 1-4, columns A-E.
   A/B/C = economy, D = premium economy, E = business. */
INSERT INTO GHE (MaMayBay, SoGhe, SoHang, CotGhe, MaHangVe)
SELECT mb.MaMayBay,
       CONCAT(r.SoHang, c.CotGhe),
       r.SoHang,
       c.CotGhe,
       CASE WHEN c.CotGhe = 'E' THEN 3
            WHEN c.CotGhe = 'D' THEN 2
            ELSE 1 END
FROM MAYBAY mb
CROSS JOIN (VALUES (1),(2),(3),(4)) AS r(SoHang)
CROSS JOIN (VALUES ('A'),('B'),('C'),('D'),('E')) AS c(CotGhe)


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


/* Generate 40 customers with consistent unique documents. */
INSERT INTO KHACHHANG
(HoTen, LoaiGiayTo, SoGiayTo, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, MaHangTV, TongChiTieu)
SELECT
    CONCAT(N'Khách hàng ', RIGHT(CONCAT('000',n),3)),
    CASE WHEN n % 5 = 0 THEN N'Hộ chiếu' ELSE N'CCCD' END,
    CONCAT('ID', RIGHT(CONCAT('000000',n),6)),
    DATEADD(YEAR, -(20 + n % 35), CONVERT(DATE,'2000-01-01')),
    CASE WHEN n % 2 = 0 THEN N'Nữ' ELSE N'Nam' END,
    CONCAT('09', RIGHT(CONCAT('00000000',n),8)),
    CONCAT('KHACHHANG',n,'@demo.local'),
    CASE WHEN n % 3 = 0 THEN N'Hà Nội' WHEN n % 3 = 1 THEN N'TP. Hồ Chí Minh' ELSE N'Đà Nẵng' END,
    1, 0
FROM (VALUES
    (1),
    (2),
    (3),
    (4),
    (5),
    (6),
    (7),
    (8),
    (9),
    (10),
    (11),
    (12),
    (13),
    (14),
    (15),
    (16),
    (17),
    (18),
    (19),
    (20),
    (21),
    (22),
    (23),
    (24),
    (25),
    (26),
    (27),
    (28),
    (29),
    (30),
    (31),
    (32),
    (33),
    (34),
    (35),
    (36),
    (37),
    (38),
    (39),
    (40)
) AS N(n)


/* Build one flight for each allowed route on allowed routes.
   Dates are relative to current date to keep search/demo useful; each allowed direction appears once. */
;WITH Routes AS
(
    SELECT * FROM (VALUES
      (1,'HAN','SGN',125),(2,'SGN','HAN',125),
      (3,'HAN','DAD',80),(4,'DAD','HAN',80),
      (5,'HAN','PQC',130),(6,'PQC','HAN',130),
      (7,'SGN','DAD',85),(8,'DAD','SGN',85),
      (9,'SGN','PQC',60),(10,'PQC','SGN',60),
      (11,'HAN','CXR',115),(12,'CXR','HAN',115),
      (13,'SGN','DLI',55),(14,'DLI','SGN',55),
      (15,'HAN','VCA',130),(16,'VCA','HAN',130),
      (17,'HPH','VCA',110),(18,'VCA','HPH',110),
      (19,'HAN','NRT',300),(20,'NRT','HAN',300),
      (21,'SGN','NRT',330),(22,'NRT','SGN',330),
      (23,'HAN','ICN',270),(24,'ICN','HAN',270),
      (25,'SGN','ICN',300),(26,'ICN','SGN',300),
      (27,'HAN','HKG',150),(28,'HKG','HAN',150),
      (29,'SGN','HKG',170),(30,'HKG','SGN',170),
      (31,'HAN','SIN',190),(32,'SIN','HAN',190),
      (33,'SGN','SIN',150),(34,'SIN','SGN',150),
      (35,'HAN','SYD',570),(36,'SYD','HAN',570),
      (37,'SGN','SYD',510),(38,'SYD','SGN',510),
      (39,'HAN','SVO',600),(40,'SVO','HAN',600),
      (41,'SGN','SVO',620),(42,'SVO','SGN',620),
      (43,'HAN','MAN',780),(44,'MAN','HAN',780),
      (45,'SGN','MAN',800),(46,'MAN','SGN',800)
    ) R(RouteID, Di, Den, Phut)
),
Seq AS
(
    SELECT n FROM (VALUES
        (1),
        (2),
        (3),
        (4),
        (5),
        (6),
        (7),
        (8),
        (9),
        (10),
        (11),
        (12),
        (13),
        (14),
        (15),
        (16),
        (17),
        (18),
        (19),
        (20),
        (21),
        (22),
        (23),
        (24),
        (25),
        (26),
        (27),
        (28),
        (29),
        (30),
        (31),
        (32),
        (33),
        (34),
        (35),
        (36),
        (37),
        (38),
        (39),
        (40),
        (41),
        (42),
        (43),
        (44),
        (45),
        (46)
    ) AS X(n)
),
Chosen AS
(
    SELECT n, (n - 1) % 46 + 1 AS RouteID,
           DATEADD(DAY, (n - 1) % 28 + 1, CONVERT(DATE,GETDATE())) AS NgayBay,
           ((n * 3) % 12 + 6) AS GioBay,
           ((n * 7) % 4) + 1 AS MayBayID
    FROM Seq
)
INSERT INTO CHUYENBAY
(MaMayBay, MaSanBayDi, MaSanBayDen, NgayGioKhoiHanh, ThoiGianBayPhut, TrangThai, NguoiTao)
SELECT c.MayBayID, r.Di, r.Den,
       DATEADD(HOUR,c.GioBay,CONVERT(DATETIME2,c.NgayBay)),
       r.Phut, N'Đang mở bán', 1
FROM Chosen c
JOIN Routes r ON r.RouteID = c.RouteID
GO

/* Create fares and seat state for every flight.
   Economy fare is route-sensitive; premium and business are multipliers. */
INSERT INTO GIAVE (MaChuyenBay, MaHangVe, DonGia)
SELECT cb.MaChuyenBay, hv.MaHangVe,
       CONVERT(MONEY,
         CASE
           WHEN cb.MaSanBayDen IN ('NRT','ICN','HKG','SIN') OR cb.MaSanBayDi IN ('NRT','ICN','HKG','SIN')
             THEN CASE WHEN hv.MaHangVe = 1 THEN 2500000 WHEN hv.MaHangVe = 2 THEN 4200000 ELSE 8500000 END
           WHEN cb.MaSanBayDen IN ('SYD','SVO','MAN') OR cb.MaSanBayDi IN ('SYD','SVO','MAN')
             THEN CASE WHEN hv.MaHangVe = 1 THEN 6500000 WHEN hv.MaHangVe = 2 THEN 9500000 ELSE 18000000 END
           ELSE CASE WHEN hv.MaHangVe = 1 THEN 900000 WHEN hv.MaHangVe = 2 THEN 1500000 ELSE 2800000 END
         END)
FROM CHUYENBAY cb
CROSS JOIN HANGVE hv
WHERE hv.MaHangVe IN (1,2,3);
GO

INSERT INTO GHECHUYENBAY (MaChuyenBay, MaGhe, TrangThai)
SELECT cb.MaChuyenBay, g.MaGhe, N'Trống'
FROM CHUYENBAY cb
JOIN GHE g ON g.MaMayBay = cb.MaMayBay;
GO

/* Compact, internally consistent demo transactions: 10 orders, 12 tickets. */
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

DECLARE @SeedVe TABLE
(
    MaDon INT NOT NULL,
    MaChuyenBay INT NOT NULL,
    MaHangVe INT NOT NULL,
    MaKH INT NOT NULL,
    PhanTramGiamHang INT NOT NULL,
    PhanTramGiamTet INT NOT NULL,
    PhanTramGiamKhuHoi INT NOT NULL,
    PhanTramGiamKM INT NOT NULL,
    TongPhanTramGiam INT NOT NULL,
    GiaGoc MONEY NOT NULL,
    GiaThucTra MONEY NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL
);

INSERT INTO @SeedVe VALUES
(1,1,1,1,0,0,0,0,0,900000,900000,N'Đã đặt'),
(2,2,1,2,0,0,0,0,0,900000,900000,N'Đã đặt'),
(3,3,1,3,0,0,0,0,0,900000,900000,N'Đã đặt'),
(4,4,1,4,0,0,0,0,0,900000,900000,N'Đã đặt'),
(5,5,1,5,0,0,10,0,10,900000,810000,N'Đã đặt'),
(5,6,1,5,0,0,10,0,10,900000,810000,N'Đã đặt'),
(6,19,1,6,0,0,10,0,10,2500000,2250000,N'Đã đặt'),
(6,20,1,6,0,0,10,0,10,2500000,2250000,N'Đã đặt'),
(7,7,1,7,0,0,0,0,0,900000,900000,N'Đã đặt'),
(8,8,1,8,0,0,0,0,0,900000,900000,N'Đã đặt'),
(9,9,1,9,0,0,0,0,0,900000,900000,N'Đã hủy'),
(10,10,1,10,0,0,0,3,3,900000,873000,N'Đã đặt');

INSERT INTO VE
(MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,
 PhanTramGiamHang,PhanTramGiamTet,PhanTramGiamKhuHoi,PhanTramGiamKM,
 TongPhanTramGiam,TienGiam,GiaThucTra,TrangThai)
SELECT sv.MaDon,sv.MaChuyenBay,g.MaGhe,sv.MaHangVe,sv.MaKH,NULL,sv.GiaGoc,
       sv.PhanTramGiamHang,sv.PhanTramGiamTet,sv.PhanTramGiamKhuHoi,sv.PhanTramGiamKM,
       sv.TongPhanTramGiam,sv.GiaGoc-sv.GiaThucTra,sv.GiaThucTra,sv.TrangThai
FROM @SeedVe sv
JOIN CHUYENBAY cb ON cb.MaChuyenBay=sv.MaChuyenBay
CROSS APPLY
(
    SELECT TOP 1 gg.MaGhe
    FROM GHE gg
    WHERE gg.MaMayBay=cb.MaMayBay AND gg.MaHangVe=sv.MaHangVe
      AND NOT EXISTS
      (
        SELECT 1 FROM VE vx
        WHERE vx.MaChuyenBay=sv.MaChuyenBay AND vx.MaGhe=gg.MaGhe AND vx.TrangThai<>N'Đã hủy'
      )
    ORDER BY gg.MaGhe
) g;
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


/* Reconcile sample customer spending and membership dates with successful purchases/refunds. */
;WITH PaymentByOrder AS
(
    SELECT MaDon, MIN(NgayThanhToan) AS NgayThanhToanDau
    FROM THANHTOAN
    WHERE TrangThai=N'Thành công'
    GROUP BY MaDon
), SpendByCustomer AS
(
    SELECT v.MaKH,
           SUM(CASE WHEN p.MaDon IS NOT NULL
                    THEN v.GiaThucTra+ISNULL(dv.TienDV,0)-ISNULL(ref.TienHoan,0)
                    ELSE 0 END) AS TongChiTieu,
           MIN(p.NgayThanhToanDau) AS NgayDauTien
    FROM VE v
    JOIN DONDATVE dd ON dd.MaDon=v.MaDon
    LEFT JOIN PaymentByOrder p ON p.MaDon=dd.MaDon
    OUTER APPLY (SELECT SUM(vd.ThanhTien) AS TienDV FROM VEDICHVU vd WHERE vd.MaVe=v.MaVe) dv
    OUTER APPLY (SELECT SUM(h.TienHoan) AS TienHoan FROM HUYVE h WHERE h.MaVe=v.MaVe) ref
    GROUP BY v.MaKH
)
UPDATE kh
SET TongChiTieu=ISNULL(x.TongChiTieu,0),
    NgayGiaoDichDauTien=x.NgayDauTien,
    NgayKetThucThanhVien=CASE WHEN x.NgayDauTien IS NULL THEN NULL ELSE DATEADD(YEAR,1,x.NgayDauTien) END,
    MaHangTV=CASE WHEN x.NgayDauTien IS NULL OR DATEADD(YEAR,1,x.NgayDauTien)<SYSDATETIME() THEN 1
                  ELSE ISNULL((SELECT TOP 1 h.MaHangTV FROM HANGTHANHVIEN h
                               WHERE h.DiemChiTieuToiThieu<=ISNULL(x.TongChiTieu,0)
                               ORDER BY h.DiemChiTieuToiThieu DESC),1) END
FROM KHACHHANG kh
LEFT JOIN SpendByCustomer x ON x.MaKH=kh.MaKH;
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


/* VIEW: V_CHUYENBAYCHITIET */
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
JOIN SANBAY sb1 ON cb.MaSanBayDi = sb1.MaSanBay
JOIN SANBAY sb2 ON cb.MaSanBayDen = sb2.MaSanBay
JOIN MAYBAY mb ON cb.MaMayBay = mb.MaMayBay
OUTER APPLY
(
    SELECT MIN(DonGia) AS GiaThapNhat
    FROM GIAVE WHERE MaChuyenBay = cb.MaChuyenBay
) gv
OUTER APPLY
(
    SELECT COUNT(*) AS SoGheTrong
    FROM GHECHUYENBAY
    WHERE MaChuyenBay = cb.MaChuyenBay AND TrangThai = N'Trống'
) gc;
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

/* VIEW: V_DOANHTHUTHEOCHUYENBAY */
CREATE VIEW V_DOANHTHUTHEOCHUYENBAY
AS
SELECT cb.MaChuyenBay, sb1.ThanhPho AS ThanhPhoDi, sb2.ThanhPho AS ThanhPhoDen,
       cb.NgayGioKhoiHanh,
       COUNT(CASE WHEN v.TrangThai <> N'Đã hủy' THEN 1 END) AS SoVeConHieuLuc,
       SUM(CASE WHEN v.TrangThai <> N'Đã hủy' THEN v.GiaThucTra ELSE 0 END) AS DoanhThuVe,
       ISNULL(dv.TongTienDichVu,0) AS DoanhThuDichVu
FROM CHUYENBAY cb
JOIN SANBAY sb1 ON cb.MaSanBayDi = sb1.MaSanBay
JOIN SANBAY sb2 ON cb.MaSanBayDen = sb2.MaSanBay
LEFT JOIN VE v ON cb.MaChuyenBay = v.MaChuyenBay
OUTER APPLY
(
    SELECT SUM(vd.ThanhTien) AS TongTienDichVu
    FROM VE v2
    JOIN VEDICHVU vd ON vd.MaVe = v2.MaVe
    WHERE v2.MaChuyenBay = cb.MaChuyenBay AND v2.TrangThai <> N'Đã hủy'
) dv
GROUP BY cb.MaChuyenBay, sb1.ThanhPho, sb2.ThanhPho, cb.NgayGioKhoiHanh, dv.TongTienDichVu;
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

/* VIEW: V_LICHSUGIAODICH */
CREATE VIEW V_LICHSUGIAODICH
AS
SELECT dd.MaDon, dd.NgayDat, dd.MaKHLienHe, kh.HoTen AS KhachHangLienHe,
       dd.TrangThai, dd.TongTienVe, dd.TongTienDichVu, dd.TienGiamKM, dd.TongThanhToan,
       ISNULL(tt.TongDaThu,0) AS TongDaThu,
       ISNULL(hv.TongTienHoan,0) AS TongTienHoan
FROM DONDATVE dd
JOIN KHACHHANG kh ON dd.MaKHLienHe = kh.MaKH
OUTER APPLY
(
    SELECT SUM(SoTien) AS TongDaThu
    FROM THANHTOAN
    WHERE MaDon = dd.MaDon AND TrangThai = N'Thành công'
) tt
OUTER APPLY
(
    SELECT SUM(HUYVE.TienHoan) AS TongTienHoan
    FROM HUYVE
    JOIN VE ON VE.MaVe = HUYVE.MaVe
    WHERE VE.MaDon = dd.MaDon
) hv;
GO


/* PROCEDURE: sp_DANGNHAP */
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


/* PROCEDURE: sp_TIMKIEMCHUYENBAY */
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

/* PROCEDURE: sp_TAOCHUYENBAY */
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
        -- TRANSACTION: TAOCHUYENBAY - Chi COMMIT khi cac buoc thanh cong.
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

/* PROCEDURE: sp_TAOMAYBAYVAGHE */
CREATE PROCEDURE sp_TAOMAYBAYVAGHE
    @SoHieu VARCHAR(20),
    @HangSanXuat NVARCHAR(60),
    @LoaiMayBay NVARCHAR(60),
    @SoHang INT = 4
AS
BEGIN
    SET NOCOUNT ON;
    IF @SoHang < 1 OR @SoHang > 60
        THROW 50020, N'Số hàng ghế phải từ 1 đến 60.', 1;
    IF EXISTS (SELECT 1 FROM MAYBAY WHERE SoHieu=@SoHieu)
        THROW 50021, N'Số hiệu máy bay đã tồn tại.', 1;

    BEGIN TRY
        -- TRANSACTION: TAOMAYBAYVAGHE - Chi COMMIT khi cac buoc thanh cong.
        BEGIN TRANSACTION;
        INSERT INTO MAYBAY(SoHieu,HangSanXuat,LoaiMayBay)
        VALUES(@SoHieu,@HangSanXuat,@LoaiMayBay);
        DECLARE @MaMayBay INT = SCOPE_IDENTITY();

        DECLARE @Hang INT = 1;
        WHILE @Hang <= @SoHang
        BEGIN
            INSERT INTO GHE(MaMayBay,SoGhe,SoHang,CotGhe,MaHangVe)
            SELECT @MaMayBay,CONCAT(@Hang,C.Cot),@Hang,C.Cot,
                   CASE WHEN C.Cot='E' THEN 3 WHEN C.Cot='D' THEN 2 ELSE 1 END
            FROM (VALUES ('A'),('B'),('C'),('D'),('E')) AS C(Cot);

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

/* NGHIEP VU: sp_DATVE nhan thong tin mot hoac hai ve bang tham so thong thuong.
   Dich vu duoc them bang INSERT co tham so tu C# va cap nhat tong tien don. Tong giam gia toi da 30%. */
/* PROCEDURE: sp_DATVE */
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

    DECLARE @DanhSachVe TABLE
    (
        SoThuTuVe INT PRIMARY KEY,
        MaChuyenBay INT NOT NULL,
        MaGhe INT NOT NULL,
        MaHangVe INT NOT NULL,
        MaKH INT NOT NULL,
        MaNguoiGiamHo INT NULL
    );

    INSERT INTO @DanhSachVe(SoThuTuVe, MaChuyenBay, MaGhe, MaHangVe, MaKH, MaNguoiGiamHo)
    VALUES (1, @MaChuyenBay1, @MaGhe1, @MaHangVe1, @MaKH1, @MaNguoiGiamHo1);

    IF @MaKH2 IS NOT NULL OR @MaChuyenBay2 IS NOT NULL OR @MaGhe2 IS NOT NULL OR @MaHangVe2 IS NOT NULL OR @MaNguoiGiamHo2 IS NOT NULL
    BEGIN
        IF @MaKH2 IS NULL OR @MaChuyenBay2 IS NULL OR @MaGhe2 IS NULL OR @MaHangVe2 IS NULL
            THROW 50030, N'Thông tin vé thứ hai chưa đầy đủ.', 1;

        INSERT INTO @DanhSachVe(SoThuTuVe, MaChuyenBay, MaGhe, MaHangVe, MaKH, MaNguoiGiamHo)
        VALUES (2, @MaChuyenBay2, @MaGhe2, @MaHangVe2, @MaKH2, @MaNguoiGiamHo2);
    END;
    IF NOT EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKHLienHe)
        THROW 50030, N'Khách hàng liên hệ không tồn tại.', 1;
    IF NOT EXISTS (SELECT 1 FROM TAIKHOAN WHERE MaTK=@MaTKNhanVien AND TrangThai=N'Hoạt động')
        THROW 50030, N'Tài khoản nhân viên không hợp lệ hoặc đã bị khóa.', 1;
    IF EXISTS
    (
        SELECT 1 FROM @DanhSachVe d
        LEFT JOIN KHACHHANG kh ON kh.MaKH=d.MaKH
        LEFT JOIN KHACHHANG ng ON ng.MaKH=d.MaNguoiGiamHo
        WHERE kh.MaKH IS NULL OR (d.MaNguoiGiamHo IS NOT NULL AND ng.MaKH IS NULL)
    )
        THROW 50030, N'Hành khách hoặc người giám hộ không tồn tại.', 1;
    IF EXISTS
    (
        SELECT 1 FROM @DanhSachVe d
        JOIN HANGVE hv ON hv.MaHangVe=d.MaHangVe
        WHERE hv.TrangThai<>N'Hoạt động'
    )
        THROW 50030, N'Hạng vé đã ngừng hoạt động.', 1;
    IF EXISTS
    (
        SELECT 1 FROM @DanhSachVe d
        LEFT JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay
        WHERE cb.MaChuyenBay IS NULL OR cb.TrangThai <> N'Đang mở bán'
           OR cb.NgayGioKhoiHanh <= SYSDATETIME()
    )
        THROW 50031, N'Chuyến bay không tồn tại, không còn mở bán hoặc đã khởi hành.', 1;
    IF EXISTS
    (
        SELECT 1 FROM @DanhSachVe d
        LEFT JOIN GHE g ON g.MaGhe=d.MaGhe
        LEFT JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay
        LEFT JOIN GIAVE gv ON gv.MaChuyenBay=d.MaChuyenBay AND gv.MaHangVe=d.MaHangVe
        WHERE g.MaGhe IS NULL OR cb.MaChuyenBay IS NULL OR gv.MaChuyenBay IS NULL
           OR g.MaMayBay <> cb.MaMayBay OR g.MaHangVe <> d.MaHangVe
    )
        THROW 50032, N'Ghế, máy bay hoặc hạng vé không hợp lệ.', 1;
    IF EXISTS
    (
        SELECT 1
        FROM @DanhSachVe d
        JOIN KHACHHANG kh ON kh.MaKH=d.MaKH
        JOIN CHUYENBAY cb ON cb.MaChuyenBay=d.MaChuyenBay
        WHERE DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
              - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,kh.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),kh.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END < 16
          AND (d.MaNguoiGiamHo IS NULL OR d.MaNguoiGiamHo=d.MaKH
               OR NOT EXISTS
               (
                   SELECT 1 FROM KHACHHANG ng
                   WHERE ng.MaKH=d.MaNguoiGiamHo
                     AND DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh))
                         - CASE WHEN DATEADD(YEAR,DATEDIFF(YEAR,ng.NgaySinh,CONVERT(DATE,cb.NgayGioKhoiHanh)),ng.NgaySinh)>CONVERT(DATE,cb.NgayGioKhoiHanh) THEN 1 ELSE 0 END >= 18
               ))
    )
        THROW 50033, N'Hành khách dưới 16 tuổi cần người giám hộ từ 18 tuổi.', 1;
    IF EXISTS (SELECT MaChuyenBay,MaGhe FROM @DanhSachVe GROUP BY MaChuyenBay,MaGhe HAVING COUNT(*)>1)
        THROW 50034, N'Đơn có ghế bị chọn trùng.', 1;
    IF EXISTS (SELECT MaChuyenBay,MaKH FROM @DanhSachVe GROUP BY MaChuyenBay,MaKH HAVING COUNT(*)>1)
        THROW 50035, N'Một hành khách không thể có hai vé cùng chuyến bay.', 1;

    BEGIN TRY
        -- TRANSACTION: DATVE - Chi COMMIT khi cac buoc thanh cong.
        BEGIN TRANSACTION;

        IF EXISTS
        (
            SELECT 1 FROM @DanhSachVe d
            LEFT JOIN GHECHUYENBAY gc WITH (UPDLOCK,HOLDLOCK)
              ON gc.MaChuyenBay=d.MaChuyenBay AND gc.MaGhe=d.MaGhe
            WHERE gc.MaGhe IS NULL OR gc.TrangThai <> N'Trống'
        )
            THROW 50036, N'Có ghế không còn trống hoặc bị khóa.', 1;

        DECLARE @NgayHienTai DATE=CONVERT(DATE,GETDATE());
        IF @ApDungTet=1 AND MONTH(@NgayHienTai) NOT BETWEEN 1 AND 3
            THROW 50037, N'Khuyến mãi Tết chỉ áp dụng khi mua vé trong tháng 1 đến tháng 3.', 1;

        IF @ApDungTet=1 AND EXISTS
        (
            SELECT d.MaKH
            FROM @DanhSachVe d
            GROUP BY d.MaKH
            HAVING
              (SELECT COUNT(*)
               FROM VE v
               JOIN DONDATVE dd ON dd.MaDon=v.MaDon
               WHERE v.MaKH=d.MaKH AND v.PhanTramGiamTet>0
                 AND YEAR(dd.NgayDat)=YEAR(GETDATE())
                 AND MONTH(dd.NgayDat) BETWEEN 1 AND 3
                 AND v.TrangThai<>N'Đã hủy') + COUNT(*) > 2
        )
            THROW 50038, N'Mỗi khách hàng chỉ được áp dụng ưu đãi Tết tối đa 2 chuyến trong năm.', 1;

        IF @ApDungKhuHoi=1
        BEGIN
            IF (SELECT COUNT(*) FROM @DanhSachVe) <> 2
               OR NOT EXISTS
               (
                 SELECT 1
                 FROM @DanhSachVe a
                 JOIN CHUYENBAY ca ON ca.MaChuyenBay=a.MaChuyenBay
                 JOIN @DanhSachVe b ON b.MaChuyenBay<>a.MaChuyenBay AND b.MaKH=a.MaKH
                 JOIN CHUYENBAY cb ON cb.MaChuyenBay=b.MaChuyenBay
                 WHERE ca.MaSanBayDi=cb.MaSanBayDen
                   AND ca.MaSanBayDen=cb.MaSanBayDi
               )
                THROW 50039, N'Giảm giá khứ hồi cần đúng hai vé cùng hành khách có tuyến bay đảo chiều.', 1;
        END;

        IF @MaKM IS NOT NULL AND EXISTS
        (
            SELECT 1 FROM KHUYENMAI
            WHERE MaKM=@MaKM AND TenKM=N'Ưu đãi Tết'
        )
            THROW 50041, N'Ưu đãi Tết được áp dụng riêng, không chọn trong danh sách khuyến mãi.', 1;

        IF @MaKM IS NOT NULL AND NOT EXISTS
        (
            SELECT 1 FROM KHUYENMAI WITH (UPDLOCK,HOLDLOCK)
            WHERE MaKM=@MaKM AND TrangThai=N'Hoạt động'
              AND @NgayHienTai BETWEEN NgayBatDau AND NgayKetThuc
              AND (SoLuotToiDa IS NULL OR SoLuotDaDung < SoLuotToiDa)
        )
            THROW 50040, N'Mã khuyến mãi không hợp lệ, hết hạn hoặc hết lượt.', 1;

        INSERT INTO DONDATVE(MaKHLienHe,MaTKNhanVien,MaKM,TrangThai)
        VALUES(@MaKHLienHe,@MaTKNhanVien,@MaKM,N'Chờ thanh toán');
        DECLARE @MaDon INT=SCOPE_IDENTITY();

        DECLARE @VeGia TABLE
        (
            SoThuTuVe INT PRIMARY KEY,
            MaChuyenBay INT NOT NULL,
            MaGhe INT NOT NULL,
            MaHangVe INT NOT NULL,
            MaKH INT NOT NULL,
            MaNguoiGiamHo INT NULL,
            GiaGoc MONEY NOT NULL,
            GiamHang INT NOT NULL,
            GiamTet INT NOT NULL,
            GiamKhuHoi INT NOT NULL,
            GiamKM INT NOT NULL,
            TongGiam INT NOT NULL,
            TienGiam MONEY NOT NULL,
            GiaThucTra MONEY NOT NULL
        );
        
        INSERT INTO @VeGia
        (
            SoThuTuVe, MaChuyenBay, MaGhe, MaHangVe, MaKH, MaNguoiGiamHo, GiaGoc,
            GiamHang, GiamTet, GiamKhuHoi, GiamKM, TongGiam, TienGiam, GiaThucTra
        ) SELECT
            d.SoThuTuVe, d.MaChuyenBay, d.MaGhe, d.MaHangVe, d.MaKH, d.MaNguoiGiamHo,
            gv.DonGia, rt.GiamHang, rt.GiamTet, rt.GiamKhuHoi, rt.GiamKM, rt.TongGiam,
            ROUND(gv.DonGia * rt.TongGiam / 100.0, 2) AS TienGiam,
            gv.DonGia - ROUND(gv.DonGia * rt.TongGiam / 100.0, 2) AS GiaThucTra

        FROM @DanhSachVe d
        JOIN GIAVE gv
            ON gv.MaChuyenBay = d.MaChuyenBay
           AND gv.MaHangVe = d.MaHangVe
        JOIN KHACHHANG kh
            ON kh.MaKH = d.MaKH
        LEFT JOIN HANGTHANHVIEN htv
            ON htv.MaHangTV = kh.MaHangTV
        LEFT JOIN KHUYENMAI km
            ON km.MaKM = @MaKM

        CROSS APPLY
        (
            SELECT
                CONVERT(INT,
                    CASE
                        WHEN kh.NgayKetThucThanhVien IS NOT NULL
                         AND kh.NgayKetThucThanhVien < SYSDATETIME()
                        THEN 0
                        ELSE ISNULL(htv.PhanTramGiam, 0)
                    END
                ) AS GiamHang,

                CONVERT(INT,
                    CASE WHEN @ApDungTet = 1 THEN 10 ELSE 0 END
                ) AS GiamTet,

                CONVERT(INT,
                    CASE WHEN @ApDungKhuHoi = 1 THEN 10 ELSE 0 END
                ) AS GiamKhuHoi,

                CONVERT(INT,
                    CASE
                        WHEN @MaKM IS NULL THEN 0
                        WHEN km.GiamToiDa IS NULL
                            THEN ISNULL(km.PhanTramGiam, 0)
                        WHEN gv.DonGia * km.PhanTramGiam / 100.0
                             > km.GiamToiDa
                            THEN km.GiamToiDa * 100.0 / gv.DonGia
                        ELSE ISNULL(km.PhanTramGiam, 0)
                    END
                ) AS GiamKM
        ) AS br

        CROSS APPLY
        (
            SELECT
                br.GiamHang,
                br.GiamTet,
                br.GiamKhuHoi,
                br.GiamKM,

                CONVERT(INT,
                    CASE
                        WHEN br.GiamHang + br.GiamTet
                           + br.GiamKhuHoi + br.GiamKM > 30
                        THEN 30
                        ELSE br.GiamHang + br.GiamTet
                           + br.GiamKhuHoi + br.GiamKM
                    END
                ) AS TongGiam
        ) AS rt;

        INSERT INTO VE
        (MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,
         PhanTramGiamHang,PhanTramGiamTet,PhanTramGiamKhuHoi,PhanTramGiamKM,
         TongPhanTramGiam,TienGiam,GiaThucTra,TrangThai)
        SELECT @MaDon,MaChuyenBay,MaGhe,MaHangVe,MaKH,MaNguoiGiamHo,GiaGoc,
               GiamHang,GiamTet,GiamKhuHoi,GiamKM,TongGiam,TienGiam,GiaThucTra,N'Đã đặt'
        FROM @VeGia;

        UPDATE gc SET TrangThai=N'Đã đặt'
        FROM GHECHUYENBAY gc
        JOIN @DanhSachVe d ON gc.MaChuyenBay=d.MaChuyenBay AND gc.MaGhe=d.MaGhe;

        DECLARE @TongTienVe MONEY, @TongTienDichVu MONEY,
                @TongGiamKM MONEY=0, @TongThanhToan MONEY;
        SELECT @TongTienVe=SUM(GiaThucTra) FROM VE WHERE MaDon=@MaDon;
        SET @TongTienDichVu=0;
        SELECT @TongGiamKM=ISNULL(SUM(TienGiam),0)
        FROM @VeGia;

        SET @TongThanhToan=@TongTienVe+@TongTienDichVu;
        UPDATE DONDATVE
        SET TongTienVe=@TongTienVe,TongTienDichVu=@TongTienDichVu,
            TienGiamKM=@TongGiamKM,TongThanhToan=@TongThanhToan
        WHERE MaDon=@MaDon;

        IF @MaKM IS NOT NULL
            UPDATE KHUYENMAI SET SoLuotDaDung=SoLuotDaDung+1 WHERE MaKM=@MaKM;

        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung)
        VALUES(@MaTKNhanVien,N'Đặt vé',N'DONDATVE',CONCAT(N'Tạo đơn đặt vé #',@MaDon));

        COMMIT TRANSACTION;
        /* KET QUA: Mot tap du lieu duy nhat; moi dong la mot ve trong don.
           Cac cot tong tien cua don duoc lap lai tren moi dong de C# doc bang ExecuteReader thong thuong. */
        SELECT
            v.MaDon, v.MaVe, v.MaChuyenBay, v.MaGhe, v.MaHangVe, v.MaKH, 
            v.GiaGoc, v.TongPhanTramGiam, v.TienGiam, v.GiaThucTra,
            dd.TongTienVe, dd.TongTienDichVu, dd.TienGiamKM, dd.TongThanhToan, dd.TrangThai AS TrangThaiDon
        FROM VE v
        JOIN DONDATVE dd ON dd.MaDon=v.MaDon
        WHERE v.MaDon=@MaDon
        ORDER BY v.MaVe;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


/* PROCEDURE: sp_THANHTOANDON */
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
        -- TRANSACTION: THANHTOANDON - Chi COMMIT khi cac buoc thanh cong.
        BEGIN TRANSACTION;

        DECLARE @TongThanhToan MONEY, @TrangThai NVARCHAR(30);
        SELECT @TongThanhToan=TongThanhToan,@TrangThai=TrangThai
        FROM DONDATVE WITH (UPDLOCK,HOLDLOCK) WHERE MaDon=@MaDon;

        IF @TongThanhToan IS NULL THROW 50050, N'Không tìm thấy đơn đặt vé.', 1;
        IF @TrangThai<>N'Chờ thanh toán' THROW 50051, N'Đơn không ở trạng thái chờ thanh toán.', 1;
        IF @SoTien<>@TongThanhToan THROW 50052, N'Số tiền thanh toán phải bằng tổng thanh toán.', 1;
        IF @PhuongThuc NOT IN (N'Tiền mặt',N'Chuyển khoản',N'Thẻ')
            THROW 50053, N'Phương thức thanh toán không hợp lệ.', 1;
        IF NOT EXISTS (SELECT 1 FROM TAIKHOAN WHERE MaTK=@MaTKNhanVien AND TrangThai=N'Hoạt động')
            THROW 50053, N'Tài khoản nhân viên không hợp lệ hoặc đã bị khóa.', 1;
        IF EXISTS (SELECT 1 FROM VE WHERE MaDon=@MaDon AND TrangThai=N'Đã hủy')
            THROW 50054, N'Đơn có vé đã hủy; hãy xử lý lại đơn trước khi thanh toán.', 1;

        INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,MaTKNhanVien,TrangThai,GhiChu)
        VALUES(@MaDon,@SoTien,@PhuongThuc,@MaTKNhanVien,N'Thành công',@GhiChu);
        UPDATE DONDATVE SET TrangThai=N'Đã thanh toán' WHERE MaDon=@MaDon;

        DECLARE @ChiTieu TABLE(MaKH INT PRIMARY KEY, SoTien MONEY);
        INSERT INTO @ChiTieu(MaKH,SoTien)
        SELECT v.MaKH,SUM(v.GiaThucTra+ISNULL(dv.TienDV,0))
        FROM VE v
        OUTER APPLY
        (
            SELECT SUM(vd.ThanhTien) AS TienDV
            FROM VEDICHVU vd WHERE vd.MaVe=v.MaVe
        ) dv
        WHERE v.MaDon=@MaDon AND v.TrangThai<>N'Đã hủy'
        GROUP BY v.MaKH;

        UPDATE kh
        SET NgayGiaoDichDauTien=ISNULL(kh.NgayGiaoDichDauTien,SYSDATETIME()),
            NgayKetThucThanhVien=CASE WHEN kh.NgayGiaoDichDauTien IS NULL
                                      THEN DATEADD(YEAR,1,SYSDATETIME())
                                      ELSE kh.NgayKetThucThanhVien END,
            TongChiTieu=kh.TongChiTieu+c.SoTien
        FROM KHACHHANG kh JOIN @ChiTieu c ON c.MaKH=kh.MaKH;

        UPDATE kh
        SET MaHangTV=CASE
            WHEN kh.NgayKetThucThanhVien IS NULL OR kh.NgayKetThucThanhVien<SYSDATETIME() THEN 1
            ELSE ISNULL((SELECT TOP 1 h.MaHangTV FROM HANGTHANHVIEN h
                         WHERE h.DiemChiTieuToiThieu<=kh.TongChiTieu
                         ORDER BY h.DiemChiTieuToiThieu DESC),1) END
        FROM KHACHHANG kh JOIN @ChiTieu c ON c.MaKH=kh.MaKH;

        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung)
        VALUES(@MaTKNhanVien,N'Thanh toán',N'DONDATVE',CONCAT(N'Thanh toán đơn #',@MaDon));

        COMMIT TRANSACTION;
        SELECT N'Thanh toán thành công' AS KetQua,@MaDon AS MaDon;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

/* PROCEDURE: sp_HUYVE */
CREATE PROCEDURE sp_HUYVE
    @MaVe INT,
    @LyDo NVARCHAR(250),
    @MaTKNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- TRANSACTION: HUYVE - Chi COMMIT khi cac buoc thanh cong.
        BEGIN TRANSACTION;

        DECLARE @MaDon INT,@MaKH INT,@MaChuyenBay INT,@MaGhe INT,@GiaThucTra MONEY,
                @TrangThaiVe NVARCHAR(20),@NgayKhoiHanh DATETIME2,@ChoPhepHuy BIT,
                @PhiHuy MONEY,@TienHoan MONEY,@MaHangVe INT,
                @TrangThaiDon NVARCHAR(30),@DaThanhToan MONEY;

        SELECT @MaDon=v.MaDon,@MaKH=v.MaKH,@MaChuyenBay=v.MaChuyenBay,@MaGhe=v.MaGhe,
               @GiaThucTra=v.GiaThucTra,@TrangThaiVe=v.TrangThai,@MaHangVe=v.MaHangVe,
               @NgayKhoiHanh=cb.NgayGioKhoiHanh,@ChoPhepHuy=hv.ChoPhepHuy,@TrangThaiDon=dd.TrangThai
        FROM VE v WITH (UPDLOCK,HOLDLOCK)
        JOIN CHUYENBAY cb ON cb.MaChuyenBay=v.MaChuyenBay
        JOIN HANGVE hv ON hv.MaHangVe=v.MaHangVe
        JOIN DONDATVE dd ON dd.MaDon=v.MaDon
        WHERE v.MaVe=@MaVe;

        IF @MaDon IS NULL THROW 50060, N'Không tìm thấy vé.', 1;
        IF @TrangThaiVe=N'Đã hủy' OR EXISTS(SELECT 1 FROM HUYVE WHERE MaVe=@MaVe)
            THROW 50061, N'Vé đã được hủy trước đó.', 1;
        IF @TrangThaiVe=N'Đã bay' OR @NgayKhoiHanh<=SYSDATETIME()
            THROW 50062, N'Không thể hủy vé đã khởi hành hoặc đã bay.', 1;
        IF @ChoPhepHuy=0
            THROW 50063, N'Hạng vé này không cho phép hủy.', 1;

        DECLARE @GioConLai INT=DATEDIFF(HOUR,SYSDATETIME(),@NgayKhoiHanh);
        IF @GioConLai < 24 SET @PhiHuy=ROUND(@GiaThucTra*0.30,0);
        ELSE IF @GioConLai < 72 SET @PhiHuy=ROUND(@GiaThucTra*0.20,0);
        ELSE SET @PhiHuy=ROUND(@GiaThucTra*0.10,0);
        SET @TienHoan=@GiaThucTra-@PhiHuy;
        IF @TienHoan<0 SET @TienHoan=0;

        IF @TrangThaiDon=N'Đã thanh toán'
        BEGIN
            INSERT INTO HUYVE(MaVe,LyDo,PhiHuy,TienHoan,MaTKNhanVien)
            VALUES(@MaVe,@LyDo,@PhiHuy,@TienHoan,@MaTKNhanVien);

            IF @TienHoan > 0
                INSERT INTO THANHTOAN(MaDon,SoTien,PhuongThuc,MaTKNhanVien,TrangThai,GhiChu)
                VALUES(@MaDon,@TienHoan,N'Tiền mặt',@MaTKNhanVien,N'Đã hoàn',CONCAT(N'Hoàn tiền vé #',@MaVe));
        END
        ELSE
        BEGIN
            INSERT INTO HUYVE(MaVe,LyDo,PhiHuy,TienHoan,MaTKNhanVien)
            VALUES(@MaVe,@LyDo,0,0,@MaTKNhanVien);
        END;

        UPDATE VE SET TrangThai=N'Đã hủy' WHERE MaVe=@MaVe;
        UPDATE GHECHUYENBAY SET TrangThai=N'Trống'
        WHERE MaChuyenBay=@MaChuyenBay AND MaGhe=@MaGhe;

        IF @TrangThaiDon=N'Đã thanh toán'
        BEGIN
            UPDATE KHACHHANG
            SET TongChiTieu=CASE WHEN TongChiTieu>=@TienHoan THEN TongChiTieu-@TienHoan ELSE 0 END
            WHERE MaKH=@MaKH;

            DECLARE @TongChiTieuSau MONEY,@NgayHetHanSau DATETIME2;
            SELECT @TongChiTieuSau=TongChiTieu,@NgayHetHanSau=NgayKetThucThanhVien
            FROM KHACHHANG WHERE MaKH=@MaKH;

            UPDATE KHACHHANG
            SET MaHangTV=CASE WHEN @NgayHetHanSau IS NULL OR @NgayHetHanSau<SYSDATETIME() THEN 1
                              ELSE ISNULL((SELECT TOP 1 MaHangTV FROM HANGTHANHVIEN
                                           WHERE DiemChiTieuToiThieu<=@TongChiTieuSau
                                           ORDER BY DiemChiTieuToiThieu DESC),1) END
            WHERE MaKH=@MaKH;
        END;

        IF NOT EXISTS(SELECT 1 FROM VE WHERE MaDon=@MaDon AND TrangThai<>N'Đã hủy')
            UPDATE DONDATVE SET TrangThai=N'Đã hủy' WHERE MaDon=@MaDon;

        INSERT INTO NHATKYHOATDONG(MaTK,HanhDong,DoiTuong,NoiDung)
        VALUES(@MaTKNhanVien,N'Hủy vé',N'VE',CONCAT(N'Hủy vé #',@MaVe));

        COMMIT TRANSACTION;
        SELECT @MaVe AS MaVe,@PhiHuy AS PhiHuy,@TienHoan AS TienHoan,N'Hủy vé thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

/* PROCEDURE: sp_TRACUUVE */
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


/* PROCEDURE: sp_THONGKEDASHBOARD */
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

/* PROCEDURE: sp_XETHANGTHANHVIEN */
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

/* PROCEDURE: sp_LAYDULIEUCOMBOBOX
   Tra ve bo cot thong nhat: Ma, Ten, MoTa, GiaTri.
   C# dung DisplayMember = "Ten", ValueMember = "Ma". */
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

/* PROCEDURE: sp_TINHTHUGIAVE
   Tinh gia du kien cho mot ve. Khi dat ve, sp_DATVE se kiem tra va tinh lai gia chinh thuc.
   @SoVeTetTrongDon la tong so ve cua cung mot khach se dung uu dai Tet trong don hien tai. */
CREATE PROCEDURE sp_TINHTHUGIAVE
    @MaChuyenBay INT,
    @MaHangVe INT,
    @MaKH INT,
    @ApDungTet BIT = 0,
    @ApDungKhuHoi BIT = 0,
    @MaKM INT = NULL,
    @MaChuyenBayKhuHoi INT = NULL,
    @SoVeTetTrongDon INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NgayHienTai DATE=CONVERT(DATE,GETDATE());
    DECLARE @GiaGoc MONEY;
    DECLARE @GiamHang INT=0;
    DECLARE @GiamTet INT=0;
    DECLARE @GiamKhuHoi INT=0;
    DECLARE @GiamKM INT=0;
    DECLARE @TongGiam INT=0;
    DECLARE @TienGiam MONEY=0;
    DECLARE @GiaThucTra MONEY=0;
    DECLARE @PhanTramKM INT=0;
    DECLARE @GiamToiDa MONEY=NULL;
    DECLARE @TenKM NVARCHAR(100)=NULL;

    IF NOT EXISTS
    (
        SELECT 1 FROM KHACHHANG WHERE MaKH=@MaKH
    )
        THROW 50071, N'Khách hàng không tồn tại.', 1;

    IF NOT EXISTS
    (
        SELECT 1 FROM CHUYENBAY
        WHERE MaChuyenBay=@MaChuyenBay
          AND TrangThai=N'Đang mở bán'
          AND NgayGioKhoiHanh>SYSDATETIME()
    )
        THROW 50072, N'Chuyến bay không tồn tại, đã đóng hoặc đã khởi hành.', 1;

    SELECT @GiaGoc=gv.DonGia
    FROM GIAVE gv
    JOIN HANGVE hv ON hv.MaHangVe=gv.MaHangVe
    WHERE gv.MaChuyenBay=@MaChuyenBay
      AND gv.MaHangVe=@MaHangVe
      AND hv.TrangThai=N'Hoạt động';

    IF @GiaGoc IS NULL
        THROW 50073, N'Không tìm thấy giá cho hạng vé đã chọn.', 1;

    SELECT @GiamHang=
        CASE WHEN kh.NgayKetThucThanhVien IS NOT NULL
                   AND kh.NgayKetThucThanhVien<SYSDATETIME()
             THEN 0 ELSE ISNULL(htv.PhanTramGiam,0) END
    FROM KHACHHANG kh
    JOIN HANGTHANHVIEN htv ON htv.MaHangTV=kh.MaHangTV
    WHERE kh.MaKH=@MaKH;

    IF @ApDungTet=1
    BEGIN
        IF MONTH(@NgayHienTai) NOT BETWEEN 1 AND 3
            THROW 50074, N'Ưu đãi Tết chỉ áp dụng khi mua vé trong tháng 1 đến tháng 3.', 1;

        IF @SoVeTetTrongDon<1 OR @SoVeTetTrongDon>2
            THROW 50075, N'Mỗi khách chỉ được áp dụng ưu đãi Tết tối đa hai vé trong một đơn.', 1;

        IF
        (
            SELECT COUNT(*)
            FROM VE v
            JOIN DONDATVE dd ON dd.MaDon=v.MaDon
            WHERE v.MaKH=@MaKH
              AND v.PhanTramGiamTet>0
              AND YEAR(dd.NgayDat)=YEAR(GETDATE())
              AND MONTH(dd.NgayDat) BETWEEN 1 AND 3
              AND v.TrangThai<>N'Đã hủy'
        ) + @SoVeTetTrongDon > 2
            THROW 50076, N'Khách hàng đã sử dụng hết lượt ưu đãi Tết.', 1;

        SET @GiamTet=10;
    END;

    IF @ApDungKhuHoi=1
    BEGIN
        IF @MaChuyenBayKhuHoi IS NULL
            THROW 50077, N'Cần chọn chuyến bay khứ hồi để kiểm tra giảm giá.', 1;

        IF NOT EXISTS
        (
            SELECT 1
            FROM CHUYENBAY cb1
            JOIN CHUYENBAY cb2 ON cb2.MaChuyenBay=@MaChuyenBayKhuHoi
            WHERE cb1.MaChuyenBay=@MaChuyenBay
              AND cb1.MaSanBayDi=cb2.MaSanBayDen
              AND cb1.MaSanBayDen=cb2.MaSanBayDi
              AND cb2.TrangThai=N'Đang mở bán'
              AND cb2.NgayGioKhoiHanh>SYSDATETIME()
        )
            THROW 50078, N'Hai chuyến bay không phải tuyến khứ hồi hợp lệ.', 1;

        SET @GiamKhuHoi=10;
    END;

    IF @MaKM IS NOT NULL
    BEGIN
        SELECT @TenKM=TenKM,
               @PhanTramKM=PhanTramGiam,
               @GiamToiDa=GiamToiDa
        FROM KHUYENMAI
        WHERE MaKM=@MaKM
          AND TrangThai=N'Hoạt động'
          AND @NgayHienTai BETWEEN NgayBatDau AND NgayKetThuc
          AND (SoLuotToiDa IS NULL OR SoLuotDaDung<SoLuotToiDa);

        IF @TenKM IS NULL
            THROW 50079, N'Mã khuyến mãi không hợp lệ, hết hạn hoặc hết lượt.', 1;

        IF @TenKM=N'Ưu đãi Tết'
            THROW 50080, N'Ưu đãi Tết được áp dụng riêng, không chọn trong danh sách khuyến mãi.', 1;

        IF @GiamToiDa IS NULL
            SET @GiamKM=@PhanTramKM;
        ELSE IF @GiaGoc*@PhanTramKM/100.0>@GiamToiDa
            SET @GiamKM=CONVERT(INT,@GiamToiDa*100.0/@GiaGoc);
        ELSE
            SET @GiamKM=@PhanTramKM;
    END;

    SET @TongGiam=@GiamHang+@GiamTet+@GiamKhuHoi+@GiamKM;
    IF @TongGiam>30 SET @TongGiam=30;
    IF @TongGiam<0 SET @TongGiam=0;

    SET @GiaThucTra=@GiaGoc-ROUND(@GiaGoc*@TongGiam/100.0,2);
    SET @TienGiam=@GiaGoc-@GiaThucTra;

    SELECT
        @GiaGoc AS GiaGoc,
        @GiamHang AS PhanTramGiamHang,
        @GiamTet AS PhanTramGiamTet,
        @GiamKhuHoi AS PhanTramGiamKhuHoi,
        @GiamKM AS PhanTramGiamKM,
        @TongGiam AS PhanTramGiam,
        @TienGiam AS TienGiam,
        @GiaThucTra AS GiaThucTra;
END;
GO

/* QUICK TESTS
   Login:
   EXEC sp_DANGNHAP 'admin','admin123';

   Dashboard:
   EXEC sp_THONGKEDASHBOARD NULL,NULL;

   Seat and flight state:
   SELECT TOP 20 * FROM V_CHUYENBAYCHITIET ORDER BY NgayGioKhoiHanh;

   EXEC sp_LAYDULIEUCOMBOBOX 'SANBAY';
   EXEC sp_LAYDULIEUCOMBOBOX 'DICHVU';
   EXEC sp_LAYDULIEUCOMBOBOX 'KHUYENMAI';
*/
