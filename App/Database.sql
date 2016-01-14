USE [InvisiblyCachedDatabase]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TableOfData]') AND type in (N'U'))
DROP TABLE [dbo].[TableOfData]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TableOfData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TableOfData](
	[Id] [int] NOT NULL,
	[ActualData] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[TableOfData] ([Id], [ActualData]) VALUES (1, N'SomeDataz')
GO
INSERT [dbo].[TableOfData] ([Id], [ActualData]) VALUES (2, N'SomeMoreDataz')
GO
