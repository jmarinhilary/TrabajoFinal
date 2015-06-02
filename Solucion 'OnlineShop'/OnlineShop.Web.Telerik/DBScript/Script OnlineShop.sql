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


CREATE DATABASE [ONLINE_SHOP]
 
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
ALTER DATABASE [ONLINE_SHOP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ONLINE_SHOP] SET  MULTI_USER 
GO
ALTER DATABASE [ONLINE_SHOP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ONLINE_SHOP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ONLINE_SHOP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ONLINE_SHOP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ONLINE_SHOP]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 25/04/2015 11:31:48 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EstadoPedido]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Imagenes]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediodePago]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pedido_Producto]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto_Proveedor]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 25/04/2015 11:31:49 p.m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

GO
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'LAPTOPS')
GO
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'PC''S')
GO
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'SERVIDORES')
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Imagenes] ON 

GO
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (1, N'~/Imagenes/jgh_1.jpg', 1, N'A', N'P')
GO
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (2, N'~/Imagenes/rgbrsh.jpg', 1, N'A', N'C')
GO
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (3, N'~/Imagenes/hp-15z-g100-y2pp_2_1.jpg', 2, N'A', N'P')
GO
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (4, N'~/Imagenes/34535_1_1.jpg', 3, N'A', N'P')
GO
INSERT [dbo].[Imagenes] ([Id], [Ruta], [IdProducto], [Estado], [Tipo]) VALUES (5, N'~/Imagenes/24235234234_1_.jpg', 4, N'A', N'P')
GO
SET IDENTITY_INSERT [dbo].[Imagenes] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (1, N'TOSHIBA', NULL, NULL)
GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (2, N'ASUS', NULL, NULL)
GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (3, N'DELL', NULL, NULL)
GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (4, N'LENOVO', NULL, NULL)
GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (5, N'HP', NULL, NULL)
GO
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion], [Imagen]) VALUES (6, N'SAMSUNG', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (1, N'
Laptop HP Compaq 15-H040LA AMD Dual Core E1 2100 1.0GHz', NULL, 5, NULL, NULL, 1099.0000, NULL, N'106060')
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (2, N'Laptop HP 15-G037CY AMD E1-2100 Dual Core 1.0GHz, RAM 4GB. HDD 500, DVD, 15.6"HD, Win 8.1', NULL, 8, NULL, NULL, 1299.0000, NULL, N'107280')
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (3, N'Laptop Toshiba Satellite C55-B5115KM Intel Dual Core N2840 2.16GHz, RAM 4GB, HDD 500GB, DVD, 15.6" HD', NULL, 10, NULL, NULL, 1399.0000, NULL, N'107101')
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Stock], [IdMarca], [IdCategoria], [PrecioCosto], [Descontinuado], [Sku]) VALUES (4, N'Laptop Toshiba Satellite L55-B5267RM Intel Dual Core N2830 2.16GHz', NULL, 50, NULL, NULL, 1399.0000, NULL, N'106037')
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Cliente__A9D10534ED82BDEB]    Script Date: 25/04/2015 11:31:49 p.m. ******/
ALTER TABLE [dbo].[Cliente] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Empleado__A9D105343353D9FE]    Script Date: 25/04/2015 11:31:49 p.m. ******/
ALTER TABLE [dbo].[Empleado] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PedidoIdCliente]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_PedidoIdCliente] ON [dbo].[Pedido]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PedidoIdEmpleado]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_PedidoIdEmpleado] ON [dbo].[Pedido]
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PedidoIdEstadoPed]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_PedidoIdEstadoPed] ON [dbo].[Pedido]
(
	[IdEstadoPed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PedidoIdMedioDePago]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_PedidoIdMedioDePago] ON [dbo].[Pedido]
(
	[IdMedioDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_Pedido_ProductoIdPedido]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_Pedido_ProductoIdPedido] ON [dbo].[Pedido_Producto]
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_Pedido_ProductoIdProducto]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_Pedido_ProductoIdProducto] ON [dbo].[Pedido_Producto]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_ProductoIdCategoria]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_ProductoIdCategoria] ON [dbo].[Producto]
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_ProductoIdMarca]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_ProductoIdMarca] ON [dbo].[Producto]
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_Producto_ProveedorIdProducto]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_Producto_ProveedorIdProducto] ON [dbo].[Producto_Proveedor]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_Producto_ProveedorIdProveedor]    Script Date: 25/04/2015 11:31:49 p.m. ******/
CREATE NONCLUSTERED INDEX [IFK_Producto_ProveedorIdProveedor] ON [dbo].[Producto_Proveedor]
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Imagenes]  WITH CHECK ADD  CONSTRAINT [FK_Imagenes_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Imagenes] CHECK CONSTRAINT [FK_Imagenes_Producto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdCliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdEmpleado]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdEstadoPed] FOREIGN KEY([IdEstadoPed])
REFERENCES [dbo].[EstadoPedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdEstadoPed]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PedidoIdMedioDePago] FOREIGN KEY([IdMedioDePago])
REFERENCES [dbo].[MediodePago] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PedidoIdMedioDePago]
GO
ALTER TABLE [dbo].[Pedido_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_ProductoIdPedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Producto] CHECK CONSTRAINT [FK_Pedido_ProductoIdPedido]
GO
ALTER TABLE [dbo].[Pedido_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_ProductoIdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Producto] CHECK CONSTRAINT [FK_Pedido_ProductoIdProducto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_ProductoIdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_ProductoIdCategoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_ProductoIdMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_ProductoIdMarca]
GO
ALTER TABLE [dbo].[Producto_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ProveedorIdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Producto_Proveedor] CHECK CONSTRAINT [FK_Producto_ProveedorIdProducto]
GO
ALTER TABLE [dbo].[Producto_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ProveedorIdProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Producto_Proveedor] CHECK CONSTRAINT [FK_Producto_ProveedorIdProveedor]
GO
USE [master]
GO
ALTER DATABASE [ONLINE_SHOP] SET  READ_WRITE 
GO
