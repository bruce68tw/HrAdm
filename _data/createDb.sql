--USE [Hr]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[Type] [varchar](20) NOT NULL,
	[Value] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Sort] [int] NOT NULL,
	[Ext] [varchar](30) NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dept](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[MgrId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flow]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flow](
	[Id] [varchar](10) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Portrait] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Flow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlowLine]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowLine](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[StartNode] [varchar](10) NOT NULL,
	[EndNode] [varchar](10) NOT NULL,
	[CondStr] [varchar](255) NULL,
	[Sort] [smallint] NOT NULL,
 CONSTRAINT [PK_FlowLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlowNode]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowNode](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[NodeType] [char](1) NOT NULL,
	[PosX] [smallint] NOT NULL,
	[PosY] [smallint] NOT NULL,
	[SignerType] [varchar](2) NULL,
	[SignerValue] [varchar](30) NULL,
	[PassType] [char](1) NOT NULL,
	[PassNum] [smallint] NULL,
 CONSTRAINT [PK_FlowNode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlowSign]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowSign](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[SourceId] [varchar](10) NOT NULL,
	[NodeName] [nvarchar](30) NOT NULL,
	[FlowLevel] [smallint] NOT NULL,
	[TotalLevel] [smallint] NOT NULL,
	[SignerId] [varchar](10) NOT NULL,
	[SignerName] [nvarchar](20) NOT NULL,
	[SignStatus] [char](1) NOT NULL,
	[SignTime] [datetime] NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_FlowSign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[AgentId] [varchar](10) NOT NULL,
	[LeaveType] [char](1) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Hours] [decimal](5, 1) NOT NULL,
	[FlowLevel] [tinyint] NOT NULL,
	[FlowStatus] [char](1) NOT NULL,
	[FileName] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Reviser] [varchar](10) NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prog]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prog](
	[Id] [varchar](10) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Icon] [varchar](20) NULL,
	[Url] [varchar](100) NULL,
 CONSTRAINT [PK_Prog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleProg]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleProg](
	[Id] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
	[ProgId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_RoleProg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [varchar](10) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Pwd] [varchar](32) NOT NULL,
	[DeptId] [varchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJob]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJob](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[JobName] [nvarchar](30) NOT NULL,
	[JobType] [nvarchar](30) NULL,
	[JobPlace] [nvarchar](30) NULL,
	[StartEnd] [varchar](30) NULL,
	[CorpName] [nvarchar](30) NULL,
	[CorpUsers] [int] NOT NULL,
	[IsManaged] [bit] NOT NULL,
	[JobDesc] [varchar](max) NULL,
 CONSTRAINT [PK_UserJob] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLang]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLang](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[LangName] [nvarchar](30) NOT NULL,
	[ListenLevel] [tinyint] NOT NULL,
	[SpeakLevel] [tinyint] NOT NULL,
	[ReadLevel] [tinyint] NOT NULL,
	[WriteLevel] [tinyint] NOT NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_UserLang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLicense]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLicense](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[LicenseName] [nvarchar](30) NOT NULL,
	[StartEnd] [varchar](30) NULL,
	[FileName] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserLicense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSchool]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSchool](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[SchoolName] [nvarchar](30) NOT NULL,
	[SchoolDept] [nvarchar](20) NULL,
	[SchoolType] [nvarchar](20) NULL,
	[StartEnd] [varchar](30) NULL,
	[Graduated] [bit] NOT NULL,
 CONSTRAINT [PK_UserSchool] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSkill]    Script Date: 2021/3/8 上午 10:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkill](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[SkillName] [nvarchar](30) NOT NULL,
	[SkillDesc] [nvarchar](500) NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_UserSkill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{A}', N'And', 1, N'Flow', N'括號for避開regular')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{O}', N'Or', 2, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'0', N'簽核中', 1, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'N', N'拒絶', 3, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'Y', N'同意', 2, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'1', N'略懂', 1, NULL, NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'2', N'普通', 2, NULL, NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'3', N'精通', 3, NULL, NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'B', N'公假', 3, NULL, N'business')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'P', N'事假', 2, NULL, N'private')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'S', N'病假', 1, NULL, N'sick')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'eq', N'=', 1, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'ge', N'>=', 4, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'gt', N'>', 3, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'neq', N'!=', 2, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'se', N'<=', 6, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'st', N'<', 5, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'1', N'不限制', 1, N'Flow', N'暫不使用')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'2', N'立即執行', 2, N'Flow', N'暫不使用')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'3', N'限制時間', 3, N'Flow', N'暫不使用')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'A', N'自動', 4, N'Flow', N'暫不使用')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'E', N'結束', 2, N'Flow', N'end')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'N', N'一般', 3, N'Flow', N'normal')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'S', N'開始', 1, N'Flow', N'start')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'PassType', N'1', N'任一人簽核', 1, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'PassType', N'C', N'達簽核人數', 2, N'Flow', N'count')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'DM', N'部門主管', 4, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'F', N'指定欄位', 2, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'U', N'指定用戶', 1, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'UM', N'用戶主管', 3, N'Flow', N'用戶部門主管')
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'0', N'未簽核', 1, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'1', N'送出', 2, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'N', N'拒絶', 4, N'Flow', NULL)
INSERT [dbo].[Code] ([Type], [Value], [Name], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'Y', N'同意', 3, N'Flow', NULL)
GO
INSERT [dbo].[Dept] ([Id], [Name], [MgrId]) VALUES (N'GM', N'管理部', N'Peter')
INSERT [dbo].[Dept] ([Id], [Name], [MgrId]) VALUES (N'RD', N'研發部', N'Nick')
GO
INSERT [dbo].[Flow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZM5H6ED1A', N'Leave', N'請假', 1, 1)
INSERT [dbo].[Flow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZMDKNA0CA', N'Test1', N'測試1', 1, 1)
GO
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAEMA', N'5ZM5H6ED1A', N'5ZM5H6EFGA', N'5ZM5H6EGHA', N'', 9)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAFJA', N'5ZM5H6ED1A', N'5ZM5H6EGHA', N'5ZM5H6EHCA', N'', 9)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAGPA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EJBA', N'Hours,ge,24', 1)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAHJA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EK3A', N'', 9)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAJQA', N'5ZM5H6ED1A', N'5ZM5H6EJBA', N'5ZM5H6EK3A', N'', 9)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA5PA', N'5ZMDKNA0CA', N'5ZMDKNA2VA', N'5ZMDKNA3LA', N'', 9)
INSERT [dbo].[FlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA6NA', N'5ZMDKNA0CA', N'5ZMDKNA3LA', N'5ZMDKNA4HA', N'', 9)
GO
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EFGA', N'5ZM5H6ED1A', N'Start', N'S', 450, 30, N'', N'', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EGHA', N'5ZM5H6ED1A', N'代理人', N'N', 410, 140, N'F', N'AgentId', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EHCA', N'5ZM5H6ED1A', N'主管', N'N', 450, 250, N'UM', N'', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EJBA', N'5ZM5H6ED1A', N'總經理', N'N', 540, 340, N'DM', N'GM', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EK3A', N'5ZM5H6ED1A', N'E', N'E', 410, 400, N'', N'', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA2VA', N'5ZMDKNA0CA', N'Start', N'S', 390, 70, N'', N'', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA3LA', N'5ZMDKNA0CA', N'Node', N'N', 370, 180, N'', N'', N'0', NULL)
INSERT [dbo].[FlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA4HA', N'5ZMDKNA0CA', N'E', N'E', 410, 280, N'', N'', N'0', NULL)
GO
INSERT [dbo].[FlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQQZZA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'Start', 0, 2, N'Alex', N'Alex Chen', N'1', CAST(N'2021-03-07T22:19:00.860' AS DateTime), NULL)
INSERT [dbo].[FlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQR6KA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'代理人', 1, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:10.060' AS DateTime), NULL)
INSERT [dbo].[FlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQRBCA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'主管', 2, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:28.310' AS DateTime), NULL)
GO
INSERT [dbo].[Leave] ([Id], [UserId], [AgentId], [LeaveType], [StartTime], [EndTime], [Hours], [FlowLevel], [FlowStatus], [FileName], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'5ZMJQQQBYA', N'Alex', N'Nick', N'P', CAST(N'2021-03-10T09:00:00.000' AS DateTime), CAST(N'2021-03-10T18:00:00.000' AS DateTime), CAST(8.0 AS Decimal(5, 1)), 3, N'Y', N'', 1, N'Alex', CAST(N'2021-03-07T22:19:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Prog] ([Id], [Code], [Name], [Icon], [Url]) VALUES (N'5YG783F9UA', N'UserExt', N'用戶經驗維護', N'', N'')
INSERT [dbo].[Prog] ([Id], [Code], [Name], [Icon], [Url]) VALUES (N'Prog', N'Prog', N'功能維護', NULL, NULL)
INSERT [dbo].[Prog] ([Id], [Code], [Name], [Icon], [Url]) VALUES (N'Role', N'Role', N'角色維護', NULL, NULL)
INSERT [dbo].[Prog] ([Id], [Code], [Name], [Icon], [Url]) VALUES (N'User', N'User', N'用戶維護', NULL, NULL)
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'Adm', N'管理者')
GO
INSERT [dbo].[RoleProg] ([Id], [RoleId], [ProgId]) VALUES (N'5YG79FYQ8A', N'Adm', N'5YG783F9UA')
INSERT [dbo].[RoleProg] ([Id], [RoleId], [ProgId]) VALUES (N'A03', N'Adm', N'Prog')
INSERT [dbo].[RoleProg] ([Id], [RoleId], [ProgId]) VALUES (N'A02', N'Adm', N'Role')
INSERT [dbo].[RoleProg] ([Id], [RoleId], [ProgId]) VALUES (N'A01', N'Adm', N'User')
GO
INSERT [dbo].[User] ([Id], [Account], [Name], [Pwd], [DeptId], [Status]) VALUES (N'Alex', N'aa', N'Alex Chen', N'aa', N'RD', 1)
INSERT [dbo].[User] ([Id], [Account], [Name], [Pwd], [DeptId], [Status]) VALUES (N'Nick', N'nn', N'Nick Wang', N'nn', N'RD', 1)
INSERT [dbo].[User] ([Id], [Account], [Name], [Pwd], [DeptId], [Status]) VALUES (N'Peter', N'PP', N'Peter Lin', N'pp', N'GM', 1)
GO
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5XLQJ73PZA', N'U01', N'11', N'22', N'33', N'44', N'55', 6, 1, N'77123')
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5YG7AZMCJA', N'Bruce', N'11abc', N'22', N'33', N'55', N'66', 10, 1, N'test')
GO
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5XL9RMXH3A', N'U01', N'22', 1, 2, 3, 2, 0)
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5YG7AZMLFA', N'Bruce', N'33', 2, 2, 2, 2, 0)
GO
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5XTM6SN9FA', N'U01', N'11ab', N'22', N'_green wall.jpg')
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5Y1MNT0KXA', N'U01', N'2', N'22', N'dog.jpg')
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5YG7AZMQ1A', N'Bruce', N'55', N'66', N'dog.jpg')
GO
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId]) VALUES (N'A01', N'Bruce', N'Adm')
GO
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5XL9R3JE9A', N'U01', N'11', N'22', N'33', N'44', 1)
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5YG7AZMHCA', N'Bruce', N'22', N'33', N'55', N'66', 1)
GO
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5XLQHPB6KA', N'U01', N'11', N'22', 0)
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5YG7AZMS4A', N'Bruce', N'66', N'77', 0)
GO
ALTER TABLE [dbo].[UserJob] ADD  CONSTRAINT [DF_UserJob_CorpUsers]  DEFAULT ((0)) FOR [CorpUsers]
GO
