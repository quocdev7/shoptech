USE [master]
GO
/****** Object:  Database [BanHangDB]    Script Date: 11/30/2019 2:11:19 PM ******/
CREATE DATABASE [BanHangDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanHangDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BanHangDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BanHangDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BanHangDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BanHangDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanHangDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BanHangDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanHangDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanHangDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanHangDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanHangDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanHangDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BanHangDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanHangDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanHangDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanHangDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanHangDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanHangDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanHangDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanHangDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanHangDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BanHangDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanHangDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanHangDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanHangDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanHangDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanHangDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanHangDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanHangDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BanHangDB] SET  MULTI_USER 
GO
ALTER DATABASE [BanHangDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanHangDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanHangDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanHangDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BanHangDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BanHangDB] SET QUERY_STORE = OFF
GO
USE [BanHangDB]
GO
/****** Object:  Table [dbo].[Links]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[TableId] [int] NOT NULL,
	[Types] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mcategogys]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mcategogys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NULL,
	[MetaKey] [nvarchar](255) NULL,
	[MetaDesc] [nvarchar](255) NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mcontacts]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mcontacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[Title] [varchar](64) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Detail] [text] NOT NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mmenu]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mmenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Link] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Type] [varchar](255) NOT NULL,
	[TableId] [int] NULL,
	[Orders] [int] NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
	[Position] [nvarchar](max) NULL,
 CONSTRAINT [PK__Mmenu__3214EC07E71F3822] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Morderdetails]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Morderdetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Morders]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Morders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustemerId] [int] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[ExportDate] [date] NULL,
	[DeliveryAddress] [nvarchar](255) NULL,
	[DeliveryName] [nvarchar](255) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mposts]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mposts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[Type] [varchar](255) NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[MetaKey] [nvarchar](155) NULL,
	[MetaDesc] [nvarchar](155) NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mproducts]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mproducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Number] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Price_sale] [float] NOT NULL,
	[MetaKey] [nvarchar](155) NULL,
	[MetaDesc] [nvarchar](155) NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Msliders]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Link] [varchar](255) NOT NULL,
	[Position] [varchar](100) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[Orders] [int] NOT NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mtopics]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mtopics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NULL,
	[MetaKey] [nvarchar](255) NULL,
	[MetaDesc] [nvarchar](255) NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musers]    Script Date: 11/30/2019 2:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](40) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Gender] [bit] NULL,
	[Phone] [varchar](15) NOT NULL,
	[Img] [varchar](255) NOT NULL,
	[Access] [int] NOT NULL,
	[Created_at] [datetime] NULL,
	[Created_by] [int] NULL,
	[Updated_at] [datetime] NULL,
	[Updated_by] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Links] ON 

INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (1, N'san-pham', 1, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (2, N'ti-vi', 2, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (3, N'sadsad', 3, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (4, N'tin-khuyen-mai-1', 4, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (5, N'sadsadas1', 19, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (6, N'tu-lanh-2525', 20, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (7, N'tu-lanh-33333333', 21, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (8, N'tin-nuoc-ngoai', 3, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (9, N'tin-khuyen-mai-2', 4, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (10, N'tin-moi', 2, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (11, N'tin-khuyen-mai-3', 4, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (12, N'ban-hoc', 10, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (13, N'chu-de-moi', 11, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (14, N'sadsa', 25, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (15, N'phan-anh-quoc', 26, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (16, N'phan-anh-quoc-11', 27, N'category')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (17, N'phan-anh-quoc1111', 103, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (18, N'phan-anh-quocphan-anh-quocphan-anh-quocphan-anh-quocphan-anh-quocphan-anh-quoc', 108, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (19, N'-sadsadasdsad111', 109, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (20, N'phan-anh-quocquoc', 110, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (21, N'thu-hien', 111, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (22, N'tu-lanh-44', 112, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (23, N'tu-lanh-8', 113, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (24, N'ban-hoc', 114, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (25, N'noi-com-dien-1', 115, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (26, N'tu-lanh-44', 116, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (27, N'tu-lanh-44', 117, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (28, N'tu-lanh-44', 118, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (29, N'tu-lanh-8', 119, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (30, N'tu-lanh-44', 120, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (31, N'tu-lanh-22', 121, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (32, N'tu-lanh-10', 122, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (33, N'tu-lanh-10', 123, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (34, N'tu-lanh-8', 124, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (35, N'tu-lanh-22222', 125, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (36, N'tivi-4', 126, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (37, N'chao-chong-dinh-1', 38, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (38, N'chao-chong-dinh-4', 41, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (39, N'noi-com-dien-6', 37, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (40, N'noi-com-dien-6', 37, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (41, N'ban-hoc', 91, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (42, N'phan-anh-quoc21212', 127, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (43, N'sadsadas1', 12, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (44, N'hinh-anh-4', 10, N'slider')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (45, N'hinh-anh-4', 10, N'slider')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (46, N'phan-anh-quoc', 16, N'slishow')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (47, N'hinh-anh-1', 7, N'slider')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (48, N'phan-anh-quoc', 17, N'slishow')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (49, N'phan-anh-quoc', 18, N'slishow')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (50, N'phan-anh-quoc', 18, N'slider')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (51, N'phan-anh-quoc', 19, N'slishow')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (52, N'sadsadsadsadasdas', 13, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (53, N'tin-khuyen-mai', 14, N'topic')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (54, N'sadsadasdsad', 13, N'post')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (55, N'abc', 14, N'post')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (56, N'phan-anh-quoc', 128, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (57, N'tin-rac-rac', 15, N'post')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (58, N'tin-giam-gia', 16, N'post')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (59, N'tin-giam-gia', 16, N'post')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (60, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (61, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (62, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (63, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (64, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (65, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (66, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (67, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (68, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (69, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (70, N'tin-moi-2', 22, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (71, N'ban-hoc', 21, N'product')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (72, N'admin', 11, N'user')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (73, N'admin', 12, N'user')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (74, N'admin', 13, N'user')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (75, N'admin', 14, N'user')
INSERT [dbo].[Links] ([Id], [Slug], [TableId], [Types]) VALUES (76, N'tu-lanh-44', 129, N'product')
SET IDENTITY_INSERT [dbo].[Links] OFF
SET IDENTITY_INSERT [dbo].[Mcategogys] ON 

INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (1, N'Sản phẩm', N'san-pham', 1, 2, N'metakey', N'metadesc', CAST(N'2019-11-27T14:16:43.503' AS DateTime), 1, CAST(N'2019-11-27T14:16:43.503' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (3, N'Tủ lạnh', N'tu-lanh', 0, 8, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-11T21:24:28.670' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (4, N'Tivi', N'ti-vi', 0, 7, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-11T21:24:24.817' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (6, N'Chảo chống dính', N'chao-chong-dinh', 0, 11, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (22, N'Nồi cơm điện', N'noi-com-dien', 0, 9, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (23, N'Ấm siêu tốc', N'am-sieu-toc', 0, 10, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mcategogys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (24, N'Bàn học', N'ban-hoc', 0, 6, N'metakey', N'metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Mcategogys] OFF
SET IDENTITY_INSERT [dbo].[Mcontacts] ON 

INSERT [dbo].[Mcontacts] ([Id], [Name], [Phone], [Title], [Email], [Detail], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (1, N'phan anh quoc', N'0342079588', N'mainmenu', N'phananhquoc1999@gmail.com', N'sadsadsadas', CAST(N'2019-11-29T20:44:33.810' AS DateTime), 1, CAST(N'2019-11-29T20:44:33.810' AS DateTime), 1, 1)
INSERT [dbo].[Mcontacts] ([Id], [Name], [Phone], [Title], [Email], [Detail], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (2, N'phan anh quoc', N'0342079588', N'mainmenu', N'lehuuhoa15101996@gmail.com', N'sadsadsada', CAST(N'2019-11-20T20:26:16.397' AS DateTime), 1, CAST(N'2019-11-29T20:13:47.883' AS DateTime), 1, 1)
INSERT [dbo].[Mcontacts] ([Id], [Name], [Phone], [Title], [Email], [Detail], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (3, N'nguyễn thị thu hiền', N'0342079588', N'mainmenu', N'nguyenthithuhien17040@gmail.com', N'sadasdsad', CAST(N'2019-11-29T20:44:30.877' AS DateTime), 1, CAST(N'2019-11-29T20:44:30.877' AS DateTime), 1, 1)
INSERT [dbo].[Mcontacts] ([Id], [Name], [Phone], [Title], [Email], [Detail], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (7, N'phan anh quoc', N'0342079588', N'mainmenu', N'phan-anh-quoc', N'ádasdasdas', CAST(N'2019-11-29T21:57:48.187' AS DateTime), 1, CAST(N'2019-11-29T21:58:13.197' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Mcontacts] OFF
SET IDENTITY_INSERT [dbo].[Mmenu] ON 

INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (2, N'Giới thiệu', N'gioi-thieu', 0, N'page', 1, 2, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-27T13:28:01.263' AS DateTime), 9, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (3, N'Sản phẩm', N'san-pham', 0, N'custom', NULL, 3, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (5, N'Nồi cơm điện', N'noi-com-dien', 3, N'category', 1, 9, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (6, N'Tivi', N'ti-vi', 3, N'category', 1, 6, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (8, N'Tủ lạnh', N'tu-lanh', 3, N'category', 1, 8, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (9, N'Ấm siêu tốc', N'am-sieu-toc', 3, N'category', 1, 23, CAST(N'2019-11-18T15:22:39.183' AS DateTime), 1, CAST(N'2019-11-18T16:00:22.283' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (11, N'Chảo Chống Dính', N'chao-chong-dinh', 3, N'category', 1, 11, CAST(N'2019-11-18T15:39:58.427' AS DateTime), 1, CAST(N'2019-11-18T15:39:58.427' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (16, N'Tin khuyến mãi', N'tin-khuyen-mai', 0, N'topic', 1, 4, CAST(N'2019-11-18T15:39:58.427' AS DateTime), 1, CAST(N'2019-11-18T15:39:58.427' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (17, N'Liên hệ', N'lien-he', 0, N'custom', NULL, 5, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
INSERT [dbo].[Mmenu] ([Id], [Name], [Link], [ParentId], [Type], [TableId], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status], [Position]) VALUES (20, N'Trang chủ', N'trang-chu', 0, N'custom', NULL, 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1, N'MainMenu')
SET IDENTITY_INSERT [dbo].[Mmenu] OFF
SET IDENTITY_INSERT [dbo].[Mposts] ON 

INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (1, 2, N'Giới thiệu', N'gioi-thieu', N'page', N'Nội dung bài viết', N'bai viet 2.jpg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (2, 1, N'Tin tức 1', N'tin-tuc-1', N'post', N'Nội dung bài viết', N'bai viet 3.jpg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (3, 1, N'Tin tức 2', N'tin-tuc-2', N'post', N'Nội dung bài viết', N'bai viet 1.jpg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (4, 1, N'Tin tức 3', N'tin-tuc-3', N'post', N'Nội dung bài viết', N'tin-tuc-3.jdg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (5, 2, N'Tin tức 4', N'tin-tuc-4', N'post', N'Nội dung bài viết', N'tin-tuc-4.jdg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (6, 2, N'Tin tức 5', N'tin-tuc-5', N'post', N'Nội dung bài viết', N'tin-tuc-5.jdg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (7, 2, N'Tin tức 6', N'tin-tuc-6', N'post', N'Nội dung bài viết', N'tin-tuc-6.jdg', N'Metakeyword', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mposts] ([Id], [CatId], [Title], [Slug], [Type], [Detail], [Img], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (16, 1, N'tin giảm giá', N'tin-giam-gia', N'page', N'giảm giá 50%', N'?nh bìa 1.jpg', N'metakeyword', N'metadesc', CAST(N'2019-11-29T16:09:37.933' AS DateTime), 1, CAST(N'2019-11-29T16:09:37.933' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Mposts] OFF
SET IDENTITY_INSERT [dbo].[Mproducts] ON 

INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (1, 3, N'Tủ lạnh 44', N'tu-lanh', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-27T20:10:32.887' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (8, 3, N'Tủ lạnh 8', N'tu-lanh', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (9, 3, N'Tủ lạnh 9', N'tu-lanh-9', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (11, 4, N'Tivi 1', N'ti-vi-1', N'tivi 2.jpg', N'Tivi mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (12, 4, N'Tivi 2', N'ti-vi-2', N'tivi 2.jpg', N'Tivi mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (13, 4, N'Tivi 3', N'ti-vi-3', N'tivi 2.jpg', N'Tivi mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (24, 3, N'Tủ lạnh 13', N'tu-lanh-3', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (25, 3, N'Tủ lạnh 14', N'tu-lanh-4', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (26, 3, N'Tủ lạnh 15', N'tu-lanh-5', N'tu lanh 1.jpg', N'Tủ lạnh mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (32, 22, N'Nồi cơm điện 1', N'noi-com-dien', N'noi com dien.jpg', N'Nồi cơm điện mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (33, 22, N'Nồi cơm điện 2', N'noi-com-dien', N'noi com dien.jpg', N'Nồi cơm điện mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (34, 22, N'Nồi cơm điện 3', N'noi-com-dien-3', N'noi com dien.jpg', N'Nồi cơm điện mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (35, 22, N'Nồi cơm điện 4', N'noi-com-dien-4', N'noi com dien.jpg', N'Nồi cơm điện mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (36, 22, N'Nồi cơm điện 5', N'noi-com-dien-5', N'noi com dien.jpg', N'Nồi cơm điện mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (37, 22, N'Nồi cơm điện 6', N'noi-com-dien-6', N'noi com dien.jpg', N'Nồi cơm điện 6', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-11-27T20:22:52.560' AS DateTime), 1, CAST(N'2019-11-27T20:22:52.560' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (38, 6, N'Chảo chống dính 1', N'chao-chong-dinh-1', N'chao chong dinh.jpg', N'Chảo chống dính mẫu 1', 10, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-11-27T20:19:15.727' AS DateTime), 1, CAST(N'2019-11-27T20:19:15.727' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (40, 6, N'Chảo chống dính 3', N'chao-chong-dinh-3', N'chao chong dinh.jpg', N'Chảo chống dính mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (41, 6, N'Chảo chống dính 4', N'chao-chong-dinh-4', N'chao chong dinh.jpg', N'Chảo chống dính mẫu 1', 10, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-11-27T20:19:40.760' AS DateTime), 1, CAST(N'2019-11-27T20:19:40.760' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (43, 23, N'Ấm siêu tốc 1', N'am-sieu-toc-1', N'am sieu toc.jpg', N'Ấm siêu tốc mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (44, 23, N'Ấm siêu tốc 2', N'am-sieu-toc-2', N'am sieu toc.jpg', N'Ấm siêu tốc mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (45, 23, N'Ấm siêu tốc 3', N'am-sieu-toc-3', N'am sieu toc.jpg', N'Ấm siêu tốc mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (46, 23, N'Ấm siêu tốc 4', N'am-sieu-toc-4', N'am sieu toc.jpg', N'Ấm siêu tốc mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (47, 23, N'Ấm siêu tốc 5', N'am-sieu-toc-5', N'am sieu toc.jpg', N'Ấm siêu tốc mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (90, 4, N'Tivi 4', N'ti-vi-4', N'tivi 2.jpg', N'Tivi mẫu 1', 10, 2000000, 1000000, N'metakey', N'metadesc', NULL, 1, NULL, 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (91, 24, N'Bàn học', N'ban-hoc', N'ban hoc.jpg', N'Bàn học', 10, 2000000, 1000000, N'metakey', N'metadesc', CAST(N'2019-11-27T20:24:16.230' AS DateTime), 1, CAST(N'2019-11-27T20:24:16.230' AS DateTime), 1, 1)
INSERT [dbo].[Mproducts] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [Price_sale], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (92, 6, N'Chảo chống dính 2', N'chao-chong-dinh-2', N'chao chong dinh.jpg', N'Chảo chống dính mẫu 1', 20, 2000000, 1000000, N'Metakey', N'Metadesc', CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-27T20:35:55.857' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Mproducts] OFF
SET IDENTITY_INSERT [dbo].[Msliders] ON 

INSERT [dbo].[Msliders] ([Id], [Name], [Link], [Position], [Img], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (7, N'Hình ảnh 1', N'hinh-anh-1', N'slidershow', N'aa.jpg', 0, CAST(N'2019-11-28T21:05:21.813' AS DateTime), 1, CAST(N'2019-11-28T21:05:21.813' AS DateTime), 1, 1)
INSERT [dbo].[Msliders] ([Id], [Name], [Link], [Position], [Img], [Orders], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (8, N'Hình ảnh 2', N'http://hinhanh.com/hhhhh', N'slidershow', N'anh bia 6.jpg', 2, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-11-28T21:38:40.943' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Msliders] OFF
SET IDENTITY_INSERT [dbo].[Mtopics] ON 

INSERT [dbo].[Mtopics] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (2, N'Tin mới', N'tin-moi', 0, 3, N'metakey', N'metadesc', CAST(N'2019-11-27T21:37:34.790' AS DateTime), 1, CAST(N'2019-11-29T20:12:53.927' AS DateTime), 1, 1)
INSERT [dbo].[Mtopics] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (3, N'Tin nước ngoài', N'tin-nuoc-ngoai', 1, 2, N'sdasdasd', N'sadasdsadas', CAST(N'2019-11-17T17:01:19.367' AS DateTime), 1, CAST(N'2019-11-29T20:12:56.630' AS DateTime), 1, 1)
INSERT [dbo].[Mtopics] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (14, N'Tin khuyến mãi', N'tin-khuyen-mai', 3, 4, N'sadasdaa', N'sadasdadas', CAST(N'2019-11-28T21:49:33.867' AS DateTime), 1, CAST(N'2019-11-28T21:49:33.867' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Mtopics] OFF
SET IDENTITY_INSERT [dbo].[Musers] ON 

INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (1, N'Phan anh quốc', N'admin', N'4QrcOUm6Wau+VuBX8g+IPg==', N'admin@gmai.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (2, N'Quản lý', N'quanly', N'4QrcOUm6Wau+VuBX8g+IPg==', N'admin@gmai.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, CAST(N'2019-10-15T20:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (9, N'Quoc', N'phananhquoc1999@gmail.com', N'ads123', N'phananhquoc1999@gmail.com', 1, N'2525132522', N'hinh.jdg', 1, NULL, 1, CAST(N'2019-11-29T21:09:40.373' AS DateTime), 1, 2)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (10, N'quoc', N'admin', N'sadasdas', N'lehuuhoa15101996@gmail.com', 1, N'0342079588', N'anh user.jpg', 0, NULL, NULL, CAST(N'2019-11-29T21:23:19.780' AS DateTime), 1, 0)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (11, N'quoc', N'admin', N'sadasdas', N'lehuuhoa15101996@gmail.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-11-29T21:33:57.830' AS DateTime), 1, CAST(N'2019-11-29T21:34:04.763' AS DateTime), 1, 0)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (12, N'quoc', N'admin', N'sadasdas', N'lehuuhoa15101996@gmail.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-11-29T21:35:56.157' AS DateTime), 1, CAST(N'2019-11-29T21:40:37.550' AS DateTime), 1, 0)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (13, N'quoc', N'admin', N'sadasdas', N'lehuuhoa15101996@gmail.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-11-29T21:40:31.153' AS DateTime), 1, CAST(N'2019-11-29T21:40:34.947' AS DateTime), 1, 0)
INSERT [dbo].[Musers] ([Id], [FullName], [UserName], [Password], [Email], [Gender], [Phone], [Img], [Access], [Created_at], [Created_by], [Updated_at], [Updated_by], [Status]) VALUES (14, N'quoc', N'admin', N'sadasdas', N'lehuuhoa15101996@gmail.com', 1, N'0342079588', N'anh user.jpg', 1, CAST(N'2019-11-29T21:43:12.047' AS DateTime), 1, CAST(N'2019-11-29T21:43:15.410' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Musers] OFF
ALTER TABLE [dbo].[Mcategogys] ADD  DEFAULT ('0') FOR [ParentId]
GO
ALTER TABLE [dbo].[Mcategogys] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mcategogys] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mcategogys] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Mcontacts] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mcontacts] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mcontacts] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Mmenu] ADD  CONSTRAINT [DF__Mmenu__ParentId__32AB8735]  DEFAULT ('0') FOR [ParentId]
GO
ALTER TABLE [dbo].[Mmenu] ADD  CONSTRAINT [DF__Mmenu__TableId__339FAB6E]  DEFAULT ('0') FOR [TableId]
GO
ALTER TABLE [dbo].[Mmenu] ADD  CONSTRAINT [DF__Mmenu__Created_b__3493CFA7]  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mmenu] ADD  CONSTRAINT [DF__Mmenu__Updated_b__3587F3E0]  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mmenu] ADD  CONSTRAINT [DF__Mmenu__Status__367C1819]  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Morders] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Mposts] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mposts] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mposts] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Mproducts] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mproducts] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mproducts] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Msliders] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Msliders] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Msliders] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Mtopics] ADD  DEFAULT ('0') FOR [ParentId]
GO
ALTER TABLE [dbo].[Mtopics] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Mtopics] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Mtopics] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[Musers] ADD  DEFAULT ('1') FOR [Created_by]
GO
ALTER TABLE [dbo].[Musers] ADD  DEFAULT ('1') FOR [Updated_by]
GO
ALTER TABLE [dbo].[Musers] ADD  DEFAULT ('1') FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [BanHangDB] SET  READ_WRITE 
GO
