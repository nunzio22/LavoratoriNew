USE [Lavoratori]
GO

/****** Object:  Table [dbo].[Lavoratore]    Script Date: 23/10/2019 15:15:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lavoratore](
	[Nome] [nvarchar](50) NOT NULL,
	[Cognome] [nvarchar](50) NOT NULL,
	[DataDiNascita] [datetime] NOT NULL,
	[StipendioAnnuale] [int] NULL,
	[DataDiAssunzione] [datetime] NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Lavoratore_1] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC,
	[Cognome] ASC,
	[DataDiNascita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

