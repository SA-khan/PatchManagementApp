USE [master]
GO
/****** Object:  Database [Release_Management_Portal]    Script Date: 3/26/2020 10:28:53 PM ******/
CREATE DATABASE [Release_Management_Portal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Release_Management_Portal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Release_Management_Portal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Release_Management_Portal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Release_Management_Portal_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Release_Management_Portal] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Release_Management_Portal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Release_Management_Portal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Release_Management_Portal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Release_Management_Portal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Release_Management_Portal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Release_Management_Portal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET RECOVERY FULL 
GO
ALTER DATABASE [Release_Management_Portal] SET  MULTI_USER 
GO
ALTER DATABASE [Release_Management_Portal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Release_Management_Portal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Release_Management_Portal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Release_Management_Portal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Release_Management_Portal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Release_Management_Portal', N'ON'
GO
ALTER DATABASE [Release_Management_Portal] SET QUERY_STORE = OFF
GO
USE [Release_Management_Portal]
GO
/****** Object:  Table [dbo].[ClientDetail]    Script Date: 3/26/2020 10:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientDetail](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [varchar](40) NULL,
	[ClientType] [varchar](40) NULL,
	[ClientDesc] [varchar](50) NULL,
	[ClientStill] [bit] NULL,
	[ClientPOCName] [varchar](40) NULL,
	[ClientPOCContact] [varchar](40) NULL,
	[ClientPOCEmail] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatchDetail]    Script Date: 3/26/2020 10:28:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatchDetail](
	[PatchID] [int] IDENTITY(1,1) NOT NULL,
	[PatchTitle] [varchar](50) NULL,
	[PatchDesc] [varchar](max) NULL,
	[PatchHotNumber] [varchar](40) NULL,
	[PatchDeployedBy] [varchar](max) NULL,
	[PatchCreatedDate] [datetime] NULL,
	[PatchDeployedDate] [datetime] NULL,
	[IsQAPassed] [bit] NULL,
	[Remarks_Dependencies] [varchar](max) NULL,
	[ClientID] [int] NULL,
	[ProductID] [int] NULL,
	[EnvironmentType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Patches]    Script Date: 3/26/2020 10:28:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Patches] AS
WITH CTE AS (
 SELECT 
  C.ClientName, C.ClientType, C.ClientPOCName, P.PatchHotNumber, P.PatchDeployedDate, P.ProductID, DATEDIFF(DAY,PatchDeployedDate,GETDATE()) As NumberOfDaysPassed  
 from ClientDetail C
      LEFT Join
	  PatchDetail P 
	  on 
	  C.ClientID = P.ClientID )
SELECT CTE.ClientName,MAX(CTE.ClientType) As ClientType,MAX(PatchHotNumber) As PatchHotNumber, MAX(PatchDeployedDate) As PatchDeployedDate,
 COUNT(ClientName) AS NumberOfPatches, MAX(CTE.ProductID) As ProductID, MAX(NumberOfDaysPassed) As NumberOfDaysPassed from CTE WHERE CTE.ProductID = 1 group by ClientName
GO
/****** Object:  Table [dbo].[ACCESS_RIGHT]    Script Date: 3/26/2020 10:28:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCESS_RIGHT](
	[ACC_ID] [int] IDENTITY(1,1) NOT NULL,
	[ACC_TITLE] [varchar](20) NULL,
	[ACC_DESC] [varchar](max) NULL,
	[ACC_VIEW] [bit] NULL,
	[ACC_EDIT] [bit] NULL,
	[ACC_DELETE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ACC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENT_TYPE]    Script Date: 3/26/2020 10:28:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENT_TYPE](
	[CTYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[CTYPE_TITLE] [varchar](max) NULL,
	[CTYPE_DESCRIPTION] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientEnvironment]    Script Date: 3/26/2020 10:28:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientEnvironment](
	[EnvID] [int] IDENTITY(1,1) NOT NULL,
	[EnvTitle] [varchar](40) NULL,
	[EnvDesc] [varchar](max) NULL,
	[ClientID] [int] NULL,
	[ProductID] [int] NULL,
	[PatchID] [int] NULL,
	[EnvAppServerName] [varchar](50) NULL,
	[EnvAppServerEnvironmentType] [int] NULL,
	[EnvAppServerIsX86Version] [bit] NULL,
	[EnvAppServerIsVirtual] [bit] NULL,
	[EnvAppServerMemory] [int] NULL,
	[EnvAppServerProcessor] [varchar](50) NULL,
	[EnvAppServerOSBuild] [bigint] NULL,
	[EnvAppServerOS] [varchar](50) NULL,
	[EnvAppServerWebBrowser] [varchar](50) NULL,
	[EnvAppServerWebBrowserVersion] [int] NULL,
	[EnvAppServerWorkingDirectoryLocation] [int] NULL,
	[EnvAppLink] [varchar](50) NULL,
	[EnvAppServerIP] [varchar](50) NULL,
	[EnvAppServerPort] [varchar](50) NULL,
	[EnvAppServerDependency] [varchar](50) NULL,
	[EnvAppServerComments] [varchar](50) NULL,
	[EnvDBServerName] [varchar](50) NULL,
	[EnvDBServerEnvironmentType] [int] NULL,
	[EnvDBServerIsX86Version] [bit] NULL,
	[EnvDBServerIsVirtual] [bit] NULL,
	[EnvDBServerMemory] [int] NULL,
	[EnvDBServerProcessor] [varchar](50) NULL,
	[EnvDBServerOSBuild] [bigint] NULL,
	[EnvDBServerOS] [varchar](50) NULL,
	[EnvDBServerDesc] [int] NULL,
	[EnvDBServerDirectoryLocation] [int] NULL,
	[EnvDBMDFFileLocation] [varchar](50) NULL,
	[EnvDBMDFFileSize] [varchar](50) NULL,
	[EnvDBLDFFileLocation] [varchar](50) NULL,
	[EnvDBLDFFileSize] [varchar](50) NULL,
	[EnvDBServerIP] [varchar](50) NULL,
	[EnvDBServerPort] [varchar](50) NULL,
	[EnvDBServerDependency] [varchar](50) NULL,
	[EnvDBServerComments] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EnvID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentInformation]    Script Date: 3/26/2020 10:28:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentInformation](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[DocReferenceNumber] [bigint] NULL,
	[DocTitle] [varchar](50) NULL,
	[DocDescription] [varchar](max) NULL,
	[ClientID] [int] NULL,
	[ProductID] [int] NULL,
	[DocName] [varchar](max) NULL,
	[DocLocation] [varchar](max) NULL,
	[DocLink] [varchar](max) NULL,
	[DocType] [varchar](20) NULL,
	[DocReference] [varchar](max) NULL,
	[DocRemarks] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Environment]    Script Date: 3/26/2020 10:28:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Environment](
	[ENV_ID] [int] IDENTITY(1,1) NOT NULL,
	[ENV_Client_ID] [int] NOT NULL,
	[ENV_Product_ID] [int] NOT NULL,
	[ENV_AppServerEnvironmentType] [int] NOT NULL,
	[ENV_DBServerEnvironmentType] [int] NOT NULL,
	[ENV_AppServerName] [varchar](50) NULL,
	[ENV_AppServerOS] [varchar](50) NULL,
	[ENV_AppServerOSBuild] [bigint] NULL,
	[ENV_AppServerIsX86Version] [bit] NULL,
	[ENV_AppServerIsVirtual] [bit] NULL,
	[ENV_AppServerProcessor] [varchar](50) NULL,
	[ENV_AppServerMemory] [int] NULL,
	[ENV_AppServerWebBrowser] [varchar](50) NULL,
	[ENV_AppServerWebBrowserVersion] [int] NULL,
	[ENV_AppServerWorkingDirectoryLocation] [varchar](max) NULL,
	[ENV_AppHyperLink] [varchar](100) NULL,
	[ENV_AppServerIP] [varchar](50) NULL,
	[ENV_AppServerPort] [int] NULL,
	[ENV_AppServerDependency] [varchar](100) NULL,
	[ENV_DBServerName] [varchar](50) NULL,
	[ENV_DBServerOS] [varchar](50) NULL,
	[ENV_DBServerOSBuild] [bigint] NULL,
	[ENV_DBServerIsX86Version] [bit] NULL,
	[ENV_DBServerIsVirtual] [bit] NULL,
	[ENV_DBServerProcessor] [varchar](50) NULL,
	[ENV_DBServerMemory] [int] NULL,
	[ENV_DBServerDirectoryLocation] [varchar](max) NULL,
	[ENV_DBMDFFileLocation] [varchar](100) NULL,
	[ENV_DBMDFFileSize] [bigint] NULL,
	[ENV_DBLDFFileLocation] [varchar](100) NULL,
	[ENV_DBLDFFileSize] [bigint] NULL,
	[ENV_DBServerIP] [varchar](50) NULL,
	[ENV_DBServerPort] [int] NULL,
	[ENV_DBServerDependency] [varchar](50) NULL,
 CONSTRAINT [PK_Environment] PRIMARY KEY CLUSTERED 
(
	[ENV_Client_ID] ASC,
	[ENV_Product_ID] ASC,
	[ENV_AppServerEnvironmentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ENV_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnvironmentType]    Script Date: 3/26/2020 10:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnvironmentType](
	[EnvID] [int] IDENTITY(1,1) NOT NULL,
	[EnvTitle] [varchar](10) NULL,
	[EnvDesc] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[EnvID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LANGUAGE]    Script Date: 3/26/2020 10:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LANGUAGE](
	[LNG_ID] [int] IDENTITY(1,1) NOT NULL,
	[LNG_SHORT_CODE] [char](10) NULL,
	[LNG_FULL_NAME] [varchar](100) NULL,
	[LNG_DESC] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LNG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LNG_FULL_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LNG_SHORT_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSCODE_POLICY]    Script Date: 3/26/2020 10:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PASSCODE_POLICY](
	[PASSP_ID] [int] IDENTITY(1,1) NOT NULL,
	[PASSP_TITLE] [varchar](30) NULL,
	[PASSP_DESC] [varchar](max) NULL,
	[PASSP_CHAR_NUM] [int] NULL,
	[PASSP_INTEGER_NUM] [int] NULL,
	[PASSP_SP_CHAR_NUM] [int] NULL,
	[PASSP_EXAMPLE] [varchar](30) NULL,
	[PASSP_COMMENTS] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PASSP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PATCH]    Script Date: 3/26/2020 10:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PATCH](
	[PAT_ID] [int] IDENTITY(1,1) NOT NULL,
	[PAT_Title] [varchar](50) NULL,
	[PAT_Desc] [varchar](max) NULL,
	[PAT_HotNumber] [varchar](50) NULL,
	[PAT_DeployedBy] [varchar](max) NULL,
	[PAT_CreatedDate] [datetime] NULL,
	[PAT_DeployedDate] [datetime] NULL,
	[PAT_IsQAPassed] [bit] NULL,
	[PAT_Dependency] [varchar](max) NULL,
	[PAT_ClientID] [int] NOT NULL,
	[PAT_ProductID] [int] NOT NULL,
	[PAT_EnvType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PAT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/26/2020 10:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](40) NULL,
	[ProductDesc] [varchar](max) NULL,
	[ProductVersion] [varchar](10) NULL,
	[ProductType] [varchar](40) NULL,
	[ProductCategory] [varchar](50) NULL,
	[ProductRating] [varchar](5) NULL,
	[ProductDemoUserId] [varchar](20) NULL,
	[ProductDemoPasscode] [varchar](20) NULL,
	[ProductPOC] [varchar](50) NULL,
	[ProductSupportEmail] [varchar](60) NULL,
	[ProductComments] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REGION]    Script Date: 3/26/2020 10:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REGION](
	[REG_ID] [int] IDENTITY(1,1) NOT NULL,
	[REG_ISO2_CODE] [char](2) NULL,
	[REG_ISO3_CODE] [char](3) NULL,
	[REGION_SHORT_NAME] [varchar](100) NULL,
	[REGION_OFFICIAL_NAME] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[REG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[REG_ISO3_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[REG_ISO2_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[REGION_SHORT_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 3/26/2020 10:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[ROLE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ROLE_TITLE] [varchar](20) NULL,
	[ROLE_DESC] [varchar](max) NULL,
	[ROLE_ACCESS_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEMP_PATCH_SELECTION]    Script Date: 3/26/2020 10:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEMP_PATCH_SELECTION](
	[TPS_ID] [int] IDENTITY(1,1) NOT NULL,
	[TPS_ProductID] [int] NULL,
	[TPS_EnvironmentID] [int] NULL,
	[TPS_ClientID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TPS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THEME]    Script Date: 3/26/2020 10:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THEME](
	[THM_ID] [int] IDENTITY(1,1) NOT NULL,
	[THM_CODE] [char](5) NULL,
	[THM_NAME] [varchar](100) NULL,
	[THM_DESC] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[THM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[THM_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[THM_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 3/26/2020 10:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[USR_ID] [int] IDENTITY(1,1) NOT NULL,
	[USR_LOGIN_ID] [varchar](50) NOT NULL,
	[USR_NAME] [varchar](50) NULL,
	[USR_EMAIL_ADDRESS] [varchar](100) NULL,
	[USR_CREATED_DATE] [datetime] NULL,
	[USR_GROUP] [int] NULL,
	[USR_ROLE] [int] NULL,
	[USR_ENABLED] [bit] NULL,
	[USR_CURRENT_PASSCODE] [varchar](40) NULL,
	[USR_IS_LOGIN] [bit] NULL,
	[USR_LOGIN_DATE] [datetime] NULL,
	[USR_WRONG_ATTEMPTS] [smallint] NULL,
	[USR_PASSCODE_1] [varchar](40) NULL,
	[USR_PASSCODE_2] [varchar](40) NULL,
	[USR_PASSCODE_3] [varchar](40) NULL,
	[USR_PASSCODE_POLICY] [int] NULL,
	[USR_QUESTION_1] [int] NULL,
	[USR_ANSWER_1] [varchar](40) NULL,
	[USR_QUESTION_2] [int] NULL,
	[USR_ANSWER_2] [varchar](40) NULL,
	[USR_QUESTION_3] [int] NULL,
	[USR_ANSWER_3] [varchar](40) NULL,
	[USR_LST_PCODE_CHG] [datetime] NULL,
	[USR_PREF_LANG] [char](10) NULL,
	[USR_PREF_THEME] [char](5) NULL,
	[USR_REGION] [char](2) NULL,
	[USR_AGREEMENT] [bit] NULL,
UNIQUE NONCLUSTERED 
(
	[USR_LOGIN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_GROUP]    Script Date: 3/26/2020 10:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_GROUP](
	[USRG_ID] [int] IDENTITY(1,1) NOT NULL,
	[USRG_NAME] [varchar](100) NULL,
	[USRG_DESC] [varchar](max) NULL,
	[USRG_ROLE] [int] NULL,
	[USRG_EMAIL] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[USRG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[USRG_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_QUESTION]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_QUESTION](
	[USRQ_ID] [int] IDENTITY(1,1) NOT NULL,
	[USRQ_QUESTION] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[USRQ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[USRQ_QUESTION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACCESS_RIGHT] ADD  DEFAULT ((0)) FOR [ACC_VIEW]
GO
ALTER TABLE [dbo].[ACCESS_RIGHT] ADD  DEFAULT ((0)) FOR [ACC_EDIT]
GO
ALTER TABLE [dbo].[ACCESS_RIGHT] ADD  DEFAULT ((0)) FOR [ACC_DELETE]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT (getdate()) FOR [USR_CREATED_DATE]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((1)) FOR [USR_GROUP]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((1)) FOR [USR_ROLE]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((1)) FOR [USR_ENABLED]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ('Test!123') FOR [USR_CURRENT_PASSCODE]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((0)) FOR [USR_IS_LOGIN]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((0)) FOR [USR_WRONG_ATTEMPTS]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT (getdate()) FOR [USR_LST_PCODE_CHG]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ('en') FOR [USR_PREF_LANG]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ('light') FOR [USR_PREF_THEME]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ('pk') FOR [USR_REGION]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((0)) FOR [USR_AGREEMENT]
GO
ALTER TABLE [dbo].[ClientEnvironment]  WITH CHECK ADD  CONSTRAINT [DBEnvID] FOREIGN KEY([EnvDBServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
GO
ALTER TABLE [dbo].[ClientEnvironment] CHECK CONSTRAINT [DBEnvID]
GO
ALTER TABLE [dbo].[ClientEnvironment]  WITH CHECK ADD  CONSTRAINT [EnvID] FOREIGN KEY([EnvAppServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientEnvironment] CHECK CONSTRAINT [EnvID]
GO
ALTER TABLE [dbo].[DocumentInformation]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
GO
ALTER TABLE [dbo].[DocumentInformation]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_AppServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_AppServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_Client_ID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_Client_ID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_DBServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_DBServerEnvironmentType])
REFERENCES [dbo].[EnvironmentType] ([EnvID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_Product_ID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Environment]  WITH CHECK ADD FOREIGN KEY([ENV_Product_ID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_ClientID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_ClientID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_EnvType])
REFERENCES [dbo].[Environment] ([ENV_ID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_EnvType])
REFERENCES [dbo].[Environment] ([ENV_ID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PATCH]  WITH CHECK ADD FOREIGN KEY([PAT_ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PatchDetail]  WITH CHECK ADD  CONSTRAINT [ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[ClientDetail] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatchDetail] CHECK CONSTRAINT [ClientID]
GO
ALTER TABLE [dbo].[PatchDetail]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PatchDetail]  WITH CHECK ADD  CONSTRAINT [FK_EnvironmentType] FOREIGN KEY([EnvironmentType])
REFERENCES [dbo].[ClientEnvironment] ([EnvID])
GO
ALTER TABLE [dbo].[PatchDetail] CHECK CONSTRAINT [FK_EnvironmentType]
GO
ALTER TABLE [dbo].[ROLE]  WITH CHECK ADD FOREIGN KEY([ROLE_ACCESS_ID])
REFERENCES [dbo].[ACCESS_RIGHT] ([ACC_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_GROUP])
REFERENCES [dbo].[USER_GROUP] ([USRG_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_GROUP])
REFERENCES [dbo].[USER_GROUP] ([USRG_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PASSCODE_POLICY])
REFERENCES [dbo].[PASSCODE_POLICY] ([PASSP_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PASSCODE_POLICY])
REFERENCES [dbo].[PASSCODE_POLICY] ([PASSP_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PREF_LANG])
REFERENCES [dbo].[LANGUAGE] ([LNG_SHORT_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PREF_LANG])
REFERENCES [dbo].[LANGUAGE] ([LNG_SHORT_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PREF_THEME])
REFERENCES [dbo].[THEME] ([THM_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_PREF_THEME])
REFERENCES [dbo].[THEME] ([THM_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_QUESTION_1])
REFERENCES [dbo].[USER_QUESTION] ([USRQ_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_REGION])
REFERENCES [dbo].[REGION] ([REG_ISO2_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_REGION])
REFERENCES [dbo].[REGION] ([REG_ISO2_CODE])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_ROLE])
REFERENCES [dbo].[ROLE] ([ROLE_ID])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([USR_ROLE])
REFERENCES [dbo].[ROLE] ([ROLE_ID])
GO
ALTER TABLE [dbo].[USER_GROUP]  WITH CHECK ADD FOREIGN KEY([USRG_ROLE])
REFERENCES [dbo].[ROLE] ([ROLE_ID])
GO
/****** Object:  StoredProcedure [dbo].[AddPatchDetail]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE PROC [dbo].[AddPatchDetail]
	@PatchTitle varchar(50),
	@PatchDesc varchar(MAX),
	@PatchHotNumber varchar(40),
	@PatchDeployedBy varchar(MAX),
	@PatchCreatedDate DateTime,
	@PatchDeployedDate DateTime,
	@IsQAPassed bit,
	@Remarks_Dependencies varchar(MAX),
	@ClientID int,
	@ProductID int,
	@EnvType int
	As
	BEGIN
	SELECT @EnvType = ENV_ID from Environment WHERE ENV_Client_ID = @ClientID AND ENV_Product_ID = @ProductID AND ENV_AppServerEnvironmentType = @EnvType
		INSERT INTO [dbo].[PATCH]
           ([PAT_Title]
           ,[PAT_Desc]
           ,[PAT_HotNumber]
           ,[PAT_DeployedBy]
           ,[PAT_CreatedDate]
           ,[PAT_DeployedDate]
           ,[PAT_IsQAPassed]
           ,[PAT_Dependency]
           ,[PAT_ClientID]
           ,[PAT_ProductID]
           ,[PAT_EnvType])
     VALUES
           (@PatchTitle
           ,@PatchDesc
           ,Concat('',@PatchHotNumber)
           ,@PatchDeployedBy
           ,@PatchCreatedDate
           ,@PatchDeployedDate
           ,@IsQAPassed
           ,@Remarks_Dependencies
           ,@ClientID
		   ,@ProductID
		   ,@EnvType)
	END;

	        
GO
/****** Object:  StoredProcedure [dbo].[GetPatchListClientWiseWithProductEnvironmentClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetPatchListClientWiseWithProductEnvironmentClient]
	@ProductID int,
	@EnvType int,
	@Client int
	As
	BEGIN
	if(@Client != 0 AND @ProductID = 0 AND @EnvType = 0)
		begin
			--select DISTINCT (SELECT ClientDetail.ClientName FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],(SELECT TOP 1 CLIENT_TYPE.CTYPE_TITLE FROM CLIENT_TYPE WHERE CLIENT_TYPE.CTYPE_ID = (SELECT TOP 1 ClientDetail.ClientType FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],(SELECT TOP 1 EnvironmentType.EnvTitle FROM EnvironmentType WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],(select top 1 ClientDetail.ClientPOCName from ClientDetail where ClientDetail.ClientID = @Client) AS [POC],(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND Environment.ENV_ID = PATCH.PAT_EnvType order by PAT_DeployedDate ) ) order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], Environment.ENV_AppHyperLink As [Link],(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], (SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'dd-MMM-yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'dd-MMM-yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],(SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,(SELECT count(*) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],(SELECT TOP 1 Products.ProductName FROM Products WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],( SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedBy desc) AS [PatchStatus],
			--	Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory] from Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID where Environment.ENV_Client_ID = @Client 
			select DISTINCT (SELECT ClientDetail.ClientName FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],(SELECT TOP 1 CLIENT_TYPE.CTYPE_TITLE FROM CLIENT_TYPE WHERE CLIENT_TYPE.CTYPE_ID = (SELECT TOP 1 ClientDetail.ClientType FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],(SELECT TOP 1 EnvironmentType.EnvTitle FROM EnvironmentType WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],(select top 1 ClientDetail.ClientPOCName from ClientDetail where ClientDetail.ClientID = @Client) AS [POC],(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND Environment.ENV_ID = PATCH.PAT_EnvType order by PAT_DeployedDate ) ) order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], Environment.ENV_AppHyperLink As [Link],(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], (SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'dd-MMM-yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'dd-MMM-yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],(SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,(SELECT count(*) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],(SELECT TOP 1 Products.ProductName FROM Products WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],( SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedBy desc) AS [PatchStatus],
				Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory] from Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID where Environment.ENV_Client_ID = @Client 
		end
	else
		begin
		if(@EnvType != 0 AND @Client = 0 AND @ProductID = 0)
			begin
				select DISTINCT (SELECT TOP 1 ClientDetail.ClientName 
                 FROM ClientDetail 
				 WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],
				(SELECT TOP 1 CLIENT_TYPE.CTYPE_TITLE 
				 FROM CLIENT_TYPE 
				 WHERE CLIENT_TYPE.CTYPE_ID = (SELECT TOP 1 ClientDetail.ClientType 
											   FROM ClientDetail 
											   WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],
				(SELECT TOP 1 EnvironmentType.EnvTitle 
				 FROM EnvironmentType 
				 WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],
				(SELECT TOP 1 ClientDetail.ClientPOCName 
				 from ClientDetail 
				 where ClientDetail.ClientID = Environment.ENV_Client_ID) AS [POC],
				(SELECT TOP 1 PATCH.PAT_HotNumber 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
				       PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
										    order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], 
				 Environment.ENV_AppHyperLink As [Link],
				 (SELECT TOP 1 PATCH.PAT_IsQAPassed 
				  FROM PATCH 
				  WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					    PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
						PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											 FROM Environment 
											 WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												   PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
										     order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], 
				(SELECT TOP 1 PATCH.PAT_DeployedBy 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
											order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], 
				(SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'ddddd MMMMM dd, yyyy') 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
											order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], 
				(SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'ddddd MMMMM dd, yyyy') 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
											order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],
				(SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
											order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,
				(SELECT count(*) 
				 FROM PATCH
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],
				(SELECT TOP 1 Products.ProductName 
				 FROM Products 
				 WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],
				(SELECT TOP 1 PATCH.PAT_Dependency 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
											order by PATCH.PAT_DeployedBy desc) AS [PatchStatus],
				Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory]
				FROM Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID 
				WHERE Environment.ENV_AppServerEnvironmentType = @EnvType
			end
		else
			begin
			if( @ProductID != 0 AND @EnvType = 0 AND @Client = 0 )
				begin
					select DISTINCT (SELECT TOP 1 ClientDetail.ClientName 
				 FROM ClientDetail 
				 WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],
				(SELECT TOP 1 CLIENT_TYPE.CTYPE_TITLE 
				 FROM CLIENT_TYPE 
				 WHERE CLIENT_TYPE.CTYPE_ID = (SELECT TOP 1 ClientDetail.ClientType 
											   FROM ClientDetail 
											   WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],
			    (SELECT TOP 1 EnvironmentType.EnvTitle 
				 FROM EnvironmentType 
				 WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],
				(SELECT TOP 1 ClientDetail.ClientPOCName 
				 FROM ClientDetail 
				 WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) AS [POC],
				(SELECT TOP 1 PATCH.PAT_HotNumber 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
				       PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND 
												  PATCH.PAT_EnvType = Environment.ENV_ID) 
																	   order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], 
				Environment.ENV_AppHyperLink As [Link],
			   (SELECT TOP 1 PATCH.PAT_IsQAPassed 
			    FROM PATCH 
				WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					  PATCH.PAT_EnvType = Environment.ENV_ID 
			    order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], 
				(SELECT TOP 1 PATCH.PAT_DeployedBy 
				 FROM PATCH 
				 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					   PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					   PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
											FROM Environment 
											WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												  PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND 
												  PATCH.PAT_EnvType = Environment.ENV_ID) 
																	   order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], 
			   (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'dd-MMM-yyyy') 
			    FROM PATCH 
				WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					  PATCH.PAT_EnvType = Environment.ENV_ID 
					  order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], 
			   (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'dd-MMM-yyyy') 
			    FROM PATCH 
				WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
										   FROM Environment 
										   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
											     PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND 
												 PATCH.PAT_EnvType = Environment.ENV_ID) 
										   order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],
			  (SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) 
			   FROM PATCH 
			   WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					 PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					 PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
										  FROM Environment 
										  WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
												PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
												PATCH.PAT_EnvType = Environment.ENV_ID ) 
										  order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed], 
			  (SELECT count(*) 
			   FROM PATCH 
			   WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					 PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
					 PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
									      FROM Environment 
										  WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
												PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND 
												PATCH.PAT_EnvType = Environment.ENV_ID)) AS [NumberOfPatches],
			  (SELECT TOP 1 Products.ProductName 
			   FROM Products 
			   WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],
			  (SELECT TOP 1 PATCH.PAT_Dependency 
			   FROM PATCH 
			   WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
					 PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
										  FROM Environment 
										  WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
												PATCH.PAT_ProductID = Environment.ENV_Product_ID  AND 
												PATCH.PAT_EnvType = Environment.ENV_ID) 
										  order by PATCH.PAT_DeployedBy desc) AS [PatchStatus],
						  Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory] 
					from Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID 
					where Environment.ENV_Product_ID = @ProductID
				end
			else
				begin
					if( @ProductID != 0 AND @EnvType != 0 AND @Client = 0 )
					begin
						WITH CTE AS (
							SELECT
								C.ClientID,
								C.ClientName,
								C.ClientType As ClientType,
								(SELECT EnvTitle FROM EnvironmentType WHERE EnvID = E.ENV_AppServerEnvironmentType) As EnvType,
								C.ClientPOCName As [POC],
								(SELECT COUNT(*) FROM PATCH INNER JOIN Environment Ed ON PATCH.PAT_EnvType = Ed.ENV_ID WHERE PATCH.PAT_ProductID = @ProductID AND C.ClientID = @Client AND PATCH.PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE Environment.ENV_AppServerEnvironmentType = @EnvType AND Environment.ENV_Product_ID = @ProductID AND Environment.ENV_Client_ID = @Client )) As NumberOfPatches,
								PATCH.PAT_ProductID As ProductID,
								DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) AS [NumberOfDaysPassed],
								PATCH.PAT_HotNumber As PatchHotNumber,
								E.ENV_AppHyperLink As [Link],
								CASE WHEN PATCH.PAT_IsQAPassed = 'false' then 'Not Tested' WHEN PATCH.PAT_IsQAPassed = 'true' then 'Tested' END As PatchQATested,
								PATCH.PAT_DeployedBy As PatchDeployedBy,
								PATCH.PAT_CreatedDate As PatchCreatedDate,
								PATCH.PAT_DeployedDate As PatchDeployedDate,
								PATCH.PAT_IsQAPassed As PatchIsQAPassed,
								(select TOP 1 PATCH.PAT_Dependency from PATCH order by PAT_DeployedDate desc) As PatchStatus,
								E.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory]
							FROM ((((Environment E INNER JOIN PATCH on E.ENV_ID = PATCH.PAT_EnvType)
									INNER JOIN Products P On E.ENV_Product_ID = P.ProductID)
									INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)
									RIGHT OUTER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID) WHERE PATCH.PAT_ProductID=@ProductID AND PATCH.PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE Environment.ENV_AppServerEnvironmentType = @EnvType AND Environment.ENV_Product_ID = @ProductID AND Environment.ENV_Client_ID = C.ClientID  )
						    
						)		  -- CTE END
						select C.ClientName,
							(SELECT CTYPE_TITLE FROM CLIENT_TYPE WHERE CTYPE_ID = C.ClientType) As [ClientType],
							MAX(CTE.EnvType) AS [EnvType],
							MAX(CTE.POC) AS [POC],
							MAX(CTE.PatchHotNumber) As [PatchHotNumber],
							MAX(CTE.Link) As [Link],
							MAX(CTE.PatchQATested) As [PatchQATested],
							MIN(CTE.PatchDeployedBy) As [PatchDeployedBy],
							MAX(CTE.PatchCreatedDate) As [PatchCreatedDate],
							MAX(CTE.PatchDeployedDate) As [PatchDeployedDate],
							MIN(CTE.NumberOfDaysPassed) As [NumberOfDaysPassed],
							Count(CTE.NumberOfPatches) As [NumberOfPatches],
							MAX(CTE.ProductID) As [ProductID],
							MAX(CTE.PatchStatus) As [PatchStatus],
							MAX(CTE.WorkingDirectory) As [WorkingDirectory]
						FROM CTE LEFT JOIN ClientDetail C on CTE.ClientID = C.ClientID 
						group by C.ClientName, C.ClientType
						--select Cla from ClientDetail C LEFT OUTER JOIN CTE on CTE.ClientID = C.ClientID group by C.ClientName
						--select * from CTE
					end
					else
						begin
							if( @ProductID != 0 AND @EnvType != 0 AND @Client != 0 )
							begin
								select DISTINCT (SELECT ClientDetail.ClientName FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],(SELECT CLIENT_TYPE.CTYPE_TITLE FROM CLIENT_TYPE WHERE CLIENT_TYPE.CTYPE_ID = (SELECT ClientDetail.ClientType FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],(SELECT EnvironmentType.EnvTitle FROM EnvironmentType WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],(select top 1 ClientDetail.ClientPOCName from ClientDetail where ClientDetail.ClientID = Environment.ENV_Client_ID) AS [POC],(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], Environment.ENV_AppHyperLink As [Link],(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], (SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'ddddd MMMMM dd, yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'ddddd MMMMM dd, yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],(SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = PAT_ClientID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,(SELECT count(*) FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = PAT_ClientID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],(SELECT Products.ProductName FROM Products WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],( SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedBy desc) AS [PatchStatus], Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory] from Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID where Environment.ENV_Product_ID = @ProductID AND Environment.ENV_Client_ID = @Client AND Environment.ENV_ID = (SELECT ENV_ID FROM Environment WHERE Environment.ENV_AppServerEnvironmentType = @EnvType AND Environment.ENV_Client_ID = @Client AND Environment.ENV_Product_ID = @ProductID)
							end 
							else
							begin
							if(@ProductID = 0 AND @EnvType = 0 AND @Client = 0)
								BEGIN
										SELECT DISTINCT (SELECT TOP 1 ClientDetail.ClientName 
										FROM ClientDetail 
										WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],
									   (SELECT TOP 1 CLIENT_TYPE.CTYPE_TITLE 
										FROM CLIENT_TYPE 
										WHERE CLIENT_TYPE.CTYPE_ID = (SELECT TOP 1 ClientDetail.ClientType 
																	  FROM ClientDetail 
																	  WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],
									   (SELECT TOP 1 EnvironmentType.EnvTitle 
										FROM EnvironmentType 
										WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],
									   (SELECT TOP 1 ClientDetail.ClientPOCName 
										FROM ClientDetail 
										WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) AS [POC],
									   (SELECT TOP 1 PATCH.PAT_HotNumber 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
																   order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], 
										Environment.ENV_AppHyperLink As [Link],
									   (SELECT TOP 1 PATCH.PAT_IsQAPassed 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
																   order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], 
									   (SELECT TOP 1 PATCH.PAT_DeployedBy 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
																   order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], 
									   (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'dd-MMM-yyyy') 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
													  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
												order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], 
									   (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'ddddd MMMMM dd, yyyy') 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
																   order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],
									   (SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) 
										FROM PATCH 
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
																   order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,
									   (SELECT TOP 1 count(*) 
										FROM PATCH
										WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
											  PATCH.PAT_ProductID = Environment.ENV_Product_ID AND 
											  PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
																   FROM Environment 
																   WHERE Environment.ENV_Client_ID = PAT_ClientID AND 
																		 PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],
										(SELECT TOP 1 Products.ProductName 
										 FROM Products 
										 WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],
										(SELECT TOP 1 PATCH.PAT_Dependency 
										 FROM PATCH 
										 WHERE PATCH.PAT_ClientID = Environment.ENV_Client_ID AND 
												PATCH.PAT_EnvType = (SELECT TOP 1 Environment.ENV_ID 
												FROM Environment 
												WHERE Environment.ENV_Client_ID = Environment.ENV_Client_ID AND 
													  PATCH.PAT_ProductID = Environment.ENV_Product_ID ) 
												order by PATCH.PAT_DeployedBy desc) AS [PatchStatus],
										Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory]
									FROM Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID 
								end
							else
								begin
									select DISTINCT (SELECT ClientDetail.ClientName FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID) As [ClientName],(SELECT CLIENT_TYPE.CTYPE_TITLE FROM CLIENT_TYPE WHERE CLIENT_TYPE.CTYPE_ID = (SELECT ClientDetail.ClientType FROM ClientDetail WHERE ClientDetail.ClientID = Environment.ENV_Client_ID)) As [ClientType],(SELECT EnvironmentType.EnvTitle FROM EnvironmentType WHERE EnvironmentType.EnvID = ENV_AppServerEnvironmentType) As [EnvType],(select top 1 ClientDetail.ClientPOCName from ClientDetail where ClientDetail.ClientID = @Client) AS [POC],(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchHotNumber], Environment.ENV_AppHyperLink As [Link],(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchQATested], (SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedBy], (SELECT TOP 1 FORMAT(PATCH.PAT_CreatedDate,'ddddd MMMMM dd, yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchCreatedDate], (SELECT TOP 1 FORMAT(PATCH.PAT_DeployedDate,'ddddd MMMMM dd, yyyy') FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [PatchDeployedDate],(SELECT TOP 1 DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedDate desc) AS [NumberOfDaysPassed] ,(SELECT count(*) FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID )) AS [NumberOfPatches],(SELECT Products.ProductName FROM Products WHERE ProductID = Environment.ENV_Product_ID) AS [ProductID],( SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = @Client AND PATCH.PAT_EnvType = (SELECT Environment.ENV_ID FROM Environment WHERE Environment.ENV_Client_ID = @Client AND PATCH.PAT_ProductID = Environment.ENV_Product_ID ) order by PATCH.PAT_DeployedBy desc) AS [PatchStatus], Environment.ENV_AppServerWorkingDirectoryLocation AS [WorkingDirectory] from Environment INNER JOIN PATCH ON Environment.ENV_Client_ID = PATCH.PAT_ClientID where Environment.ENV_Client_ID = @Client AND Environment.ENV_AppServerEnvironmentType = @EnvType
								end
							end
						end
				end
			end
		end

	END


GO
/****** Object:  StoredProcedure [dbo].[GetUpdatedPatchListClientWise]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUpdatedPatchListClientWise]
	@ProductID int,
	@EnvType int
	As
	BEGIN
WITH CTE AS (
	SELECT
	C.ClientID,
	C.ClientName,
	C.ClientType As ClientType,
	(SELECT EnvTitle FROM EnvironmentType WHERE EnvID = E.ENV_AppServerEnvironmentType) As EnvType,
	C.ClientPOCName As [POC],
	(SELECT COUNT(*) FROM PATCH INNER JOIN Environment Ed ON PATCH.PAT_EnvType = Ed.ENV_ID WHERE PATCH.PAT_ProductID = @ProductID AND PATCH.PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE Environment.ENV_AppServerEnvironmentType = @EnvType AND Environment.ENV_Product_ID = @ProductID AND Environment.ENV_Client_ID = C.ClientID )) As NumberOfPatches,
	PATCH.PAT_ProductID As ProductID,
	DATEDIFF(DAY,PATCH.PAT_DeployedDate,GETDATE()) AS [NumberOfDaysPassed],
	PATCH.PAT_HotNumber As PatchHotNumber,
	E.ENV_AppHyperLink As [Link],
	CASE WHEN PATCH.PAT_IsQAPassed = 'false' then 'Not Tested' WHEN PATCH.PAT_IsQAPassed = 'true' then 'Tested' END As PatchQATested,
	PATCH.PAT_DeployedBy As PatchDeployedBy,
	PATCH.PAT_CreatedDate As PatchCreatedDate,
	PATCH.PAT_DeployedDate As PatchDeployedDate,
	PATCH.PAT_IsQAPassed As PatchIsQAPassed,
	(select TOP 1 PATCH.PAT_Dependency from PATCH order by PAT_DeployedDate desc) As PatchStatus
FROM ((((Environment E INNER JOIN PATCH on E.ENV_ID = PATCH.PAT_EnvType)
		 INNER JOIN Products P On E.ENV_Product_ID = P.ProductID)
		 INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)
		 RIGHT OUTER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID) WHERE PATCH.PAT_ProductID=@ProductID AND PATCH.PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE Environment.ENV_AppServerEnvironmentType = @EnvType AND Environment.ENV_Product_ID = @ProductID AND Environment.ENV_Client_ID = C.ClientID )
)		  -- CTE END
select C.ClientName,
	   (SELECT CTYPE_TITLE FROM CLIENT_TYPE WHERE CTYPE_ID = C.ClientType) As [ClientType],
	   MAX(CTE.EnvType) AS [EnvType],
	   MAX(CTE.POC) AS [POC],
	   MAX(cast(CTE.PatchHotNumber as bigint)) As [PatchHotNumber],
	   MAX(CTE.Link) As [Link],
	   MAX(CTE.PatchQATested) As [PatchQATested],
	   MIN(CTE.PatchDeployedBy) As [PatchDeployedBy],
	   MAX(CTE.PatchCreatedDate) As [PatchCreatedDate],
	   MAX(CTE.PatchDeployedDate) As [PatchDeployedDate],
	   MIN(CTE.NumberOfDaysPassed) As [NumberOfDaysPassed],
	   Count(CTE.NumberOfPatches) As [NumberOfPatches],
	   MAX(CTE.ProductID) As [ProductID],
	   MAX(CTE.PatchStatus) As [PatchStatus]
	FROM CTE FULL JOIN ClientDetail C on CTE.ClientID = C.ClientID 
	group by C.ClientName, C.ClientType
--select Cla from ClientDetail C LEFT OUTER JOIN CTE on CTE.ClientID = C.ClientID group by C.ClientName
--select * from CTE 
	END


GO
/****** Object:  StoredProcedure [dbo].[spCreateNewClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[spCreateNewClient]
  @ClientName varchar(40),
  @ClientType text,
  @ClientDesc text,
  @ClientStill bit,
  @ClientPOCName varchar(40),
  @ClientPOCContact varchar(40),
  @ClientPOCEmail varchar(60)
  AS
  BEGIN
  INSERT into dbo.ClientDetail(ClientName, ClientType, ClientDesc, ClientStill,
  ClientPOCName, ClientPOCContact, ClientPOCEmail) VALUES (@ClientName, @ClientType,
  @ClientDesc, @ClientStill, @ClientPOCName, @ClientPOCContact, @ClientPOCEmail)
  END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteClient]
	@ClientID int
AS
BEGIN 
	DELETE FROM PATCH WHERE PAT_ClientID = @ClientID
	DELETE FROM Environment WHERE ENV_Client_ID = @ClientID
	DELETE FROM ClientDetail WHERE ClientID = @ClientID
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteClientType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteClientType]
	@ClientTypeID int
  AS
  BEGIN
	DELETE FROM [CLIENT_TYPE] WHERE [CTYPE_ID] = @ClientTypeID
  END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEnvironmentType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteEnvironmentType]
	@EnvTypeID int

As
BEGIN
		DELETE FROM [EnvironmentType] WHERE [EnvID] = @EnvTypeID
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProduct]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteProduct]
	@ProductID int
AS
BEGIN
	DELETE FROM Products WHERE [ProductID] = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteRelease]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteRelease]
	@PatchTitle varchar(50),
	@PatchHotNumber varchar(50),
	@PatchCreatedDate datetime,
	@PatchDeployedDate datetime,
	@ClientID int,
	@ProductID int,
	@EnvType varchar(40)
	As
BEGIN
	DELETE FROM PATCH WHERE (PAT_ClientID = @ClientID AND PAT_ProductID = @ProductID AND PAT_EnvType = @EnvType AND PAT_HotNumber = @PatchHotNumber)  OR (PAT_Title = @PatchTitle AND PAT_HotNumber = @PatchHotNumber AND PAT_CreatedDate = @PatchCreatedDate AND PAT_DeployedDate = @PatchDeployedDate AND PAT_ClientID = @ClientID AND PAT_ProductID = @ProductID AND PAT_EnvType = @EnvType)
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteUser]
	@UserID int
AS
BEGIN
	DELETE FROM [dbo].[USER] WHERE [USER_ID] = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUserRole]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDeleteUserRole]
	@UserRoleID int
AS
BEGIN
DELETE FROM [dbo].[ROLES]
      WHERE ROLE_ID = @UserRoleID
END
GO
/****** Object:  StoredProcedure [dbo].[spDifferentAppServers]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[spDifferentAppServers]
	@ProductID int,
	@EnvID int,
	@ClientID int
AS
BEGIN
SELECT DISTINCT
       PAT_ClientID
      ,[PAT_ProductID]
      ,E.ENV_AppServerEnvironmentType
  FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
  END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetAllClient] 
AS
BEGIN
SELECT [ClientID]
      ,[ClientName]
      ,(SELECT CTYPE_TITLE FROM CLIENT_TYPE WHERE CTYPE_ID = [ClientType]) As [ClientType]
      ,[ClientDesc]
      ,[ClientStill]
      ,[ClientPOCName]
      ,[ClientPOCContact]
      ,[ClientPOCEmail]
  FROM [ClientDetail]
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEnvironment]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetAllEnvironment]
AS
BEGIN
	SELECT [ENV_ID]
      ,(SELECT ClientDetail.ClientName FROM ClientDetail WHERE ClientDetail.ClientID = ENV_Client_ID) As [ENV_Client_ID]
	  ,(SELECT ProductName FROM Products WHERE Products.ProductID = ENV_Product_ID) As [ENV_Product_ID]
	  ,(SELECT EnvTitle FROM EnvironmentType WHERE EnvID = ENV_AppServerEnvironmentType) As [ENV_AppServerEnvironmentType]
	  ,(SELECT EnvTitle FROM EnvironmentType WHERE EnvID = ENV_DBServerEnvironmentType) As [ENV_DBServerEnvironmentType]
      ,[ENV_AppServerName]
      ,[ENV_AppServerOS]
      ,[ENV_AppServerOSBuild]
      ,[ENV_AppServerIsX86Version]
      ,[ENV_AppServerIsVirtual]
      ,[ENV_AppServerProcessor]
      ,[ENV_AppServerMemory]
      ,[ENV_AppServerWebBrowser]
      ,[ENV_AppServerWebBrowserVersion]
      ,[ENV_AppServerWorkingDirectoryLocation]
      ,[ENV_AppHyperLink]
      ,[ENV_AppServerIP]
      ,[ENV_AppServerPort]
      ,[ENV_AppServerDependency]
      ,[ENV_DBServerName]
      ,[ENV_DBServerOS]
      ,[ENV_DBServerOSBuild]
      ,[ENV_DBServerIsX86Version]
      ,[ENV_DBServerIsVirtual]
      ,[ENV_DBServerProcessor]
      ,[ENV_DBServerMemory]
      ,[ENV_DBServerDirectoryLocation]
      ,[ENV_DBMDFFileLocation]
      ,[ENV_DBMDFFileSize]
      ,[ENV_DBLDFFileLocation]
      ,[ENV_DBLDFFileSize]
      ,[ENV_DBServerIP]
      ,[ENV_DBServerPort]
      ,[ENV_DBServerDependency] FROM Environment
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllUser]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[spGetAllUser]
AS
BEGIN
SELECT [USER_ID]
      ,[USER_NAME]
      ,(select [ROLE_TITLE] FROM ROLES WHERE [ROLE_ID] = [USER_ROLE]) As USER_ROLE
      ,[USER_STATUS]
      ,[USER_PASSCODE]
      ,[USER_LOGINDATE]
      ,[USER_WRONG_ATTEMPTS]
  FROM [Release_Management_Portal].[dbo].[USER]
END
GO
/****** Object:  StoredProcedure [dbo].[spGetClientEnvironmentByProduct]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROC [dbo].[spGetClientEnvironmentByProduct]
	@ProductID int,
	@EnvType int,
	@ClientID int
	As
	BEGIN
	IF @ProductID = 0 AND @EnvType = 0 AND @ClientID = 0
		SELECT C.ClientName, E.ENV_AppServerName, (select Products.ProductName from Products where Products.ProductID = E.ENV_Product_ID) AS ENV_Product_ID, (select EnvTitle from EnvironmentType where EnvID = E.ENV_AppServerEnvironmentType) AS ENV_AppServerEnvironmentType,
	   E.ENV_AppServerIsX86Version, E.ENV_AppServerIsVirtual, E.ENV_AppServerMemory,
	   E.ENV_AppServerProcessor, E.ENV_AppServerOSBuild, E.ENV_AppServerOS, E.ENV_AppServerWebBrowser,
	   E.ENV_AppServerWebBrowserVersion, E.ENV_AppHyperLink,E.ENV_AppServerWorkingDirectoryLocation, E.ENV_AppServerIP,
	   E.ENV_AppServerPort, E.ENV_AppServerDependency,
	   E.ENV_DBServerName, E.ENV_DBServerEnvironmentType, E.ENV_DBServerIsX86Version,
	   E.ENV_DBServerIsVirtual, E.ENV_DBServerMemory, E.ENV_DBServerProcessor, E.ENV_DBServerOSBuild,
	   E.ENV_DBServerOS, E.ENV_DBServerDirectoryLocation, E.ENV_DBMDFFileLocation,
	   E.ENV_DBMDFFileSize, E.ENV_DBLDFFileLocation, E.ENV_DBLDFFileSize, E.ENV_DBServerIP,
	   E.ENV_DBServerPort, E.ENV_DBServerDependency		
  FROM [Environment] E 
  INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID
	ELSE
		IF @ProductID != 0 AND @EnvType = 0 AND @ClientID = 0
SELECT C.ClientName, E.ENV_AppServerName, (select Products.ProductName from Products where Products.ProductID = E.ENV_Product_ID) AS ENV_Product_ID, (select EnvTitle from EnvironmentType where EnvID = E.ENV_AppServerEnvironmentType) AS ENV_AppServerEnvironmentType,
	   E.ENV_AppServerIsX86Version, E.ENV_AppServerIsVirtual, E.ENV_AppServerMemory,
	   E.ENV_AppServerProcessor, E.ENV_AppServerOSBuild, E.ENV_AppServerOS, E.ENV_AppServerWebBrowser,
	   E.ENV_AppServerWebBrowserVersion, E.ENV_AppHyperLink,E.ENV_AppServerWorkingDirectoryLocation, E.ENV_AppServerIP,
	   E.ENV_AppServerPort, E.ENV_AppServerDependency,
	   E.ENV_DBServerName, E.ENV_DBServerEnvironmentType, E.ENV_DBServerIsX86Version,
	   E.ENV_DBServerIsVirtual, E.ENV_DBServerMemory, E.ENV_DBServerProcessor, E.ENV_DBServerOSBuild,
	   E.ENV_DBServerOS, E.ENV_DBServerDirectoryLocation, E.ENV_DBMDFFileLocation,
	   E.ENV_DBMDFFileSize, E.ENV_DBLDFFileLocation, E.ENV_DBLDFFileSize, E.ENV_DBServerIP,
	   E.ENV_DBServerPort, E.ENV_DBServerDependency		
  FROM [Environment] E 
  INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID WHERE E.ENV_Product_ID = @ProductID

  ELSE IF @EnvType != 0 AND @ProductID = 0 AND @ClientID = 0

SELECT C.ClientName, E.ENV_AppServerName, (select Products.ProductName from Products where Products.ProductID = E.ENV_Product_ID) AS ENV_Product_ID, (select EnvTitle from EnvironmentType where EnvID = E.ENV_AppServerEnvironmentType) AS ENV_AppServerEnvironmentType,
	   E.ENV_AppServerIsX86Version, E.ENV_AppServerIsVirtual, E.ENV_AppServerMemory,
	   E.ENV_AppServerProcessor, E.ENV_AppServerOSBuild, E.ENV_AppServerOS, E.ENV_AppServerWebBrowser,
	   E.ENV_AppServerWebBrowserVersion, E.ENV_AppHyperLink,E.ENV_AppServerWorkingDirectoryLocation, E.ENV_AppServerIP,
	   E.ENV_AppServerPort, E.ENV_AppServerDependency,
	   E.ENV_DBServerName, E.ENV_DBServerEnvironmentType, E.ENV_DBServerIsX86Version,
	   E.ENV_DBServerIsVirtual, E.ENV_DBServerMemory, E.ENV_DBServerProcessor, E.ENV_DBServerOSBuild,
	   E.ENV_DBServerOS, E.ENV_DBServerDirectoryLocation, E.ENV_DBMDFFileLocation,
	   E.ENV_DBMDFFileSize, E.ENV_DBLDFFileLocation, E.ENV_DBLDFFileSize, E.ENV_DBServerIP,
	   E.ENV_DBServerPort, E.ENV_DBServerDependency		
  FROM [Environment] E 
  INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID WHERE ENV_AppServerEnvironmentType = @EnvType

  ELSE IF @ClientID != 0 AND @EnvType = 0 AND @ProductID = 0

SELECT C.ClientName, E.ENV_AppServerName, (select Products.ProductName from Products where Products.ProductID = E.ENV_Product_ID) AS ENV_Product_ID, (select EnvTitle from EnvironmentType where EnvID = E.ENV_AppServerEnvironmentType) AS ENV_AppServerEnvironmentType,
	   E.ENV_AppServerIsX86Version, E.ENV_AppServerIsVirtual, E.ENV_AppServerMemory,
	   E.ENV_AppServerProcessor, E.ENV_AppServerOSBuild, E.ENV_AppServerOS, E.ENV_AppServerWebBrowser,
	   E.ENV_AppServerWebBrowserVersion, E.ENV_AppHyperLink,E.ENV_AppServerWorkingDirectoryLocation, E.ENV_AppServerIP,
	   E.ENV_AppServerPort, E.ENV_AppServerDependency,
	   E.ENV_DBServerName, E.ENV_DBServerEnvironmentType, E.ENV_DBServerIsX86Version,
	   E.ENV_DBServerIsVirtual, E.ENV_DBServerMemory, E.ENV_DBServerProcessor, E.ENV_DBServerOSBuild,
	   E.ENV_DBServerOS, E.ENV_DBServerDirectoryLocation, E.ENV_DBMDFFileLocation,
	   E.ENV_DBMDFFileSize, E.ENV_DBLDFFileLocation, E.ENV_DBLDFFileSize, E.ENV_DBServerIP,
	   E.ENV_DBServerPort, E.ENV_DBServerDependency		
  FROM [Environment] E 
  INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID WHERE E.ENV_Client_ID = @ClientID

  ELSE 

  SELECT C.ClientName, E.ENV_AppServerName, (select Products.ProductName from Products where Products.ProductID = E.ENV_Product_ID) AS ENV_Product_ID, (select EnvTitle from EnvironmentType where EnvID = E.ENV_AppServerEnvironmentType) AS ENV_AppServerEnvironmentType,
	   E.ENV_AppServerIsX86Version, E.ENV_AppServerIsVirtual, E.ENV_AppServerMemory,
	   E.ENV_AppServerProcessor, E.ENV_AppServerOSBuild, E.ENV_AppServerOS, E.ENV_AppServerWebBrowser,
	   E.ENV_AppServerWebBrowserVersion, E.ENV_AppHyperLink,E.ENV_AppServerWorkingDirectoryLocation, E.ENV_AppServerIP,
	   E.ENV_AppServerPort, E.ENV_AppServerDependency,
	   E.ENV_DBServerName, E.ENV_DBServerEnvironmentType, E.ENV_DBServerIsX86Version,
	   E.ENV_DBServerIsVirtual, E.ENV_DBServerMemory, E.ENV_DBServerProcessor, E.ENV_DBServerOSBuild,
	   E.ENV_DBServerOS, E.ENV_DBServerDirectoryLocation, E.ENV_DBMDFFileLocation,
	   E.ENV_DBMDFFileSize, E.ENV_DBLDFFileLocation, E.ENV_DBLDFFileSize, E.ENV_DBServerIP,
	   E.ENV_DBServerPort, E.ENV_DBServerDependency		
  FROM [Environment] E 
  INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID WHERE ENV_AppServerEnvironmentType = @EnvType AND E.ENV_Product_ID = @ProductID AND E.ENV_Client_ID = @ClientID

  END
GO
/****** Object:  StoredProcedure [dbo].[spGetClientType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetClientType]
  AS
  BEGIN
	SELECT [CTYPE_ID]
      ,[CTYPE_TITLE]
      ,[CTYPE_DESCRIPTION]
  FROM [CLIENT_TYPE]
  END
GO
/****** Object:  StoredProcedure [dbo].[spGetEnvTypeList]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetEnvTypeList]
AS
BEGIN
SELECT *
  FROM [dbo].[EnvironmentType]
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPatchList]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[spGetPatchList]
	@ProductID int,
	@EnvID int,
	@ClientID int
	AS
  BEGIN
	--IF STATEMENT # 1 
	if(@ProductID = 0 AND @EnvID = 0 AND @ClientID = 0)
		BEGIN
			PRINT('IF # 1 :=')
		END
	else
		BEGIN
			--IF STATEMENT # 2 
			if(@ProductID != 0 AND @EnvID = 0 AND @ClientID = 0)
				BEGIN
					PRINT('IF # 2 :=')
				END
			else
				BEGIN
					--IF STATEMENT # 3
					if(@ProductID = 0 AND @EnvID != 0 AND @ClientID = 0)
						BEGIN
							PRINT('IF # 3 :=')
						END
					else
						BEGIN
							--IF STATEMENT # 4 
							if(@ProductID = 0 AND @EnvID = 0 AND @ClientID != 0)
								BEGIN
									PRINT('IF # 4 :=')
								END
							else
								BEGIN
									--IF STATEMENT # 5 
									if(@ProductID != 0 AND @EnvID != 0 AND @ClientID = 0)
										BEGIN
											PRINT('IF # 5 :=')
										END
									else
										BEGIN
											--IF STATEMENT # 6
											if(@ProductID != 0 AND @EnvID = 0 AND @ClientID != 0)
												BEGIN
													PRINT('IF # 6 :=')
												END
											else
												BEGIN
													--IF STATEMENT # 7
													if(@ProductID = 0 AND @EnvID != 0 AND @ClientID != 0)
														BEGIN
															PRINT('IF # 7 := Product ID: ')
														END
													else
														BEGIN
															--IF STATEMENT # 8
															if(@ProductID != 0 AND @EnvID != 0 AND @ClientID != 0)
																BEGIN
																	PRINT('IF # 8 :=')
																END
															else
																BEGIN
																	PRINT('Unknown Parameter Value!')
																END
														END
												END
										END
								END
						END
				END
		END
  END
GO
/****** Object:  StoredProcedure [dbo].[spGetPatchListThroughCurser]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetPatchListThroughCurser]
	@ProductID int,
	@EnvID int,
	@ClientID int
	AS
DECLARE 
    @ProductCursor varchar(MAX), 
    @EnvironmentCursor varchar(MAX),
	@ClientCursor varchar(MAX);
  BEGIN
	--IF STATEMENT # 1 
	if(@ProductID = 0 AND @EnvID = 0 AND @ClientID = 0)
		BEGIN
			PRINT('IF # 1 := Product ID: ')
			DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
				SELECT DISTINCT
					[PAT_ProductID] AS ProductID,
					E.ENV_AppServerEnvironmentType AS EnvType,
					[PAT_ClientID] AS ClientID
				FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
				ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
				TRUNCATE TABLE TEMP_PATCH_SELECTION;
			OPEN CURSOR_DIFF_ENV
			Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
			WHILE @@fetch_status = 0
				BEGIN 
					--SELECT @ProductCursor AS [ProductID]
					INSERT INTO [TEMP_PATCH_SELECTION]
					([TPS_ProductID]
					,[TPS_EnvironmentID]
					,[TPS_ClientID])
					VALUES
					 (@ProductCursor,
					  @EnvironmentCursor,
					  @ClientCursor);
					PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
					fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
				END
				CLOSE CURSOR_DIFF_ENV
				SELECT  C.ClientName
					,CT.CTYPE_TITLE As ClientType
					,PD.ProductName As [ProductID]
					,ET.EnvTitle As EnvType
					,C.ClientPOCName As [POC]
					,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
					,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
					,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
					,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
					,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
					,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
					,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
					,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
					,E.ENV_AppHyperLink As [Link]
					,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
				FROM [TEMP_PATCH_SELECTION] TPS 
				INNER JOIN Environment E 
				ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
				   TPS.[TPS_ClientID] = E.ENV_Client_ID 
				INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
				INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
				INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
				INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
		END
	else
		BEGIN
			--IF STATEMENT # 2 
			if(@ProductID != 0 AND @EnvID = 0 AND @ClientID = 0)
				BEGIN
					PRINT('IF # 2 := Product ID: ')
					DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
						SELECT DISTINCT
							[PAT_ProductID] AS ProductID,
							E.ENV_AppServerEnvironmentType AS EnvType,
							[PAT_ClientID] AS ClientID
						FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
						WHERE [PAT_ProductID] = @ProductID
						ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
					TRUNCATE TABLE TEMP_PATCH_SELECTION;
					OPEN CURSOR_DIFF_ENV
					Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
					WHILE @@fetch_status = 0
						BEGIN 
							--SELECT @ProductCursor AS [ProductID]
							INSERT INTO [TEMP_PATCH_SELECTION]
							([TPS_ProductID]
							,[TPS_EnvironmentID]
							,[TPS_ClientID])
							VALUES
							(@ProductCursor,
							 @EnvironmentCursor,
							 @ClientCursor);
							PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
							fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
						END
					CLOSE CURSOR_DIFF_ENV
					SELECT  C.ClientName
							,CT.CTYPE_TITLE As ClientType
							,PD.ProductName As [ProductID]
							,ET.EnvTitle As EnvType
							,C.ClientPOCName As [POC]
							,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
							,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
							,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
							,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
							,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
							,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
							,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
							,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
							,E.ENV_AppHyperLink As [Link]
							,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
					FROM [TEMP_PATCH_SELECTION] TPS 
					INNER JOIN Environment E 
					ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
					   TPS.[TPS_ClientID] = E.ENV_Client_ID 
					INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
					INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
					INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
					INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
				END
			else
				BEGIN
					--IF STATEMENT # 3
					if(@ProductID = 0 AND @EnvID != 0 AND @ClientID = 0)
						BEGIN
							PRINT('IF # 3 := Product ID: ')
							BEGIN
								DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
									SELECT DISTINCT
										[PAT_ProductID] AS ProductID,
										E.ENV_AppServerEnvironmentType AS EnvType,
										[PAT_ClientID] AS ClientID
									FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
									WHERE E.ENV_AppServerEnvironmentType = @EnvID
									ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
								TRUNCATE TABLE TEMP_PATCH_SELECTION;
								OPEN CURSOR_DIFF_ENV
								Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
								WHILE @@fetch_status = 0
									BEGIN 
										--SELECT @ProductCursor AS [ProductID]
										INSERT INTO [TEMP_PATCH_SELECTION]
										([TPS_ProductID]
										,[TPS_EnvironmentID]
										,[TPS_ClientID])
										VALUES
										(@ProductCursor,
										 @EnvironmentCursor,
										 @ClientCursor);
										PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
										fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
									END
								CLOSE CURSOR_DIFF_ENV
								SELECT  C.ClientName
										,CT.CTYPE_TITLE As ClientType
										,PD.ProductName As [ProductID]
										,ET.EnvTitle As EnvType
										,C.ClientPOCName As [POC]
										,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
										,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
										,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
										,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
										,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
										,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
										,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
										,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
										,E.ENV_AppHyperLink As [Link]
										,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
								FROM [TEMP_PATCH_SELECTION] TPS 
								INNER JOIN Environment E 
								ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
								   TPS.[TPS_ClientID] = E.ENV_Client_ID 
								INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
								INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
								INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
								INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
							END
						END
					else
						BEGIN
							--IF STATEMENT # 4 
							if(@ProductID = 0 AND @EnvID = 0 AND @ClientID != 0)
								BEGIN
									PRINT('IF # 4 := Product ID: ')
									DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
										SELECT DISTINCT
											[PAT_ProductID] AS ProductID,
											E.ENV_AppServerEnvironmentType AS EnvType,
											[PAT_ClientID] AS ClientID
										FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
										WHERE [PAT_ClientID] = @ClientID
										ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
									TRUNCATE TABLE TEMP_PATCH_SELECTION;
									OPEN CURSOR_DIFF_ENV
									Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
									WHILE @@fetch_status = 0
										BEGIN 
											--SELECT @ProductCursor AS [ProductID]
											INSERT INTO [TEMP_PATCH_SELECTION]
											([TPS_ProductID]
											,[TPS_EnvironmentID]
											,[TPS_ClientID])
											VALUES
											(@ProductCursor,
											@EnvironmentCursor,
											@ClientCursor);
											PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
											fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
										END
									CLOSE CURSOR_DIFF_ENV
									SELECT  C.ClientName
											,CT.CTYPE_TITLE As ClientType
											,PD.ProductName As [ProductID]
											,ET.EnvTitle As EnvType
											,C.ClientPOCName As [POC]
											,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
											,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
											,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
											,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
											,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
											,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
											,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
											,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
											,E.ENV_AppHyperLink As [Link]
											,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
									FROM [TEMP_PATCH_SELECTION] TPS 
									INNER JOIN Environment E 
									ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
									   TPS.[TPS_ClientID] = E.ENV_Client_ID 
									INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
									INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
									INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
									INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
								END
							else
								BEGIN
									--IF STATEMENT # 5 
									if(@ProductID != 0 AND @EnvID != 0 AND @ClientID = 0)
										BEGIN
											PRINT('IF # 5 := Product ID: ')
											DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
												SELECT DISTINCT
													[PAT_ProductID] AS ProductID,
													E.ENV_AppServerEnvironmentType AS EnvType,
													[PAT_ClientID] AS ClientID
													FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
													WHERE [PAT_ProductID] = @ProductID AND
														  E.ENV_AppServerEnvironmentType = @EnvID
												ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
											TRUNCATE TABLE TEMP_PATCH_SELECTION;
											OPEN CURSOR_DIFF_ENV
											Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
											WHILE @@fetch_status = 0
												BEGIN 
													--SELECT @ProductCursor AS [ProductID]
													INSERT INTO [TEMP_PATCH_SELECTION]
													([TPS_ProductID]
													,[TPS_EnvironmentID]
													,[TPS_ClientID])
													VALUES
													(@ProductCursor,
													 @EnvironmentCursor,
													 @ClientCursor);
													PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
													fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
												END
											CLOSE CURSOR_DIFF_ENV
											SELECT  C.ClientName
												,CT.CTYPE_TITLE As ClientType
												,PD.ProductName As [ProductID]
												,ET.EnvTitle As EnvType
												,C.ClientPOCName As [POC]
												,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
												,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
												,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
												,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
												,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
												,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
												,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
												,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
												,E.ENV_AppHyperLink As [Link]
												,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
											FROM [TEMP_PATCH_SELECTION] TPS 
											INNER JOIN Environment E 
											ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
											   TPS.[TPS_ClientID] = E.ENV_Client_ID 
											INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
											INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
											INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
											INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
										END
									else
										BEGIN
											--IF STATEMENT # 6
											if(@ProductID != 0 AND @EnvID = 0 AND @ClientID != 0)
												BEGIN
													PRINT('IF # 6 := Product ID: ')
													DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
														SELECT DISTINCT
															[PAT_ProductID] AS ProductID,
															E.ENV_AppServerEnvironmentType AS EnvType,
															[PAT_ClientID] AS ClientID
														FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
														WHERE [PAT_ProductID] = @ProductID AND
															  [PAT_ClientID] = @ClientID
														ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
													TRUNCATE TABLE TEMP_PATCH_SELECTION;
													OPEN CURSOR_DIFF_ENV
													Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
													WHILE @@fetch_status = 0
														BEGIN 
															--SELECT @ProductCursor AS [ProductID]
															INSERT INTO [TEMP_PATCH_SELECTION]
															([TPS_ProductID]
															,[TPS_EnvironmentID]
															,[TPS_ClientID])
															VALUES
															(@ProductCursor,
															 @EnvironmentCursor,
															 @ClientCursor);
															PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
															fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
														END
													CLOSE CURSOR_DIFF_ENV
													SELECT  C.ClientName
														,CT.CTYPE_TITLE As ClientType
														,PD.ProductName As [ProductID]
														,ET.EnvTitle As EnvType
														,C.ClientPOCName As [POC]
														,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
														,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
														,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
														,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
														,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
														,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
														,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
														,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
														,E.ENV_AppHyperLink As [Link]
														,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
													FROM [TEMP_PATCH_SELECTION] TPS 
													INNER JOIN Environment E 
													ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
													   TPS.[TPS_ClientID] = E.ENV_Client_ID 
													INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
													INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
													INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
													INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
												END
											else
												BEGIN
													--IF STATEMENT # 7
													if(@ProductID = 0 AND @EnvID != 0 AND @ClientID != 0)
														BEGIN
															PRINT('IF # 7 := Product ID: ')
															DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
																SELECT DISTINCT
																	[PAT_ProductID] AS ProductID,
																	E.ENV_AppServerEnvironmentType AS EnvType,
																	[PAT_ClientID] AS ClientID
																FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
																WHERE E.ENV_AppServerEnvironmentType = @EnvID AND
																	  [PAT_ClientID] = @ClientID
																ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
															TRUNCATE TABLE TEMP_PATCH_SELECTION;
															OPEN CURSOR_DIFF_ENV
															Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
															WHILE @@fetch_status = 0
																BEGIN 
																	--SELECT @ProductCursor AS [ProductID]
																	INSERT INTO [TEMP_PATCH_SELECTION]
																	([TPS_ProductID]
																	,[TPS_EnvironmentID]
																	,[TPS_ClientID])
																	VALUES
																	(@ProductCursor,
																	 @EnvironmentCursor,
																	 @ClientCursor);
																	PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
																	fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
																END
															CLOSE CURSOR_DIFF_ENV
															SELECT  C.ClientName
																,CT.CTYPE_TITLE As ClientType
																,PD.ProductName As [ProductID]
																,ET.EnvTitle As EnvType
																,C.ClientPOCName As [POC]
																,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
																,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
																,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
																,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
																,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
																,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
																,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
																,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
																,E.ENV_AppHyperLink As [Link]
																,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
															FROM [TEMP_PATCH_SELECTION] TPS 
															INNER JOIN Environment E 
															ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
															   TPS.[TPS_ClientID] = E.ENV_Client_ID 
															INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
															INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
															INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
															INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
														END
													else
														BEGIN
															--IF STATEMENT # 8
															if(@ProductID != 0 AND @EnvID != 0 AND @ClientID != 0)
																BEGIN
																	PRINT('IF # 8 := Product ID: ')
																	DECLARE CURSOR_DIFF_ENV CURSOR local fast_forward FOR
																		SELECT DISTINCT
																			[PAT_ProductID] AS ProductID,
																			E.ENV_AppServerEnvironmentType AS EnvType,
																			[PAT_ClientID] AS ClientID
																		FROM [PATCH] INNER JOIN Environment E ON PATCH.PAT_EnvType = E.ENV_ID
																		WHERE [PAT_ProductID] = @ProductID AND
																			  E.ENV_AppServerEnvironmentType = @EnvID AND
																			  [PAT_ClientID] = @ClientID
																		ORDER BY PAT_ProductID, ENV_AppServerEnvironmentType,PAT_ClientID;
																	TRUNCATE TABLE TEMP_PATCH_SELECTION;
																	OPEN CURSOR_DIFF_ENV
																	Fetch next FROM CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
																	WHILE @@fetch_status = 0
																		BEGIN 
																			--SELECT @ProductCursor AS [ProductID]
																			INSERT INTO [TEMP_PATCH_SELECTION]
																			([TPS_ProductID]
																			,[TPS_EnvironmentID]
																			,[TPS_ClientID])
																			VALUES
																			(@ProductCursor,
																			 @EnvironmentCursor,
																			 @ClientCursor);
																			PRINT ('ProductID: ' + @ProductCursor + ', EnvironmentID: ' + @EnvironmentCursor + ', ClientID: '+ @ClientCursor)
																			fetch next from CURSOR_DIFF_ENV into @ProductCursor,@EnvironmentCursor,@ClientCursor
																		END
																	CLOSE CURSOR_DIFF_ENV
																	SELECT  C.ClientName
																		,CT.CTYPE_TITLE As ClientType
																		,PD.ProductName As [ProductID]
																		,ET.EnvTitle As EnvType
																		,C.ClientPOCName As [POC]
																		,(SELECT COUNT(*) FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID) As [NumberOfPatches]
																		,(SELECT TOP 1 PATCH.PAT_HotNumber FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchHotNumber]
																		,(SELECT TOP 1 PATCH.PAT_DeployedBy FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) AS [PatchDeployedBy]
																		,(SELECT TOP 1 PATCH.PAT_IsQAPassed FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchQATested]
																		,(SELECT TOP 1 PATCH.PAT_CreatedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchCreatedDate]
																		,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchDeployedDate]
																		,DATEDIFF(DAY,(SELECT TOP 1 PATCH.PAT_DeployedDate FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PATCH.PAT_DeployedDate desc),GETDATE()) AS [NumberOfDaysPassed]
																		,(SELECT TOP 1 PATCH.PAT_Dependency FROM PATCH WHERE PATCH.PAT_ClientID = TPS.TPS_ClientID AND PATCH.PAT_ProductID = TPS_ProductID AND PATCH.PAT_EnvType = E.ENV_ID ORDER BY PAT_DeployedDate desc) As [PatchStatus]
																		,E.ENV_AppHyperLink As [Link]
																		,E.ENV_AppServerWorkingDirectoryLocation As [WorkingDirectory]
																	FROM [TEMP_PATCH_SELECTION] TPS 
																	INNER JOIN Environment E 
																	ON TPS.[TPS_EnvironmentID] = E.ENV_AppServerEnvironmentType AND TPS.[TPS_ProductID] = E.ENV_Product_ID AND
																	   TPS.[TPS_ClientID] = E.ENV_Client_ID 
																	INNER JOIN ClientDetail C ON TPS.[TPS_ClientID] = C.ClientID
																	INNER JOIN CLIENT_TYPE CT ON C.ClientType = CT.CTYPE_ID
																	INNER JOIN Products PD ON  TPS.[TPS_ProductID] = PD.ProductID
																	INNER JOIN EnvironmentType ET ON TPS.[TPS_EnvironmentID] = ET.EnvID
																END
															else
																BEGIN
																	PRINT('Unknown Parameter Value!')
																END
														END
												END
										END
								END
						END
				END
		END
  END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductList]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[spGetProductList]
AS
BEGIN
SELECT *
  FROM Products
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUpdatedPatchListClientWise]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetUpdatedPatchListClientWise]
	@ProductID int
	,@EnvType int
	As
	BEGIN
	DECLARE @TOTAL_PATCH int
	DECLARE @ENVIRONMENT_DESC varchar(20)
	DECLARE @EnvTitle varchar(10)
	SELECT @TOTAL_PATCH = COUNT(*) FROM PatchDetail WHERE ProductID = @ProductID AND EnvironmentType = @EnvType; 
SELECT @ENVIRONMENT_DESC = [EnvTitle] FROM EnvironmentType WHERE EnvID = @EnvType;
WITH CTE AS (
	SELECT DISTINCT CPPlus.ClientID,CPPlus.ClientName, CPPlus.ClientType, E.EnvAppServerEnvironmentType, CPPlus.PatchHotNumber, CPPlus.IsQAPassed, CPPlus.ClientPOCName, E.EnvAppLink, CPPlus.PatchDeployedDate, CPPlus.NumberOfDaysPassed, CPPlus.ProductID,CPPlus.Remarks_Dependencies As [Status]  from ((
		 SELECT C.ClientID, C.ClientName, C.ClientType, C.ClientPOCName, P.PatchHotNumber, P.IsQAPassed, P.PatchDeployedDate, P.ProductID, P.EnvironmentType, DATEDIFF(DAY,PatchDeployedDate,GETDATE()) As NumberOfDaysPassed, P.Remarks_Dependencies  
         FROM ClientDetail C 
		 LEFT Join PatchDetail P ON C.ClientID = P.ClientID
		 )) 
	As CPPlus
	LEFT JOIN ClientEnvironment E on CPPlus.EnvironmentType = E.EnvID WHERE E.EnvAppServerEnvironmentType = @EnvType AND CPPlus.ProductID = @ProductID
	)
--SELECT DISTINCT ClientName, ClientType, EnvAppServerEnvironmentType, PatchHotNumber, ClientPOCName, EnvAppLink, PatchDeployedDate, NumberOfDaysPassed, ProductID, PatchHotNumber As NumberOfPatches , Status AS [PatchStatus] FROM CTE

SELECT
			CTE.ClientName,
			MAX(CTE.ClientType) As ClientType,
			MAX(CASE WHEN CTE.EnvAppServerEnvironmentType = 1 THEN 'LIVE' WHEN CTE.EnvAppServerEnvironmentType = 2 THEN 'HA' WHEN CTE.EnvAppServerEnvironmentType = 3 THEN 'UAT' WHEN CTE.EnvAppServerEnvironmentType = 4 THEN 'TEST' END) As EnvType ,
			MAX(CTE.ClientPOCName) As POC, 
			MAX(PatchHotNumber) As PatchHotNumber,
			MAX(EnvAppLink) As Link,
			MAX(CAST(CTE.IsQAPassed As int)) As PatchQATested, 
			MAX(PatchDeployedDate) As PatchDeployedDate,
            COUNT(ClientName) AS NumberOfPatches, 
			MAX(CTE.ProductID) As ProductID, 
			MIN(NumberOfDaysPassed) As NumberOfDaysPassed,
			MIN(CTE.Status) As PatchStatus
		from CTE WHERE CTE.ProductID = @ProductID group by ClientName

	END

GO
/****** Object:  StoredProcedure [dbo].[spGetUserRole]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetUserRole]
AS
BEGIN
SELECT [ROLE_ID]
      ,[ROLE_TITLE]
      ,[ROLE_DESC]
  FROM [ROLES]
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spInsertClient]
	@ClientName varchar(50),
	@ClientType varchar(50),
	@ClientDesc varchar(MAX),
	@POCName varchar(50),
	@POCEmail varchar(70),
	@POCPhone varchar(50)
	AS
BEGIN
INSERT INTO [dbo].[ClientDetail]
           ([ClientName]
           ,[ClientType]
           ,[ClientDesc]
           ,[ClientStill]
           ,[ClientPOCName]
           ,[ClientPOCContact]
           ,[ClientPOCEmail])
     VALUES
           (@ClientName
           ,@ClientType
           ,@ClientDesc
           ,1
           ,@POCName
           ,@POCPhone
           ,@POCEmail)
END


GO
/****** Object:  StoredProcedure [dbo].[spInsertClientType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertClientType]
	@ClientTypeTitle varchar(MAX),
	@ClientTypeDesc varchar(MAX)
  AS
  BEGIN
	INSERT INTO [dbo].[CLIENT_TYPE]
           ([CTYPE_TITLE]
           ,[CTYPE_DESCRIPTION])
     VALUES
           (@ClientTypeTitle
           ,@ClientTypeDesc)
  END
GO
/****** Object:  StoredProcedure [dbo].[spInsertEnvironment]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spInsertEnvironment]
	@ClientID int,
	@ProductID int,
	@AppServerEnvType int,
	@DBServerEnvType int,
	@AppServerName varchar(50),
	@AppServerOS varchar(50),
	@AppServerOSBuild bigint,
	@AppServerIsX86Version bit,
	@AppServerIsVirtual bit,
	@AppServerProcessor varchar(50),
	@AppServerMemory int,
	@AppServerWebBrowser varchar(50),
	@AppServerWebBrowserVersion int,
	@AppServerWorkingDirectoryLocation varchar(max),
	@AppHyperLink varchar(100),
	@AppServerIP varchar(50),
	@AppServerPort int,
	@AppServerDependency varchar(100),
	@DBServerName varchar(50),
	@DBServerOS varchar(50),
	@DBerverOSBuild bigint,
	@DBServerIsX86Version bit,
	@DBServerIsVirtual bit,
	@DBServerProcessor varchar(50),
	@DBServerMemory int,
	@DBServerWorkingDirectoryLocation varchar(max),
	@DBMDFFileLocation varchar(100),
	@DBMDFFileSize bigint,
	@DBLDFFileLocation varchar(100),
	@DBLDFFileSize bigint,
	@DBServerIP varchar(50),
	@DBServerPort int,
	@DBServerDependency varchar(100)
AS
BEGIN
INSERT INTO [dbo].[Environment]
           ([ENV_Client_ID]
           ,[ENV_Product_ID]
           ,[ENV_AppServerEnvironmentType]
           ,[ENV_DBServerEnvironmentType]
           ,[ENV_AppServerName]
           ,[ENV_AppServerOS]
           ,[ENV_AppServerOSBuild]
           ,[ENV_AppServerIsX86Version]
           ,[ENV_AppServerIsVirtual]
           ,[ENV_AppServerProcessor]
           ,[ENV_AppServerMemory]
           ,[ENV_AppServerWebBrowser]
           ,[ENV_AppServerWebBrowserVersion]
           ,[ENV_AppServerWorkingDirectoryLocation]
           ,[ENV_AppHyperLink]
           ,[ENV_AppServerIP]
           ,[ENV_AppServerPort]
           ,[ENV_AppServerDependency]
           ,[ENV_DBServerName]
           ,[ENV_DBServerOS]
           ,[ENV_DBServerOSBuild]
           ,[ENV_DBServerIsX86Version]
           ,[ENV_DBServerIsVirtual]
           ,[ENV_DBServerProcessor]
           ,[ENV_DBServerMemory]
           ,[ENV_DBServerDirectoryLocation]
           ,[ENV_DBMDFFileLocation]
           ,[ENV_DBMDFFileSize]
           ,[ENV_DBLDFFileLocation]
           ,[ENV_DBLDFFileSize]
           ,[ENV_DBServerIP]
           ,[ENV_DBServerPort]
           ,[ENV_DBServerDependency])
     VALUES
           (@ClientID
           ,@ProductID
           ,@AppServerEnvType
           ,@DBServerEnvType
           ,@AppServerName
           ,@AppServerOS
           ,@AppServerOSBuild
           ,@AppServerIsX86Version
           ,@AppServerIsVirtual
           ,@AppServerProcessor
           ,@AppServerMemory
           ,@AppServerWebBrowser
           ,@AppServerWebBrowserVersion
           ,@AppServerWorkingDirectoryLocation
           ,@AppHyperLink
           ,@AppServerIP
           ,@AppServerPort
           ,@AppServerDependency
           ,@DBServerName
           ,@DBServerOS
           ,@DBerverOSBuild
           ,@DBServerIsX86Version
           ,@DBServerIsVirtual
           ,@DBServerProcessor
           ,@DBServerMemory
           ,@DBServerWorkingDirectoryLocation
           ,@DBLDFFileLocation
           ,@DBMDFFileSize
           ,@DBLDFFileLocation
           ,@DBLDFFileSize
           ,@DBServerIP
           ,@DBServerPort
           ,@DBServerDependency)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertEnvironmentType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertEnvironmentType]
	@EnvTitle varchar(10),
	@EnvDesc varchar(20)
As
BEGIN
INSERT INTO [dbo].[EnvironmentType]
           ([EnvTitle]
           ,[EnvDesc])
     VALUES
           (@EnvTitle
           ,@EnvDesc)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertPatch]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spInsertPatch]
	@PatchTitle varchar(50),
	@PatchDesc varchar(MAX),
	@PatchHotNumber varchar(50),
	@PatchDeployedBy varchar(40),
	@PatchCreatedDate datetime,
	@PatchDeployedDate datetime,
	@IsQAPassed bit,
	@Dependency varchar(MAX),
	@ClientID int,
	@ProductID int,
	@EnvironmentType varchar(40)
	As
BEGIN
INSERT INTO [dbo].[PATCH]
           ([PAT_Title]
           ,[PAT_Desc]
           ,[PAT_HotNumber]
           ,[PAT_DeployedBy]
           ,[PAT_CreatedDate]
           ,[PAT_DeployedDate]
           ,[PAT_IsQAPassed]
           ,[PAT_Dependency]
           ,[PAT_ClientID]
           ,[PAT_ProductID]
           ,[PAT_EnvType])
     VALUES
           (@PatchTitle
           ,@PatchDesc
           ,@PatchHotNumber
           ,@PatchDeployedBy
           ,@PatchCreatedDate
           ,@PatchDeployedDate
           ,@IsQAPassed
           ,@Dependency
           ,@ClientID
           ,@ProductID
           ,@EnvironmentType)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertProduct]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertProduct]
	    @ProductName varchar(40),
        @ProductDesc varchar(MAX),
        @ProductVersion varchar(10),
        @ProductType varchar(40),
        @ProductCategory varchar(50),
        @ProductRating varchar(5),
        @ProductUserID varchar(20),
        @ProductPassword varchar(20),
        @ProductPOC varchar(50),
        @ProductSupportEmail varchar(60),
        @ProductComments varchar(MAX)
		AS
BEGIN
INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[ProductDesc]
           ,[ProductVersion]
           ,[ProductType]
           ,[ProductCategory]
           ,[ProductRating]
           ,[ProductDemoUserId]
           ,[ProductDemoPasscode]
           ,[ProductPOC]
           ,[ProductSupportEmail]
           ,[ProductComments])
     VALUES
           (@ProductName
           ,@ProductDesc
           ,@ProductVersion
           ,@ProductType
           ,@ProductCategory
           ,@ProductRating
           ,@ProductUserID
           ,@ProductPassword
           ,@ProductPOC
           ,@ProductSupportEmail
           ,@ProductComments)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertUser]
	@Username varchar(30),
	@Role int,
	@Passcode varchar(30)
	As
BEGIN
INSERT INTO [dbo].[USER]
           ([USER_NAME]
           ,[USER_ROLE]
           ,[USER_STATUS]
           ,[USER_PASSCODE]
           ,[USER_LOGINDATE]
           ,[USER_WRONG_ATTEMPTS])
     VALUES
           (@Username
           ,@Role
           ,1
           ,@Passcode
           ,'1900-01-01 00:00:00'
           ,0)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserRole]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertUserRole]
	@ROLE_TITLE varchar(20),
	@ROLE_DESC varchar(MAX)
AS
BEGIN
	INSERT INTO [ROLES]
           ([ROLE_TITLE]
           ,[ROLE_DESC])
     VALUES
           (@ROLE_TITLE
           ,@ROLE_DESC)
END
GO
/****** Object:  StoredProcedure [dbo].[spNumberOfPatchesForGraph]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spNumberOfPatchesForGraph]
AS 
BEGIN
WITH CTE AS (
	SELECT
	C.ClientID,
	C.ClientName,
	(SELECT COUNT(*) FROM PATCH INNER JOIN Environment Ed ON PATCH.PAT_EnvType = Ed.ENV_ID ) As NumberOfPatches
FROM ((((Environment E INNER JOIN PATCH on E.ENV_ID = PATCH.PAT_EnvType)
		 INNER JOIN Products P On E.ENV_Product_ID = P.ProductID)
		 INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)
		 INNER JOIN ClientDetail C ON E.ENV_Client_ID = C.ClientID) 
)		  -- CTE END
select C.ClientName,
	   Count(*) As [NumberOfPatches]
	FROM CTE RIGHT OUTER JOIN ClientDetail C on CTE.ClientID = C.ClientID group by C.ClientName
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateClient]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateClient] 
	@ClientID int,
	@ClientName varchar(40),
	@ClientType varchar(40),
	@ClientDesc varchar(50),
	@ClientStill bit,
	@POCName varchar(40),
	@POCEmail varchar(60),
	@POCContact varchar(40)
AS
BEGIN 
UPDATE ClientDetail
 SET ClientName = @ClientName,
	 ClientType = @ClientType,
	 ClientDesc = @ClientDesc,
	 ClientStill = @ClientStill,
	 ClientPOCName = @POCName,
	 ClientPOCEmail = @POCEmail,
	 ClientPOCContact = @POCContact
 WHERE ClientID = @ClientID 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateClientType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateClientType]
	@ClientTypeID int,
	@ClientTypeTitle varchar(MAX),
	@ClientTypeDesc varchar(MAX)
  AS
  BEGIN
	UPDATE [CLIENT_TYPE] SET [CTYPE_TITLE] = @ClientTypeTitle,[CTYPE_DESCRIPTION]=@ClientTypeDesc WHERE [CTYPE_ID] = @ClientTypeID
  END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEnvironment]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateEnvironment]
	@EnvID int,
	@ClientName varchar(40),
	@ProductName varchar(50),
	@AppServerEnvType int,
	@DBServerEnvType int,
	@AppServerName varchar(50),
	@AppServerOS varchar(50),
	@AppServerOSBuild bigint,
	@AppServerIsX86Version bit,
	@AppServerIsVirtual bit,
	@AppServerProcessor varchar(50),
	@AppServerMemory int,
	@AppServerWebBrowser varchar(50),
	@AppServerWebBrowserVersion int,
	@AppServerWorkingDirectoryLocation varchar(max),
	@AppHyperLink varchar(100),
	@AppServerIP varchar(50),
	@AppServerPort int,
	@AppServerDependency varchar(100),
	@DBServerName varchar(50),
	@DBServerOS varchar(50),
	@DBerverOSBuild bigint,
	@DBServerIsX86Version bit,
	@DBServerIsVirtual bit,
	@DBServerProcessor varchar(50),
	@DBServerMemory int,
	@DBServerWorkingDirectoryLocation varchar(max),
	@DBMDFFileLocation varchar(100),
	@DBMDFFileSize bigint,
	@DBLDFFileLocation varchar(100),
	@DBLDFFileSize bigint,
	@DBServerIP varchar(50),
	@DBServerPort int,
	@DBServerDependency varchar(100)
AS
BEGIN
UPDATE [dbo].[Environment]
   SET --[ENV_Client_ID] = @ClientID
      --,[ENV_Product_ID] = @ProductID
      --,[ENV_AppServerEnvironmentType] = @EnvironmentAppServerEnvType
      --,[ENV_DBServerEnvironmentType] = @DBServerEnvType,
      [ENV_AppServerName] = @AppServerName
      ,[ENV_AppServerOS] = @AppServerOS
      ,[ENV_AppServerOSBuild] = @AppServerOSBuild
      ,[ENV_AppServerIsX86Version] = @AppServerIsX86Version
      ,[ENV_AppServerIsVirtual] = @AppServerIsVirtual
      ,[ENV_AppServerProcessor] = @AppServerProcessor
      ,[ENV_AppServerMemory] = @AppServerMemory
      ,[ENV_AppServerWebBrowser] = @AppServerWebBrowser
      ,[ENV_AppServerWebBrowserVersion] = @AppServerWebBrowserVersion
      ,[ENV_AppServerWorkingDirectoryLocation] = @AppServerWorkingDirectoryLocation
      ,[ENV_AppHyperLink] = @AppHyperLink
      ,[ENV_AppServerIP] = @AppServerIP
      ,[ENV_AppServerPort] = @AppServerPort
      ,[ENV_AppServerDependency] = @AppServerDependency
      ,[ENV_DBServerName] = @DBServerName
      ,[ENV_DBServerOS] = @DBServerOS
      ,[ENV_DBServerOSBuild] = @DBerverOSBuild
      ,[ENV_DBServerIsX86Version] = @DBServerIsX86Version
      ,[ENV_DBServerIsVirtual] = @DBServerIsVirtual
      ,[ENV_DBServerProcessor] = @DBServerProcessor
      ,[ENV_DBServerMemory] = @DBServerMemory
      ,[ENV_DBServerDirectoryLocation] = @DBServerWorkingDirectoryLocation
      ,[ENV_DBMDFFileLocation] = @DBMDFFileLocation
      ,[ENV_DBMDFFileSize] = @DBMDFFileSize
      ,[ENV_DBLDFFileLocation] = @DBLDFFileLocation
      ,[ENV_DBLDFFileSize] = @DBLDFFileSize
      ,[ENV_DBServerIP] = @DBServerIP
      ,[ENV_DBServerPort] = @DBServerPort
      ,[ENV_DBServerDependency] = @DBServerDependency
 WHERE ENV_ID = @EnvID
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEnvType]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateEnvType]
	@EnvTypeID int,
	@EnvTypeTitle varchar(10),
	@EnvTypeDesc varchar(20)
	As
BEGIN
UPDATE [dbo].[EnvironmentType]
   SET [EnvTitle] = @EnvTypeTitle
      ,[EnvDesc] = @EnvTypeDesc
 WHERE EnvID = @EnvTypeID
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProduct]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateProduct]
	@ProductID int,
    @ProductName varchar(40),
    @ProductDesc varchar(MAX),
    @ProductVersion varchar(10),
    @ProductType varchar(40),
    @ProductCategory varchar(50),
    @ProductRating varchar(5),
    @ProductUserID varchar(20),
    @ProductPassword varchar(20),
    @ProductPOC varchar(50),
    @ProductEmail varchar(60),
    @ProductComment varchar(MAX)
AS
BEGIN
UPDATE [dbo].[Products]
   SET [ProductName] = @ProductName
      ,[ProductDesc] = @ProductDesc
      ,[ProductVersion] = @ProductVersion
      ,[ProductType] = @ProductType
      ,[ProductCategory] = @ProductCategory
      ,[ProductRating] = @ProductRating
      ,[ProductDemoUserId] = @ProductUserID
      ,[ProductDemoPasscode] = @ProductPassword
      ,[ProductPOC] = @ProductPOC
      ,[ProductSupportEmail] = @ProductEmail
      ,[ProductComments] = @ProductComment
 WHERE ProductID = @ProductID
END


GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateUser]
	@UserID int,
	@Username varchar(30),
	@UserRole varchar(30),
	@UserStatus bit,
	@UserLoginDate datetime,
	@UserWrongAttempts smallint
AS
BEGIN
	UPDATE [dbo].[USER]
   SET [USER_NAME] = @Username
      ,[USER_ROLE] = (SELECT ROLE_ID FROM ROLES WHERE ROLE_TITLE = @UserRole)
      ,[USER_STATUS] = @UserStatus
      ,[USER_LOGINDATE] = @UserLoginDate
      ,[USER_WRONG_ATTEMPTS] = @UserWrongAttempts
	WHERE [USER_ID] = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUserRole]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUpdateUserRole]
	@Role_ID int,
	@Role_Title varchar(20),
	@Role_Desc varchar(MAX)
AS
BEGIN
UPDATE [dbo].[ROLES]
   SET [ROLE_TITLE] = @Role_Title
      ,[ROLE_DESC] = @Role_Desc
      WHERE ROLE_ID = @Role_ID
END


GO
/****** Object:  StoredProcedure [dbo].[spViewClientSortedByName]    Script Date: 3/26/2020 10:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[spViewClientSortedByName]
  AS
  BEGIN
  select * from ClientDetail order by ClientName
  END
GO
USE [master]
GO
ALTER DATABASE [Release_Management_Portal] SET  READ_WRITE 
GO
