USE [ont_db_Reports]
GO
/****** Object:  Table [dbo].[attT_Zusatz]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Zusatz](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Zusatz] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Zahl__real_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Zahl__real_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Zahl__real_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Zahl__int_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Zahl__int_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Zahl__int_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Z]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Z](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Z] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_X]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_X](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_X] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Width]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Width](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Width] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Vorname]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Vorname](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Vorname] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Valutadatum]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Valutadatum](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Valutadatum] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Todesdatum]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Todesdatum](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Todesdatum] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_to_Pay]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_to_Pay](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_to_Pay] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Timestamp__To_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Timestamp__To_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Timestamp__To_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_taking]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_taking](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_taking] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Start]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Start](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Start] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Standard]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Standard](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Standard] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Seperator]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Seperator](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Seperator] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_sended]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_sended](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_sended] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Seite_2_in_Zeitschrift]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Seite_2_in_Zeitschrift](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Seite_2_in_Zeitschrift] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_RTF_Text]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_RTF_Text](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_RTF_Text] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_RelationType]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_RelationType](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_RelationType] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Prozent]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Prozent](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Prozent] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_propositional]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_propositional](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_propositional] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_ProcessorID]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_ProcessorID](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_ProcessorID] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Postfach]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Postfach](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Postfach] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Path]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Path](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Objektsprache_Satz_wahr]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Objektsprache_Satz_wahr](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Objektsprache_Satz_wahr] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Nummer]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Nummer](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Nummer] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Nenner]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Nenner](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Nenner] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Nachbestellnummer]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Nachbestellnummer](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Nachbestellnummer] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Mulchfunktion]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Mulchfunktion](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Mulchfunktion] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Mitbenutzer_Nummer]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Mitbenutzer_Nummer](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Mitbenutzer_Nummer] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Menge]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Menge](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Menge] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Losnummer]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Losnummer](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Losnummer] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Level]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Level](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Jahr__Ende_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Jahr__Ende_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Jahr__Ende_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_ist_Sprachunabhängig]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_ist_Sprachunabhängig](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_ist_Sprachunabhängig] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_is_Null]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_is_Null](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_is_Null] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_is_Active]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_is_Active](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_is_Active] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Include]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Include](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Include] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Identifkationsnummer__IdNr_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Identifkationsnummer__IdNr_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Identifkationsnummer__IdNr_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_gültig_bis]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_gültig_bis](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_gültig_bis] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Füllmenge___l]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Füllmenge___l](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Füllmenge___l] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Füllmenge___cm]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Füllmenge___cm](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Füllmenge___cm] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Found]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Found](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Found] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Folge_unumstritten]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Folge_unumstritten](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Folge_unumstritten] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Exponent]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Exponent](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Exponent] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Erstzulassung]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Erstzulassung](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Erstzulassung] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Erhalten_am]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Erhalten_am](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Erhalten_am] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Ende__Minuten_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Ende__Minuten_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Ende__Minuten_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_encrypted_POP3_Connection]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_encrypted_POP3_Connection](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_encrypted_POP3_Connection] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Einwände]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Einwände](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Einwände] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Eigeninitiative]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Eigeninitiative](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Eigeninitiative] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Deflektor]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Deflektor](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Deflektor] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_db_postfix]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_db_postfix](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_db_postfix] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_DateTimeStamp__Change_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_DateTimeStamp__Change_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_DateTimeStamp__Change_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_date_of_expiry]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_date_of_expiry](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_date_of_expiry] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Create_Object_Reference_Typs]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Create_Object_Reference_Typs](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Create_Object_Reference_Typs] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_comment]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_comment](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_comment] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Codepage]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Codepage](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Codepage] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Code]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Code](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_closing_Date]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_closing_Date](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_closing_Date] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Bestellnummer]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Bestellnummer](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Bestellnummer] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Begünstigter_Zahlungspflichtiger]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Begünstigter_Zahlungspflichtiger](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Begünstigter_Zahlungspflichtiger] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Beginn_ab]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Beginn_ab](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Beginn_ab] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Basis]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Basis](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Basis] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Ausgabe]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Ausgabe](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Ausgabe] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Anschlusskennung]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Anschlusskennung](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [nvarchar](max) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Anschlusskennung] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Angetrieben_Achsen__Anzahl_]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Angetrieben_Achsen__Anzahl_](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [bigint] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Angetrieben_Achsen__Anzahl_] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_Amount]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_Amount](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [real] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_Amount] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attT_abgeschickt_am]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attT_abgeschickt_am](
	[GUID_Attribute] [nvarchar](36) NOT NULL,
	[GUID_AttributeType] [nvarchar](36) NOT NULL,
	[Name_AttributeType] [nvarchar](255) NOT NULL,
	[GUID_Object] [nvarchar](36) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[val] [datetime] NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_abgeschickt_am] PRIMARY KEY CLUSTERED 
(
	[GUID_Attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[initialize_Table]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[initialize_Table]
	-- Add the parameters for the stored procedure here
	@Name_Table		nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SET @Name_Table = REPLACE(@Name_Table,'','_')
	SET @Name_Table = REPLACE(@Name_Table,' ','_')
	SET @Name_Table = REPLACE(@Name_Table,':','_')
	SET @Name_Table = REPLACE(@Name_Table,'-','_')
	SET @Name_Table = REPLACE(@Name_Table,'(','_')
	SET @Name_Table = REPLACE(@Name_Table,')','_')
	SET @Name_Table = REPLACE(@Name_Table,'/','_')
	SET @Name_Table = REPLACE(@Name_Table,'\','_')
	SET @Name_Table = REPLACE(@Name_Table,'>','_')
	SET @Name_Table = REPLACE(@Name_Table,'*','_')
	SET @Name_Table = REPLACE(@Name_Table,'.','_')

    -- Insert statements for procedure here
    DECLARE @SQL	nvarchar(max)
    
	SET @SQL = '
		IF OBJECT_ID(''' + @Name_Table + ''', N''U'') IS NOT NULL 
		BEGIN
			UPDATE ' + @Name_Table + '
			SET Exist=0
		END'
	
	EXEC(@SQL)
	
	SELECT 1 AS Done
END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_Class]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile_Class] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)

	
	SET @SQL = '
	
		CREATE TABLE #tmp_xml
		(
			XMLCol xml
		)
		
		INSERT INTO #tmp_xml
		SELECT *
		FROM OPENROWSET(
		BULK ''' + @Path_File + ''',
		SINGLE_BLOB) AS tmp_Table
		
		INSERT INTO [' + @Name_Table + ']
		SELECT	 xmlset.DS.value(''GUID[1]'',''nvarchar(36)'') AS GUID
			,xmlset.DS.value(''Name[1]'',''nvarchar(max)'') AS Name
			,xmlset.DS.value(''GUID_Class[1]'',''nvarchar(36)'') AS GUID_Class
			,xmlset.DS.value(''Exist[1]'',''bit'') AS Exist
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join + ' '
	
	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_Attribute]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile_Attribute] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
	,@DataType			nvarchar(128)
	,@Length			nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)

	
	SET @SQL = '
	
		CREATE TABLE #tmp_xml
		(
			XMLCol xml
		)
		
		INSERT INTO #tmp_xml
		SELECT *
		FROM OPENROWSET(
		BULK ''' + @Path_File + ''',
		SINGLE_BLOB) AS tmp_Table
		
		INSERT INTO [' + @Name_Table + ']
		SELECT	 xmlset.DS.value(''GUID_Attribute[1]'',''nvarchar(36)'') AS GUID_Attribute
			,xmlset.DS.value(''GUID_AttributeType[1]'',''nvarchar(36)'') AS GUID_AttributeType
			,xmlset.DS.value(''Name_AttributeType[1]'',''nvarchar(max)'') AS Name_AttributeType
			,xmlset.DS.value(''GUID_Object[1]'',''nvarchar(36)'') AS GUID_Object
			,xmlset.DS.value(''OrderID[1]'',''bigint'') AS OrderID'
		if Not @Length='0'
		BEGIN
		SET @SQL = @SQL + ',xmlset.DS.value(''val[1]'',''' + @DataType + '(' + @Length +')'') AS Val'
		END
		ELSE
		BEGIN
			SET @SQL = @SQL + ',xmlset.DS.value(''val[1]'',''' + @DataType +''') AS Val'
		END
			
		SET @SQL = @SQL + '
			,1 AS Exist
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join + ' '
	PRINT @SQL
	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile.bak]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile.bak] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	SET @SQL = 'UPDATE ' + @Name_Table + '
		SET Exist=0'
	EXEC(@SQL)
	
	SET @SQL = @SQL_TMPTABLE + '
	
		BULK INSERT [#tmp_' + @Name_Table + '] 
		FROM  ''' + @Path_File + ''' 
		WITH (
			FIELDTERMINATOR=''@@@'')
		
		INSERT INTO [' + @Name_Table + ']
		SELECT ' + @SELECT + '
		FROM [#tmp_' + @Name_Table + ']
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + ' 
		FROM [#tmp_' + @Name_Table + ']
		INNER JOIN ' + @Join + ' '
	exec(@SQL)
	
	SET @SQL = 'DELETE FROM ' + @Name_Table + '
		WHERE Exist=0'
	EXEC(@SQL)
END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	EXEC(@SQL)
	
	SET @SQL = @SQL_TMPTABLE + '
		INSERT INTO #tmp_' + @Name_Table + '
		SELECT ' +  @SELECT + '
		FROM OPENROWSET(
		BULK ''' + @Path_File + ''',
		SINGLE_BLOB) AS tmp_Table
		
		INSERT INTO [' + @Name_Table + ']
		SELECT * FROM #tmp_' + @Name_Table + '
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_' + @Name_Table + '
		INNER JOIN ' + @Join + ' '
	print @SQL
	exec(@SQL)
	
	
END
GO
/****** Object:  Table [dbo].[systbl_Tables]    Script Date: 02/18/2013 21:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systbl_Tables](
	[Type] [nvarchar](128) NOT NULL,
	[Name_Table] [nvarchar](128) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_systbl_Tables] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Name_Table] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insert_Object]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_Object] 
	-- Add the parameters for the stored procedure here
	 @GUID_Session		varchar(36)
	,@GUID_Class		varchar(36)
	,@GUID_Object		varchar(36)
	,@Name_Object		nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	SET @SQL = 'INSERT INTO [@TABLE@] VALUES (''@GUID_OBJECT@'',''@NAME_OBJECT@'',''@GUID_CLASS@'')'
	
	SET @SQL = REPLACE(@SQL,'@TABLE@',@GUID_Session+@GUID_Class)
	SET @SQL = REPLACE(@SQL,'@GUID_OBJECT@',@GUID_Object)
	SET @SQL = REPLACE(@SQL,'@NAME_OBJECT@',@Name_Object)
	SET @SQL = REPLACE(@SQL,'@GUID_CLASS@',@GUID_Class)
	PRINT @SQL
	EXEC(@SQL)
END
GO
/****** Object:  StoredProcedure [dbo].[finalize_Table]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[finalize_Table]
	-- Add the parameters for the stored procedure here
	@Name_Table		nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @SQL	nvarchar(max)
    
    SET @Name_Table = REPLACE(@Name_Table,'','_')
	SET @Name_Table = REPLACE(@Name_Table,' ','_')
	SET @Name_Table = REPLACE(@Name_Table,':','_')
	SET @Name_Table = REPLACE(@Name_Table,'-','_')
	SET @Name_Table = REPLACE(@Name_Table,'(','_')
	SET @Name_Table = REPLACE(@Name_Table,')','_')
	SET @Name_Table = REPLACE(@Name_Table,'/','_')
	SET @Name_Table = REPLACE(@Name_Table,'\','_')
	SET @Name_Table = REPLACE(@Name_Table,'>','_')
	SET @Name_Table = REPLACE(@Name_Table,'*','_')
	SET @Name_Table = REPLACE(@Name_Table,'.','_')
    
	SET @SQL = 'DELETE FROM ' + @Name_Table + '
		WHERE Exist=0'
	EXEC(@SQL)
	
	SELECT 1 AS Done
END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_relT]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_relT]
	-- Add the parameters for the stored procedure here
	 @Ontology				nvarchar(128)
	,@Name_Class_Left		nvarchar(128)
	,@Name_Class_Right		nvarchar(128)
	,@Name_RelationType		nvarchar(128)
	,@OrderID				nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,' ','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,':','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'-','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'(','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,')','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'/','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'\','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'>','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'*','_')
	
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,' ','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,':','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'-','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'(','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,')','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'/','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'\','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'>','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'*','_')
	
	SET @Name_RelationType = REPLACE(@Name_RelationType,'','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,' ','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,':','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'-','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'(','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,')','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'/','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'\','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'>','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'*','_')

	SET @SQL = 'IF OBJECT_ID(''relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ''', N''U'') IS NOT NULL 
		DROP TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType  + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']
	(
		[GUID_Class_Left] varchar(36) NOT NULL,
		[GUID_Class_Left] varchar(36) NOT NULL,
		[GUID_RelationType] varchar(36) NOT NULL,
		[OrderID] long NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] ADD CONSTRAINT
	[PK_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Attribute]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] SET (LOCK_ESCALATION = TABLE);'

IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType, 1)
END

SELECT object_id
FROM sys.objects 
WHERE name='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
AND type='U'
END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_orgT.bak]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_orgT.bak]
	-- Add the parameters for the stored procedure here
	 @Ontology		nvarchar(128)
	,@Name_Class	nvarchar(255)
	,@Path_File		nvarchar(255)	
	,@Objects		bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	DECLARE @SQL_Table		nvarchar(max)
	
	SET @Name_Class = REPLACE(@Name_Class,'','_')
	SET @Name_Class = REPLACE(@Name_Class,' ','_')
	SET @Name_Class = REPLACE(@Name_Class,':','_')
	SET @Name_Class = REPLACE(@Name_Class,'-','_')
	SET @Name_Class = REPLACE(@Name_Class,'(','_')
	SET @Name_Class = REPLACE(@Name_Class,')','_')
	SET @Name_Class = REPLACE(@Name_Class,'/','_')
	SET @Name_Class = REPLACE(@Name_Class,'\','_')
	SET @Name_Class = REPLACE(@Name_Class,'>','_')
	SET @Name_Class = REPLACE(@Name_Class,'*','_')
	

	SET @SQL = 'IF OBJECT_ID(''orgT_' + @Name_Class + ''', N''U'') IS NOT NULL 
		DROP TABLE [orgT_' + @Name_Class + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [orgT_' + @Name_Class + ']
	(
		[GUID_' + @Name_Class +'] varchar(36) NOT NULL,
		[Name_' + @Name_Class + '] nvarchar(255) NOT NULL,
		[GUID_Class_' + @Name_Class + '] varchar(36) NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] ADD CONSTRAINT
	[PK_' + @Name_Class + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_' + @Name_Class + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] SET (LOCK_ESCALATION = TABLE);'

	
exec(@SQL)



IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='orgT_' + @Name_Class)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='orgT_' + @Name_Class
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'orgT_' + @Name_Class, 1)
END

IF @Objects = 1
BEGIN
	SET @SQL_Table = 'CREATE TABLE #tmp_orgt_' + @Name_Class + '
		(
			[GUID] varchar(36) NOT NULL,
			[Name] nvarchar(255) NOT NULL,
			[GUID_Class] varchar(36) NOT NULL,
			[Exist]	bit NOT NULL DEFAULT 1
		)'
	SET @SELECT = '#tmp_orgt_' + @Name_Class + '.GUID_' + @Name_Class +',#tmp_orgt_' + @Name_Class + '.Name_' + @Name_Class + ',#tmp_orgt_' + @Name_Class + '.GUID_Class_' + @Name_Class + ',#tmp_orgt_' + @Name_Class + '.Exist'
	SET @Name_Table = 'orgT_' + @Name_Class
	SET @SET_UPdate = '[orgT_' + @Name_Class + '].Name_' + @Name_Class + '=[#tmp_orgt_' + @Name_Class + '].Name_' + @Name_Class + ', '  + 
					'[orgT_' + @Name_Class + '].GUID_Class_' + @Name_Class + '=[#tmp_orgt_' + @Name_Class + '].GUID_Class_' + @Name_Class
	SET @WHERE_Insert = 'WHERE [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' IS NULL'
	SET @JOIN = '[orgT_' + @Name_Class + '] ON [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' = [#tmp_orgt_' + @Name_Class + '].GUID_' + @Name_Class
	
	execute import_BulkFile @Name_Table, @SQL_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File
END

SELECT object_id
FROM sys.objects 
WHERE name='orgT_' + @Name_Class
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_orgT]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_orgT]
	-- Add the parameters for the stored procedure here
	 @Ontology		nvarchar(128)
	,@Name_Class	nvarchar(255)
	,@Path_File		nvarchar(255)	
	,@Objects		bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	DECLARE @SQL_Table		nvarchar(max)
	
	SET @Name_Class = REPLACE(@Name_Class,'','_')
	SET @Name_Class = REPLACE(@Name_Class,' ','_')
	SET @Name_Class = REPLACE(@Name_Class,':','_')
	SET @Name_Class = REPLACE(@Name_Class,'-','_')
	SET @Name_Class = REPLACE(@Name_Class,'(','_')
	SET @Name_Class = REPLACE(@Name_Class,')','_')
	SET @Name_Class = REPLACE(@Name_Class,'/','_')
	SET @Name_Class = REPLACE(@Name_Class,'\','_')
	SET @Name_Class = REPLACE(@Name_Class,'>','_')
	SET @Name_Class = REPLACE(@Name_Class,'*','_')
	SET @Name_Class = REPLACE(@Name_Class,'.','_')
	


	SET @SQL = '
	IF OBJECT_ID(''orgT_' + @Name_Class + ''', N''U'') IS NULL 
	BEGIN
	CREATE TABLE [orgT_' + @Name_Class + ']
	(
		[GUID_' + @Name_Class +'] varchar(36) NOT NULL,
		[Name_' + @Name_Class + '] nvarchar(255) NOT NULL,
		[GUID_Class_' + @Name_Class + '] varchar(36) NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] ADD CONSTRAINT
	[PK_' + @Name_Class + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_' + @Name_Class + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] SET (LOCK_ESCALATION = TABLE);
	END'
	
exec(@SQL)



IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='orgT_' + @Name_Class)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='orgT_' + @Name_Class
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'orgT_' + @Name_Class, 1)
END

IF @Objects = 1
BEGIN
	SET @SQL_Table = 'CREATE TABLE #tmp_orgt_' + @Name_Class + '
		(
			[GUID] varchar(36) NOT NULL,
			[Name] nvarchar(255) NOT NULL,
			[GUID_Class] varchar(36) NOT NULL,
			[Exist]	bit NOT NULL DEFAULT 1
		)
		
		ALTER TABLE #tmp_orgt_' + @Name_Class + ' ADD CONSTRAINT
		[PK_tmp_' + @Name_Class + '] PRIMARY KEY CLUSTERED 
		(
			[GUID]
		)'
	SET @SELECT = 'GUID,Name,GUID_Class,Exist'
	SET @Name_Table = 'orgT_' + @Name_Class
	SET @SET_UPdate = '[orgT_' + @Name_Class + '].Name_' + @Name_Class + '=xmlset.DS.value(''Name[1]'',''nvarchar(max)''),[orgT_' + @Name_Class + '].Exist=1'
	SET @WHERE_Insert = 'WHERE [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' IS NULL'
	SET @JOIN = '[orgT_' + @Name_Class + '] ON [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' = xmlset.DS.value(''GUID[1]'',''nvarchar(36)'')'
	
	execute import_BulkFile_Class @Name_Table, @SQL_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File
END

SELECT object_id
FROM sys.objects 
WHERE name='orgT_' + @Name_Class
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_attT]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_attT]
	-- Add the parameters for the stored procedure here
	 @Ontology				nvarchar(128)
	,@Name_AttributeType	nvarchar(128)
	,@DataType				nvarchar(128)
	,@Length				nvarchar(128)
	,@Objects				bit
	,@Path_File				nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SQL_Table		nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	
	
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,' ','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,':','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'-','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'(','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,')','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'/','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'\','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'>','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'*','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'.','_')
	
	
	SET @SQL = '
	IF OBJECT_ID(''attT_' + @Name_AttributeType + ''', N''U'') IS NULL 
	BEGIN
	
	CREATE TABLE [attT_' + @Name_AttributeType + ']
	(
		[GUID_Attribute] nvarchar(36) NOT NULL,
		[GUID_AttributeType] nvarchar(36) NOT NULL,
		[Name_AttributeType] nvarchar(255) NOT NULL,
		[GUID_Object] nvarchar(36) NOT NULL,
		[OrderID] bigint NOT NULL,'
		
		if @Length='0'
		BEGIN
			SET @SQL = @SQL + '[val] ' + @DataType + ' NOT NULL,'
		END
		ELSE
		BEGIN
			SET @SQL = @SQL + '[val] ' + @DataType + '(' + @Length + ') NOT NULL,'
			
		END
		
		SET @SQL = @SQL + '[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [attT_' + @Name_AttributeType + '] ADD CONSTRAINT
	[PK_' + @Name_AttributeType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Attribute]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [attT_' + @Name_AttributeType + '] SET (LOCK_ESCALATION = TABLE);
	END'

	EXEC(@SQL)
IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='attT_' + @Name_AttributeType)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='attT_' + @Name_AttributeType
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'attT_' + @Name_AttributeType, 1)
END

IF @Objects = 1
BEGIN
	SET @SQL_Table = 'CREATE TABLE #tmp_attt_' + @Name_AttributeType + '
		(
			[GUID_Attribute] nvarchar(36) NOT NULL,
			[GUID_AttributeType] nvarchar(36) NOT NULL,
			[Name_AttributeType] nvarchar(255) NOT NULL,
			[GUID_Object] nvarchar(36) NOT NULL,
			[OrderID] bigint NOT NULL,'
			if @Length='0'
		BEGIN
			SET @SQL_Table = @SQL_Table + '[val] ' + @DataType + ' NOT NULL,'
		END
		ELSE
		BEGIN
			SET @SQL_Table = @SQL_Table + '[val] ' + @DataType + '(' + @Length + ') NOT NULL,'
			
		END
		SET @SQL_Table = @SQL_Table + '
		[Exist]	bit NOT NULL DEFAULT 1
		)
		
		ALTER TABLE #tmp_attt_' + @Name_AttributeType + ' ADD CONSTRAINT
		[PK_tmp_' + @Name_AttributeType + '] PRIMARY KEY CLUSTERED 
		(
			[GUID_Attribute]
		)'

	SET @SELECT = 'GUID_Attribute,GUID_AttributeType,GUID_Object,OrderID,val,Exist'
	SET @Name_Table = 'attT_' + @Name_AttributeType
	SET @SET_UPdate = '[attT_' + @Name_AttributeType + '].Name_AttributeType=xmlset.DS.value(''Name_AttributeType[1]'',''nvarchar(max)''),[attT_' + @Name_AttributeType + '].Exist=1'
	SET @WHERE_Insert = 'WHERE [attT_' + @Name_AttributeType + '].GUID_Attribute IS NULL'
	SET @JOIN = '[attT_' + @Name_AttributeType + '] ON [attT_' + @Name_AttributeType + '].GUID_Attribute= xmlset.DS.value(''GUID_Attribute[1]'',''nvarchar(36)'')'
		
	execute import_BulkFile_Attribute @Name_Table, @SQL_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File, @DataType, @Length
END

SELECT object_id
FROM sys.objects 
WHERE name='attT_' + @Name_AttributeType
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[initialize_Tables]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[initialize_Tables] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE systbl_Tables
	SET Exist=0
	
	SELECT COUNT(*) AS Count_NonExistant
	FROM systbl_Tables
	WHERE Exist=1
END
GO
/****** Object:  StoredProcedure [dbo].[finalize_Tables]    Script Date: 02/18/2013 21:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[finalize_Tables] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM systbl_Tables
	WHERE Exist = 0
	
	SELECT	 Type
			,Name_Table
			,Exist
	FROM systbl_Tables
	WHERE Exist = 0
END
GO
/****** Object:  Default [DF__attT_abge__Exist__37C60D64]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_abgeschickt_am] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Amou__Exist__34E9A0B9]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Amount] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Ange__Exist__1EC55570]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Angetrieben_Achsen__Anzahl_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Ansc__Exist__3D7EE6BA]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Anschlusskennung] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Ausg__Exist__0446695E]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Ausgabe] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Basi__Exist__731BDD5C]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Basis] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Begi__Exist__76B76416]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Beginn_ab] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Begü__Exist__269B8162]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Begünstigter_Zahlungspflichtiger] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Best__Exist__0722D609]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Bestellnummer] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_clos__Exist__275A9B71]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_closing_Date] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Code__Exist__190C7C1A]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Code] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Code__Exist__2C545AB8]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Codepage] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_comm__Exist__0D9AC96E]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_comment] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Crea__Exist__21A1C21B]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Create_Object_Reference_Typs] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_date__Exist__70FE8AC0]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_date_of_expiry] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Date__Exist__4337C010]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_DateTimeStamp__Change_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_db_p__Exist__5CF79213]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_db_postfix] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Defl__Exist__0FB81C0A]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Deflektor] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Eige__Exist__2FEFE172]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Eigeninitiative] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Einw__Exist__5FD3FEBE]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Einwände] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_encr__Exist__1B29CEB6]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_encrypted_POP3_Connection] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Ende__Exist__686944BF]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Ende__Minuten_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Erha__Exist__62B06B69]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Erhalten_am] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Erst__Exist__022916C2]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Erstzulassung] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Expo__Exist__78D4B6B2]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Exponent] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Folg__Exist__573EB8BD]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Folge_unumstritten] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Foun__Exist__129488B5]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Found] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Füll__Exist__73DAF76B]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Füllmenge___cm] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Füll__Exist__0505836D]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Füllmenge___l] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_gült__Exist__46142CBB]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_gültig_bis] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Iden__Exist__4BCD0611]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Identifkationsnummer__IdNr_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Incl__Exist__1BE8E8C5]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Include] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_is_A__Exist__54624C12]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_is_Active] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_is_N__Exist__7BB1235D]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_is_Null] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_ist___Exist__1E063B61]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_ist_Sprachunabhängig] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Jahr__Exist__184D620B]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Jahr__Ende_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Leve__Exist__07E1F018]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Level] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Losn__Exist__0ABE5CC3]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Losnummer] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Meng__Exist__4EA972BC]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Menge] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Mitb__Exist__7C703D6C]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Mitbenutzer_Nummer] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Mulc__Exist__32CC4E1D]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Mulchfunktion] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Nach__Exist__2F30C763]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Nachbestellnummer] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Nenn__Exist__1353A2C4]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Nenner] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Numm__Exist__7F4CAA17]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Nummer] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Obje__Exist__2A37081C]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Objektsprache_Satz_wahr] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Path__Exist__16300F6F]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Path] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Post__Exist__2977EE0D]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Postfach] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Proc__Exist__5185DF67]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_ProcessorID] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_prop__Exist__6B45B16A]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_propositional] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Proz__Exist__5A1B2568]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Prozent] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Rela__Exist__0CDBAF5F]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_RelationType] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_RTF___Exist__703F70B1]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_RTF_Text] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Seit__Exist__7E8D9008]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Seite_2_in_Zeitschrift] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_send__Exist__20E2A80C]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_sended] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Sepe__Exist__23BF14B7]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Seperator] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Stan__Exist__247E2EC6]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Standard] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Star__Exist__2D1374C7]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Start] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_taki__Exist__48F09966]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_taking] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Time__Exist__1570F560]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Timestamp__To_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_to_P__Exist__0169FCB3]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_to_Pay] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Tode__Exist__10773619]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Todesdatum] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Valu__Exist__658CD814]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Valutadatum] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Vorn__Exist__320D340E]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Vorname] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Widt__Exist__09FF42B4]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Width] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_X__Exist__75F84A07]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_X] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Z__Exist__3AA27A0F]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Z] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Zahl__Exist__6E221E15]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Zahl__int_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Zahl__Exist__7993D0C1]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Zahl__real_] ADD  DEFAULT ((1)) FOR [Exist]
GO
/****** Object:  Default [DF__attT_Zusa__Exist__405B5365]    Script Date: 02/18/2013 21:52:24 ******/
ALTER TABLE [dbo].[attT_Zusatz] ADD  DEFAULT ((1)) FOR [Exist]
GO
