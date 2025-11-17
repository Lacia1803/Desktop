-- ===============================================
-- COMPLETE DATABASE RESET & SETUP
-- Dự án: Lab07_2212364_PVQHien
-- ===============================================
-- Script này sẽ XÓA và TẠO LẠI toàn bộ database
-- để đảm bảo cấu trúc hoàn toàn chính xác
-- ===============================================

USE [master]
GO

-- Xóa database cũ nếu tồn tại
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'RestaurantManagement')
BEGIN
    ALTER DATABASE [RestaurantManagement] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [RestaurantManagement]
    PRINT 'Đã xóa database RestaurantManagement cũ'
END
GO

-- Tạo database mới
CREATE DATABASE [RestaurantManagement]
GO

PRINT 'Đã tạo database RestaurantManagement mới'
PRINT ''

USE [RestaurantManagement]
GO

PRINT '========================================='
PRINT 'BẮT ĐẦU TẠO CẤU TRÚC DATABASE'
PRINT '========================================='
PRINT ''

-- =============================================
-- 1. BẢNG CATEGORY
-- =============================================
CREATE TABLE [dbo].[Category](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [Type] [int] NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
)
PRINT '✓ Đã tạo bảng Category'
GO

-- =============================================
-- 2. BẢNG FOOD
-- =============================================
CREATE TABLE [dbo].[Food](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [Unit] [nvarchar](50) NULL,
    [FoodCategoryId] [int] NOT NULL,
    [Price] [int] NOT NULL,
    [Notes] [nvarchar](500) NULL,
    CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Food_Category] FOREIGN KEY([FoodCategoryId])
        REFERENCES [dbo].[Category] ([Id]) ON DELETE CASCADE
)
PRINT '✓ Đã tạo bảng Food'
GO

-- =============================================
-- 3. BẢNG RESTAURANT
-- =============================================
CREATE TABLE [dbo].[Restaurant](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [Address] [nvarchar](500) NULL,
    [Phone] [nvarchar](20) NULL,
    CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED ([Id] ASC)
)
PRINT '✓ Đã tạo bảng Restaurant'
GO

-- =============================================
-- 4. BẢNG HALL
-- =============================================
CREATE TABLE [dbo].[Hall](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [RestaurantId] [int] NOT NULL,
    CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Hall_Restaurant] FOREIGN KEY([RestaurantId])
        REFERENCES [dbo].[Restaurant] ([Id])
)
PRINT '✓ Đã tạo bảng Hall'
GO

-- =============================================
-- 5. BẢNG TABLE
-- =============================================
CREATE TABLE [dbo].[Table](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](100) NOT NULL,
    [Capacity] [int] NOT NULL DEFAULT 4,
    [HallId] [int] NOT NULL,
    [Status] [nvarchar](50) NOT NULL DEFAULT N'Available',
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_Hall] FOREIGN KEY([HallId])
        REFERENCES [dbo].[Hall] ([Id])
)
PRINT '✓ Đã tạo bảng Table'
GO

-- =============================================
-- 6. BẢNG ROLE
-- =============================================
CREATE TABLE [dbo].[Role](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](100) NOT NULL,
    [Description] [nvarchar](255) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
)
PRINT '✓ Đã tạo bảng Role'
GO

-- =============================================
-- 7. BẢNG ACCOUNT
-- =============================================
CREATE TABLE [dbo].[Account](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Username] [nvarchar](100) NOT NULL,
    [Password] [nvarchar](255) NOT NULL,
    [FullName] [nvarchar](255) NOT NULL,
    [Email] [nvarchar](255) NULL,
    [Phone] [nvarchar](20) NULL,
    [DateCreated] [datetime] NOT NULL DEFAULT GETDATE(),
    [IsActive] [bit] NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Account_Username] UNIQUE ([Username])
)
PRINT '✓ Đã tạo bảng Account'
GO

-- =============================================
-- 8. BẢNG ROLEACCOUNT
-- =============================================
CREATE TABLE [dbo].[RoleAccount](
    [RoleId] [int] NOT NULL,
    [AccountId] [int] NOT NULL,
    CONSTRAINT [PK_RoleAccount] PRIMARY KEY CLUSTERED ([RoleId] ASC, [AccountId] ASC),
    CONSTRAINT [FK_RoleAccount_Role] FOREIGN KEY([RoleId])
        REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [FK_RoleAccount_Account] FOREIGN KEY([AccountId])
        REFERENCES [dbo].[Account] ([Id])
)
PRINT '✓ Đã tạo bảng RoleAccount'
GO

-- =============================================
-- 9. BẢNG INVOICE
-- =============================================
CREATE TABLE [dbo].[Invoice](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [TableId] [int] NOT NULL,
    [AccountId] [int] NOT NULL,
    [DateCreated] [datetime] NOT NULL DEFAULT GETDATE(),
    [DatePayment] [datetime] NULL,
    [TotalAmount] [int] NOT NULL DEFAULT 0,
    [Discount] [int] NOT NULL DEFAULT 0,
    [Status] [nvarchar](50) NOT NULL DEFAULT N'Đang phục vụ',
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoice_Table] FOREIGN KEY([TableId])
        REFERENCES [dbo].[Table] ([Id]),
    CONSTRAINT [FK_Invoice_Account] FOREIGN KEY([AccountId])
        REFERENCES [dbo].[Account] ([Id])
)
PRINT '✓ Đã tạo bảng Invoice'
GO

-- =============================================
-- 10. BẢNG INVOICEDETAILS
-- =============================================
CREATE TABLE [dbo].[InvoiceDetails](
    [InvoiceId] [int] NOT NULL,
    [FoodId] [int] NOT NULL,
    [Quantity] [int] NOT NULL,
    [Price] [int] NOT NULL,
    [Amount] [int] NOT NULL,
    CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED ([InvoiceId] ASC, [FoodId] ASC),
    CONSTRAINT [FK_InvoiceDetails_Invoice] FOREIGN KEY([InvoiceId])
        REFERENCES [dbo].[Invoice] ([Id]),
    CONSTRAINT [FK_InvoiceDetails_Food] FOREIGN KEY([FoodId])
        REFERENCES [dbo].[Food] ([Id])
)
PRINT '✓ Đã tạo bảng InvoiceDetails'
GO

PRINT ''
PRINT '========================================='
PRINT 'BẮT ĐẦU THÊM DỮ LIỆU MẪU'
PRINT '========================================='
PRINT ''

-- =============================================
-- DỮ LIỆU - CATEGORY
-- =============================================
SET IDENTITY_INSERT [dbo].[Category] ON

INSERT INTO [dbo].[Category] ([Id], [Name], [Type]) VALUES 
(1, N'Đồ uống có cồn', 0),
(2, N'Đồ uống không cồn', 0),
(3, N'Món khai vị', 1),
(4, N'Món chính', 1),
(5, N'Món tráng miệng', 1),
(6, N'Món ăn nhanh', 1)

SET IDENTITY_INSERT [dbo].[Category] OFF
PRINT '✓ Đã thêm 6 danh mục'
GO

-- =============================================
-- DỮ LIỆU - FOOD
-- =============================================
SET IDENTITY_INSERT [dbo].[Food] ON

INSERT INTO [dbo].[Food] ([Id], [Name], [Unit], [FoodCategoryId], [Price], [Notes]) VALUES 
(1, N'Bia Tiger', N'Lon', 1, 15000, N'Bia Tiger 330ml'),
(2, N'Bia Heineken', N'Chai', 1, 25000, N'Bia Heineken 330ml'),
(3, N'Rượu vang đỏ', N'Chai', 1, 150000, N'Rượu vang Pháp'),
(4, N'Coca Cola', N'Lon', 2, 10000, N'Coca 330ml'),
(5, N'Pepsi', N'Lon', 2, 10000, N'Pepsi 330ml'),
(6, N'Nước cam ép', N'Ly', 2, 20000, N'Cam tươi 100%'),
(7, N'Trà đá', N'Ly', 2, 5000, N'Trà đá truyền thống'),
(8, N'Gỏi cuốn', N'Đĩa', 3, 30000, N'Gỏi cuốn tôm thịt (4 cuốn)'),
(9, N'Nem rán', N'Đĩa', 3, 35000, N'Nem rán giòn (5 cái)'),
(10, N'Salad trộn', N'Đĩa', 3, 40000, N'Salad rau trộn'),
(11, N'Cơm rang dương châu', N'Đĩa', 4, 50000, N'Cơm rang thập cẩm'),
(12, N'Phở bò', N'Tô', 4, 45000, N'Phở bò tái chín'),
(13, N'Bún chả Hà Nội', N'Suất', 4, 50000, N'Bún chả truyền thống'),
(14, N'Lẩu Thái', N'Nồi', 4, 250000, N'Lẩu Thái hải sản (2-3 người)'),
(15, N'Gà nướng mật ong', N'Con', 4, 180000, N'Gà nguyên con nướng'),
(16, N'Chè khúc bạch', N'Chén', 5, 15000, N'Chè khúc bạch truyền thống'),
(17, N'Kem tươi', N'Ly', 5, 20000, N'Kem tươi các vị'),
(18, N'Trái cây tráng miệng', N'Đĩa', 5, 30000, N'Trái cây theo mùa'),
(19, N'Bánh mì thịt', N'Cái', 6, 25000, N'Bánh mì thịt nguội pate'),
(20, N'Xôi xéo', N'Suất', 6, 20000, N'Xôi xéo đậu xanh')

SET IDENTITY_INSERT [dbo].[Food] OFF
PRINT '✓ Đã thêm 20 món ăn'
GO

-- =============================================
-- DỮ LIỆU - RESTAURANT
-- =============================================
SET IDENTITY_INSERT [dbo].[Restaurant] ON

INSERT INTO [dbo].[Restaurant] ([Id], [Name], [Address], [Phone]) VALUES 
(1, N'Nhà hàng Sài Gòn Xưa', N'123 Nguyễn Huệ, Quận 1, TP.HCM', N'0283 8297 456')

SET IDENTITY_INSERT [dbo].[Restaurant] OFF
PRINT '✓ Đã thêm 1 nhà hàng'
GO

-- =============================================
-- DỮ LIỆU - HALL
-- =============================================
SET IDENTITY_INSERT [dbo].[Hall] ON

INSERT INTO [dbo].[Hall] ([Id], [Name], [RestaurantId]) VALUES 
(1, N'Tầng 1', 1),
(2, N'Tầng 2', 1),
(3, N'Phòng VIP', 1),
(4, N'Sân thượng', 1)

SET IDENTITY_INSERT [dbo].[Hall] OFF
PRINT '✓ Đã thêm 4 khu vực'
GO

-- =============================================
-- DỮ LIỆU - TABLE
-- =============================================
SET IDENTITY_INSERT [dbo].[Table] ON

INSERT INTO [dbo].[Table] ([Id], [Name], [Capacity], [HallId], [Status]) VALUES 
(1, N'Bàn 01', 4, 1, N'Available'),
(2, N'Bàn 02', 4, 1, N'Available'),
(3, N'Bàn 03', 6, 1, N'Available'),
(4, N'Bàn 04', 4, 1, N'Available'),
(5, N'Bàn 05', 2, 1, N'Available'),
(6, N'Bàn 06', 6, 2, N'Available'),
(7, N'Bàn 07', 8, 2, N'Available'),
(8, N'Bàn 08', 4, 2, N'Available'),
(9, N'Bàn 09', 4, 2, N'Available'),
(10, N'Bàn 10', 6, 2, N'Available'),
(11, N'VIP 01', 10, 3, N'Available'),
(12, N'VIP 02', 12, 3, N'Available'),
(13, N'VIP 03', 8, 3, N'Available'),
(14, N'ST 01', 6, 4, N'Available'),
(15, N'ST 02', 4, 4, N'Available')

SET IDENTITY_INSERT [dbo].[Table] OFF
PRINT '✓ Đã thêm 15 bàn'
GO

-- =============================================
-- DỮ LIỆU - ROLE
-- =============================================
SET IDENTITY_INSERT [dbo].[Role] ON

INSERT INTO [dbo].[Role] ([Id], [Name], [Description]) VALUES 
(1, N'Admin', N'Quản trị viên hệ thống - Toàn quyền'),
(2, N'Manager', N'Quản lý nhà hàng - Quản lý nhân viên, báo cáo'),
(3, N'Waiter', N'Nhân viên phục vụ - Nhận order, phục vụ khách'),
(4, N'Cashier', N'Thu ngân - Thanh toán hóa đơn'),
(5, N'Chef', N'Bếp trưởng - Quản lý bếp, món ăn')

SET IDENTITY_INSERT [dbo].[Role] OFF
PRINT '✓ Đã thêm 5 vai trò'
GO

-- =============================================
-- DỮ LIỆU - ACCOUNT
-- =============================================
SET IDENTITY_INSERT [dbo].[Account] ON

INSERT INTO [dbo].[Account] ([Id], [Username], [Password], [FullName], [Email], [Phone], [IsActive]) VALUES 
(1, N'admin', N'admin', N'Quản trị viên', N'admin@restaurant.com', N'0901234567', 1),
(2, N'manager', N'123456', N'Nguyễn Văn Quản Lý', N'manager@restaurant.com', N'0902345678', 1),
(3, N'waiter1', N'123456', N'Trần Thị Thu', N'waiter1@restaurant.com', N'0903456789', 1),
(4, N'waiter2', N'123456', N'Lê Văn Nam', N'waiter2@restaurant.com', N'0904567890', 1),
(5, N'cashier', N'123456', N'Phạm Thị Lan', N'cashier@restaurant.com', N'0905678901', 1),
(6, N'chef', N'123456', N'Hoàng Văn Bếp', N'chef@restaurant.com', N'0906789012', 1)

SET IDENTITY_INSERT [dbo].[Account] OFF
PRINT '✓ Đã thêm 6 tài khoản'
GO

-- =============================================
-- DỮ LIỆU - ROLEACCOUNT
-- =============================================
INSERT INTO [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES 
(1, 1), (2, 2), (3, 3), (3, 4), (4, 5), (5, 6),
(2, 1), (4, 2)

PRINT '✓ Đã thêm phân quyền'
GO

-- =============================================
-- DỮ LIỆU - INVOICE
-- =============================================
SET IDENTITY_INSERT [dbo].[Invoice] ON

INSERT INTO [dbo].[Invoice] ([Id], [TableId], [AccountId], [DateCreated], [DatePayment], [TotalAmount], [Discount], [Status]) VALUES 
(1, 1, 3, DATEADD(day, -2, GETDATE()), DATEADD(day, -2, DATEADD(hour, 1, GETDATE())), 185000, 0, N'Đã thanh toán'),
(2, 3, 4, DATEADD(day, -1, GETDATE()), DATEADD(day, -1, DATEADD(hour, 2, GETDATE())), 250000, 10000, N'Đã thanh toán'),
(3, 5, 3, DATEADD(hour, -5, GETDATE()), DATEADD(hour, -4, GETDATE()), 120000, 0, N'Đã thanh toán'),
(4, 2, 4, DATEADD(hour, -1, GETDATE()), NULL, 60000, 0, N'Đang phục vụ'),
(5, 7, 3, DATEADD(minute, -30, GETDATE()), NULL, 240000, 0, N'Đang phục vụ')

SET IDENTITY_INSERT [dbo].[Invoice] OFF
PRINT '✓ Đã thêm 5 hóa đơn'
GO

-- =============================================
-- DỮ LIỆU - INVOICEDETAILS
-- =============================================
INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId], [FoodId], [Quantity], [Price], [Amount]) VALUES 
(1, 12, 2, 45000, 90000),
(1, 4, 2, 10000, 20000),
(1, 8, 1, 30000, 30000),
(1, 16, 1, 15000, 15000),
(1, 6, 2, 20000, 40000),
(2, 14, 1, 250000, 250000),
(3, 11, 2, 50000, 100000),
(3, 6, 1, 20000, 20000),
(4, 13, 1, 50000, 50000),
(4, 5, 1, 10000, 10000),
(5, 15, 1, 180000, 180000),
(5, 1, 4, 15000, 60000)

PRINT '✓ Đã thêm chi tiết hóa đơn'
GO

PRINT ''
PRINT '========================================='
PRINT '  HOÀN TẤT SETUP DATABASE'
PRINT '========================================='
PRINT ''
PRINT 'Đã tạo thành công:'
PRINT '  ✓ 10 bảng với cấu trúc chính xác'
PRINT '  ✓ 6 danh mục | 20 món ăn'
PRINT '  ✓ 1 nhà hàng | 4 khu vực | 15 bàn'
PRINT '  ✓ 5 vai trò | 6 tài khoản'
PRINT '  ✓ 5 hóa đơn mẫu với chi tiết'
PRINT ''
PRINT 'TÀI KHOẢN:'
PRINT '  admin/admin | manager/123456'
PRINT '  waiter1/123456 | cashier/123456'
PRINT ''
PRINT 'Database sẵn sàng sử dụng!'
PRINT '========================================='
GO
