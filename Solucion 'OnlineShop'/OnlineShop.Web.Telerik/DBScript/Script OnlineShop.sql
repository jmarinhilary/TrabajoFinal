/*****************************************************************
SCRIPT PARA PROYECTO WEB DE CURSO CIBERTEC ADVANCED WEB DEVELOPER
CREADO POR : JOHN MARIN HILARY
FECHA : 23/03/2015
VERSION : 1.0
******************************************************************/	
USE master
GO

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

CREATE TABLE dbo.Cliente(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(50),
	[ApellidoP]		NVARCHAR(50),
	[ApellidoM]		NVARCHAR(50),
	[DNI]			NVARCHAR(8),
	[Direccion]		NVARCHAR(100),
	[Ubigeo]		NVARCHAR(100),
	[Telefono]		NVARCHAR(24),
	[Fax]			NVARCHAR(24),
	[Email]			NVARCHAR(60) UNIQUE,
	[FechaNac]		DATETIME,
	[NroTarjeta]	NVARCHAR(100)
)

CREATE TABLE dbo.Empleado(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(50),
	[ApellidoP]		NVARCHAR(50),
	[ApellidoM]		NVARCHAR(50),
	[DNI]			NVARCHAR(50),
	[Direccion]		NVARCHAR(100),
	[Ubigeo]		NVARCHAR(100),
	[Telefono]		NVARCHAR(24),
	[Email]			NVARCHAR(60) UNIQUE,
	[FechaNac]		DATETIME,
	[FechaCon]		DATETIME
)

CREATE TABLE dbo.Categoria(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100)
)


CREATE TABLE dbo.Producto(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100),
	[Descripcion]	NVARCHAR(100),
	[Stock]			INTEGER,
	[IdMarca]		INTEGER,
	[IdCategoria]	INTEGER,
	[PrecioCosto]	MONEY,
	[Descontinuado]	CHAR(1)
)

CREATE TABLE dbo.Producto_Proveedor(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[IdProducto]	INTEGER,
	[IdProveedor]	INTEGER
)

CREATE TABLE dbo.Proveedor(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[NombreCompania]NVARCHAR(100),
	[NombreContacto]NVARCHAR(100),
	[Dirección]		NVARCHAR(100),
	[Ubigeo]		NVARCHAR(100),
	[Telefono]		NVARCHAR(100),
	[Fax]			NVARCHAR(100),
	[Web]			NVARCHAR(100),
	[Email]			NVARCHAR(100)
)

CREATE TABLE dbo.Marca(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100),
	[Descripcion]	NVARCHAR(100),
	[Imagen]		NVARCHAR(100)

)

CREATE TABLE dbo.Pedido(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[IdCliente]		INTEGER,
	[FechaPedido]	DATETIME,
	[FechaExpira]	DATETIME,
	[IdEstadoPed]	INTEGER,
	[IdMedioDePago]	INTEGER,
	[IdEmpleado]	INTEGER
)

CREATE TABLE dbo.Pedido_Producto(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[IdPedido]		INTEGER,
	[IdProducto]	INTEGER,
	[Item]			INTEGER,
	[Cantidad]		INTEGER,
	[Descuento]		MONEY,
	[Precio]		MONEY,
	[Igv]			MONEY,
	[PTotal]		MONEY
)

CREATE TABLE dbo.MediodePago(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100),
	[Descripcion]	NVARCHAR(100)
)

CREATE TABLE dbo.EstadoPedido(
	[Id]			INTEGER IDENTITY PRIMARY KEY,
	[Nombre]		NVARCHAR(100)
)



ALTER TABLE [dbo].[Producto] ADD CONSTRAINT [FK_ProductoIdMarca]
    FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marca] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_ProductoIdMarca] ON [dbo].[Producto] ([IdMarca]);
GO
ALTER TABLE [dbo].[Producto] ADD CONSTRAINT [FK_ProductoIdCategoria]
    FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_ProductoIdCategoria] ON [dbo].[Producto] ([IdCategoria]);
GO
ALTER TABLE [dbo].[Producto_Proveedor] ADD CONSTRAINT [FK_Producto_ProveedorIdProducto]
    FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_Producto_ProveedorIdProducto] ON [dbo].[Producto_Proveedor] ([IdProducto]);
GO

ALTER TABLE [dbo].[Producto_Proveedor] ADD CONSTRAINT [FK_Producto_ProveedorIdProveedor]
    FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedor] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_Producto_ProveedorIdProveedor] ON [dbo].[Producto_Proveedor] ([IdProveedor]);
GO

ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [FK_PedidoIdCliente]
    FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_PedidoIdCliente] ON [dbo].[Pedido] ([IdCliente]);
GO

ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [FK_PedidoIdEstadoPed]
    FOREIGN KEY ([IdEstadoPed]) REFERENCES [dbo].[EstadoPedido] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_PedidoIdEstadoPed] ON [dbo].[Pedido] ([IdEstadoPed]);
GO

ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [FK_PedidoIdMedioDePago]
    FOREIGN KEY ([IdMedioDePago]) REFERENCES [dbo].[MediodePago] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_PedidoIdMedioDePago] ON [dbo].[Pedido] ([IdMedioDePago]);
GO

ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [FK_PedidoIdEmpleado]
    FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleado] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_PedidoIdEmpleado] ON [dbo].[Pedido] ([IdEmpleado]);
GO

ALTER TABLE [dbo].[Pedido_Producto] ADD CONSTRAINT [FK_Pedido_ProductoIdPedido]
    FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_Pedido_ProductoIdPedido] ON [dbo].[Pedido_Producto] ([IdPedido]);
GO

ALTER TABLE [dbo].[Pedido_Producto] ADD CONSTRAINT [FK_Pedido_ProductoIdProducto]
    FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_Pedido_ProductoIdProducto] ON [dbo].[Pedido_Producto] ([IdProducto]);
GO


