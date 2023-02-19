USE [master]
GO
/****** Object:  Database [IEMSystem]    Script Date: 1/26/2023 9:55:36 AM ******/
CREATE DATABASE [IEMSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IEMSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\IEMSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IEMSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\IEMSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [IEMSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IEMSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IEMSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IEMSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IEMSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IEMSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IEMSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [IEMSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IEMSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IEMSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IEMSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IEMSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IEMSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IEMSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IEMSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IEMSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IEMSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IEMSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IEMSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IEMSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IEMSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IEMSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IEMSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IEMSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IEMSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IEMSystem] SET  MULTI_USER 
GO
ALTER DATABASE [IEMSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IEMSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IEMSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IEMSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IEMSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IEMSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IEMSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [IEMSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [IEMSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/26/2023 9:55:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenditures]    Script Date: 1/26/2023 9:55:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenditures](
	[ExpID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Expenditures] PRIMARY KEY CLUSTERED 
(
	[ExpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 1/26/2023 9:55:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes](
	[IncomeID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Incomes] PRIMARY KEY CLUSTERED 
(
	[IncomeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/26/2023 9:55:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [IEMSystem] SET  READ_WRITE 
GO
