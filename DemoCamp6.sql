USE [master]
GO
/****** Object:  Database [LoanManagement_db]    Script Date: 26-10-2024 16:04:01 ******/
CREATE DATABASE [LoanManagement_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LoanManagement_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LoanManagement_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LoanManagement_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LoanManagement_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LoanManagement_db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LoanManagement_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LoanManagement_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LoanManagement_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LoanManagement_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LoanManagement_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LoanManagement_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [LoanManagement_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LoanManagement_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LoanManagement_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LoanManagement_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LoanManagement_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LoanManagement_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LoanManagement_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LoanManagement_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LoanManagement_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LoanManagement_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LoanManagement_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LoanManagement_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LoanManagement_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LoanManagement_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LoanManagement_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LoanManagement_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LoanManagement_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LoanManagement_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LoanManagement_db] SET  MULTI_USER 
GO
ALTER DATABASE [LoanManagement_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LoanManagement_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LoanManagement_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LoanManagement_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LoanManagement_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LoanManagement_db] SET QUERY_STORE = OFF
GO
USE [LoanManagement_db]
GO
/****** Object:  Table [dbo].[BackgroundVerification]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackgroundVerification](
	[VerificationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NULL,
	[LoanOfficerID] [int] NULL,
	[Status] [varchar](20) NULL,
	[Notes] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[VerificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[FullName] [varchar](100) NULL,
	[DateOfBirth] [date] NULL,
	[Address] [varchar](255) NULL,
	[AnnualIncome] [decimal](15, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Comments] [text] NULL,
	[Rating] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Help]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Help](
	[HelpID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [text] NULL,
	[Answer] [text] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HelpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanApplications]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplications](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[LoanID] [int] NULL,
	[RequestedAmount] [decimal](10, 2) NULL,
	[ApplicationDate] [date] NULL,
	[Status] [varchar](20) NULL,
	[ApprovedBy] [int] NULL,
	[ApprovalDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loans]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loans](
	[LoanID] [int] IDENTITY(1,1) NOT NULL,
	[LoanName] [varchar](100) NULL,
	[MaxAmount] [decimal](10, 2) NULL,
	[InterestRate] [decimal](5, 2) NULL,
	[DurationMonths] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanVerification]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanVerification](
	[VerificationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NULL,
	[LoanOfficerID] [int] NULL,
	[Status] [varchar](20) NULL,
	[Notes] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[VerificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26-10-2024 16:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](255) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BackgroundVerification] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[LoanApplications] ADD  DEFAULT (getdate()) FOR [ApplicationDate]
GO
ALTER TABLE [dbo].[LoanApplications] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[LoanVerification] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[BackgroundVerification]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[LoanApplications] ([ApplicationID])
GO
ALTER TABLE [dbo].[BackgroundVerification]  WITH CHECK ADD FOREIGN KEY([LoanOfficerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Help]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD FOREIGN KEY([LoanID])
REFERENCES [dbo].[Loans] ([LoanID])
GO
ALTER TABLE [dbo].[LoanVerification]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[LoanApplications] ([ApplicationID])
GO
ALTER TABLE [dbo].[LoanVerification]  WITH CHECK ADD FOREIGN KEY([LoanOfficerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[BackgroundVerification]  WITH CHECK ADD CHECK  (([Status]='Failed' OR [Status]='Completed' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD CHECK  (([Status]='Rejected' OR [Status]='Approved' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[LoanVerification]  WITH CHECK ADD CHECK  (([Status]='Not Verified' OR [Status]='Verified' OR [Status]='Pending'))
GO
USE [master]
GO
ALTER DATABASE [LoanManagement_db] SET  READ_WRITE 
GO
