USE [master]
GO
/****** Object:  Database [BankSystem]    Script Date: 5/17/2022 1:47:52 AM ******/
CREATE DATABASE [BankSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BankSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BankSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BankSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BankSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BankSystem', N'ON'
GO
ALTER DATABASE [BankSystem] SET QUERY_STORE = OFF
GO
USE [BankSystem]
GO
/****** Object:  Table [dbo].[BankAccount]    Script Date: 5/17/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK__BankAcco__3214EC07AFA34AEA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/17/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 5/17/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[BankAccountId] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [float] NOT NULL,
	[SenderBankAccountId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 5/17/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BankAccount] ON 

INSERT [dbo].[BankAccount] ([Id], [CustomerId], [Balance]) VALUES (1, 1, 1500)
INSERT [dbo].[BankAccount] ([Id], [CustomerId], [Balance]) VALUES (2, 2, 1500)
SET IDENTITY_INSERT [dbo].[BankAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name]) VALUES (1, N'Sarah')
INSERT [dbo].[Customer] ([Id], [Name]) VALUES (2, N'John')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionHistory] ON 

INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (1, 1, 1, CAST(N'2022-05-17T00:45:18.247' AS DateTime), 1000, NULL)
INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (2, 1, 2, CAST(N'2022-05-17T00:46:26.833' AS DateTime), 2000, NULL)
INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (17, 5, 2, CAST(N'2022-05-17T01:25:31.487' AS DateTime), 200, NULL)
INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (18, 4, 1, CAST(N'2022-05-17T01:25:36.157' AS DateTime), 200, 2)
INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (22, 5, 2, CAST(N'2022-05-17T01:46:16.743' AS DateTime), 100, NULL)
INSERT [dbo].[TransactionHistory] ([Id], [TransactionTypeId], [BankAccountId], [TransactionDate], [Amount], [SenderBankAccountId]) VALUES (23, 4, 1, CAST(N'2022-05-17T01:46:17.053' AS DateTime), 100, 2)
SET IDENTITY_INSERT [dbo].[TransactionHistory] OFF
GO
INSERT [dbo].[TransactionType] ([Id], [Name]) VALUES (1, N'Initial Deposite')
INSERT [dbo].[TransactionType] ([Id], [Name]) VALUES (2, N'Deposite')
INSERT [dbo].[TransactionType] ([Id], [Name]) VALUES (3, N'Withdrawal')
INSERT [dbo].[TransactionType] ([Id], [Name]) VALUES (4, N'IncomingTransfer')
INSERT [dbo].[TransactionType] ([Id], [Name]) VALUES (5, N'OutgoingTransfer')
GO
ALTER TABLE [dbo].[BankAccount]  WITH CHECK ADD  CONSTRAINT [FK__BankAccou__Custo__267ABA7A] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[BankAccount] CHECK CONSTRAINT [FK__BankAccou__Custo__267ABA7A]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__BankA__2C3393D0] FOREIGN KEY([BankAccountId])
REFERENCES [dbo].[BankAccount] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK__Transacti__BankA__2C3393D0]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__Sende__2D27B809] FOREIGN KEY([SenderBankAccountId])
REFERENCES [dbo].[BankAccount] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK__Transacti__Sende__2D27B809]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionType] ([Id])
GO
USE [master]
GO
ALTER DATABASE [BankSystem] SET  READ_WRITE 
GO
