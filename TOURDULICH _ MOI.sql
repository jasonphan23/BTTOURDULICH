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
	SLNgay int not null,
	DacDiem nvarchar(255),
	LoaiHinhDL int not null,
	TrangThai bit not null,
	GhiChu nvarchar(50),
	primary key (MaTour),
	foreign key (LoaiHinhDL) references LoaiHinhDL(MaLHDL)
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
	MaTourGia int not null,
	SLKhach int not null,
	SLNV int not null,
	NgayKH date not null, --ngay khoi hanh cua doan
	NgayKT date not null, --ngay ket thuc di cua doan 
	MoTaChiTiet nvarchar(255), -- chi tiet cua doan trong 1 tour
	TruongDoan int not null, -- luu id nhan vien 
	primary key (MaDoan),
	foreign key (MaTourGia) references Tour_Gia(MaTourGia),
	foreign key (TruongDoan) references NhanVien(MaNV)
)
create table CTDoan
(
	MaCTDoan int identity(1,1) not null,
	MaDoan int not null,
	TongCPKS int not null,
	TongCPPT int not null, --phuong tien
	TongCPBA int not null, --bua an
	TongCPKhac int,
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
	MaDD int not null,
	TenDiaDiem int not null,
	DiaChi nvarchar(255),
	GhiChu nvarchar(255),
	primary key (MaTDD),
	foreign key (MaTour) references Tour(MaTour),
	foreign key (MaDD) references DiaDiem(MaDD)
)
create table Doan_KhachSan
(
	MaDKS int identity(1,1) not null,
	MaTour int not null,
	TenKS nvarchar(30) not null,
	Gia int not null,
	DiaChi nvarchar(50),
	primary key (MaDKS),
	foreign key (MaTour) references Tour(MaTour)
)
create table Doan_QuanAn
(
	MaDQA int identity(1,1) not null,
	MaDoan int not null,
	TenQA nvarchar(30) not null,
	Gia int not null,
	DiaChi nvarchar(50),
	primary key (MaDQA),
	foreign key (MaDoan) references Doan(MaDoan),
)
create table Doan_PhuongTien
(
	MaDPT int identity(1,1) not null,
	MaDoan int not null,
	TenPT nvarchar(30) not null,
	Gia int not null,
	primary key (MaDPT),
	foreign key (MaDoan) references Doan(MaDoan),
)
create table Doan_ChiPhiKhac
(
	MaDCPK int identity(1,1) not null,
	MaDoan int not null,
	TenCPKhac nvarchar(30),
	Gia int not null,
	primary key (MaDCPK),
	foreign key (MaDoan) references Doan(MaDoan),
)

