USE [WatchListConfig]
GO
/****** Object:  Table [dbo].[MatchingCriteria]    Script Date: 23/02/2022 19:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchingCriteria](
	[matchingMethodId] [int] NULL,
	[returnOnMatchRatio] [int] NULL,
	[dateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatchingMethod]    Script Date: 23/02/2022 19:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchingMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[method] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[MatchingCriteria] ([matchingMethodId], [returnOnMatchRatio], [dateModified]) VALUES (2, 80, CAST(N'2022-02-22T14:51:03.090' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[MatchingMethod] ON 

INSERT [dbo].[MatchingMethod] ([id], [method]) VALUES (1, N'Ratio')
INSERT [dbo].[MatchingMethod] ([id], [method]) VALUES (2, N'Token Ratio')
SET IDENTITY_INSERT [dbo].[MatchingMethod] OFF
GO
