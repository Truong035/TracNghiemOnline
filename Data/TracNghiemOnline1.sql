USE [master]
GO
/****** Object:  Database [TracNghiemOnLine1]    Script Date: 3/1/2021 11:07:29 AM ******/
CREATE DATABASE [TracNghiemOnLine1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TracNghiemOnLine1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TracNghiemOnLine1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TracNghiemOnLine1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TracNghiemOnLine1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TracNghiemOnLine1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TracNghiemOnLine1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TracNghiemOnLine1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ARITHABORT OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TracNghiemOnLine1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TracNghiemOnLine1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TracNghiemOnLine1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TracNghiemOnLine1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TracNghiemOnLine1] SET  MULTI_USER 
GO
ALTER DATABASE [TracNghiemOnLine1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TracNghiemOnLine1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TracNghiemOnLine1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TracNghiemOnLine1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TracNghiemOnLine1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TracNghiemOnLine1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TracNghiemOnLine1] SET QUERY_STORE = OFF
GO
USE [TracNghiemOnLine1]
GO
/****** Object:  User [sa]    Script Date: 3/1/2021 11:07:29 AM ******/
CREATE USER [sa] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [PHAMTRONGTRUONG]    Script Date: 3/1/2021 11:07:29 AM ******/
CREATE USER [PHAMTRONGTRUONG] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Bo_De]    Script Date: 3/1/2021 11:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bo_De](
	[Ma_BoDe] [bigint] IDENTITY(1,1) NOT NULL,
	[NoiDung] [text] NULL,
	[Ma_NguoiTao] [bigint] NULL,
	[TrangThai] [bit] NULL,
	[Ma_Mon] [bigint] NULL,
	[SoCau] [int] NULL,
	[ThoiGianThi] [nvarchar](20) NULL,
 CONSTRAINT [PK_De_Thi] PRIMARY KEY CLUSTERED 
(
	[Ma_BoDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[Ma_BoDe] [bigint] NOT NULL,
	[Ma_CauHoi] [bigint] NOT NULL,
	[MaCT] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CauHoi_1] PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoiDeThi]    Script Date: 3/1/2021 11:07:30 AM ******/
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
/****** Object:  Table [dbo].[Chuong_Hoc]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuong_Hoc](
	[Ma_Chuong] [bigint] IDENTITY(1,1) NOT NULL,
	[TenChuong] [nvarchar](50) NULL,
	[Ma_Mon] [bigint] NULL,
 CONSTRAINT [PK_Chuong_Hoc] PRIMARY KEY CLUSTERED 
(
	[Ma_Chuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Da_SVLuaChon]    Script Date: 3/1/2021 11:07:30 AM ******/
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
/****** Object:  Table [dbo].[Dap_AN]    Script Date: 3/1/2021 11:07:30 AM ******/
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
/****** Object:  Table [dbo].[De_Thi]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[De_Thi](
	[Ma_SV] [bigint] NULL,
	[Ma_BoDe] [bigint] NULL,
	[TrangThai] [bit] NULL,
	[MaDeThi] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TronDe] PRIMARY KEY CLUSTERED 
(
	[MaDeThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_LopHP]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_LopHP](
	[Ma_LOP] [char](10) NULL,
	[MA_SV] [bigint] NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DS_LopHP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_MonHoc]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_MonHoc](
	[Ma_Mon] [bigint] NOT NULL,
	[Ma_Nganh] [bigint] NOT NULL,
	[MADS] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DS_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MADS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_SVThi]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_SVThi](
	[Ma_SV] [bigint] NOT NULL,
	[MaPhong] [char](10) NOT NULL,
	[MaDS] [bigint] IDENTITY(1,1) NOT NULL,
	[MaDeThi] [bigint] NULL,
 CONSTRAINT [PK_DS_SVThi] PRIMARY KEY CLUSTERED 
(
	[MaDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [bigint] NOT NULL,
	[TenGV] [nvarchar](50) NULL,
	[Ma_Nganh] [bigint] NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaThi]    Script Date: 3/1/2021 11:07:30 AM ******/
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
/****** Object:  Table [dbo].[Kho_CauHoi]    Script Date: 3/1/2021 11:07:30 AM ******/
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
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[Ma_CauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Ma_Lop] [nvarchar](50) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[Ma_Nganh] [bigint] NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[Ma_Lop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[MaLop] [char](10) NOT NULL,
	[TenLop] [nvarchar](max) NULL,
	[MaGV] [bigint] NULL,
	[SiSo] [nchar](10) NULL,
	[MaMon] [bigint] NULL,
	[ThoiGianHoc] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_LopHocPhan] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Ma_Mon] [bigint] IDENTITY(1,1000) NOT NULL,
	[TenMon] [nchar](10) NULL,
 CONSTRAINT [PK_Ma_Mon] PRIMARY KEY CLUSTERED 
(
	[Ma_Mon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[Ma_Nganh] [bigint] NOT NULL,
	[TenNganh] [nvarchar](50) NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[Ma_Nganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong_Thi]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong_Thi](
	[MaPhong] [char](10) NOT NULL,
	[NguoiTao] [bigint] NULL,
	[ThoiGianMo] [datetime] NULL,
	[ThoiGianDong] [datetime] NULL,
	[TrangThai] [nvarchar](20) NULL,
 CONSTRAINT [PK_Phong_Thi] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [bigint] NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Ma_Lop] [nvarchar](50) NULL,
	[DaXoa] [tinyint] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 3/1/2021 11:07:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoan] [bigint] NOT NULL,
	[MatKhau] [nchar](10) NULL,
	[ChưcVu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KetQuaThi] ADD  CONSTRAINT [DF_KetQuaThi_NgayThi]  DEFAULT (getdate()) FOR [NgayThi]
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
ALTER TABLE [dbo].[De_Thi]  WITH CHECK ADD  CONSTRAINT [FK_De_Thi_SinhVien] FOREIGN KEY([Ma_SV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[De_Thi] CHECK CONSTRAINT [FK_De_Thi_SinhVien]
GO
ALTER TABLE [dbo].[DS_LopHP]  WITH CHECK ADD  CONSTRAINT [FK_DS_LopHP_LopHocPhan] FOREIGN KEY([Ma_LOP])
REFERENCES [dbo].[LopHocPhan] ([MaLop])
GO
ALTER TABLE [dbo].[DS_LopHP] CHECK CONSTRAINT [FK_DS_LopHP_LopHocPhan]
GO
ALTER TABLE [dbo].[DS_LopHP]  WITH CHECK ADD  CONSTRAINT [FK_DS_LopHP_SinhVien] FOREIGN KEY([MA_SV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[DS_LopHP] CHECK CONSTRAINT [FK_DS_LopHP_SinhVien]
GO
ALTER TABLE [dbo].[DS_MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_DS_MonHoc_Ma_Mon] FOREIGN KEY([Ma_Mon])
REFERENCES [dbo].[MonHoc] ([Ma_Mon])
GO
ALTER TABLE [dbo].[DS_MonHoc] CHECK CONSTRAINT [FK_DS_MonHoc_Ma_Mon]
GO
ALTER TABLE [dbo].[DS_MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_DS_MonHoc_Nganh] FOREIGN KEY([Ma_Nganh])
REFERENCES [dbo].[Nganh] ([Ma_Nganh])
GO
ALTER TABLE [dbo].[DS_MonHoc] CHECK CONSTRAINT [FK_DS_MonHoc_Nganh]
GO
ALTER TABLE [dbo].[DS_SVThi]  WITH CHECK ADD  CONSTRAINT [FK_DS_SVThi_Phong_Thi] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong_Thi] ([MaPhong])
GO
ALTER TABLE [dbo].[DS_SVThi] CHECK CONSTRAINT [FK_DS_SVThi_Phong_Thi]
GO
ALTER TABLE [dbo].[DS_SVThi]  WITH CHECK ADD  CONSTRAINT [FK_DS_SVThi_SinhVien] FOREIGN KEY([Ma_SV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[DS_SVThi] CHECK CONSTRAINT [FK_DS_SVThi_SinhVien]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_Nganh] FOREIGN KEY([Ma_Nganh])
REFERENCES [dbo].[Nganh] ([Ma_Nganh])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_Nganh]
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
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [fk_htk_id_manganh] FOREIGN KEY([Ma_Nganh])
REFERENCES [dbo].[Nganh] ([Ma_Nganh])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [fk_htk_id_manganh]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_GiaoVien] FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_GiaoVien]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_Ma_Mon] FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonHoc] ([Ma_Mon])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_Ma_Mon]
GO
ALTER TABLE [dbo].[Phong_Thi]  WITH CHECK ADD  CONSTRAINT [FK_Phong_Thi_GiaoVien] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[Phong_Thi] CHECK CONSTRAINT [FK_Phong_Thi_GiaoVien]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([Ma_Lop])
REFERENCES [dbo].[Lop] ([Ma_Lop])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
USE [master]
GO
ALTER DATABASE [TracNghiemOnLine1] SET  READ_WRITE 
GO
