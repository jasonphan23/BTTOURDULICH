DROP DATABASE TourDuLich
create database TourDuLich
use TourDuLich

create table KhachHang
(
	MaKH int identity(1,1) not null,
	HoTen nvarchar(30) not null,
	GioiTinh bit not null,
	NgaySinh date not null,
	SoDT varchar(20) not null,
	CMND varchar(30) not null,
	Passport varchar(30) not null,
	QuocTich nvarchar(20) not null,
	DiaChi nvarchar(30),
	TrangThai bit not null,
	primary key (MaKH) 
)
create table NhanVien
(
	MaNV int identity(1,1) not null,
	HoTen nvarchar(30) not null,
	GioiTinh bit not null,
	NgaySinh date not null,
	SoDT varchar(20) not null,
	CMND varchar(30) not null,
	DiaChi nvarchar(30),
	TrangThai bit not null,
	primary key (MaNV) 
)
create table ChucVu
(
	MaCV int identity(1,1) not null,
	Ten nvarchar(30) not null,
	primary key (MaCV) 
)
create table Xe
(
	MaXe int identity(1,1) not null,
	BienSoXe nchar(20) not null,
	SLCho int not null,
	TrangThai bit not null,
	primary key (MaXe) 
)
create table LoaiHinhDL
(
	MaLHDL int identity(1,1) not null,
	Ten nvarchar(30) not null,
	primary key (MaLHDL) 
)
create table TinhThanh
(
	MaTT int identity(1,1) not null,
	Ten nvarchar(30) not null,
	primary key (MaTT) 
)
create table DiaDiem
(
	MaDD int identity(1,1) not null,
	Ten nvarchar(30) not null,
	TinhThanh int not null,
	primary key (MaDD),
	foreign key (TinhThanh) references TinhThanh(MaTT)
)
----------------------------------------------------
create table Tour
(
	MaTour int identity(1,1) not null,
	Ten nvarchar(30) not null,
	DiemKhoiHanh int not null, 
	DiemKetThuc int not null, 
	SLNgay int not null,
	LoaiHinhDL int not null,
	TrangThai bit not null,
	primary key (MaTour),
	foreign key (DiemKhoiHanh) references DiaDiem(MaDD),
	foreign key (DiemKetThuc) references DiaDiem(MaDD),
	foreign key (LoaiHinhDL) references LoaiHinhDL(MaLHDL)
)
create table Gia
(
	MaGia int identity(1,1) not null,
	MaTour int not null,
	Gia int not null,
	khoangTGBD date not null, -- khoang thoi gian lon
	khoangTGKT date not null,
	primary key (MaGia),
	foreign key (MaTour) references Tour(MaTour)
)
create table Tour_Gia
(
	MaTourGia int identity(1,1) not null,
	MaTour int not null,
	TGBD date not null,-- thoi gian cu the
	TGKT date not null,
	Gia int not null,
	TrangThai bit not null,
	primary key (MaTourGia),
	foreign key (MaTour) references Tour(MaTour)
)
create table Doan
(
	MaDoan int identity(1,1) not null,
	Ten nvarchar(30) not null,
	SLKhach int not null,
	SLNV int not null,
	MaTourGia int not null,
	MaXe int not null,
	GiaXe int not null,
	TruongDoan int not null, -- luu id nhan vien 
	primary key (MaDoan),
	foreign key (MaTourGia) references Tour_Gia(MaTourGia),
	foreign key (MaXe) references Xe(MaXe),
	foreign key (TruongDoan) references NhanVien(MaNV)
)
create table CTDoan
(
	MaCTDoan int identity(1,1) not null,
	MaDoan int not null,
	TongCPKS int not null,
	TongCPPT int not null, --phuong tien
	TongCPBA int not null, --bua an
	CPKhac int,
	GhiChu nvarchar(50),
	primary key (MaCTDoan),
	foreign key (MaDoan) references Doan(MaDoan)
)
create table DangKi
(
	MaDK int identity(1,1) not null,
	MaDoan int not null,
	MaKH int not null,
	NgayDK date not null,
	primary key (MaDK),
	foreign key (MaDoan) references Doan(MaDoan),
	foreign key (MaKH) references KhachHang(MaKH)
)
create table PhanCong
(
	MaPC int identity(1,1) not null,
	MaDoan int not null,
	MaNV int not null,
	MaCV int not null,
	primary key (MaPC),
	foreign key (MaDoan) references Doan(MaDoan),
	foreign key (MaNV) references NhanVien(MaNV),
	foreign key (MaCV) references ChucVu(MaCV)
)
create table Tour_DiaDiem
(
	MaTDD int identity(1,1) not null,
	MaTour int not null,
	TenDiaDiem nvarchar(255),
	DiaChi nvarchar(255),
	GhiChu nvarchar(50),
	primary key (MaTDD),
	foreign key (MaTour) references Tour(MaTour)
)
create table Tour_KhachSan
(
	MaTKS int identity(1,1) not null,
	MaTour int not null,
	TenKhachSan nvarchar(255),
	DiaChi nvarchar(255),
	Gia int not null,
	GhiChu nvarchar(50),
	primary key (MaTKS),
	foreign key (MaTour) references Tour(MaTour)
)
create table Tour_QuanAn
(
	MaTQA int identity(1,1) not null,
	MaTour int not null,
	Tenquan nvarchar(255),
	Gia int not null,
	Diachi nvarchar(50),
	GhiChu nvarchar(50),
	primary key (MaTQA),
	foreign key (MaTour) references Tour(MaTour),
)
create table Tour_ChiPhiKhac
(
	MaCPK int identity(1,1) not null,
	MaDoan int not null,
	TenCPKhac nvarchar(30),
	Gia int not null,
	GhiChu nvarchar(50),
	primary key (MaCPK),
	foreign key (MaDoan) references Doan(MaDoan)
)

