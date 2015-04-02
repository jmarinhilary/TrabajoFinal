/*****************************************************************
SCRIPT PARA PROYECTO WEB DE CURSO CIBERTEC ADVANCED WEB DEVELOPER
CREADO POR : JOHN MARIN HILARY
FECHA : 23/03/2015
VERSION : 1.0
******************************************************************/	

IF(EXISTS(SELECT NAME FROM master.DBO.SYSDATABASES WHERE NAME = 'ONLINE_SHOP'))
BEGIN
	ALTER DATABASE [ONLINE_SHOP] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [ONLINE_SHOP] SET ONLINE;
	DROP DATABASE [ONLINE_SHOP];
END

GO


CREATE DATABASE ONLINE_SHOP
GO

USE ONLINE_SHOP
GO

CREATE TABLE Dbo.Cliente(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(50),
	[ApellidoP]		NVARCHAR(50),
	[ApellidoM]		NVARCHAR(50),
	[DNI]			NVARCHAR(8),
	[Direccion]		NVARCHAR(100),
	[Ubigeo]		NVARCHAR(100),
    [Telefono]		NVARCHAR(24),
    [Fax]			NVARCHAR(24),
    [Email]			NVARCHAR(60) NOT NULL
)


CREATE TABLE Dbo.Categoria(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100)
)


CREATE TABLE dbo.Producto(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100),
	[Descripcion]	NVARCHAR(100),
	[Stock]			INTEGER,
	[IdCategoria]	INTEGER,
	[PrecioCosto]	MONEY,
	[Descontinuado]	CHAR(1)
)

CREATE TABLE Dbo.Pedido(

)