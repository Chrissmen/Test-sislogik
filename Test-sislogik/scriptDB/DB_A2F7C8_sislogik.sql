USE [master]
GO
/****** Object:  Database [DB_A2F7C8_sislogik]    Script Date: 16/03/2021 08:59:15 p. m. ******/
CREATE DATABASE [DB_A2F7C8_sislogik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A2F7C8_sislogik_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DB_A2F7C8_sislogik_DATA.mdf' , SIZE = 4096KB , MAXSIZE = 204800KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A2F7C8_sislogik_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DB_A2F7C8_sislogik_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A2F7C8_sislogik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DB_A2F7C8_sislogik]
GO
/****** Object:  Table [dbo].[Tbl_Empleados]    Script Date: 16/03/2021 08:59:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Empleados](
	[nidEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[cTipo] [char](10) NULL,
	[nSeccion] [int] NULL,
	[cNombres] [char](100) NULL,
	[cApellidos] [char](100) NULL,
	[nHoras] [decimal](18, 0) NULL,
	[mImporte] [money] NULL,
	[nidStatus] [int] NULL,
 CONSTRAINT [PK_Tbl_Empleados] PRIMARY KEY CLUSTERED 
(
	[nidEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_EmpleadosTMP2]    Script Date: 16/03/2021 08:59:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_EmpleadosTMP2](
	[nidEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[cTipo] [char](10) NULL,
	[nSeccion] [int] NULL,
	[cNombres] [char](100) NULL,
	[cApellidos] [char](100) NULL,
	[nHoras] [decimal](18, 2) NULL,
	[mImporte] [money] NULL,
	[nidStatus] [int] NULL,
 CONSTRAINT [PK_Tbl_EmpleadosTMP2] PRIMARY KEY CLUSTERED 
(
	[nidEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Empleados] ON 

INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (45, N'Cajero    ', 1, N'Luis Antonio                                                                                        ', N'Gaona                                                                                               ', CAST(20 AS Decimal(18, 0)), 9550.8000, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (46, N'Repositor ', 2, N'Laura Is                                                                                            ', N'Gaona Robledo                                                                                       ', CAST(20 AS Decimal(18, 0)), 9500.5000, 0)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (47, N'cajero    ', 4, N'José Luis                                                                                           ', N'Carteaux Lizzi                                                                                      ', CAST(20 AS Decimal(18, 0)), 500.5000, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (48, N'cajero    ', 2, N'Eli Abigailb                                                                                        ', N'Blackeberg Lorsenb                                                                                  ', CAST(50 AS Decimal(18, 0)), 1000.0000, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (49, N'repositor ', 2, N'Oskar Owen                                                                                          ', N'Lindqvist Torn                                                                                      ', CAST(89 AS Decimal(18, 0)), 456324.9800, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (50, N'repositor ', 4, N'Amado Máximo                                                                                        ', N'Budo Kerner                                                                                         ', CAST(100 AS Decimal(18, 0)), 22000.5000, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (51, N'supervisor', 0, N'Nestor Saúl                                                                                         ', N'Alfonso Sin                                                                                         ', CAST(10 AS Decimal(18, 0)), 5000.0000, 1)
INSERT [dbo].[Tbl_Empleados] ([nidEmpleado], [cTipo], [nSeccion], [cNombres], [cApellidos], [nHoras], [mImporte], [nidStatus]) VALUES (52, N'cajero    ', 2, N'Eli Abigail                                                                                         ', N'Blackeberg Lorsen                                                                                   ', CAST(20 AS Decimal(18, 0)), 450.0000, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Empleados] OFF
/****** Object:  StoredProcedure [dbo].[SP_Alta_Confirmacion_XML]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<C MENESES>
-- Create date: <16/03/2021>
-- Description:	<STORED CONFIRMACION DE COPIA DE TABLA TEMPORAL A TABLA PRODUCCIÓN>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Alta_Confirmacion_XML]

AS

declare @cTipo char(10), @nSeccion int,@cNombres char(100),@cApellidos char(100),@nHoras decimal(18,2),
@mImporte money, @nidStatus int;

DECLARE ClientCursor CURSOR 
FOR
--EXEC SP_Alta_EmpleadosFunc @cTipo, @nSeccion, @cNombres, @cApellidos, @nHoras,@mImporte ,@nidStatus 
--INSERT INTO Tbl_Empleados(cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte, nidStatus)
--SELECT  @cTipo=cTipo, @nSeccion= nSeccion , @cNombres=cNombres, @cApellidos=cApellidos, @nHoras=nHoras, @mImporte=mImporte, @nidStatus=nidStatus 
SELECT cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte, nidStatus
FROM Tbl_EmpleadosTMP2

OPEN ClientCursor;
FETCH NEXT FROM ClientCursor INTO @cTipo, @nSeccion, @cNombres, @cApellidos, @nHoras,@mImporte ,@nidStatus;

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC SP_Alta_EmpleadosFunc @cTipo, @nSeccion, @cNombres, @cApellidos, @nHoras,@mImporte ,@nidStatus 

    FETCH NEXT FROM ClientCursor INTO @cTipo, @nSeccion, @cNombres, @cApellidos, @nHoras,@mImporte ,@nidStatus;


	

END
CLOSE ClientCursor
DEALLOCATE ClientCursor
DELETE Tbl_EmpleadosTMP2
GO
/****** Object:  StoredProcedure [dbo].[SP_Alta_Empleados]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<C,MENESES>
-- Create date: <14/03/21>
-- Description:	<Alta de empleados>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Alta_Empleados]
	(@cTipo	[char](10),
	 @nSeccion 	[int],
	 @cNombres 	[char](100),
	 @cApellidos 	[char](100),
	 @nHoras 	[decimal],
	 @mImporte 	[money],
	 @nidStatus 	[int])

AS INSERT INTO [Tbl_Empleados] 
	 ( [cTipo],
	 [nSeccion],
	 [cNombres],
	 [cApellidos],
	 [nHoras],
	 [mImporte],
	 [nidStatus]) 
 
VALUES 
	( @cTipo,
	 @nSeccion,
	 @cNombres,
	 @cApellidos,
	 @nHoras,
	 @mImporte,
	 @nidStatus)
GO
/****** Object:  StoredProcedure [dbo].[SP_Alta_Empleados_XML]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<C MENESES>
-- Create date: <15/03/2021>
-- Description:	<STORED QUE RECIBE XML E INSERTA EMPLEADOS>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Alta_Empleados_XML]
@xml XML
AS
BEGIN


INSERT INTO Tbl_EmpleadosTMP2(cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte, nidStatus)
-- EXEC DBO.SP_Alta_EmpleadosFunc  cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte,nidStatus
	  
      SELECT
      empleados.empleado.value('@tipo','CHAR(10)') AS cTipo, 
	  empleados.empleado.value('@seccion','int') AS nSeccion, 
      empleados.empleado.value('(nombres/text())[1]','CHAR(100)') AS cNombres,
      empleados.empleado.value('(apellidos/text())[1]','CHAR(100)') AS cApellidos,
	  empleados.empleado.value('(horas/text())[1]','Decimal') AS nHoras,
	  empleados.empleado.value('(importe/text())[1]','Money') AS mImporte,
	  1 as nidStatus
      FROM
      @xml.nodes('/empleados/empleado')AS empleados(empleado)

	 exec SP_Alta_Confirmacion_XML
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Alta_EmpleadosFunc]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<C,MENESES>
-- Create date: <14/03/21>
-- Description:	<Alta de empleados>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Alta_EmpleadosFunc]
	(@cTipo	[char](10),
	 @nSeccion 	[int],
	 @cNombres 	[char](100),
	 @cApellidos 	[char](100),
	 @nHoras 	[decimal],
	 @mImporte 	[money],
	 @nidStatus 	[int])

AS
IF NOT EXISTS (select 1 cNombres from Tbl_Empleados where (cNombres = @cNombres AND cApellidos = @cApellidos))  
BEGIN
INSERT INTO [Tbl_Empleados] 
	 ( [cTipo],
	 [nSeccion],
	 [cNombres],
	 [cApellidos],
	 [nHoras],
	 [mImporte],
	 [nidStatus]) 
 
VALUES 
	( @cTipo,
	 @nSeccion,
	 @cNombres,
	 @cApellidos,
	 @nHoras,
	 @mImporte,
	 @nidStatus)
END
ELSE IF EXISTS (select 1 cNombres from Tbl_Empleados where (cNombres = @cNombres AND cApellidos = @cApellidos))  
BEGIN

Declare @nidEmpleado int
Select @nidEmpleado = nidEmpleado from Tbl_Empleados
Where cNombres = @cNombres AND cApellidos = @cApellidos



UPDATE [Tbl_Empleados] 
SET  [cTipo] = @cTipo,
[nSeccion] = @nSeccion,
[cNombres] = @cNombres,
[cApellidos] = @cApellidos,
[nHoras] = @nHoras,
[mImporte] = @mImporte,
[nidStatus] = @nidStatus

WHERE 
	([nidEmpleado] = @nidEmpleado)
END



GO
/****** Object:  StoredProcedure [dbo].[SP_Borrado_Logico_Empleados]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_Borrado_Logico_Empleados]
(@nidEmpleado 	[int],
 @nidStatus 	[int])
	
AS UPDATE [Tbl_Empleados] 
SET  [nidStatus]	 = @nidStatus 

WHERE 
	( [nidEmpleado]	 = @nidEmpleado)
GO
/****** Object:  StoredProcedure [dbo].[SP_Edicion_Empleados]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Edicion_Empleados]
	(@nidEmpleado [int],
	@cTipo	[char](10),
	 @nSeccion 	[int],
	 @cNombres 	[char](100),
	 @cApellidos 	[char](100),
	 @nHoras 	[decimal],
	 @mImporte 	[money],
	 @nidStatus 	[int])
	
AS UPDATE [Tbl_Empleados] 
SET  [cTipo] = @cTipo,
[nSeccion] = @nSeccion,
[cNombres] = @cNombres,
[cApellidos] = @cApellidos,
[nHoras] = @nHoras,
[mImporte] = @mImporte,
[nidStatus] = @nidStatus

WHERE 
	( [nidEmpleado]	 = @nidEmpleado)
GO
/****** Object:  StoredProcedure [dbo].[SP_XMLDATADROP]    Script Date: 16/03/2021 08:59:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<C MENESES>
-- Create date: <15/03/2021>
-- Description:	<STORED QUE RECIBE XML E INSERTA EMPLEADOS>
-- =============================================
CREATE PROCEDURE [dbo].[SP_XMLDATADROP]

AS
BEGIN


--INSERT INTO Tbl_Empleados(cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte, nidStatus)
EXEC DBO.SP_Alta_EmpleadosFunc  cTipo, 2, cNombres, cApellidos, 5, 100,1
	  
SELECT cTipo, CONVERT(NVARCHAR(10),CONVERT(INT,nSeccion)) AS nSeccion1, cNombres, cApellidos, CONVERT(VARCHAR(30),CONVERT(DECIMAL(18,0),nHoras))as nHoras1, convert(VARCHAR(30),CONVERT(MONEY, mImporte)) as mImporte1,CONVERT(INT,nidStatus) AS nidStatus1 
FROM Tbl_EmpleadosTMP


END
GO
USE [master]
GO
ALTER DATABASE [DB_A2F7C8_sislogik] SET  READ_WRITE 
GO
