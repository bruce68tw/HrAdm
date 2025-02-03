/****** Object:  Table [dbo].[Cms]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cms](
	[Id] [varchar](10) NOT NULL,
	[CmsType] [varchar](10) NOT NULL,
	[DataType] [varchar](10) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Html] [nvarchar](max) NULL,
	[Note] [nvarchar](255) NULL,
	[FileName] [nvarchar](100) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Reviser] [varchar](10) NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Cms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustInput]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustInput](
	[Id] [varchar](10) NOT NULL,
	[FldText] [nchar](10) NULL,
	[FldInt] [int] NULL,
	[FldDec] [float] NULL,
	[FldCheck] [bit] NULL,
	[FldRadio] [tinyint] NULL,
	[FldSelect] [varchar](10) NULL,
	[FldDate] [date] NULL,
	[FldDt] [datetime] NULL,
	[FldFile] [nvarchar](100) NULL,
	[FldColor] [varchar](10) NULL,
	[FldTextarea] [nvarchar](max) NULL,
	[FldHtml] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustInput] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[UserJob]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[UserLang]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[UserLicense]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[UserSchool]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[UserSkill]    Script Date: 2025/2/3 下午 05:04:31 ******/
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
/****** Object:  Table [dbo].[XpCode]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpCode](
	[Type] [varchar](20) NOT NULL,
	[Value] [varchar](10) NOT NULL,
	[Name_zhTW] [nvarchar](30) NOT NULL,
	[Name_zhCN] [nvarchar](30) NULL,
	[Name_enUS] [nvarchar](30) NULL,
	[Sort] [int] NOT NULL,
	[Ext] [varchar](30) NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_XpCode] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpDept]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpDept](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[MgrId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpEasyRpt]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpEasyRpt](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TplFile] [nvarchar](100) NOT NULL,
	[ToEmails] [varchar](500) NOT NULL,
	[Sql] [nvarchar](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_XpEasyRpt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpFlow]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlow](
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
/****** Object:  Table [dbo].[XpFlowLine]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowLine](
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
/****** Object:  Table [dbo].[XpFlowNode]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowNode](
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
/****** Object:  Table [dbo].[XpFlowSign]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowSign](
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
/****** Object:  Table [dbo].[XpImportLog]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpImportLog](
	[Id] [varchar](10) NOT NULL,
	[Type] [varchar](10) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[OkCount] [smallint] NOT NULL,
	[FailCount] [smallint] NOT NULL,
	[TotalCount] [smallint] NOT NULL,
	[CreatorName] [nvarchar](30) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_XpImportLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpProg]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpProg](
	[Id] [varchar](10) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Icon] [varchar](20) NULL,
	[Url] [varchar](100) NULL,
	[Sort] [smallint] NOT NULL,
	[AuthRow] [tinyint] NOT NULL,
	[FunCreate] [tinyint] NOT NULL,
	[FunRead] [tinyint] NOT NULL,
	[FunUpdate] [tinyint] NOT NULL,
	[FunDelete] [tinyint] NOT NULL,
	[FunPrint] [tinyint] NOT NULL,
	[FunExport] [tinyint] NOT NULL,
	[FunView] [tinyint] NOT NULL,
	[FunOther] [tinyint] NOT NULL,
 CONSTRAINT [PK_Prog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpRole]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpRole](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpRoleProg]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpRoleProg](
	[Id] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
	[ProgId] [varchar](10) NOT NULL,
	[FunCreate] [tinyint] NOT NULL,
	[FunRead] [tinyint] NOT NULL,
	[FunUpdate] [tinyint] NOT NULL,
	[FunDelete] [tinyint] NOT NULL,
	[FunPrint] [tinyint] NOT NULL,
	[FunExport] [tinyint] NOT NULL,
	[FunView] [tinyint] NOT NULL,
	[FunOther] [tinyint] NOT NULL,
 CONSTRAINT [PK_RoleProg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpTranLog]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpTranLog](
	[Sn] [int] IDENTITY(1,1) NOT NULL,
	[RowId] [varchar](10) NOT NULL,
	[TableName] [varchar](30) NOT NULL,
	[ColName] [varchar](30) NULL,
	[OldValue] [nvarchar](500) NULL,
	[NewValue] [nvarchar](500) NULL,
	[Act] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_XpTranLog] PRIMARY KEY CLUSTERED 
(
	[Sn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpUser]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpUser](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Pwd] [varchar](32) NOT NULL,
	[DeptId] [varchar](10) NOT NULL,
	[PhotoFile] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpUserRole]    Script Date: 2025/2/3 下午 05:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpUserRole](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cms] ([Id], [CmsType], [DataType], [Title], [Text], [Html], [Note], [FileName], [StartTime], [EndTime], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D6ZF8WZ96A', N'Msg', NULL, N'系統維護公告', N'系統為提升更好的服務品質，並因應 Windows 公告重大修補漏洞更新，本系統安排於 110/12/30 (星期四) AM 10:00-12:00 進行系統維護作業，屆時將暫停相關服務。
造成不便，敬請見諒！', NULL, N'', N'', CAST(N'2021-12-30T00:00:00.000' AS DateTime), CAST(N'2021-12-30T12:00:00.000' AS DateTime), 1, N'Peter', CAST(N'2021-12-23T16:29:02.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CustInput] ([Id], [FldText], [FldInt], [FldDec], [FldCheck], [FldRadio], [FldSelect], [FldDate], [FldDt], [FldFile], [FldColor], [FldTextarea], [FldHtml]) VALUES (N'D6Z5Q6JUSA', N'text      ', 2, 1.5, 1, 1, N'1', CAST(N'2021-12-02' AS Date), CAST(N'2021-12-02T09:00:00.000' AS DateTime), N'cat3.jpg', NULL, N'area', N'<p>test</p><p><b style=""><font style="" color="#ff9c00">test2</font></b></p>')
GO
INSERT [dbo].[Leave] ([Id], [UserId], [AgentId], [LeaveType], [StartTime], [EndTime], [Hours], [FlowLevel], [FlowStatus], [FileName], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'5ZMJQQQBYA', N'Alex', N'Nick', N'S', CAST(N'2021-03-10T09:00:00.000' AS DateTime), CAST(N'2021-03-10T18:00:00.000' AS DateTime), CAST(8.0 AS Decimal(5, 1)), 3, N'Y', N'醫院証明.jpg', 1, N'Alex', CAST(N'2021-03-07T22:19:00.000' AS DateTime), N'Alex', CAST(N'2021-12-23T13:15:50.000' AS DateTime))
GO
INSERT [dbo].[Leave] ([Id], [UserId], [AgentId], [LeaveType], [StartTime], [EndTime], [Hours], [FlowLevel], [FlowStatus], [FileName], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D6Z20WUQGA', N'Alex', N'Nick', N'P', CAST(N'2021-12-01T09:00:00.000' AS DateTime), CAST(N'2021-12-01T18:00:00.000' AS DateTime), CAST(8.0 AS Decimal(5, 1)), 4, N'Y', N'', 1, N'Alex', CAST(N'2021-12-23T11:34:15.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Leave] ([Id], [UserId], [AgentId], [LeaveType], [StartTime], [EndTime], [Hours], [FlowLevel], [FlowStatus], [FileName], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D6Z2T9WRSA', N'Alex', N'Nick', N'P', CAST(N'2021-12-03T09:00:00.000' AS DateTime), CAST(N'2021-12-03T18:00:00.000' AS DateTime), CAST(8.0 AS Decimal(5, 1)), 4, N'Y', N'', 1, N'Alex', CAST(N'2021-12-23T11:51:32.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5XLQJ73PZA', N'Alex', N'程式設計師', N'PG', N'台北市', N'2011/12 ~ 2015/9', N'公司1', 10, 0, N'77123')
GO
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5YG7AZMCJA', N'Alex', N'系統分析師', N'SA', N'台北市', N'2016/12 ~ 2019/9', N'公司2', 50, 0, N'test')
GO
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5XL9RMXH3A', N'Alex', N'中文', 3, 3, 3, 3, 0)
GO
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5YG7AZMLFA', N'Alex', N'英文', 2, 2, 2, 2, 1)
GO
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5XTM6SN9FA', N'Alex', N'系統分析師', N'2016/12 ~ 2017/9', N'_green wall.jpg')
GO
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5Y1MNT0KXA', N'Alex', N'專案管理師', N'2018/12 ~ 2019/9', N'dog.jpg')
GO
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5XL9R3JE9A', N'Alex', N'大學1', N'資訊', N'大學', N'2005/9 ~ 2009/6', 1)
GO
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5YG7AZMHCA', N'Alex', N'研究所1', N'資訊', N'研究所', N'2009/9 ~ 2011/6', 1)
GO
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5XLQHPB6KA', N'Alex', N'系統框架開發', N'', 0)
GO
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5YG7AZMS4A', N'Alex', N'專案管理', N'', 1)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{A}', N'And', N'And', N'And', 1, N'Flow', N'括號for避開regular')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{O}', N'Or', N'Or', N'Or', 2, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'0', N'無', N'無', N'None', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'1', N'個人', N'個人', N'Person', 2, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'2', N'部門', N'部門', N'Depart', 3, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'9', N'全部', N'全部', N'All', 9, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'0', N'簽核中', N'簽核中', N'Signing', 1, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'N', N'拒絶', N'拒絶', N'Reject', 3, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'Y', N'同意', N'同意', N'Agree', 2, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'1', N'略懂', N'略懂', N'Not Good', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'2', N'普通', N'普通', N'Normal', 2, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'3', N'精通', N'精通', N'Good', 3, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'B', N'公假', N'公假', N'Public', 3, NULL, N'business')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'P', N'事假', N'事假', N'Private', 2, NULL, N'private')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'S', N'病假', N'病假', N'Sick', 1, NULL, N'sick')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'EQ', N'=', N'=', N'=', 1, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'GE', N'>=', N'>=', N'>=', 4, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'GT', N'>', N'>', N'>', 3, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'NEQ', N'!=', N'!=', N'!=', 2, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'SE', N'<=', N'<=', N'<=', 6, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'ST', N'<', N'<', N'<', 5, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'CmsMsg', N'11.最新消息維護', N'11.最新消息維護', N'11.News', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'CustInput', N'9.自訂輸入欄位', N'9.自訂輸入欄位', N'9.Custom Input', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'Leave', N'1.請假作業', N'1.請假作業', N'1.Leave', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'LeaveSign', N'2.待簽核假單', N'2.待簽核假單', N'2.Signing Leave', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'User', N'5.用戶管理', N'5.用戶管理', N'5.User', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'UserExt', N'8.用戶經歷維護', N'8.用戶經歷維護', N'8.User Experience', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'UserImport', N'10.匯入用戶資料', N'10.匯入用戶資料', N'10.Import User', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpEasyRpt', N'12.簡單報表維護', N'12.簡單報表維護', N'12.Easy Report', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpFlow', N'3.流程維護', N'3.流程維護', N'3.Flow', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpFlowSign', N'4.簽核資料查詢', N'4.簽核資料查詢', N'4.Signing Query', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpProg', N'7.功能維護', N'7.功能維護', N'7.Function', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpRole', N'6.角色維護', N'6.角色維護', N'6.Role', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpTranLog', N'13.異動記錄查詢', N'13.異動記錄查詢', N'13.Transaction Log', 1, NULL, NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'1', N'不限制', N'不限制', N'No Limit', 1, N'Flow', N'暫不使用')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'2', N'立即執行', N'立即執行', N'Run Now', 2, N'Flow', N'暫不使用')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'3', N'限制時間', N'限制時間', N'Limit Time', 3, N'Flow', N'暫不使用')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'A', N'自動', N'自動', N'Auto', 4, N'Flow', N'暫不使用')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'E', N'結束', N'結束', N'End', 2, N'Flow', N'end')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'N', N'一般', N'一般', N'Normal', 3, N'Flow', N'normal')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'S', N'開始', N'開始', N'Start', 1, N'Flow', N'start')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'PassType', N'1', N'任一人簽核', N'任一人簽核', N'Anyone', 1, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'PassType', N'C', N'達簽核人數', N'達簽核人數', N'達簽核人數', 2, N'Flow', N'count')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'DM', N'部門主管', N'部門主管', N'Depart Manager', 4, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'F', N'指定欄位', N'指定欄位', N'Department', 2, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'U', N'指定用戶', N'指定用戶', N'User', 1, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'UM', N'用戶主管', N'用戶主管', N'Manager', 3, N'Flow', N'用戶部門主管')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'0', N'未簽核', N'未簽核', N'Not Sign', 1, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'1', N'送出', N'送出', N'Submit', 2, N'Flow', NULL)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'N', N'拒絶', N'拒絶', N'Reject', 4, N'1', N'for LeaveSign')
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'Y', N'同意', N'同意', N'Agree', 3, N'1', N'for LeaveSign')
GO
INSERT [dbo].[XpDept] ([Id], [Name], [MgrId]) VALUES (N'GM', N'管理部', N'Peter')
GO
INSERT [dbo].[XpDept] ([Id], [Name], [MgrId]) VALUES (N'RD', N'研發部', N'Nick')
GO
INSERT [dbo].[XpEasyRpt] ([Id], [Name], [TplFile], [ToEmails], [Sql], [Status]) VALUES (N'D71J9T4NYA', N'用戶資料報表', N'User.xlsx', N'youremail@gmail.com', N'select Name,Account,DeptId,Status 
from dbo.[User]
where status=1
order by Id', 1)
GO
INSERT [dbo].[XpFlow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZM5H6ED1A', N'Leave', N'請假', 1, 1)
GO
INSERT [dbo].[XpFlow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZMDKNA0CA', N'Test1', N'測試1', 1, 1)
GO
INSERT [dbo].[XpFlow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'D6Z38YPM2A', N'Test2', N'測試2', 1, 1)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAEMA', N'5ZM5H6ED1A', N'5ZM5H6EFGA', N'5ZM5H6EGHA', N'', 0)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAFJA', N'5ZM5H6ED1A', N'5ZM5H6EGHA', N'5ZM5H6EHCA', N'', 1)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAGPA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EJBA', N'Hours,GE,24', 2)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAHJA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EK3A', N'', 3)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAJQA', N'5ZM5H6ED1A', N'5ZM5H6EJBA', N'5ZM5H6EK3A', N'', 4)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA5PA', N'5ZMDKNA0CA', N'5ZMDKNA2VA', N'5ZMDKNA3LA', N'', 0)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA6NA', N'5ZMDKNA0CA', N'5ZMDKNA3LA', N'5ZMDKNA4HA', N'', 1)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'D6Z38YSBRA', N'D6Z38YPM2A', N'D6Z38YQHRA', N'D6Z38YQZ7A', N'', 0)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'D6Z38YSSSA', N'D6Z38YPM2A', N'D6Z38YQZ7A', N'D6Z38YREEA', N'', 1)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'D6Z38YT8TA', N'D6Z38YPM2A', N'D6Z38YREEA', N'D6Z38YRV7A', N'', 2)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EFGA', N'5ZM5H6ED1A', N'Start', N'S', 430, 30, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EGHA', N'5ZM5H6ED1A', N'代理人', N'N', 410, 140, N'F', N'AgentId', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EHCA', N'5ZM5H6ED1A', N'主管', N'N', 450, 250, N'UM', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EJBA', N'5ZM5H6ED1A', N'總經理', N'N', 540, 340, N'DM', N'GM', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EK3A', N'5ZM5H6ED1A', N'End', N'E', 410, 400, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA2VA', N'5ZMDKNA0CA', N'Start', N'S', 390, 60, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA3LA', N'5ZMDKNA0CA', N'Node', N'N', 370, 180, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA4HA', N'5ZMDKNA0CA', N'End', N'E', 410, 280, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'D6Z38YQHRA', N'D6Z38YPM2A', N'Start', N'S', 480, 50, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'D6Z38YQZ7A', N'D6Z38YPM2A', N'Node1', N'N', 440, 160, N'U', N'UserId', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'D6Z38YREEA', N'D6Z38YPM2A', N'Node2', N'N', 530, 260, N'U', N'AgentId', N'0', NULL)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'D6Z38YRV7A', N'D6Z38YPM2A', N'End', N'E', 500, 390, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQQZZA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'Start', 0, 2, N'Alex', N'Alex Chen', N'1', CAST(N'2021-03-07T22:19:00.860' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQR6KA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'代理人', 1, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:10.060' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQRBCA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'主管', 2, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:28.310' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z20WX0AA', N'5ZM5H6ED1A', N'D6Z20WUQGA', N'Start', 0, 3, N'Alex', N'Alex Chen', N'1', CAST(N'2021-12-23T11:34:15.750' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z20WXFKA', N'5ZM5H6ED1A', N'D6Z20WUQGA', N'代理人', 1, 3, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-12-23T11:44:08.340' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z20WXWCA', N'5ZM5H6ED1A', N'D6Z20WUQGA', N'主管', 2, 3, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-12-23T11:45:03.300' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z20WYBSA', N'5ZM5H6ED1A', N'D6Z20WUQGA', N'總經理', 3, 3, N'Peter', N'Peter Lin', N'Y', CAST(N'2021-12-23T11:48:54.710' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z2T9YJXA', N'5ZM5H6ED1A', N'D6Z2T9WRSA', N'Start', 0, 3, N'Alex', N'Alex Chen', N'1', CAST(N'2021-12-23T11:51:32.733' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z2T9Z0HA', N'5ZM5H6ED1A', N'D6Z2T9WRSA', N'代理人', 1, 3, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-12-23T11:52:25.713' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z2TA0C5A', N'5ZM5H6ED1A', N'D6Z2T9WRSA', N'主管', 2, 3, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-12-23T11:59:26.037' AS DateTime), NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'D6Z2TA0TSA', N'5ZM5H6ED1A', N'D6Z2T9WRSA', N'總經理', 3, 3, N'Peter', N'Peter Lin', N'Y', CAST(N'2021-12-23T11:59:49.550' AS DateTime), NULL)
GO
INSERT [dbo].[XpImportLog] ([Id], [Type], [FileName], [OkCount], [FailCount], [TotalCount], [CreatorName], [Created]) VALUES (N'D6ZMH4PAWA', N'User', N'UserImport.xlsx', 2, 0, 2, N'Peter Lin', CAST(N'2021-12-23T18:48:04.000' AS DateTime))
GO
INSERT [dbo].[XpImportLog] ([Id], [Type], [FileName], [OkCount], [FailCount], [TotalCount], [CreatorName], [Created]) VALUES (N'D6ZMS8SDBA', N'User', N'UserImport.xlsx', 0, 2, 2, N'Peter Lin', CAST(N'2021-12-23T18:54:02.000' AS DateTime))
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'CmsMsg', N'CmsMsg', N'CmsMsg', NULL, N'/CmsMsg/Read', 11, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'CustInput', N'CustInput', N'CustInput', NULL, N'/CustInput/Read', 9, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'Leave', N'Leave', N'Leave', NULL, N'/Leave/Read', 1, 1, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'LeaveSign', N'LeaveSign', N'LeaveSign', NULL, N'/LeaveSign/Read', 2, 0, 0, 1, 1, 0, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'TranLog', N'XpTranLog', N'XpTranLog', NULL, N'/XpTranLog/Read', 13, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'UserExt', N'UserExt', N'UserExt', NULL, N'/UserExt/Read', 8, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'UserImport', N'UserImport', N'UserImport', NULL, N'/UserImport/Read', 10, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpEasyRpt', N'XpEasyRpt', N'XpEasyRpt', NULL, N'/XpEasyRpt/Read', 12, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpFlow', N'XpFlow', N'XpFlow', NULL, N'/XpFlow/Read', 3, 0, 1, 1, 1, 1, 0, 0, 0, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpFlowSign', N'XpFlowSign', N'XpFlowSign', NULL, N'/XpFlowSign/Read', 4, 1, 0, 1, 0, 0, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpProg', N'XpProg', N'XpProg', NULL, N'/XpProg/Read', 7, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpRole', N'XpRole', N'XpRole', NULL, N'/XpRole/Read', 6, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpUser', N'XpUser', N'XpUser', NULL, N'/XpUser/Read', 5, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'Adm', N'管理者')
GO
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'All', N'所有人員')
GO
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'D57A8Z8R7A', N'部門主管')
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A01', N'Adm', N'User', 1, 1, 1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A02', N'Adm', N'XpRole', 1, 1, 1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A03', N'Adm', N'XpProg', 1, 1, 1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDDQA', N'All', N'Leave', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDJ9A', N'All', N'LeaveSign', 0, 1, 1, 0, 0, 0, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDU6A', N'All', N'XpFlowSign', 0, 1, 0, 0, 0, 0, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JE9EA', N'All', N'CustInput', 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNJ8LA', N'D57A8Z8R7A', N'Leave', 0, 2, 0, 0, 0, 2, 2, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNJP2A', N'D57A8Z8R7A', N'LeaveSign', 0, 2, 0, 0, 0, 2, 0, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNK5DA', N'D57A8Z8R7A', N'XpFlowSign', 0, 2, 0, 0, 0, 2, 0, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AWMKYTA', N'Adm', N'XpFlow', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6XLEHQXPA', N'Adm', N'UserExt', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6XLJ4J08A', N'Adm', N'UserImport', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y6ANAKQA', N'Adm', N'TranLog', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y6EJWKFA', N'Adm', N'CmsMsg', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y6EJWPQA', N'Adm', N'XpEasyRpt', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y708NTHA', N'Adm', N'Leave', 0, 9, 0, 0, 0, 9, 9, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y708P7YA', N'Adm', N'LeaveSign', 0, 9, 0, 0, 0, 9, 9, 0)
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D6Y708PK4A', N'Adm', N'XpFlowSign', 0, 9, 0, 0, 0, 9, 9, 0)
GO
SET IDENTITY_INSERT [dbo].[XpTranLog] ON 
GO
INSERT [dbo].[XpTranLog] ([Sn], [RowId], [TableName], [ColName], [OldValue], [NewValue], [Act], [Created]) VALUES (1, N'Alex', N'User', N'Name', N'Alex Chen', N'Alex Chen2', N'Update', CAST(N'2021-12-24T17:47:13.810' AS DateTime))
GO
INSERT [dbo].[XpTranLog] ([Sn], [RowId], [TableName], [ColName], [OldValue], [NewValue], [Act], [Created]) VALUES (2, N'Alex', N'User', N'Name', N'Alex Chen2', N'Alex Chen', N'Update', CAST(N'2021-12-24T19:09:34.533' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[XpTranLog] OFF
GO
INSERT [dbo].[XpUser] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Alex', N'Alex Chen', N'aa', N'aa', N'RD', N'Photo.png', 1)
GO
INSERT [dbo].[XpUser] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'D6ZMH4E87A', N't01', N'T01', N'T01', N'RD', NULL, 1)
GO
INSERT [dbo].[XpUser] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'D6ZMH4NU5A', N't02', N'T02', N'T02', N'RD', NULL, 1)
GO
INSERT [dbo].[XpUser] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Nick', N'Nick Wang', N'nn', N'nn', N'RD', NULL, 1)
GO
INSERT [dbo].[XpUser] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Peter', N'Peter Lin', N'pp', N'pp', N'GM', NULL, 1)
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'A01', N'Bruce', N'Adm')
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D56N9NW7WA', N'Peter', N'Adm')
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D57A8Z97UA', N'Nick', N'D57A8Z8R7A')
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT5HDA', N'Alex', N'All')
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT5Z1A', N'Nick', N'All')
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT6GNA', N'Peter', N'All')
GO
ALTER TABLE [dbo].[UserJob] ADD  CONSTRAINT [DF_UserJob_CorpUsers]  DEFAULT ((0)) FOR [CorpUsers]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_AuthRow]  DEFAULT ((0)) FOR [AuthRow]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunCreate]  DEFAULT ((0)) FOR [FunCreate]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunRead]  DEFAULT ((0)) FOR [FunRead]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunUpdate]  DEFAULT ((0)) FOR [FunUpdate]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunDelete]  DEFAULT ((0)) FOR [FunDelete]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunPrint]  DEFAULT ((0)) FOR [FunPrint]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunExport]  DEFAULT ((0)) FOR [FunExport]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunView]  DEFAULT ((0)) FOR [FunView]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunOther]  DEFAULT ((0)) FOR [FunOther]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunCreate]  DEFAULT ((0)) FOR [FunCreate]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunRead]  DEFAULT ((0)) FOR [FunRead]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunUpdate]  DEFAULT ((0)) FOR [FunUpdate]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunDelete]  DEFAULT ((0)) FOR [FunDelete]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunPrint]  DEFAULT ((0)) FOR [FunPrint]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunExport]  DEFAULT ((0)) FOR [FunExport]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunView]  DEFAULT ((0)) FOR [FunView]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunOther]  DEFAULT ((0)) FOR [FunOther]
GO
