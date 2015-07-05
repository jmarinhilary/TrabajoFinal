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

CREATE DATABASE ONLINE_SHOP
GO

USE [ONLINE_SHOP]
GO
 
ALTER DATABASE [ONLINE_SHOP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ONLINE_SHOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ONLINE_SHOP] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET ARITHABORT OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET AUTO_CLOSE ON
GO
ALTER DATABASE [ONLINE_SHOP] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ONLINE_SHOP] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ONLINE_SHOP] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ONLINE_SHOP] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET  ENABLE_BROKER
GO
ALTER DATABASE [ONLINE_SHOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ONLINE_SHOP] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ONLINE_SHOP] SET  READ_WRITE
GO
ALTER DATABASE [ONLINE_SHOP] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ONLINE_SHOP] SET  MULTI_USER
GO
ALTER DATABASE [ONLINE_SHOP] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ONLINE_SHOP] SET DB_CHAINING OFF
GO
USE [ONLINE_SHOP]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompania] [nvarchar](100) NULL,
	[NombreContacto] [nvarchar](100) NULL,
	[Dirección] [nvarchar](100) NULL,
	[Ubigeo] [nvarchar](100) NULL,
	[Telefono] [nvarchar](100) NULL,
	[Fax] [nvarchar](100) NULL,
	[Web] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoPedido]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoPedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadoPedido] ON
INSERT [dbo].[EstadoPedido] ([Id], [Nombre]) VALUES (1, N'Aceptado')
INSERT [dbo].[EstadoPedido] ([Id], [Nombre]) VALUES (2, N'Cancelado')
SET IDENTITY_INSERT [dbo].[EstadoPedido] OFF
/****** Object:  Table [dbo].[Empleado]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[ApellidoP] [nvarchar](50) NULL,
	[ApellidoM] [nvarchar](50) NULL,
	[DNI] [nvarchar](50) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Ubigeo] [nvarchar](100) NULL,
	[Telefono] [nvarchar](24) NULL,
	[Email] [nvarchar](60) NULL,
	[FechaNac] [datetime] NULL,
	[FechaCon] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[ApellidoP] [nvarchar](50) NULL,
	[ApellidoM] [nvarchar](50) NULL,
	[DNI] [nvarchar](8) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Ubigeo] [nvarchar](100) NULL,
	[Telefono] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[Email] [nvarchar](60) NULL,
	[FechaNac] [datetime] NULL,
	[NroTarjeta] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'LAPTOPS')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'PC''S')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'SERVIDORES')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
/****** Object:  Table [dbo].[MediodePago]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediodePago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Imagen] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marca] ON
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (1, N'TOSHIBA', N'Marca Japonesa excelente', NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (2, N'ASUS', NULL, NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (3, N'DELL', NULL, NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (4, N'LENOVO', NULL, NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (5, N'HP', NULL, NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (6, N'SAMSUNG', NULL, NULL)
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (7, N'MSI', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Marca] OFF
/****** Object:  Table [dbo].[Producto]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](400) NULL,
	[Descripcion] [nvarchar](400) NULL,
	[Stock] [int] NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[PrecioCosto] [money] NULL,
	[Descontinuado] [bit] NULL,
	[Sku] [varchar](10) NULL,
 CONSTRAINT [PK__Producto__3214EC07D12376B8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IFK_ProductoIdCategoria] ON [dbo].[Producto] 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_ProductoIdMarca] ON [dbo].[Producto] 
(
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (1, N'
Laptop HP Compaq 15-H040LA AMD Dual Core E1 2100 1.0GHz', NULL, 5, NULL, NULL, 1099.0000, 0, N'106060')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (2, N'Laptop HP 15-G037CY AMD E1-2100 Dual Core 1.0GHz, RAM 4GB. HDD 500, DVD, 15.6"HD, Win 8.1', NULL, 8, NULL, NULL, 1299.0000, 0, N'107280')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (3, N'Laptop Toshiba Satellite C55-B5115KM Intel Dual Core N2840 2.16GHz, RAM 4GB, HDD 500GB, DVD, 15.6" HD', NULL, 10, NULL, NULL, 1399.0000, 0, N'107101')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (4, N'Laptop Toshiba Satellite L55-B5267RM Intel Dual Core N2830 2.16GHz', NULL, 50, NULL, NULL, 1399.0000, 0, N'106037')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (5, N'Convertible HP Pavilion 11-h020la x2 Intel® Celeron® N2910 1.6GHz, RAM 4GB, SSD 64GB, 2 Camaras, LED 11.6 HD Táctil, Win 8', N'<ul><li><span style="margin:0px;padding:0px;">Intel&reg; Celeron&reg; N2910</span>&nbsp;(1,6 GHz)</li></ul>', 108, 5, 1, 1899.0000, 0, N'170222')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (6, N'Laptop HP Pavilion TouchSmart 15T P100-Y2NF Intel Core i7-4510U 2.0 GHz, RAM 12GB, HDD 1TB , DVD, Video 2GB , 15.6" Full HD Touch, Windows 8.1 Neon Purple', N'<ul><li>Intel Core i7-4510U 2.0 GHz (3.1GHz c/TB)</li></ul>', 120, 5, 1, 3699.0000, 0, N'107274')
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (7, N'Dell WorkStation Precision M4800 Intel Core i7 4800MQ 2.7GHz(vPro), RAM 16GB, HDD 1TB , NVidia Quadro K2100M 2GB, DVD, 15.6" Full HD UltraSharp, Win7 Pro', N'<ul><li>Intel Core i7 4800MQ 2.7GHz (3.7 GHz)</li><li>Pantalla LED 15.6" Full HD (1920x1080) UltraSharp</li></ul>', 112, 3, 1, 7599.0000, 0, N'107343')
SET IDENTITY_INSERT [dbo].[Producto] OFF
/****** Object:  Table [dbo].[Pedido]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[FechaPedido] [datetime] NULL,
	[FechaExpira] [datetime] NULL,
	[IdEstadoPed] [int] NULL,
	[IdMedioDePago] [int] NULL,
	[IdEmpleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_PedidoIdCliente] ON [dbo].[Pedido] 
(
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_PedidoIdEmpleado] ON [dbo].[Pedido] 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_PedidoIdEstadoPed] ON [dbo].[Pedido] 
(
	[IdEstadoPed] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_PedidoIdMedioDePago] ON [dbo].[Pedido] 
(
	[IdMedioDePago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Producto_Proveedor]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_Producto_ProveedorIdProducto] ON [dbo].[Producto_Proveedor] 
(
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_Producto_ProveedorIdProveedor] ON [dbo].[Producto_Proveedor] 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido_Producto]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NULL,
	[IdProducto] [int] NULL,
	[Item] [int] NULL,
	[Cantidad] [int] NULL,
	[Descuento] [money] NULL,
	[Precio] [money] NULL,
	[Igv] [money] NULL,
	[PTotal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_Pedido_ProductoIdPedido] ON [dbo].[Pedido_Producto] 
(
	[IdPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IFK_Pedido_ProductoIdProducto] ON [dbo].[Pedido_Producto] 
(
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Imagenes]    Script Date: 07/04/2015 21:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Imagenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [varchar](400) NULL,
	[IdProducto] [int] NULL,
	[Estado] [varchar](1) NULL,
	[Tipo] [varchar](1) NULL,
 CONSTRAINT [PK_Imagenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Imagenes] ON
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (1, N'~/Imagenes/jgh_1.jpg', 1, N'A', N'P')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (2, N'~/Imagenes/rgbrsh.jpg', 1, N'A', N'C')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (3, N'~/Imagenes/hp-15z-g100-y2pp_2_1.jpg', 2, N'A', N'P')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (4, N'~/Imagenes/34535_1_1.jpg', 3, N'A', N'P')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (5, N'~/Imagenes/24235234234_1_.jpg', 4, N'A', N'P')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (6, N'~/Imagenes/pavilion-11-h020la-x2.jpg', 5, N'A', N'P')
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (7, N'~/Imagenes/touchsmart-15t-p100_3_1.jpg', 6, N'A', N'P')
SET IDENTITY_INSERT [dbo].[Imagenes] OFF
/****** Object:  ForeignKey [FK_ProductoIdCategoria]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_ProductoIdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_ProductoIdCategoria]
GO
/****** Object:  ForeignKey [FK_ProductoIdMarca]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_ProductoIdMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_ProductoIdMarca]
GO
/****** Object:  ForeignKey [FK_PedidoIdCliente]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdCliente]
GO
/****** Object:  ForeignKey [FK_PedidoIdEmpleado]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdEmpleado]
GO
/****** Object:  ForeignKey [FK_PedidoIdEstadoPed]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdEstadoPed] FOREIGN KEY([IdEstadoPed])
REFERENCES [dbo].[EstadoPedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdEstadoPed]
GO
/****** Object:  ForeignKey [FK_PedidoIdMedioDePago]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdMedioDePago] FOREIGN KEY([IdMedioDePago])
REFERENCES [dbo].[MediodePago] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdMedioDePago]
GO
/****** Object:  ForeignKey [FK_Producto_ProveedorIdProducto]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Producto_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ProveedorIdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Producto_Proveedor] CHECK CONSTRAINT [FK_Producto_ProveedorIdProducto]
GO
/****** Object:  ForeignKey [FK_Producto_ProveedorIdProveedor]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Producto_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ProveedorIdProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Producto_Proveedor] CHECK CONSTRAINT [FK_Producto_ProveedorIdProveedor]
GO
/****** Object:  ForeignKey [FK_Pedido_ProductoIdPedido]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_ProductoIdPedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Producto] CHECK CONSTRAINT [FK_Pedido_ProductoIdPedido]
GO
/****** Object:  ForeignKey [FK_Pedido_ProductoIdProducto]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Pedido_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_ProductoIdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Producto] CHECK CONSTRAINT [FK_Pedido_ProductoIdProducto]
GO
/****** Object:  ForeignKey [FK_Imagenes_Producto]    Script Date: 07/04/2015 21:33:12 ******/
ALTER TABLE [dbo].[Imagenes]  WITH CHECK ADD  CONSTRAINT [FK_Imagenes_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Imagenes] CHECK CONSTRAINT [FK_Imagenes_Producto]
GO
