USE [master]
GO
/****** Object:  Database [BaseDatos]    Script Date: 31/10/2023 20:56:42 ******/
CREATE DATABASE [BaseDatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BaseDatos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BaseDatos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BaseDatos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDatos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDatos] SET RECOVERY FULL 
GO
ALTER DATABASE [BaseDatos] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDatos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDatos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaseDatos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BaseDatos', N'ON'
GO
ALTER DATABASE [BaseDatos] SET QUERY_STORE = OFF
GO
USE [BaseDatos]
GO
/****** Object:  Table [dbo].[PEDIDO]    Script Date: 31/10/2023 20:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEDIDO](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[NombreCliente] [varchar](50) NULL,
	[MontoPedido] [int] NULL,
	[Distrito] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarPedido]    Script Date: 31/10/2023 20:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_RegistrarPedido](
    @Fecha DATETIME,
    @NombreCliente VARCHAR(50),
    @MontoPedido INT,
    @Distrito VARCHAR(50),
	@Resultado int output,
	@Mensaje varchar(500) output
)
as
begin
SET @Resultado = 0
	DECLARE @IDPERSONA INT 
	INSERT INTO PEDIDO (Fecha, NombreCliente, MontoPedido, Distrito)
    VALUES (@Fecha, @NombreCliente, @MontoPedido, @Distrito);
	end


GO
USE [master]
GO
ALTER DATABASE [BaseDatos] SET  READ_WRITE 
GO
