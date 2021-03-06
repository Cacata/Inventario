USE [Inventario]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/7/2018 12:30:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Precio] [money] NULL,
	[IDProductoUbicacion] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoUbicacion]    Script Date: 2/7/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoUbicacion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDProducto] [int] NOT NULL,
	[IDUbicacion] [int] NOT NULL,
	[Sucursal] [varchar](100) NULL,
 CONSTRAINT [PK_ProductoUbicacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 2/7/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[IDProductoUbicacion] [int] NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductoUbicacion]  WITH CHECK ADD  CONSTRAINT [FK_ProductoUbicacion_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[Producto] ([ID])
GO
ALTER TABLE [dbo].[ProductoUbicacion] CHECK CONSTRAINT [FK_ProductoUbicacion_Producto]
GO
ALTER TABLE [dbo].[ProductoUbicacion]  WITH CHECK ADD  CONSTRAINT [FK_ProductoUbicacion_Ubicacion] FOREIGN KEY([IDUbicacion])
REFERENCES [dbo].[Ubicacion] ([ID])
GO
ALTER TABLE [dbo].[ProductoUbicacion] CHECK CONSTRAINT [FK_ProductoUbicacion_Ubicacion]
GO
