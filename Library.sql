USE [master]
GO
/****** Object:  Database [Library]    Script Date: 19/02/2017 06:04:25 p. m. ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL_LAPBLOX\MSSQL\DATA\Library.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL_LAPBLOX\MSSQL\DATA\Library_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 19/02/2017 06:04:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Author] [nvarchar](100) NULL,
	[Genre] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[InInventory] [bit] NULL,
	[BorrowedTimes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BorrowedBooks]    Script Date: 19/02/2017 06:04:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowedBooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[BookId] [int] NULL,
	[IsBorrowed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 19/02/2017 06:04:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (1, N'Title1', N'Author1', N'Physics', 2001, 1, 1)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (2, N'Title2', N'Author2', N'Math', 2011, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (3, N'Title3', N'Author3', N'Phisics', 2007, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (4, N'Title4', N'Author4', N'VLSI', 2016, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (5, N'Title5', N'Author5', N'Electronics', 2005, 1, 1)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (6, N'Title6', N'Author6', N'History', 2003, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (7, N'Title7', N'Author7', N'Economics', 1979, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (8, N'Title8', N'Author8', N'Aeronautics', 1985, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (9, N'Title9', N'Author9', N'Languages', 2017, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (10, N'Title10', N'Author10', N'Physics', 2001, 1, 0)
INSERT [dbo].[Books] ([Id], [Title], [Author], [Genre], [Year], [InInventory], [BorrowedTimes]) VALUES (11, N'Mi Vida', N'JP', N'Personal', 1979, 1, 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[BorrowedBooks] ON 

INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (1, 8, 5, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (2, 3, 2, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (3, 9, 5, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (4, 1, 7, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (5, 7, 9, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (6, 3, 1, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (7, 9, 5, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (8, 5, 4, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (9, 3, 6, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (10, 3, 6, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (11, 3, 2, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (12, 11, 10, 0)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (13, 11, 3, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (14, 25, 1, 1)
INSERT [dbo].[BorrowedBooks] ([Id], [StudentId], [BookId], [IsBorrowed]) VALUES (15, 8, 3, 0)
SET IDENTITY_INSERT [dbo].[BorrowedBooks] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name]) VALUES (1, N'Lupe')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (2, N'Antonio')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (3, N'Jesus')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (4, N'Carolina')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (5, N'Pedro')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (6, N'Felipe')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (7, N'Maria')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (8, N'Yana')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (9, N'Josefina')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (10, N'Daniel')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (11, N'Carmen')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (12, N'Jose')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (25, N'JamesQ')
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
