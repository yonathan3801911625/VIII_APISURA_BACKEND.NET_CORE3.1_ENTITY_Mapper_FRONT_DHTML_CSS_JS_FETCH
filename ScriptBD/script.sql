USE [DBSeguros]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 11/11/2022 5:29:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] NOT NULL,
	[nombrePais] [nvarchar](50) NOT NULL,
	[subContiente] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliza](
	[idPoliza] [int] NOT NULL,
	[fechaVigenciaPoliza] [datetime] NOT NULL,
	[idVehiculoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Poliza] PRIMARY KEY CLUSTERED 
(
	[idPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] NOT NULL,
	[nombreProducto] [nvarchar](50) NOT NULL,
	[tipoProducto] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoPais]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoPais](
	[idProductoPais] [int] NOT NULL,
	[idPais] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
 CONSTRAINT [PK_ProductoPais] PRIMARY KEY CLUSTERED 
(
	[idProductoPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoPoliza]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoPoliza](
	[idProductoPoliza] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[idPoliza] [int] NOT NULL,
 CONSTRAINT [PK_ProductoPoliza] PRIMARY KEY CLUSTERED 
(
	[idProductoPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguridad]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguridad](
	[idSeguridad] [int] NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[nombreUsuario] [nvarchar](100) NOT NULL,
	[contrasena] [nvarchar](50) NOT NULL,
	[rol] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Seguridad] PRIMARY KEY CLUSTERED 
(
	[idSeguridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] NOT NULL,
	[numIdentificacionUsuario] [nvarchar](15) NOT NULL,
	[tipoDocUsuario] [nvarchar](15) NOT NULL,
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[apellidosUsuario] [nvarchar](50) NOT NULL,
	[loginUsuario] [nvarchar](50) NOT NULL,
	[passwordUsuario] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[idVehiculo] [int] NOT NULL,
	[placaVehiculo] [nvarchar](20) NOT NULL,
	[marcaVehiculo] [nvarchar](20) NOT NULL,
	[vinVehiculo] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[idVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiculoUsuario]    Script Date: 11/11/2022 5:29:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiculoUsuario](
	[idVehiculoUsuario] [int] NOT NULL,
	[idVehiculo] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_VehiculoUsuario] PRIMARY KEY CLUSTERED 
(
	[idVehiculoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_VehiculoUsuario] FOREIGN KEY([idVehiculoUsuario])
REFERENCES [dbo].[VehiculoUsuario] ([idVehiculoUsuario])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_VehiculoUsuario]
GO
ALTER TABLE [dbo].[ProductoPais]  WITH CHECK ADD  CONSTRAINT [FK_Pais_ProductoPais] FOREIGN KEY([idPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[ProductoPais] CHECK CONSTRAINT [FK_Pais_ProductoPais]
GO
ALTER TABLE [dbo].[ProductoPais]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPais_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[ProductoPais] CHECK CONSTRAINT [FK_ProductoPais_Producto]
GO
ALTER TABLE [dbo].[ProductoPoliza]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPoliza_Poliza] FOREIGN KEY([idPoliza])
REFERENCES [dbo].[Poliza] ([idPoliza])
GO
ALTER TABLE [dbo].[ProductoPoliza] CHECK CONSTRAINT [FK_ProductoPoliza_Poliza]
GO
ALTER TABLE [dbo].[ProductoPoliza]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPoliza_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[ProductoPoliza] CHECK CONSTRAINT [FK_ProductoPoliza_Producto]
GO
ALTER TABLE [dbo].[VehiculoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_VehiculoUsuario_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[VehiculoUsuario] CHECK CONSTRAINT [FK_VehiculoUsuario_Usuario]
GO
ALTER TABLE [dbo].[VehiculoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_VehiculoUsuario_Vehiculo] FOREIGN KEY([idVehiculo])
REFERENCES [dbo].[Vehiculo] ([idVehiculo])
GO
ALTER TABLE [dbo].[VehiculoUsuario] CHECK CONSTRAINT [FK_VehiculoUsuario_Vehiculo]
GO
