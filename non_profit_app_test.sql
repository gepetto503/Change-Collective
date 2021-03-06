USE [non_profit_app_test]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[banks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[balance] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[organizations]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[website] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[bio] [text] NULL,
	[large_bio] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[organizations_banks_users]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizations_banks_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[bank_id] [int] NULL,
	[organization_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[organizations_categories]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizations_categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[organization_id] [int] NULL,
	[category_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[organizations_users]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizations_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[organization_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 6/22/2017 1:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[bio] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
