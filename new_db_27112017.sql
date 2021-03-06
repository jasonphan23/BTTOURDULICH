USE [TourDuLich]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTDoan]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDoan](
	[MaCTDoan] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[TongCPKS] [int] NOT NULL,
	[TongCPPT] [int] NOT NULL,
	[TongCPBA] [int] NOT NULL,
	[TongCPKhac] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangKi]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKi](
	[MaDK] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[NgayDK] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiaDiem]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaDiem](
	[MaDD] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
	[TinhThanh] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan](
	[MaDoan] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
	[MaTourGia] [int] NOT NULL,
	[NgayKH] [date] NOT NULL,
	[NgayKT] [date] NOT NULL,
	[MoTaChiTiet] [nvarchar](255) NULL,
	[TruongDoan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan_ChiPhiKhac]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan_ChiPhiKhac](
	[MaDCPK] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[TenCPKhac] [nvarchar](30) NULL,
	[Gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDCPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan_KhachSan]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan_KhachSan](
	[MaDKS] [int] IDENTITY(1,1) NOT NULL,
	[MaTour] [int] NOT NULL,
	[TenKS] [nvarchar](30) NOT NULL,
	[Gia] [int] NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDKS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan_PhuongTien]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan_PhuongTien](
	[MaDPT] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[TenPT] [nvarchar](30) NOT NULL,
	[Gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan_QuanAn]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan_QuanAn](
	[MaDQA] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[TenQA] [nvarchar](30) NOT NULL,
	[Gia] [int] NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDQA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](30) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoDT] [varchar](20) NOT NULL,
	[CMND] [varchar](30) NOT NULL,
	[Passport] [varchar](30) NOT NULL,
	[QuocTich] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](30) NULL,
	[TrangThai] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiHinhDL]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHinhDL](
	[MaLHDL] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLHDL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](30) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoDT] [varchar](20) NOT NULL,
	[CMND] [varchar](30) NOT NULL,
	[DiaChi] [nvarchar](30) NULL,
	[TrangThai] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaPC] [int] IDENTITY(1,1) NOT NULL,
	[MaDoan] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[MaCV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhThanh]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhThanh](
	[MaTT] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[MaTour] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](30) NOT NULL,
	[DiemBatDau] [int] NOT NULL,
	[DiemKetThuc] [int] NOT NULL,
	[DacDiem] [nvarchar](255) NULL,
	[LoaiHinhDL] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_DiaDiem]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_DiaDiem](
	[MaTDD] [int] IDENTITY(1,1) NOT NULL,
	[MaTour] [int] NOT NULL,
	[MaDD] [int] NOT NULL,
	[GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Gia]    Script Date: 27/11/2017 2:19:10 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Gia](
	[MaTourGia] [int] IDENTITY(1,1) NOT NULL,
	[MaTour] [int] NOT NULL,
	[TGBD] [date] NOT NULL,
	[TGKT] [date] NOT NULL,
	[Gia] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTourGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DiaDiem] ON 

INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (1, N'Bến Nhà Rồng', 1)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (2, N'Dinh Độc Lập', 1)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (3, N'Hồ Hoàn Kiếm', 2)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (6, N'Quản Trường Ba Đình', 2)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (7, N'Văn Miếu – Quốc Tử Giám', 2)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (8, N'Bà Nà Hills', 3)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (9, N'Cù Lao Chàm', 3)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (10, N'Hồ Xuân Hương', 4)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (11, N'Dinh Bảo Đại', 4)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (12, N'Làng Sen quê Bác', 5)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (14, N'Thành cổ Vinh', 5)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (15, N'Hòn Bà', 6)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (16, N'Viện Hải dương học Nha Trang', 7)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (17, N'Hòn Chồng - Hòn Vợ', 7)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (18, N'Côn Đảo', 8)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (19, N'Địa đạo Long Phước', 8)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (21, N'Khu bảo tồn Pù Luông', 9)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (22, N'Rừng quốc gia U Minh hạ', 10)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (23, N'Vườn dâu Cái Tàu', 10)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (24, N'Cụm du lịch sông Đà', 11)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (25, N'Đỉnh Pha Luông – Mộc Châu', 11)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (26, N'Cổng trời', 12)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (27, N'Cốc San', 12)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (30, N'Đình Ngọc Xuyên', 13)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (31, N'Thiền viện Trúc Lâm', 14)
INSERT [dbo].[DiaDiem] ([MaDD], [Ten], [TinhThanh]) VALUES (33, N'Chùa Ông', 14)
SET IDENTITY_INSERT [dbo].[DiaDiem] OFF
SET IDENTITY_INSERT [dbo].[LoaiHinhDL] ON 

INSERT [dbo].[LoaiHinhDL] ([MaLHDL], [Ten]) VALUES (1, N'du lịch di động')
INSERT [dbo].[LoaiHinhDL] ([MaLHDL], [Ten]) VALUES (2, N'du lịch kết hợp nghề nghiệp')
INSERT [dbo].[LoaiHinhDL] ([MaLHDL], [Ten]) VALUES (3, N'du lịch xã hội và gia đình')
SET IDENTITY_INSERT [dbo].[LoaiHinhDL] OFF
SET IDENTITY_INSERT [dbo].[TinhThanh] ON 

INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (1, N'TPHCM')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (2, N'Hà Nội')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (3, N'Đà Nẵng')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (4, N'Lâm Đồng')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (5, N'Nghệ An')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (6, N'Vũng Tàu')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (7, N'Nha Trang')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (8, N'Bà Rịa-Vũng Tàu')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (9, N'Thanh Hóa')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (10, N'Cà Mau')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (11, N'Sơn La')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (12, N'Sa Pa')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (13, N'Hải Phòng')
INSERT [dbo].[TinhThanh] ([MaTT], [Ten]) VALUES (14, N'Cần Thơ')
SET IDENTITY_INSERT [dbo].[TinhThanh] OFF
SET IDENTITY_INSERT [dbo].[Tour] ON 

INSERT [dbo].[Tour] ([MaTour], [Ten], [DiemBatDau], [DiemKetThuc], [DacDiem], [LoaiHinhDL], [TrangThai], [GhiChu]) VALUES (1, N'Tour TPHCM - Đà Nẵng', 1, 3, NULL, 1, 1, NULL)
INSERT [dbo].[Tour] ([MaTour], [Ten], [DiemBatDau], [DiemKetThuc], [DacDiem], [LoaiHinhDL], [TrangThai], [GhiChu]) VALUES (3, N'Tour Hà Nội - Sapa', 2, 12, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Tour] OFF
SET IDENTITY_INSERT [dbo].[Tour_DiaDiem] ON 

INSERT [dbo].[Tour_DiaDiem] ([MaTDD], [MaTour], [MaDD], [GhiChu]) VALUES (2, 1, 1, NULL)
INSERT [dbo].[Tour_DiaDiem] ([MaTDD], [MaTour], [MaDD], [GhiChu]) VALUES (3, 1, 8, NULL)
INSERT [dbo].[Tour_DiaDiem] ([MaTDD], [MaTour], [MaDD], [GhiChu]) VALUES (4, 1, 9, NULL)
INSERT [dbo].[Tour_DiaDiem] ([MaTDD], [MaTour], [MaDD], [GhiChu]) VALUES (5, 3, 3, NULL)
INSERT [dbo].[Tour_DiaDiem] ([MaTDD], [MaTour], [MaDD], [GhiChu]) VALUES (7, 3, 26, NULL)
SET IDENTITY_INSERT [dbo].[Tour_DiaDiem] OFF
ALTER TABLE [dbo].[CTDoan]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[DangKi]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[DangKi]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DiaDiem]  WITH CHECK ADD FOREIGN KEY([TinhThanh])
REFERENCES [dbo].[TinhThanh] ([MaTT])
GO
ALTER TABLE [dbo].[Doan]  WITH CHECK ADD FOREIGN KEY([MaTourGia])
REFERENCES [dbo].[Tour_Gia] ([MaTourGia])
GO
ALTER TABLE [dbo].[Doan]  WITH CHECK ADD FOREIGN KEY([TruongDoan])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Doan_ChiPhiKhac]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[Doan_KhachSan]  WITH CHECK ADD FOREIGN KEY([MaTour])
REFERENCES [dbo].[Tour] ([MaTour])
GO
ALTER TABLE [dbo].[Doan_PhuongTien]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[Doan_QuanAn]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaDoan])
REFERENCES [dbo].[Doan] ([MaDoan])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD FOREIGN KEY([DiemBatDau])
REFERENCES [dbo].[TinhThanh] ([MaTT])
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD FOREIGN KEY([DiemKetThuc])
REFERENCES [dbo].[TinhThanh] ([MaTT])
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD FOREIGN KEY([LoaiHinhDL])
REFERENCES [dbo].[LoaiHinhDL] ([MaLHDL])
GO
ALTER TABLE [dbo].[Tour_DiaDiem]  WITH CHECK ADD FOREIGN KEY([MaTour])
REFERENCES [dbo].[Tour] ([MaTour])
GO
ALTER TABLE [dbo].[Tour_DiaDiem]  WITH CHECK ADD FOREIGN KEY([MaDD])
REFERENCES [dbo].[DiaDiem] ([MaDD])
GO
ALTER TABLE [dbo].[Tour_Gia]  WITH CHECK ADD FOREIGN KEY([MaTour])
REFERENCES [dbo].[Tour] ([MaTour])
GO
