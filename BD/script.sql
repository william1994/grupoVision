USE [master]
GO
/****** Object:  Database [grupoVision]    Script Date: 4/22/2024 8:02:07 AM ******/
CREATE DATABASE [grupoVision]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'grupoVision', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\grupoVision.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'grupoVision_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\grupoVision_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [grupoVision] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [grupoVision].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [grupoVision] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [grupoVision] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [grupoVision] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [grupoVision] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [grupoVision] SET ARITHABORT OFF 
GO
ALTER DATABASE [grupoVision] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [grupoVision] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [grupoVision] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [grupoVision] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [grupoVision] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [grupoVision] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [grupoVision] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [grupoVision] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [grupoVision] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [grupoVision] SET  ENABLE_BROKER 
GO
ALTER DATABASE [grupoVision] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [grupoVision] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [grupoVision] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [grupoVision] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [grupoVision] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [grupoVision] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [grupoVision] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [grupoVision] SET RECOVERY FULL 
GO
ALTER DATABASE [grupoVision] SET  MULTI_USER 
GO
ALTER DATABASE [grupoVision] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [grupoVision] SET DB_CHAINING OFF 
GO
ALTER DATABASE [grupoVision] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [grupoVision] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [grupoVision] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [grupoVision] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'grupoVision', N'ON'
GO
ALTER DATABASE [grupoVision] SET QUERY_STORE = ON
GO
ALTER DATABASE [grupoVision] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [grupoVision]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/22/2024 8:02:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varbinary](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PassWordVerification]    Script Date: 4/22/2024 8:02:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,William>
-- Create date: <04/19/2024,,>
-- Description:	<Encrip,,>
-- =============================================
CREATE PROCEDURE [dbo].[PassWordVerification]
	-- Add the parameters for the stored procedure here
	@passinput varchar(max)
AS
BEGIN
declare @pass varchar(max);
set @pass= (SELECT convert(varchar(1000), (select HASHBYTES('SHA2_256',@passinput)), 2) )
select LOWER(@pass) as pass;
END
GO
/****** Object:  StoredProcedure [dbo].[VerificacionUsuario]    Script Date: 4/22/2024 8:02:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VerificacionUsuario]
	-- Add the parameters for the stored procedure here
	@usuario varchar(50),@pass varchar(50)
AS
BEGIN
select * from Usuario where UserName = @usuario and PassWord = (select HASHBYTES('SHA2_256',@pass));
END
GO
USE [master]
GO
ALTER DATABASE [grupoVision] SET  READ_WRITE 
GO
