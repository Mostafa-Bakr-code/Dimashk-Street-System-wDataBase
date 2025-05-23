USE [master]
GO
/****** Object:  Database [Dimash-Street]    Script Date: 5/19/2025 5:44:17 AM ******/
CREATE DATABASE [Dimash-Street]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dimash-Street', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Dimash-Street.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dimash-Street_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Dimash-Street_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Dimash-Street] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dimash-Street].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dimash-Street] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dimash-Street] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dimash-Street] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dimash-Street] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dimash-Street] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dimash-Street] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dimash-Street] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dimash-Street] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dimash-Street] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dimash-Street] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dimash-Street] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dimash-Street] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dimash-Street] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dimash-Street] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dimash-Street] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dimash-Street] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dimash-Street] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dimash-Street] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dimash-Street] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dimash-Street] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dimash-Street] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dimash-Street] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dimash-Street] SET RECOVERY FULL 
GO
ALTER DATABASE [Dimash-Street] SET  MULTI_USER 
GO
ALTER DATABASE [Dimash-Street] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dimash-Street] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dimash-Street] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dimash-Street] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dimash-Street] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dimash-Street] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dimash-Street', N'ON'
GO
ALTER DATABASE [Dimash-Street] SET QUERY_STORE = ON
GO
ALTER DATABASE [Dimash-Street] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Dimash-Street]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[InitialPrice] [decimal](18, 4) NOT NULL,
	[TaxValue] [decimal](18, 4) NOT NULL,
	[TaxRate] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LogIN] [datetime] NOT NULL,
	[LogOut] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[TotalItemsPrice] [smallmoney] NOT NULL,
	[Comment] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [decimal](18, 4) NOT NULL,
	[SerialNumber] [int] NULL,
	[ActiveUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/19/2025 5:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Permissions] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Users]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Items]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_OrderItems] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_OrderItems]
GO
USE [master]
GO
ALTER DATABASE [Dimash-Street] SET  READ_WRITE 
GO
