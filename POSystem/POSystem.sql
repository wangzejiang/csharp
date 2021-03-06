USE [master]
GO
/****** Object:  Database [PODB]    Script Date: 2019-08-19 23:19:01 ******/
CREATE DATABASE [PODB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PODB', FILENAME = N'D:\SQLServer2017Media\MSSQL14.MSSQLSERVER\MSSQL\DATA\PODB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [FileStreamGroup] CONTAINS FILESTREAM  DEFAULT
( NAME = N'FileStream', FILENAME = N'D:\SQLServer2017Media\DD' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'PODB_log', FILENAME = N'D:\SQLServer2017Media\MSSQL14.MSSQLSERVER\MSSQL\DATA\PODB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PODB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PODB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PODB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PODB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PODB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PODB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PODB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PODB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PODB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PODB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PODB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PODB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PODB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PODB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PODB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PODB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PODB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PODB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PODB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PODB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PODB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PODB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PODB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PODB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PODB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PODB] SET  MULTI_USER 
GO
ALTER DATABASE [PODB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PODB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PODB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PODB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PODB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PODB] SET QUERY_STORE = OFF
GO
USE [PODB]
GO
/****** Object:  Table [dbo].[Attachment]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachment](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Content] [varbinary](max) FILESTREAM  NULL,
	[length] [bigint] NULL,
 CONSTRAINT [PK__Attachme__3214EC27AF93A4AF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] FILESTREAM_ON [FileStreamGroup]
) ON [PRIMARY] FILESTREAM_ON [FileStreamGroup]
GO
/****** Object:  Table [dbo].[ProductInfo]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInfo](
	[pID] [int] IDENTITY(1,1) NOT NULL,
	[pImageID] [uniqueidentifier] NULL,
	[pName] [varchar](200) NULL,
	[pPrice] [decimal](18, 2) NULL,
	[pPriceX] [decimal](18, 2) NULL,
	[pWeigth] [decimal](18, 2) NULL,
	[pNumber] [varchar](200) NULL,
	[pSuppliter] [varchar](200) NULL,
	[pRemark] [varchar](2000) NULL,
	[update_date] [datetime] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_ProductInfo] PRIMARY KEY CLUSTERED 
(
	[pID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Products]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Products]
AS
SELECT   dbo.ProductInfo.pID, dbo.ProductInfo.pImageID, dbo.ProductInfo.pName, dbo.ProductInfo.pPrice, 
                dbo.ProductInfo.pWeigth, dbo.ProductInfo.pNumber, dbo.ProductInfo.pSuppliter, dbo.ProductInfo.pRemark, 
                dbo.ProductInfo.update_date, dbo.ProductInfo.create_date, dbo.Attachment.length, dbo.Attachment.[Content], 
                dbo.ProductInfo.pPriceX
FROM      dbo.Attachment INNER JOIN
                dbo.ProductInfo ON dbo.Attachment.ID = dbo.ProductInfo.pImageID
GO
/****** Object:  Table [dbo].[CustomerInfo]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInfo](
	[cID] [int] IDENTITY(1,1) NOT NULL,
	[cName] [varchar](200) NULL,
	[cPhone] [varchar](200) NULL,
	[cAddress] [varchar](1000) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_CustomerInfo] PRIMARY KEY CLUSTERED 
(
	[cID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[oID] [int] IDENTITY(1,1) NOT NULL,
	[uName] [varchar](200) NULL,
	[oNumber] [varchar](200) NULL,
	[oWeigth] [decimal](18, 2) NULL,
	[oPrice] [decimal](18, 2) NULL,
	[oPriceX] [decimal](18, 2) NULL,
	[oPriceZ] [decimal](18, 2) NULL,
	[otherPrice] [decimal](18, 2) NULL,
	[cID] [int] NULL,
	[cName] [varchar](200) NULL,
	[cPhone] [varchar](200) NULL,
	[cAddress] [varchar](200) NULL,
	[oRemark] [varchar](2000) NULL,
	[oRemark2] [varchar](2000) NULL,
	[oDate] [datetime] NULL,
	[oStatus] [int] NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[oPriceOK] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[oID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProductInfo]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProductInfo](
	[opID] [int] IDENTITY(1,1) NOT NULL,
	[oID] [int] NULL,
	[cID] [int] NULL,
	[pID] [int] NULL,
	[oNumber] [varchar](200) NULL,
	[opImageID] [uniqueidentifier] NULL,
	[opName] [varchar](200) NULL,
	[opPrice] [decimal](18, 2) NULL,
	[opWeigth] [decimal](18, 2) NULL,
	[opNumber] [varchar](200) NULL,
	[opSuppliter] [varchar](200) NULL,
	[opRemark] [varchar](2000) NULL,
	[opCount] [decimal](18, 2) NULL,
	[opPriceX] [decimal](18, 2) NULL,
	[update_date] [datetime] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [PK_OrderProductInfo] PRIMARY KEY CLUSTERED 
(
	[opID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2019-08-19 23:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[uID] [int] IDENTITY(1,1) NOT NULL,
	[uName] [varchar](200) NULL,
	[uPassword] [varchar](200) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[attr1] [varchar](200) NULL,
	[attr2] [varchar](200) NULL,
	[attr3] [varchar](200) NULL,
	[attr4] [varchar](200) NULL,
	[attr5] [varchar](200) NULL,
	[attr6] [varchar](200) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[uID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerInfo] ADD  CONSTRAINT [DF_CustomerInfo_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[CustomerInfo] ADD  CONSTRAINT [DF_CustomerInfo_update_date]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_update_date]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[OrderProductInfo] ADD  CONSTRAINT [DF_OrderProductInfo_update_date]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[OrderProductInfo] ADD  CONSTRAINT [DF_OrderProductInfo_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[ProductInfo] ADD  CONSTRAINT [DF_ProductInfo_update_date]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[ProductInfo] ADD  CONSTRAINT [DF_ProductInfo_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_update_date]  DEFAULT (getdate()) FOR [update_date]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[38] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Attachment"
            Begin Extent = 
               Top = 10
               Left = 415
               Bottom = 180
               Right = 557
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductInfo"
            Begin Extent = 
               Top = 9
               Left = 86
               Bottom = 188
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1560
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Products'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Products'
GO
USE [master]
GO
ALTER DATABASE [PODB] SET  READ_WRITE 
GO
