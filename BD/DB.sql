USE [PruebaAgencia]
GO
/****** Object:  User [PruebaAgencia]    Script Date: 3/01/2022 2:06:15 p. m. ******/
CREATE USER [PruebaAgencia] FOR LOGIN [PruebaAgencia] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PruebaAgencia]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 3/01/2022 2:06:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [bigint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[ValorTotal] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 3/01/2022 2:06:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Stock] [bigint] NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
	[Descripcion] [nchar](20) NOT NULL,
	[Valor] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 
GO
INSERT [dbo].[Pedido] ([IdPedido], [Id], [IdProducto], [Cantidad], [ValorTotal]) VALUES (2, 2, 1, 3, CAST(305973 AS Numeric(18, 0)))
GO
INSERT [dbo].[Pedido] ([IdPedido], [Id], [IdProducto], [Cantidad], [ValorTotal]) VALUES (1, 3, 2, 1, CAST(305973 AS Numeric(18, 0)))
GO
INSERT [dbo].[Pedido] ([IdPedido], [Id], [IdProducto], [Cantidad], [ValorTotal]) VALUES (1, 4, 5, 2, CAST(171200 AS Numeric(18, 0)))
GO
INSERT [dbo].[Pedido] ([IdPedido], [Id], [IdProducto], [Cantidad], [ValorTotal]) VALUES (6, 5, 5, 4, CAST(85600 AS Numeric(18, 0)))
GO
INSERT [dbo].[Pedido] ([IdPedido], [Id], [IdProducto], [Cantidad], [ValorTotal]) VALUES (6, 6, 1, 6, CAST(611946 AS Numeric(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([IdProducto], [Stock], [Nombre], [Descripcion], [Valor]) VALUES (1, 10, N'Poison Girl de Dior ', N'Poison Girl de Dior ', CAST(101991 AS Numeric(18, 0)))
GO
INSERT [dbo].[Productos] ([IdProducto], [Stock], [Nombre], [Descripcion], [Valor]) VALUES (2, 5, N'Rose vents de Louis ', N'Rose vents de Louis ', CAST(150000 AS Numeric(18, 0)))
GO
INSERT [dbo].[Productos] ([IdProducto], [Stock], [Nombre], [Descripcion], [Valor]) VALUES (3, 2, N'Chloé, de Chloé     ', N'Chloé, de Chloé     ', CAST(98500 AS Numeric(18, 0)))
GO
INSERT [dbo].[Productos] ([IdProducto], [Stock], [Nombre], [Descripcion], [Valor]) VALUES (4, 8, N'Guilty, de Gucci    ', N'Guilty, de Gucci    ', CAST(280000 AS Numeric(18, 0)))
GO
INSERT [dbo].[Productos] ([IdProducto], [Stock], [Nombre], [Descripcion], [Valor]) VALUES (5, 6, N'Flower, de Kenzo    ', N'Flower, de Kenzo    ', CAST(85600 AS Numeric(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
