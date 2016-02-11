USE [ServicesDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10.02.2016 13:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[PhoneNumber] [int] NULL,
	[NIP] [nchar](10) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10.02.2016 13:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SellerId] [int] NOT NULL,
	[OrderDate] [date] NULL,
	[PaymentDate] [date] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sellers]    Script Date: 10.02.2016 13:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sellers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[PhoneNumber] [int] NULL,
	[NIP] [int] NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 10.02.2016 13:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[NetPrice] [float] NOT NULL,
	[VAT] [int] NOT NULL,
	[VATAmount] [float] NOT NULL,
	[PretaxPrice] [float] NOT NULL,
	[FaVatPosition] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 10.02.2016 13:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[Id] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[ServiceTypeName] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers1] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers1]
GO
ALTER TABLE [dbo].[ServiceTypes]  WITH CHECK ADD  CONSTRAINT [FK_ServiceTypes_Orders1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[ServiceTypes] CHECK CONSTRAINT [FK_ServiceTypes_Orders1]
GO
ALTER TABLE [dbo].[ServiceTypes]  WITH CHECK ADD  CONSTRAINT [FK_ServiceTypes_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[ServiceTypes] CHECK CONSTRAINT [FK_ServiceTypes_Services]
GO
