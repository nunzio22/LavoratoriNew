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
INSERT INTO Lavoratore(Nome, Cognome, DataDiNascita, StipendioAnnuale, DataDiAssunzione, Tipo)
VALUES ('Nunzio','Sava',convert(datetime,'18-06-12 10:34:09 PM',5),10000,NULL,2);

INSERT INTO Lavoratore(Nome, Cognome, DataDiNascita, StipendioAnnuale, DataDiAssunzione, Tipo)
VALUES ('Marco','Zanca',convert(datetime,'02-05-01 10:34:09 PM',5),50000,convert(datetime,'17-05-12 10:34:09 PM',5),1);

INSERT INTO Lavoratore(Nome, Cognome, DataDiNascita, StipendioAnnuale, DataDiAssunzione, Tipo)
VALUES ('Pippo','Baudo',convert(datetime,'18-06-12 10:34:09 PM',5),1000000,NULL,2);

INSERT INTO Lavoratore(Nome, Cognome, DataDiNascita, StipendioAnnuale, DataDiAssunzione, Tipo)
VALUES ('Christiano','Ronaldo',convert(datetime,'02-05-01 10:34:09 PM',5),500000000000000,convert(datetime,'17-05-12 10:34:09 PM',5),1);
GO