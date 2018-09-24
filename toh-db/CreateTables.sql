USE [TourOfHeroes]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 16/07/2018 11:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HeroeId] [int] NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CreditCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Heroes]    Script Date: 16/07/2018 11:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heroes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Heroes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CreditCards] ON 

INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (1, 1, N'498-49483938-90')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (2, 2, N'595-40494030-78')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (3, 3, N'589-39484303-89')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (4, 4, N'498-34849439-09')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (5, 5, N'890-39484939-89')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (6, 6, N'789-39484940-88')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (7, 7, N'789-39494903-78')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (8, 8, N'888-40495040-90')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (9, 9, N'555-58939389-09')
INSERT [dbo].[CreditCards] ([Id], [HeroeId], [Number]) VALUES (10, 10, N'898-49494589-01')
SET IDENTITY_INSERT [dbo].[CreditCards] OFF
SET IDENTITY_INSERT [dbo].[Heroes] ON 

INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (1, N'Mr. Nice')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (2, N'Narco')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (3, N'Bombasto')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (4, N'Celeritas')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (5, N'Magneta')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (6, N'RubberMan')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (7, N'Dynama')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (8, N'Dr. IQ')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (9, N'Magma')
INSERT [dbo].[Heroes] ([Id], [Name]) VALUES (10, N'Tornado')
SET IDENTITY_INSERT [dbo].[Heroes] OFF
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Heroes] FOREIGN KEY([HeroeId])
REFERENCES [dbo].[Heroes] ([Id])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Heroes]
GO
/****** Object:  StoredProcedure [dbo].[SearchHeroes]    Script Date: 16/07/2018 11:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchHeroes]
	-- Add the parameters for the stored procedure here
	@SearchTerm VARCHAR(50)
AS
BEGIN
	DECLARE @query VARCHAR(100)
	SET @query = 'SELECT * FROM dbo.Heroes WHERE name LIKE ''%' + @SearchTerm + '%'''
	Exec(@query)
END
GO