USE [master]
GO
/****** Object:  Database [StudAppDB]    Script Date: 9/26/2019 8:53:08 AM ******/
CREATE DATABASE [StudAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudAppDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudAppDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudAppDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudAppDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudAppDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudAppDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudAppDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudAppDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudAppDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudAppDB]
GO
/****** Object:  Table [dbo].[AppCollegeMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppCollegeMaster](
	[AppCollegeId] [int] IDENTITY(1,1) NOT NULL,
	[ApllicationId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[CollegeId] [int] NOT NULL,
	[StremId] [int] NOT NULL,
 CONSTRAINT [PK_AppCollegeMaster] PRIMARY KEY CLUSTERED 
(
	[AppCollegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationMaster](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationNumber] [nvarchar](50) NULL,
	[EntryDate] [datetime] NULL,
	[BoardId] [int] NOT NULL,
	[PassingYearId] [int] NOT NULL,
	[ExamType] [int] NOT NULL,
	[BOD] [date] NOT NULL,
	[RollCode] [nvarchar](50) NOT NULL,
	[RollNumber] [nvarchar](50) NOT NULL,
	[ApplicantName] [nvarchar](200) NOT NULL,
	[FatherName] [nvarchar](200) NOT NULL,
	[MotherName] [nvarchar](200) NOT NULL,
	[S10MaxiMarks] [int] NOT NULL,
	[S10TotalMarks] [int] NOT NULL,
	[Is10Compartmentally] [bit] NOT NULL CONSTRAINT [DF_ApplicationMaster_Is10Compartmentally]  DEFAULT ((0)),
	[SchoolName] [nvarchar](100) NULL,
	[SchoolAddress] [nvarchar](max) NULL,
	[DistrictId] [int] NULL,
	[YearOfJoin] [int] NULL,
	[YearOfLeaving] [int] NULL,
	[Gender] [nchar](10) NULL,
	[MotherTongue] [nvarchar](50) NULL,
	[Nationality] [nvarchar](50) NULL,
	[Religion] [nvarchar](50) NULL,
	[BloodGroup] [nchar](10) NULL,
	[State] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[Block] [nvarchar](50) NULL,
	[HouseAddress] [nvarchar](max) NULL,
	[PinCode] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[TelephoneNo] [nvarchar](50) NULL,
	[ReservationId] [int] NULL,
	[EWS] [int] NULL,
	[SpecialAbied] [int] NULL,
	[IsCondition1] [bit] NULL,
	[IsCondition2] [bit] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_ApplicationMaster_IsActive]  DEFAULT ((1)),
	[UpdateDate] [datetime] NULL,
	[Photo] [nvarchar](max) NULL,
	[Signature] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApplicationMaster] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlockMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlockMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_BlockMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BloodGroupMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroupMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_BloodGroupMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoardMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardMaster](
	[BoardId] [int] NOT NULL,
	[BoardName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_BoardMaster_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_BoardMaster] PRIMARY KEY CLUSTERED 
(
	[BoardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CollegeMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollegeMaster](
	[CollegeId] [int] NOT NULL,
	[CollegeName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_CollegeMaster_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_CollegeMaster] PRIMARY KEY CLUSTERED 
(
	[CollegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DistrictMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistrictMaster](
	[DistrictId] [int] NOT NULL,
	[DistrictName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_DistrictMaster_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_DistrictMaster] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenderMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GenderMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_GenderMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MotherToungeMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherToungeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_MotherToungeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NationalityMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NationalityMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_NationalityMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReligionMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReligionMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_ReligionMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StateMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateMaster](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](200) NULL,
 CONSTRAINT [PK_StateMaster] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StreamMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StreamMaster](
	[StreamId] [int] NOT NULL,
	[StreamName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_StreamMaster_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_StreamMaster] PRIMARY KEY CLUSTERED 
(
	[StreamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[YearMaster]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YearMaster](
	[YearId] [int] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_YearMaster] PRIMARY KEY CLUSTERED 
(
	[YearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AppCollegeMaster] ON 

GO
INSERT [dbo].[AppCollegeMaster] ([AppCollegeId], [ApllicationId], [DistrictId], [CollegeId], [StremId]) VALUES (1, 1, 1, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[AppCollegeMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ApplicationMaster] ON 

GO
INSERT [dbo].[ApplicationMaster] ([ApplicationId], [ApplicationNumber], [EntryDate], [BoardId], [PassingYearId], [ExamType], [BOD], [RollCode], [RollNumber], [ApplicantName], [FatherName], [MotherName], [S10MaxiMarks], [S10TotalMarks], [Is10Compartmentally], [SchoolName], [SchoolAddress], [DistrictId], [YearOfJoin], [YearOfLeaving], [Gender], [MotherTongue], [Nationality], [Religion], [BloodGroup], [State], [District], [Block], [HouseAddress], [PinCode], [MobileNo], [Email], [TelephoneNo], [ReservationId], [EWS], [SpecialAbied], [IsCondition1], [IsCondition2], [IsActive], [UpdateDate], [Photo], [Signature]) VALUES (1, N'0926362223', CAST(N'2019-09-26 08:36:22.233' AS DateTime), 1, 2008, 2, CAST(N'2019-12-31' AS Date), N'df', N'df', N'sds', N'sd', N'aqssa', 0, 0, 0, N'we', N'fg', 1, 2008, 2008, N'1         ', N'1', N'1', N'2', N'1         ', N'1', N'1', N'1', N'fe', N'454545', N'4455665555', N'test@rr.com', NULL, 1, 1, 0, NULL, NULL, 1, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ApplicationMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[BlockMaster] ON 

GO
INSERT [dbo].[BlockMaster] ([Id], [Name]) VALUES (1, N'A')
GO
INSERT [dbo].[BlockMaster] ([Id], [Name]) VALUES (2, N'B')
GO
SET IDENTITY_INSERT [dbo].[BlockMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[BloodGroupMaster] ON 

GO
INSERT [dbo].[BloodGroupMaster] ([Id], [Name]) VALUES (1, N'A')
GO
INSERT [dbo].[BloodGroupMaster] ([Id], [Name]) VALUES (2, N'AB')
GO
INSERT [dbo].[BloodGroupMaster] ([Id], [Name]) VALUES (3, N'B')
GO
INSERT [dbo].[BloodGroupMaster] ([Id], [Name]) VALUES (4, N'O+')
GO
SET IDENTITY_INSERT [dbo].[BloodGroupMaster] OFF
GO
INSERT [dbo].[BoardMaster] ([BoardId], [BoardName], [IsActive]) VALUES (1, N'Board-Bihar', 1)
GO
INSERT [dbo].[BoardMaster] ([BoardId], [BoardName], [IsActive]) VALUES (2, N'Borad-Other', 1)
GO
INSERT [dbo].[CollegeMaster] ([CollegeId], [CollegeName], [IsActive]) VALUES (1, N'College1', 1)
GO
INSERT [dbo].[CollegeMaster] ([CollegeId], [CollegeName], [IsActive]) VALUES (2, N'College2', 1)
GO
INSERT [dbo].[DistrictMaster] ([DistrictId], [DistrictName], [IsActive]) VALUES (1, N'District1', 1)
GO
INSERT [dbo].[DistrictMaster] ([DistrictId], [DistrictName], [IsActive]) VALUES (2, N'District2', 1)
GO
SET IDENTITY_INSERT [dbo].[GenderMaster] ON 

GO
INSERT [dbo].[GenderMaster] ([Id], [Name]) VALUES (1, N'Male')
GO
INSERT [dbo].[GenderMaster] ([Id], [Name]) VALUES (2, N'Female')
GO
SET IDENTITY_INSERT [dbo].[GenderMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[MotherToungeMaster] ON 

GO
INSERT [dbo].[MotherToungeMaster] ([Id], [Name]) VALUES (1, N'Hindi')
GO
INSERT [dbo].[MotherToungeMaster] ([Id], [Name]) VALUES (2, N'English')
GO
SET IDENTITY_INSERT [dbo].[MotherToungeMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[NationalityMaster] ON 

GO
INSERT [dbo].[NationalityMaster] ([Id], [Name]) VALUES (1, N'Indian')
GO
SET IDENTITY_INSERT [dbo].[NationalityMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ReligionMaster] ON 

GO
INSERT [dbo].[ReligionMaster] ([Id], [Name]) VALUES (1, N'Hindu')
GO
INSERT [dbo].[ReligionMaster] ([Id], [Name]) VALUES (2, N'Christian')
GO
SET IDENTITY_INSERT [dbo].[ReligionMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[StateMaster] ON 

GO
INSERT [dbo].[StateMaster] ([StateId], [StateName]) VALUES (1, N'State1')
GO
INSERT [dbo].[StateMaster] ([StateId], [StateName]) VALUES (2, N'State2')
GO
SET IDENTITY_INSERT [dbo].[StateMaster] OFF
GO
INSERT [dbo].[StreamMaster] ([StreamId], [StreamName], [IsActive]) VALUES (1, N'Science', 1)
GO
INSERT [dbo].[StreamMaster] ([StreamId], [StreamName], [IsActive]) VALUES (2, N'Commerce', 1)
GO
INSERT [dbo].[StreamMaster] ([StreamId], [StreamName], [IsActive]) VALUES (3, N'Arts', 1)
GO
INSERT [dbo].[YearMaster] ([YearId], [Year]) VALUES (1, 2008)
GO
INSERT [dbo].[YearMaster] ([YearId], [Year]) VALUES (2, 2010)
GO
INSERT [dbo].[YearMaster] ([YearId], [Year]) VALUES (3, 2011)
GO
INSERT [dbo].[YearMaster] ([YearId], [Year]) VALUES (4, 2012)
GO
INSERT [dbo].[YearMaster] ([YearId], [Year]) VALUES (5, 2013)
GO
/****** Object:  StoredProcedure [dbo].[GetAutoCompleteData]    Script Date: 9/26/2019 8:53:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[GetAutoCompleteData] @Keyword='',@Count=10,@TableName='BusinessRuleMaster',@DisplayColumnName='concat(RuleName,''('',convert(varchar(12),startdate,101),'' To '', convert(varchar(20),enddate,101),'')'')',@ValueColumnName='BusinessRuleId'
CREATE PROCEDURE [dbo].[GetAutoCompleteData]      
 @Keyword nvarchar(100)=null      
 ,@Count int=10      
 ,@TableName nvarchar(max)=null    
 ,@DisplayColumnName nvarchar(100)=null   
 ,@ValueColumnName nvarchar(100)=null 
 ,@WhereClause nvarchar(500)=null     
 ,@Type nvarchar(50)='LIST'    
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
 DECLARE @QRY nvarchar(max)      
 IF ISNULL(@Type,'LIST')='LIST'    
 BEGIN    
   IF ISNULL(@WhereClause,'')=''      
    BEGIN      
     SET @WhereClause=' 1=1 '      
    END      
   SET @QRY='SELECT Distinct TOP '+CONVERT(nvarchar,@Count)+' '+@DisplayColumnName+' as Name,'+@ValueColumnName+' as ID FROM '+@TableName+' WHERE '+@WhereClause+' AND '+@DisplayColumnName+' LIKE ''%'+@Keyword+'%'' ORDER BY '+@DisplayColumnName+' ASC'      
  print @QRY      
   EXEC(@QRY)      
 END      
 ELSE    
 BEGIN    
   IF ISNULL(@WhereClause,'')=''      
    BEGIN      
     SET @WhereClause=' 1=1 '      
    END      
   SET @QRY='SELECT Distinct '+@DisplayColumnName+' as Name,'+@ValueColumnName+' as ID FROM '+@TableName+' WHERE '+@WhereClause+' AND '+@DisplayColumnName+' ='''+@Keyword+''' ORDER BY '+@DisplayColumnName+' ASC'      
   print @QRY      
   EXEC(@QRY)      
 END    
END    



GO
USE [master]
GO
ALTER DATABASE [StudAppDB] SET  READ_WRITE 
GO
