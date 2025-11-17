-- Tạo database RestaurantManagement
CREATE DATABASE [RestaurantManagement]
GO

USE [RestaurantManagement]
GO

-- Tạo bảng Category
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Type] [int] NOT NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

-- Tạo bảng Food
CREATE TABLE [dbo].[Food](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[FoodCategoryId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Food_Category] FOREIGN KEY([FoodCategoryId])
		REFERENCES [dbo].[Category] ([Id])
		ON DELETE CASCADE
)
GO

-- Thêm dữ liệu mẫu cho Category
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Cơm', 0)
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Bún/Phở', 0)
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Món xào', 0)
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Nước ngọt', 1)
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Trà sữa', 1)
INSERT INTO [dbo].[Category] ([Name], [Type]) VALUES (N'Cà phê', 1)
GO

-- Thêm dữ liệu mẫu cho Food
INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Cơm tấm', N'Phần', 1, 35000, N'Cơm tấm sườn bì chả')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Cơm gà', N'Phần', 1, 40000, N'Cơm gà xối mỡ')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Phở bò', N'Tô', 2, 45000, N'Phở bò tái nạm')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Bún bò Huế', N'Tô', 2, 40000, N'Bún bò Huế đặc biệt')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Thập cẩm xào', N'Đĩa', 3, 55000, N'Thập cẩm xào thập cẩm')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Coca Cola', N'Lon', 4, 15000, N'Coca lon 330ml')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Pepsi', N'Lon', 4, 15000, N'Pepsi lon 330ml')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Trà sữa truyền thống', N'Ly', 5, 25000, N'Trà sữa truyền thống size M')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Trà sữa matcha', N'Ly', 5, 30000, N'Trà sữa matcha size M')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Cà phê đen', N'Ly', 6, 20000, N'Cà phê đen đá')

INSERT INTO [dbo].[Food] ([Name], [Unit], [FoodCategoryId], [Price], [Notes]) 
VALUES (N'Cà phê sữa', N'Ly', 6, 25000, N'Cà phê sữa đá')
GO

PRINT 'Database và dữ liệu mẫu đã được tạo thành công!'
