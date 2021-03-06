USE [master]
GO
/****** Object:  Database [TracNghiemOnline1]    Script Date: 4/6/2021 8:36:29 AM ******/
CREATE DATABASE [TracNghiemOnline1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TracNghiemOnline1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TracNghiemOnline1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TracNghiemOnline1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TracNghiemOnline1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TracNghiemOnline1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TracNghiemOnline1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TracNghiemOnline1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET ARITHABORT OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TracNghiemOnline1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TracNghiemOnline1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TracNghiemOnline1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TracNghiemOnline1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TracNghiemOnline1] SET  MULTI_USER 
GO
ALTER DATABASE [TracNghiemOnline1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TracNghiemOnline1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TracNghiemOnline1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TracNghiemOnline1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TracNghiemOnline1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TracNghiemOnline1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TracNghiemOnline1] SET QUERY_STORE = OFF
GO
USE [TracNghiemOnline1]
GO
/****** Object:  Table [dbo].[Bo_De]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bo_De](
	[Ma_BoDe] [bigint] IDENTITY(1,1) NOT NULL,
	[NoiDung] [text] NULL,
	[Ma_NguoiTao] [nchar](10) NULL,
	[TrangThai] [bit] NULL,
	[Ma_Mon] [bigint] NULL,
	[SoCau] [int] NULL,
	[ThoiGianThi] [nvarchar](20) NULL,
	[Xoa] [bit] NULL,
	[PheDuyet] [nvarchar](50) NULL,
	[ThoiGianMo] [datetime] NULL,
	[ThoiGianDong] [datetime] NULL,
	[NguoiDuyet] [nchar](10) NULL,
 CONSTRAINT [PK_De_Thi] PRIMARY KEY CLUSTERED 
(
	[Ma_BoDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoDeOnTap]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoDeOnTap](
	[MaBoDe] [bigint] NULL,
	[MaLopHP] [char](10) NULL,
	[ThoiGianMo] [datetime] NULL,
	[ThoiGianDong] [datetime] NULL,
	[id] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoMon]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoMon](
	[Ma_BoMon] [nchar](10) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BoMon] PRIMARY KEY CLUSTERED 
(
	[Ma_BoMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[Ma_BoDe] [bigint] NOT NULL,
	[Ma_CauHoi] [bigint] NOT NULL,
	[MaCT] [bigint] IDENTITY(1,1) NOT NULL,
	[trangThai] [bit] NULL,
 CONSTRAINT [PK_CauHoi_1] PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoiDeThi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoiDeThi](
	[MaDeThi] [bigint] NULL,
	[MaCauHoi] [bigint] NULL,
	[MaCT] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CauHoiDeThi] PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chuong_Hoc]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuong_Hoc](
	[Ma_Chuong] [bigint] IDENTITY(1,1) NOT NULL,
	[TenChuong] [nvarchar](50) NULL,
	[Ma_Mon] [bigint] NULL,
	[TrangThai] [bigint] NULL,
 CONSTRAINT [PK_Chuong_Hoc] PRIMARY KEY CLUSTERED 
(
	[Ma_Chuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Da_SVLuaChon]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Da_SVLuaChon](
	[MaDeThi] [bigint] NULL,
	[Ma_DAN] [bigint] NULL,
	[MA_CT] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Da_SVLuaChon] PRIMARY KEY CLUSTERED 
(
	[MA_CT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Danh_Gia]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Danh_Gia](
	[MaDG] [bigint] IDENTITY(1,1) NOT NULL,
	[MaDeThi] [bigint] NULL,
	[MaChuong] [bigint] NULL,
	[SoCauDung] [int] NULL,
	[TongCau] [int] NULL,
	[NhanXet] [text] NULL,
	[DanhGia] [nvarchar](20) NULL,
 CONSTRAINT [PK_Danh_Gia] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dap_AN]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dap_AN](
	[MA_DAN] [bigint] IDENTITY(1,1) NOT NULL,
	[NoiDung] [ntext] NULL,
	[HinhAnh] [ntext] NULL,
	[Ma_CauHoi] [bigint] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Dap_AN] PRIMARY KEY CLUSTERED 
(
	[MA_DAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[De_Thi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[De_Thi](
	[Ma_SV] [char](10) NULL,
	[Ma_BoDe] [bigint] NULL,
	[TrangThai] [bit] NULL,
	[MaDeThi] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TronDe] PRIMARY KEY CLUSTERED 
(
	[MaDeThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_LopHP]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_LopHP](
	[Ma_LOP] [char](10) NULL,
	[MA_SV] [char](10) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DS_LopHP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_SVThi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_SVThi](
	[Ma_SV] [char](10) NOT NULL,
	[MaPhong] [char](10) NOT NULL,
	[MaDS] [bigint] IDENTITY(1,1) NOT NULL,
	[MaDeThi] [bigint] NULL,
	[TrangThai] [nvarchar](15) NULL,
 CONSTRAINT [PK_DS_SVThi] PRIMARY KEY CLUSTERED 
(
	[MaDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [nchar](10) NOT NULL,
	[TenGV] [nvarchar](50) NULL,
	[Ma_Nganh] [bigint] NULL,
	[TrangThai] [bit] NULL,
	[MaBoMon] [nchar](10) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaThi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaThi](
	[Ma_DeThi] [bigint] NULL,
	[DiemSo] [float] NULL,
	[SoCauSai] [int] NULL,
	[SoCauDung] [int] NULL,
	[NgayThi] [date] NULL,
	[MAKQ] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KetQuaThi] PRIMARY KEY CLUSTERED 
(
	[MAKQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho_CauHoi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho_CauHoi](
	[Ma_CauHoi] [bigint] IDENTITY(1,1) NOT NULL,
	[NoiDung] [ntext] NULL,
	[HinhAnh] [ntext] NULL,
	[MucDo] [nvarchar](20) NULL,
	[Ma_Chuong] [bigint] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[Ma_CauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KiThi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KiThi](
	[MAKI] [bigint] IDENTITY(1,1) NOT NULL,
	[TenKi] [nvarchar](100) NULL,
	[TGBatDau] [date] NULL,
	[TGKetThuc] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_KiThi] PRIMARY KEY CLUSTERED 
(
	[MAKI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Ma_Lop] [nvarchar](20) NOT NULL,
	[TenLop] [nvarchar](100) NULL,
	[Ma_Nganh] [bigint] NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[Ma_Lop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[MaLop] [char](10) NOT NULL,
	[TenLop] [nvarchar](max) NULL,
	[MaGV] [nchar](10) NULL,
	[SiSo] [nchar](10) NULL,
	[MaMon] [bigint] NULL,
	[MaKi] [bigint] NULL,
	[TrangThai] [bigint] NULL,
 CONSTRAINT [PK_LopHocPhan] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Ma_Mon] [bigint] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
	[MaBoMon] [nchar](10) NULL,
 CONSTRAINT [PK_Ma_Mon] PRIMARY KEY CLUSTERED 
(
	[Ma_Mon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[Ma_Nganh] [bigint] NOT NULL,
	[TenNganh] [nvarchar](100) NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[Ma_Nganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong_Thi]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong_Thi](
	[MaPhong] [char](10) NOT NULL,
	[NguoiTao] [nchar](10) NULL,
	[ThoiGianMo] [datetime] NULL,
	[ThoiGianDong] [datetime] NULL,
	[TrangThai] [nvarchar](20) NULL,
	[MaBoDe] [bigint] NULL,
	[MaLopHP] [char](10) NOT NULL,
	[Xoa] [bit] NULL,
	[TenPhong] [nvarchar](100) NULL,
	[MaCanBo1] [nchar](10) NULL,
	[MaCanBo2] [nchar](10) NULL,
 CONSTRAINT [PK_Phong_Thi] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [char](10) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Ma_Lop] [nvarchar](20) NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[Ten] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 4/6/2021 8:36:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoan] [nchar](10) NOT NULL,
	[MatKhau] [nchar](10) NULL,
	[ChưcVu] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
	[TenDangNhap] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bo_De] ON 

INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (1, N'De thi cuoi kì ', N'1         ', 0, 1, 5, N'40', 1, N'Đã duyệt', NULL, NULL, N'2         ')
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (2, N'De thi cuoi kì', N'2         ', NULL, 1, NULL, N'40', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (3, N'De thi cuoi kì', N'2         ', 1, 1, NULL, N'40', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (4, N'De thi cuoi kì', N'2         ', 0, 1, NULL, N'60', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (5, N'De thi cuoi kì', N'2         ', 1, 1, NULL, N'40', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (6, N'De thi cuoi kì', N'2         ', 1, 1, NULL, N'40', 1, N'Đã duyệt', NULL, NULL, N'6         ')
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (7, N'De thi cuoi kì ', N'2         ', 1, 1, NULL, N'40', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (8, N'De thi cuoi kì ', N'2         ', 1, 1, NULL, N'40', 1, N'Đã duyệt', NULL, NULL, N'6         ')
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (9, N'De On tap 1', N'1         ', 0, NULL, NULL, N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (10, N'De On tap 1', N'1         ', 0, NULL, NULL, N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (11, N'OnTap 1', N'1         ', 0, NULL, NULL, N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (12, N'ON TAP', N'1         ', 0, 1, NULL, N'10', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (13, N'On Tap2', N'1         ', 0, 1, NULL, N'30', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bo_De] ([Ma_BoDe], [NoiDung], [Ma_NguoiTao], [TrangThai], [Ma_Mon], [SoCau], [ThoiGianThi], [Xoa], [PheDuyet], [ThoiGianMo], [ThoiGianDong], [NguoiDuyet]) VALUES (14, N'On Tap 4', N'1         ', 0, 1, NULL, N'50', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Bo_De] OFF
GO
SET IDENTITY_INSERT [dbo].[BoDeOnTap] ON 

INSERT [dbo].[BoDeOnTap] ([MaBoDe], [MaLopHP], [ThoiGianMo], [ThoiGianDong], [id]) VALUES (12, N'EW1       ', NULL, NULL, 4)
INSERT [dbo].[BoDeOnTap] ([MaBoDe], [MaLopHP], [ThoiGianMo], [ThoiGianDong], [id]) VALUES (13, N'EW1       ', CAST(N'2021-04-05T13:22:00.000' AS DateTime), CAST(N'2021-04-24T22:22:00.000' AS DateTime), 5)
INSERT [dbo].[BoDeOnTap] ([MaBoDe], [MaLopHP], [ThoiGianMo], [ThoiGianDong], [id]) VALUES (14, N'EW1       ', NULL, CAST(N'2021-04-09T22:28:00.000' AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[BoDeOnTap] OFF
GO
INSERT [dbo].[BoMon] ([Ma_BoMon], [Ten], [TrangThai]) VALUES (N'1         ', N'Công Nghệ Thông Tin', 1)
INSERT [dbo].[BoMon] ([Ma_BoMon], [Ten], [TrangThai]) VALUES (N'2         ', N'Công Trình Xây Dựng', 1)
INSERT [dbo].[BoMon] ([Ma_BoMon], [Ten], [TrangThai]) VALUES (N'2000000002', N'Bo Mon Kinh Te', 1)
INSERT [dbo].[BoMon] ([Ma_BoMon], [Ten], [TrangThai]) VALUES (N'BM62295513', N'Bo Mon Dien TU', 1)
GO
SET IDENTITY_INSERT [dbo].[CauHoi] ON 

INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (1, 5, 1, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (1, 1, 2, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (1, 2, 3, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (1, 3, 4, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (1, 4, 5, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (2, 5, 6, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (2, 1, 7, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (2, 2, 8, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (2, 3, 9, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (2, 4, 10, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (3, 5, 11, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (3, 1, 12, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (3, 2, 13, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (3, 3, 14, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (3, 4, 15, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (4, 5, 16, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (4, 1, 17, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (4, 2, 18, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (4, 3, 19, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (4, 4, 20, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (5, 5, 21, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (5, 1, 22, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (5, 2, 23, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (5, 3, 24, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (5, 4, 25, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (6, 5, 26, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (6, 1, 27, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (6, 2, 28, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (6, 3, 29, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (6, 4, 30, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (7, 5, 31, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (7, 1, 32, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (7, 2, 33, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (7, 3, 34, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (7, 4, 35, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (8, 5, 36, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (8, 1, 37, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (8, 2, 38, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (8, 3, 39, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (8, 4, 40, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (11, 25, 41, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (11, 26, 42, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (11, 27, 43, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (11, 28, 44, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (12, 29, 45, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (12, 30, 46, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (12, 31, 47, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (12, 32, 48, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (13, 45, 49, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (13, 46, 50, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (13, 47, 51, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (13, 48, 52, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (14, 53, 53, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (14, 54, 54, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (14, 55, 55, NULL)
INSERT [dbo].[CauHoi] ([Ma_BoDe], [Ma_CauHoi], [MaCT], [trangThai]) VALUES (14, 56, 56, NULL)
SET IDENTITY_INSERT [dbo].[CauHoi] OFF
GO
SET IDENTITY_INSERT [dbo].[CauHoiDeThi] ON 

INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (1, 32, 1)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (1, 31, 2)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (1, 30, 3)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (1, 29, 4)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (2, 31, 5)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (2, 32, 6)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (2, 30, 7)
INSERT [dbo].[CauHoiDeThi] ([MaDeThi], [MaCauHoi], [MaCT]) VALUES (2, 29, 8)
SET IDENTITY_INSERT [dbo].[CauHoiDeThi] OFF
GO
SET IDENTITY_INSERT [dbo].[Chuong_Hoc] ON 

INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (1, N'Chuong1', 1, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (2, N'Chuong2', 1, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (3, N'chuong2', 2, 0)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (4, N'Chuong2', 2, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (5, NULL, 5, 0)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (6, NULL, 7, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (7, N'chuong0', 3, 0)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (8, N'chuong2', 3, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (9, N'chuong3', 3, 0)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (10, N'chuong2', 3, 1)
INSERT [dbo].[Chuong_Hoc] ([Ma_Chuong], [TenChuong], [Ma_Mon], [TrangThai]) VALUES (11, N'chuong1', 4, 1)
SET IDENTITY_INSERT [dbo].[Chuong_Hoc] OFF
GO
SET IDENTITY_INSERT [dbo].[Da_SVLuaChon] ON 

INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (1, 124, 7)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (1, 120, 8)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (1, 116, 9)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (1, 112, 10)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (2, 120, 14)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (2, 116, 15)
INSERT [dbo].[Da_SVLuaChon] ([MaDeThi], [Ma_DAN], [MA_CT]) VALUES (2, 112, 16)
SET IDENTITY_INSERT [dbo].[Da_SVLuaChon] OFF
GO
SET IDENTITY_INSERT [dbo].[Dap_AN] ON 

INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (1, N'Cads', N'', 1, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (2, N'ads', N'', 1, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (3, N'ád', N'', 1, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (4, N'ád', N'', 1, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (5, N'ad', N'', 2, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (6, N'ads', N'', 2, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (7, N'ad', N'', 2, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (8, N'ad', N'', 2, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (9, N'ad', N'', 3, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (10, N'aád', N'', 3, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (11, N'ad', N'', 3, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (12, N'ad', N'', 3, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (13, N'123', N'', 4, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (14, N'31', N'', 4, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (15, N'32', N'', 4, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (16, N'31', N'', 4, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (17, N' Dữ liệu là đối tượng mang thông tin. ', N'', 5, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (18, N' Dữ liệu là các tín hiệu vật lý và các số liệu. ', N'', 5, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (19, N'Dữ liệu là các kí hiệu, các hình ảnh. ', N'', 5, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (20, N'Cads', N'', 6, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (21, N'ads', N'', 6, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (22, N'ád', N'', 6, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (23, N'ád', N'', 6, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (24, N'Cads', N'', 7, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (25, N'ads', N'', 7, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (26, N'ád', N'', 7, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (27, N'ád', N'', 7, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (28, N'Cads', N'', 8, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (29, N'ads', N'', 8, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (30, N'ád', N'', 8, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (31, N'ád', N'', 8, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (32, N'Cads', N'', 9, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (33, N'ads', N'', 9, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (34, N'ád', N'', 9, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (35, N'ád', N'', 9, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (36, N'ad', N'', 10, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (37, N'ads', N'', 10, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (38, N'ad', N'', 10, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (39, N'ad', N'', 10, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (40, N'ad', N'', 11, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (41, N'aád', N'', 11, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (42, N'ad', N'', 11, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (43, N'ad', N'', 11, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (44, N'123', N'', 12, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (45, N'31', N'', 12, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (46, N'32', N'', 12, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (47, N'31', N'', 12, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (48, N'Cads', N'', 13, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (49, N'ads', N'', 13, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (50, N'ád', N'', 13, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (51, N'ád', N'', 13, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (52, N'ad', N'', 14, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (53, N'ads', N'', 14, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (54, N'ad', N'', 14, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (55, N'ad', N'', 14, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (56, N'ad', N'', 15, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (57, N'aád', N'', 15, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (58, N'ad', N'', 15, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (59, N'ad', N'', 15, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (60, N'123', N'', 16, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (61, N'31', N'', 16, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (62, N'32', N'', 16, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (63, N'31', N'', 16, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (64, N'Cads', N'', 17, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (65, N'ads', N'', 17, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (66, N'ád', N'', 17, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (67, N'ád', N'', 17, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (68, N'ad', N'', 18, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (69, N'ads', N'', 18, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (70, N'ad', N'', 18, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (71, N'ad', N'', 18, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (72, N'ad', N'', 19, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (73, N'aád', N'', 19, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (74, N'ad', N'', 19, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (75, N'ad', N'', 19, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (76, N'123', N'', 20, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (77, N'31', N'', 20, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (78, N'32', N'', 20, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (79, N'31', N'', 20, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (80, N'Cads', N'', 21, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (81, N'ads', N'', 21, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (82, N'ád', N'', 21, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (83, N'ád', N'', 21, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (84, N'ad', N'', 22, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (85, N'ads', N'', 22, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (86, N'ad', N'', 22, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (87, N'ad', N'', 22, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (88, N'ad', N'', 23, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (89, N'aád', N'', 23, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (90, N'ad', N'', 23, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (91, N'ad', N'', 23, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (92, N'123', N'', 24, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (93, N'31', N'', 24, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (94, N'32', N'', 24, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (95, N'31', N'', 24, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (96, N'Cads', N'', 25, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (97, N'ads', N'', 25, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (98, N'ád', N'', 25, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (99, N'ád', N'', 25, 0)
GO
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (100, N'ad', N'', 26, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (101, N'ads', N'', 26, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (102, N'ad', N'', 26, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (103, N'ad', N'', 26, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (104, N'ad', N'', 27, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (105, N'aád', N'', 27, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (106, N'ad', N'', 27, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (107, N'ad', N'', 27, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (108, N'123', N'', 28, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (109, N'31', N'', 28, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (110, N'32', N'', 28, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (111, N'31', N'', 28, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (112, N'Cads', N'', 29, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (113, N'ads', N'', 29, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (114, N'ád', N'', 29, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (115, N'ád', N'', 29, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (116, N'ad', N'', 30, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (117, N'ads', N'', 30, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (118, N'ad', N'', 30, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (119, N'ad', N'', 30, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (120, N'ad', N'', 31, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (121, N'aád', N'', 31, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (122, N'ad', N'', 31, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (123, N'ad', N'', 31, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (124, N'123', N'', 32, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (125, N'31', N'', 32, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (126, N'32', N'', 32, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (127, N'31', N'', 32, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (128, N'Cads', N'', 33, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (129, N'ads', N'', 33, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (130, N'ád', N'', 33, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (131, N'ád', N'', 33, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (132, N'ad', N'', 34, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (133, N'ads', N'', 34, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (134, N'ad', N'', 34, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (135, N'ad', N'', 34, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (136, N'ad', N'', 35, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (137, N'aád', N'', 35, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (138, N'ad', N'', 35, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (139, N'ad', N'', 35, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (140, N'123', N'', 36, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (141, N'31', N'', 36, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (142, N'32', N'', 36, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (143, N'31', N'', 36, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (144, N'Cads', N'', 37, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (145, N'ads', N'', 37, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (146, N'ád', N'', 37, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (147, N'ád', N'', 37, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (148, N'ad', N'', 38, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (149, N'ads', N'', 38, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (150, N'ad', N'', 38, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (151, N'ad', N'', 38, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (152, N'ad', N'', 39, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (153, N'aád', N'', 39, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (154, N'ad', N'', 39, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (155, N'ad', N'', 39, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (156, N'123', N'', 40, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (157, N'31', N'', 40, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (158, N'32', N'', 40, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (159, N'31', N'', 40, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (160, N'Cads', N'', 41, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (161, N'ads', N'', 41, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (162, N'ád', N'', 41, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (163, N'ád', N'', 41, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (164, N'ad', N'', 42, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (165, N'ads', N'', 42, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (166, N'ad', N'', 42, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (167, N'ad', N'', 42, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (168, N'ad', N'', 43, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (169, N'aád', N'', 43, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (170, N'ad', N'', 43, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (171, N'ad', N'', 43, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (172, N'123', N'', 44, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (173, N'31', N'', 44, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (174, N'32', N'', 44, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (175, N'31', N'', 44, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (176, N'Cads', N'', 45, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (177, N'ads', N'', 45, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (178, N'ád', N'', 45, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (179, N'ád', N'', 45, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (180, N'ad', N'', 46, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (181, N'ads', N'', 46, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (182, N'ad', N'', 46, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (183, N'ad', N'', 46, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (184, N'ad', N'', 47, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (185, N'aád', N'', 47, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (186, N'ad', N'', 47, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (187, N'ad', N'', 47, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (188, N'123', N'', 48, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (189, N'31', N'', 48, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (190, N'32', N'', 48, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (191, N'31', N'', 48, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (192, N'Cads', N'', 49, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (193, N'ads', N'', 49, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (194, N'ád', N'', 49, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (195, N'ád', N'', 49, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (196, N'ad', N'', 50, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (197, N'ads', N'', 50, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (198, N'ad', N'', 50, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (199, N'ad', N'', 50, 0)
GO
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (200, N'ad', N'', 51, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (201, N'aád', N'https://binhminhdigital.com/StoreData/PageData/3429/Tim-hieu-ve-ban-quyen-hinh-anh%20(3).jpg', 51, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (202, N'ad', N'', 51, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (203, N'ad', N'', 51, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (204, N'123', N'', 52, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (205, N'31', N'', 52, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (206, N'32', N'', 52, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (207, N'31', N'', 52, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (208, N'Cads', N'', 53, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (209, N'ads', N'https://binhminhdigital.com/StoreData/PageData/3429/Tim-hieu-ve-ban-quyen-hinh-anh%20(3).jpg', 53, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (210, N'ád', N'', 53, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (211, N'ád', N'', 53, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (212, N'ad', N'https://binhminhdigital.com/StoreData/PageData/3429/Tim-hieu-ve-ban-quyen-hinh-anh%20(3).jpg', 54, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (213, N'ads', N'', 54, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (214, N'ad', N'', 54, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (215, N'ad', N'', 54, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (216, N'ad', N'', 55, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (217, N'aád', N'https://binhminhdigital.com/StoreData/PageData/3429/Tim-hieu-ve-ban-quyen-hinh-anh%20(3).jpg', 55, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (218, N'ad', N'', 55, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (219, N'ad', N'', 55, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (220, N'123', N'', 56, 1)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (221, N'31', N'', 56, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (222, N'32', N'', 56, 0)
INSERT [dbo].[Dap_AN] ([MA_DAN], [NoiDung], [HinhAnh], [Ma_CauHoi], [TrangThai]) VALUES (223, N'31', N'', 56, 0)
SET IDENTITY_INSERT [dbo].[Dap_AN] OFF
GO
SET IDENTITY_INSERT [dbo].[De_Thi] ON 

INSERT [dbo].[De_Thi] ([Ma_SV], [Ma_BoDe], [TrangThai], [MaDeThi]) VALUES (N'5951071113', 12, 1, 1)
INSERT [dbo].[De_Thi] ([Ma_SV], [Ma_BoDe], [TrangThai], [MaDeThi]) VALUES (N'5951071113', 12, 1, 2)
SET IDENTITY_INSERT [dbo].[De_Thi] OFF
GO
SET IDENTITY_INSERT [dbo].[DS_LopHP] ON 

INSERT [dbo].[DS_LopHP] ([Ma_LOP], [MA_SV], [ID], [TrangThai]) VALUES (N'EW1       ', N'5951071113', 1, NULL)
INSERT [dbo].[DS_LopHP] ([Ma_LOP], [MA_SV], [ID], [TrangThai]) VALUES (N'EW1       ', N'5951071114', 2, NULL)
INSERT [dbo].[DS_LopHP] ([Ma_LOP], [MA_SV], [ID], [TrangThai]) VALUES (N'EW1       ', N'5951071125', 3, NULL)
INSERT [dbo].[DS_LopHP] ([Ma_LOP], [MA_SV], [ID], [TrangThai]) VALUES (N'EW1       ', N'5951071118', 4, NULL)
SET IDENTITY_INSERT [dbo].[DS_LopHP] OFF
GO
SET IDENTITY_INSERT [dbo].[DS_SVThi] ON 

INSERT [dbo].[DS_SVThi] ([Ma_SV], [MaPhong], [MaDS], [MaDeThi], [TrangThai]) VALUES (N'5951071113', N'MHSTMAQVHF', 1, NULL, NULL)
INSERT [dbo].[DS_SVThi] ([Ma_SV], [MaPhong], [MaDS], [MaDeThi], [TrangThai]) VALUES (N'5951071114', N'MHSTMAQVHF', 2, NULL, NULL)
INSERT [dbo].[DS_SVThi] ([Ma_SV], [MaPhong], [MaDS], [MaDeThi], [TrangThai]) VALUES (N'5951071125', N'MHSTMAQVHF', 3, NULL, NULL)
INSERT [dbo].[DS_SVThi] ([Ma_SV], [MaPhong], [MaDS], [MaDeThi], [TrangThai]) VALUES (N'5951071118', N'MHSTMAQVHF', 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DS_SVThi] OFF
GO
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'1         ', N'Trần Thi Dung', NULL, 1, N'2         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'2         ', N'Nha Tran', NULL, 0, N'1         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'3         ', N'BoMonCongNghe Thong TIN', NULL, 0, N'1         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'4         ', N'BoMonXayDung', NULL, 0, N'2         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'5         ', N'Trần Thi Thanh', NULL, 1, N'2         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'6         ', N'Admin', NULL, 1, NULL)
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'75215422  ', NULL, NULL, 0, N'2000000002')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'9         ', N'nguyen thi thu', NULL, 1, N'1         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'BM62295513', NULL, NULL, 0, N'BM62295513')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'GV12345   ', N'VI', NULL, 0, N'BM62295513')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'GV12346   ', N'WW', NULL, 0, N'BM62295513')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'GV12347   ', N'VI', NULL, 0, N'2         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'GV12348   ', N'VI', NULL, 0, N'1         ')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Ma_Nganh], [TrangThai], [MaBoMon]) VALUES (N'GV12349   ', N'VI', NULL, 1, N'1         ')
GO
SET IDENTITY_INSERT [dbo].[Kho_CauHoi] ON 

INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (1, N'Cau1', N'', N'Nhận Biết', 1, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (2, N'Cau2', N'', N'Thông Hiểu', 1, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (3, N'Cau3', N'', N'Vận Dụng', 1, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (4, N'Cau4', N'', N'Vận Dụng Cao', 1, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (5, N' Khái niệm dữ liệu là? ', N'', N'Nhận Biết', 1, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (6, N'Cau1', N'', N'Nhận Biết', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (7, N'Cau1', N'', N'Nhận Biết', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (8, N'Cau1', N'', N'Nhận Biết', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (9, N'Cau1', N'', N'Nhận Biết', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (10, N'Cau2', N'', N'Thông Hiểu', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (11, N'Cau3', N'', N'Vận Dụng', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (12, N'Cau4', N'', N'Vận Dụng Cao', 11, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (13, N'Cau1', N'', N'Nhận Biết', 8, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (14, N'Cau2', N'', N'Thông Hiểu', 8, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (15, N'Cau3', N'', N'Vận Dụng', 8, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (16, N'Cau4', N'', N'Vận Dụng Cao', 8, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (17, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (18, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (19, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (20, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (21, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (22, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (23, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (24, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (25, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (26, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (27, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (28, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (29, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (30, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (31, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (32, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (33, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (34, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (35, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (36, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (37, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (38, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (39, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (40, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (41, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (42, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (43, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (44, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (45, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (46, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (47, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (48, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (49, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (50, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (51, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (52, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (53, N'Cau1', N'', N'Nhận Biết', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (54, N'Cau2', N'', N'Thông Hiểu', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (55, N'Cau3', N'', N'Vận Dụng', NULL, NULL)
INSERT [dbo].[Kho_CauHoi] ([Ma_CauHoi], [NoiDung], [HinhAnh], [MucDo], [Ma_Chuong], [TrangThai]) VALUES (56, N'Cau4', N'', N'Vận Dụng Cao', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Kho_CauHoi] OFF
GO
SET IDENTITY_INSERT [dbo].[KiThi] ON 

INSERT [dbo].[KiThi] ([MAKI], [TenKi], [TGBatDau], [TGKetThuc], [TrangThai]) VALUES (1, N'Ki Thi 2021_2022', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[KiThi] OFF
GO
INSERT [dbo].[Lop] ([Ma_Lop], [TenLop], [Ma_Nganh], [DaXoa]) VALUES (N'1', N'Công Nghệ Thông Tin K59', 1, 1)
INSERT [dbo].[Lop] ([Ma_Lop], [TenLop], [Ma_Nganh], [DaXoa]) VALUES (N'2', N'Công Nghệ Thông Tin k59', 1, 1)
INSERT [dbo].[Lop] ([Ma_Lop], [TenLop], [Ma_Nganh], [DaXoa]) VALUES (N'CQ_CNTT_K57', N'Công Nghê Thông Tin K57', 1, NULL)
INSERT [dbo].[Lop] ([Ma_Lop], [TenLop], [Ma_Nganh], [DaXoa]) VALUES (N'CQ_CNTT_K58', N'Công Nghê Thông Tin 59', 1, 1)
INSERT [dbo].[Lop] ([Ma_Lop], [TenLop], [Ma_Nganh], [DaXoa]) VALUES (N'CQ_CNTT_K59', N'Công Nghê Thông Tin K59', 1, NULL)
GO
INSERT [dbo].[LopHocPhan] ([MaLop], [TenLop], [MaGV], [SiSo], [MaMon], [MaKi], [TrangThai]) VALUES (N'EW1       ', N'Câu Trúc Va Giai Thuật', N'1         ', NULL, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (1, N'Cấu Trúc Dư Lieu', 1, N'1         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (2, N'Lập Trình Truc Quan', 1, N'1         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (3, N'Lý Thuyết Tro Choi', 1, N'2         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (4, N'MoHinhXayDung', 1, N'2         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (5, N'Toan', 1, N'2         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (6, N'Toan giai tich', 0, N'2         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (7, N'Tuyen tinh1', 1, N'2         ')
INSERT [dbo].[MonHoc] ([Ma_Mon], [TenMon], [TrangThai], [MaBoMon]) VALUES (8, N'Bo Mon Kinh Te', 1, N'2         ')
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
GO
INSERT [dbo].[Nganh] ([Ma_Nganh], [TenNganh], [DaXoa]) VALUES (1, N'Công Nghệ Thông Tin', NULL)
INSERT [dbo].[Nganh] ([Ma_Nganh], [TenNganh], [DaXoa]) VALUES (2, N'Xây dựng', NULL)
GO
INSERT [dbo].[Phong_Thi] ([MaPhong], [NguoiTao], [ThoiGianMo], [ThoiGianDong], [TrangThai], [MaBoDe], [MaLopHP], [Xoa], [TenPhong], [MaCanBo1], [MaCanBo2]) VALUES (N'MHSTMAQVHF', N'6         ', CAST(N'2021-04-10T00:24:00.000' AS DateTime), NULL, N'Chưa Thi', NULL, N'EW1       ', 0, N'Ki thi cuoi ki', N'9         ', N'2         ')
INSERT [dbo].[Phong_Thi] ([MaPhong], [NguoiTao], [ThoiGianMo], [ThoiGianDong], [TrangThai], [MaBoDe], [MaLopHP], [Xoa], [TenPhong], [MaCanBo1], [MaCanBo2]) VALUES (N'WZKMKBPIMG', N'6         ', CAST(N'2021-04-10T13:53:00.000' AS DateTime), NULL, N'Chưa Thi', NULL, N'EW1       ', 1, N'aa', N'5         ', N'1         ')
GO
INSERT [dbo].[SinhVien] ([MaSV], [Ten], [NgaySinh], [DiaChi], [Ma_Lop], [DaXoa]) VALUES (N'5951071118', N'Le anh anh', CAST(N'2021-03-12' AS Date), N'ASSAAAA', N'CQ_CNTT_K59', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [Ten], [NgaySinh], [DiaChi], [Ma_Lop], [DaXoa]) VALUES (N'5951071114', N'Qtruong', CAST(N'2000-03-05' AS Date), N'null', N'2', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [Ten], [NgaySinh], [DiaChi], [Ma_Lop], [DaXoa]) VALUES (N'5951071113', N'Truong', CAST(N'2000-03-05' AS Date), N'null', N'2', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [Ten], [NgaySinh], [DiaChi], [Ma_Lop], [DaXoa]) VALUES (N'5951071125', N'Yến', CAST(N'2000-03-05' AS Date), N'null', N'2', NULL)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'1         ', N'1         ', N'Cán Bộ', 1, N'1')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'2         ', N'1         ', N'BoMon', 1, N'2')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'4         ', N'1         ', N'BoMon', 1, N'3')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'5951071113', N'1         ', N'SinhViên', 1, N'5951071113')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'5951071114', N'1         ', N'SinhViên', 1, N'5951071114')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'5951071118', N'1         ', NULL, 1, N'5951071118')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'5951071125', N'1         ', N'SinhViên', 1, N'5951071115')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'6         ', N'1         ', N'Admin', 1, N'Admin')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'9         ', N'1         ', N'Cán Bộ', 1, N'9')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'GV12345   ', N'1         ', N'Cán Bộ', 0, N'GV12345')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'GV12346   ', N'1         ', N'Cán Bộ', 0, N'GV12346')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'GV12347   ', N'1         ', N'Cán Bộ', 0, N'GV12347')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'GV12348   ', N'1         ', N'Cán Bộ', 0, N'GV12348')
INSERT [dbo].[TaiKhoan] ([TaiKhoan], [MatKhau], [ChưcVu], [TrangThai], [TenDangNhap]) VALUES (N'GV12349   ', N'1         ', N'Cán Bộ', 1, N'GV12349')
GO
ALTER TABLE [dbo].[KetQuaThi] ADD  CONSTRAINT [DF_KetQuaThi_NgayThi]  DEFAULT (getdate()) FOR [NgayThi]
GO
ALTER TABLE [dbo].[KiThi] ADD  CONSTRAINT [DF_KiThi_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Bo_De]  WITH CHECK ADD  CONSTRAINT [FK_Bo_De_GiaoVien] FOREIGN KEY([Ma_NguoiTao])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[Bo_De] CHECK CONSTRAINT [FK_Bo_De_GiaoVien]
GO
ALTER TABLE [dbo].[Bo_De]  WITH CHECK ADD  CONSTRAINT [FK_Bo_De_Ma_Mon] FOREIGN KEY([Ma_Mon])
REFERENCES [dbo].[MonHoc] ([Ma_Mon])
GO
ALTER TABLE [dbo].[Bo_De] CHECK CONSTRAINT [FK_Bo_De_Ma_Mon]
GO
ALTER TABLE [dbo].[Bo_De]  WITH CHECK ADD  CONSTRAINT [FK_Bo_De_TaiKhoan] FOREIGN KEY([NguoiDuyet])
REFERENCES [dbo].[TaiKhoan] ([TaiKhoan])
GO
ALTER TABLE [dbo].[Bo_De] CHECK CONSTRAINT [FK_Bo_De_TaiKhoan]
GO
ALTER TABLE [dbo].[BoDeOnTap]  WITH CHECK ADD  CONSTRAINT [FK_BoDeOnTap_Bo_De] FOREIGN KEY([MaBoDe])
REFERENCES [dbo].[Bo_De] ([Ma_BoDe])
GO
ALTER TABLE [dbo].[BoDeOnTap] CHECK CONSTRAINT [FK_BoDeOnTap_Bo_De]
GO
ALTER TABLE [dbo].[BoDeOnTap]  WITH CHECK ADD  CONSTRAINT [FK_BoDeOnTap_LopHocPhan] FOREIGN KEY([MaLopHP])
REFERENCES [dbo].[LopHocPhan] ([MaLop])
GO
ALTER TABLE [dbo].[BoDeOnTap] CHECK CONSTRAINT [FK_BoDeOnTap_LopHocPhan]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_Bo_De] FOREIGN KEY([Ma_BoDe])
REFERENCES [dbo].[Bo_De] ([Ma_BoDe])
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_Bo_De]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_Kho_CauHoi] FOREIGN KEY([Ma_CauHoi])
REFERENCES [dbo].[Kho_CauHoi] ([Ma_CauHoi])
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_Kho_CauHoi]
GO
ALTER TABLE [dbo].[CauHoiDeThi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoiDeThi_De_Thi] FOREIGN KEY([MaDeThi])
REFERENCES [dbo].[De_Thi] ([MaDeThi])
GO
ALTER TABLE [dbo].[CauHoiDeThi] CHECK CONSTRAINT [FK_CauHoiDeThi_De_Thi]
GO
ALTER TABLE [dbo].[CauHoiDeThi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoiDeThi_Kho_CauHoi] FOREIGN KEY([MaCauHoi])
REFERENCES [dbo].[Kho_CauHoi] ([Ma_CauHoi])
GO
ALTER TABLE [dbo].[CauHoiDeThi] CHECK CONSTRAINT [FK_CauHoiDeThi_Kho_CauHoi]
GO
ALTER TABLE [dbo].[Chuong_Hoc]  WITH CHECK ADD  CONSTRAINT [FK_Chuong_Hoc_Ma_Mon] FOREIGN KEY([Ma_Mon])
REFERENCES [dbo].[MonHoc] ([Ma_Mon])
GO
ALTER TABLE [dbo].[Chuong_Hoc] CHECK CONSTRAINT [FK_Chuong_Hoc_Ma_Mon]
GO
ALTER TABLE [dbo].[Da_SVLuaChon]  WITH CHECK ADD  CONSTRAINT [FK_Da_SVLuaChon_Dap_AN] FOREIGN KEY([Ma_DAN])
REFERENCES [dbo].[Dap_AN] ([MA_DAN])
GO
ALTER TABLE [dbo].[Da_SVLuaChon] CHECK CONSTRAINT [FK_Da_SVLuaChon_Dap_AN]
GO
ALTER TABLE [dbo].[Da_SVLuaChon]  WITH CHECK ADD  CONSTRAINT [FK_Da_SVLuaChon_De_Thi] FOREIGN KEY([MaDeThi])
REFERENCES [dbo].[De_Thi] ([MaDeThi])
GO
ALTER TABLE [dbo].[Da_SVLuaChon] CHECK CONSTRAINT [FK_Da_SVLuaChon_De_Thi]
GO
ALTER TABLE [dbo].[Danh_Gia]  WITH CHECK ADD  CONSTRAINT [FK_Danh_Gia_Chuong_Hoc] FOREIGN KEY([MaChuong])
REFERENCES [dbo].[Chuong_Hoc] ([Ma_Chuong])
GO
ALTER TABLE [dbo].[Danh_Gia] CHECK CONSTRAINT [FK_Danh_Gia_Chuong_Hoc]
GO
ALTER TABLE [dbo].[Danh_Gia]  WITH CHECK ADD  CONSTRAINT [FK_Danh_Gia_De_Thi] FOREIGN KEY([MaDeThi])
REFERENCES [dbo].[De_Thi] ([MaDeThi])
GO
ALTER TABLE [dbo].[Danh_Gia] CHECK CONSTRAINT [FK_Danh_Gia_De_Thi]
GO
ALTER TABLE [dbo].[Dap_AN]  WITH CHECK ADD  CONSTRAINT [FK_Dap_AN_CauHoi] FOREIGN KEY([Ma_CauHoi])
REFERENCES [dbo].[Kho_CauHoi] ([Ma_CauHoi])
GO
ALTER TABLE [dbo].[Dap_AN] CHECK CONSTRAINT [FK_Dap_AN_CauHoi]
GO
ALTER TABLE [dbo].[De_Thi]  WITH CHECK ADD  CONSTRAINT [FK_De_Thi_Bo_De] FOREIGN KEY([Ma_BoDe])
REFERENCES [dbo].[Bo_De] ([Ma_BoDe])
GO
ALTER TABLE [dbo].[De_Thi] CHECK CONSTRAINT [FK_De_Thi_Bo_De]
GO
ALTER TABLE [dbo].[DS_LopHP]  WITH CHECK ADD  CONSTRAINT [FK_DS_LopHP_LopHocPhan] FOREIGN KEY([Ma_LOP])
REFERENCES [dbo].[LopHocPhan] ([MaLop])
GO
ALTER TABLE [dbo].[DS_LopHP] CHECK CONSTRAINT [FK_DS_LopHP_LopHocPhan]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_BoMon] FOREIGN KEY([MaBoMon])
REFERENCES [dbo].[BoMon] ([Ma_BoMon])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_BoMon]
GO
ALTER TABLE [dbo].[KetQuaThi]  WITH CHECK ADD  CONSTRAINT [FK_KetQuaThi_De_Thi] FOREIGN KEY([Ma_DeThi])
REFERENCES [dbo].[De_Thi] ([MaDeThi])
GO
ALTER TABLE [dbo].[KetQuaThi] CHECK CONSTRAINT [FK_KetQuaThi_De_Thi]
GO
ALTER TABLE [dbo].[Kho_CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_Chuong_Hoc] FOREIGN KEY([Ma_Chuong])
REFERENCES [dbo].[Chuong_Hoc] ([Ma_Chuong])
GO
ALTER TABLE [dbo].[Kho_CauHoi] CHECK CONSTRAINT [FK_CauHoi_Chuong_Hoc]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_Nganh] FOREIGN KEY([Ma_Nganh])
REFERENCES [dbo].[Nganh] ([Ma_Nganh])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_Nganh]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_GiaoVien] FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_GiaoVien]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_KiThi] FOREIGN KEY([MaKi])
REFERENCES [dbo].[KiThi] ([MAKI])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_KiThi]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_Ma_Mon] FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonHoc] ([Ma_Mon])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_Ma_Mon]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_BoMon] FOREIGN KEY([MaBoMon])
REFERENCES [dbo].[BoMon] ([Ma_BoMon])
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_BoMon]
GO
ALTER TABLE [dbo].[Phong_Thi]  WITH CHECK ADD  CONSTRAINT [FK_Phong_Thi_Bo_De] FOREIGN KEY([MaBoDe])
REFERENCES [dbo].[Bo_De] ([Ma_BoDe])
GO
ALTER TABLE [dbo].[Phong_Thi] CHECK CONSTRAINT [FK_Phong_Thi_Bo_De]
GO
ALTER TABLE [dbo].[Phong_Thi]  WITH CHECK ADD  CONSTRAINT [FK_Phong_Thi_GiaoVien] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[Phong_Thi] CHECK CONSTRAINT [FK_Phong_Thi_GiaoVien]
GO
ALTER TABLE [dbo].[Phong_Thi]  WITH CHECK ADD  CONSTRAINT [FK_Phong_Thi_LopHocPhan] FOREIGN KEY([MaLopHP])
REFERENCES [dbo].[LopHocPhan] ([MaLop])
GO
ALTER TABLE [dbo].[Phong_Thi] CHECK CONSTRAINT [FK_Phong_Thi_LopHocPhan]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([Ma_Lop])
REFERENCES [dbo].[Lop] ([Ma_Lop])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
USE [master]
GO
ALTER DATABASE [TracNghiemOnline1] SET  READ_WRITE 
GO
