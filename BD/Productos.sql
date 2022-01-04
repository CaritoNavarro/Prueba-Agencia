USE [PruebaAgencia]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 3/01/2022 1:50:29 p. m. ******/
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


