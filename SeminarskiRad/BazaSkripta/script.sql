USE [master]
GO
/****** Object:  Database [140-SeminarskiRad]    Script Date: 11.4.2017. 23:23:43 ******/
CREATE DATABASE [140-SeminarskiRad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'140-SeminarskiRad_data', FILENAME = N'D:\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\140-SeminarskiRad_data.mdf' , SIZE = 4160KB , MAXSIZE = 1024000KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'140-SeminarskiRad_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\140-SeminarskiRad_log.ldf' , SIZE = 1024KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [140-SeminarskiRad] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [140-SeminarskiRad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [140-SeminarskiRad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET ARITHABORT OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [140-SeminarskiRad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [140-SeminarskiRad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [140-SeminarskiRad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET  ENABLE_BROKER 
GO
ALTER DATABASE [140-SeminarskiRad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [140-SeminarskiRad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [140-SeminarskiRad] SET  MULTI_USER 
GO
ALTER DATABASE [140-SeminarskiRad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [140-SeminarskiRad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [140-SeminarskiRad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [140-SeminarskiRad] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [140-SeminarskiRad]
GO
/****** Object:  User [140-Ivan]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE USER [140-Ivan] FOR LOGIN [140-Ivan] WITH DEFAULT_SCHEMA=[140-Ivan]
GO
ALTER ROLE [db_owner] ADD MEMBER [140-Ivan]
GO
/****** Object:  Schema [140-Ivan]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE SCHEMA [140-Ivan]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [date] NOT NULL,
	[StudentName] [nvarchar](100) NOT NULL,
	[StudentSurname] [nvarchar](100) NOT NULL,
	[StudentAddress] [nvarchar](150) NOT NULL,
	[SeminarID] [int] NOT NULL,
	[Approved] [bit] NULL,
 CONSTRAINT [PK__Booking__3214EC27EBDDE1EE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Claim]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Claim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLogin]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seminar]    Script Date: 11.4.2017. 23:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seminar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SeminarDescription] [nvarchar](500) NOT NULL,
	[SeminarDate] [datetime] NOT NULL,
	[Teacher] [nvarchar](100) NOT NULL,
	[Closed] [bit] NOT NULL,
	[MaxStudents] [int] NOT NULL,
 CONSTRAINT [PK__Seminar__3214EC27A975CABA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_UserId]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Claim]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Employee]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[EmployeeLogin]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[EmployeeRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[EmployeeRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11.4.2017. 23:23:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Role]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [fk_Seminar_Booking] FOREIGN KEY([SeminarID])
REFERENCES [dbo].[Seminar] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [fk_Seminar_Booking]
GO
ALTER TABLE [dbo].[Claim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Claim_dbo.Employee_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Claim] CHECK CONSTRAINT [FK_dbo.Claim_dbo.Employee_UserId]
GO
ALTER TABLE [dbo].[EmployeeLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmployeeLogin_dbo.Employee_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeLogin] CHECK CONSTRAINT [FK_dbo.EmployeeLogin_dbo.Employee_UserId]
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmployeeRole_dbo.Employee_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [FK_dbo.EmployeeRole_dbo.Employee_UserId]
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmployeeRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [FK_dbo.EmployeeRole_dbo.Role_RoleId]
GO
USE [master]
GO
ALTER DATABASE [140-SeminarskiRad] SET  READ_WRITE 
GO
