-- ===============================================
-- COMPLETE DATABASE SETUP SCRIPT - DUY NHẤT
-- Dự án: Lab07_2212364_PVQHien
-- Hệ thống quản lý nhà hàng
-- ===============================================
-- Script này tạo đầy đủ cấu trúc database và dữ liệu mẫu
-- để chạy tất cả các chức năng của dự án.
-- File SQL DUY NHẤT cần thiết - Chứa mọi thứ!
-- ===============================================

USE [master]
GO

-- Tạo database nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'RestaurantManagement')
BEGIN
    CREATE DATABASE [RestaurantManagement]
    PRINT 'Đã tạo database RestaurantManagement'
END
ELSE
BEGIN
    PRINT 'Database RestaurantManagement đã tồn tại'
END
GO

USE [RestaurantManagement]
GO

PRINT ''
PRINT '========================================='
PRINT 'BẮT ĐẦU TẠO CẤU TRÚC DATABASE'
PRINT '========================================='
PRINT ''

-- =============================================
-- 1. BẢNG CATEGORY (Danh mục món ăn/đồ uống)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Category](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](255) NOT NULL,
        [Type] [int] NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    PRINT '✓ Đã tạo bảng Category'
END
ELSE
BEGIN
    PRINT '✓ Bảng Category đã tồn tại'
END
GO

-- =============================================
-- 2. BẢNG FOOD (Món ăn/Đồ uống)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Food]') AND type in (N'U'))
BEGIN
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
END
ELSE
BEGIN
    PRINT '✓ Bảng Food đã tồn tại'
    
    -- Kiểm tra và thêm cột Unit nếu chưa có
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Food]') 
                   AND name = 'Unit')
    BEGIN
        ALTER TABLE [dbo].[Food] ADD [Unit] [nvarchar](50) NULL
        PRINT '  → Đã thêm cột Unit vào bảng Food'
    END
END
GO

-- =============================================
-- 3. BẢNG RESTAURANT (Nhà hàng)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Restaurant]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Restaurant](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](255) NOT NULL,
        [Address] [nvarchar](500) NULL,
        [Phone] [nvarchar](20) NULL,
        CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    PRINT '✓ Đã tạo bảng Restaurant'
END
ELSE
BEGIN
    PRINT '✓ Bảng Restaurant đã tồn tại'
END
GO

-- =============================================
-- 4. BẢNG HALL (Phòng/Khu vực)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hall]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Hall](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](255) NOT NULL,
        [RestaurantId] [int] NOT NULL,
        CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Hall_Restaurant] FOREIGN KEY([RestaurantId])
            REFERENCES [dbo].[Restaurant] ([Id])
    )
    
    PRINT '✓ Đã tạo bảng Hall'
END
ELSE
BEGIN
    PRINT '✓ Bảng Hall đã tồn tại'
END
GO

-- =============================================
-- 5. BẢNG TABLE (Bàn ăn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
BEGIN
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
END
ELSE
BEGIN
    PRINT '✓ Bảng Table đã tồn tại'
    
    -- Kiểm tra và thêm cột Capacity nếu chưa có
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Table]') 
                   AND name = 'Capacity')
    BEGIN
        ALTER TABLE [dbo].[Table] ADD [Capacity] [int] NOT NULL DEFAULT 4
        PRINT '  → Đã thêm cột Capacity vào bảng Table'
    END
    
    -- Kiểm tra và thêm cột HallId nếu chưa có
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Table]') 
                   AND name = 'HallId')
    BEGIN
        -- Cần có ít nhất 1 Hall trước khi thêm HallId
        IF EXISTS (SELECT 1 FROM [dbo].[Hall])
        BEGIN
            DECLARE @DefaultHallId INT = (SELECT TOP 1 Id FROM [dbo].[Hall])
            ALTER TABLE [dbo].[Table] ADD [HallId] [int] NOT NULL DEFAULT @DefaultHallId
            
            IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Table_Hall')
            BEGIN
                ALTER TABLE [dbo].[Table] ADD CONSTRAINT [FK_Table_Hall] FOREIGN KEY([HallId])
                    REFERENCES [dbo].[Hall] ([Id])
            END
            PRINT '  → Đã thêm cột HallId vào bảng Table'
        END
    END
    
    -- Kiểm tra và sửa kiểu dữ liệu cột Status
    DECLARE @StatusDataType NVARCHAR(50)
    SELECT @StatusDataType = DATA_TYPE 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Table' AND COLUMN_NAME = 'Status'
    
    IF @StatusDataType = 'int'
    BEGIN
        -- Xóa constraint mặc định cũ nếu có
        DECLARE @ConstraintName NVARCHAR(200)
        SELECT @ConstraintName = dc.name
        FROM sys.default_constraints dc
        INNER JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
        WHERE c.object_id = OBJECT_ID(N'[dbo].[Table]') AND c.name = 'Status'
        
        IF @ConstraintName IS NOT NULL
        BEGIN
            EXEC('ALTER TABLE [dbo].[Table] DROP CONSTRAINT [' + @ConstraintName + ']')
        END
        
        -- Chuyển đổi dữ liệu
        ALTER TABLE [dbo].[Table] ALTER COLUMN [Status] NVARCHAR(50) NOT NULL
        
        UPDATE [dbo].[Table] 
        SET [Status] = CASE 
            WHEN TRY_CAST([Status] AS INT) = 0 OR [Status] IS NULL THEN N'Available'
            WHEN TRY_CAST([Status] AS INT) = 1 THEN N'Occupied'
            WHEN TRY_CAST([Status] AS INT) = 2 THEN N'Reserved'
            ELSE N'Available'
        END
        WHERE [Status] NOT IN (N'Available', N'Occupied', N'Reserved')
        
        PRINT '  → Đã chuyển đổi cột Status từ INT sang NVARCHAR(50)'
    END
END
GO

-- =============================================
-- 6. BẢNG ROLE (Vai trò)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Role](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](100) NOT NULL,
        [Description] [nvarchar](255) NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    PRINT '✓ Đã tạo bảng Role'
END
ELSE
BEGIN
    PRINT '✓ Bảng Role đã tồn tại'
    
    -- *** SỬA LỖI: Thêm các cột còn thiếu vào bảng Role ***
    
    -- Thêm cột Name
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Role]') 
                   AND name = 'Name')
    BEGIN
        ALTER TABLE [dbo].[Role] ADD [Name] [nvarchar](100) NOT NULL DEFAULT N'Role'
        PRINT '  → Đã thêm cột Name vào bảng Role'
    END
    
    -- Thêm cột Description
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Role]') 
                   AND name = 'Description')
    BEGIN
        ALTER TABLE [dbo].[Role] ADD [Description] [nvarchar](255) NULL
        PRINT '  → Đã thêm cột Description vào bảng Role'
    END
END
GO

-- =============================================
-- 7. BẢNG ACCOUNT (Tài khoản)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Account](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Username] [nvarchar](100) NOT NULL,
        [Password] [nvarchar](255) NOT NULL,
        [FullName] [nvarchar](255) NOT NULL,
        [Email] [nvarchar](255) NULL,
        [Phone] [nvarchar](20) NULL,
        [DateCreated] [datetime] NOT NULL DEFAULT GETDATE(),
        [IsActive] [bit] NOT NULL DEFAULT 1,
        CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    -- Tạo unique constraint cho Username
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'UQ_Account_Username')
    BEGIN
        ALTER TABLE [dbo].[Account] ADD CONSTRAINT [UQ_Account_Username] UNIQUE ([Username])
    END
    
    PRINT '✓ Đã tạo bảng Account'
END
ELSE
BEGIN
    PRINT '✓ Bảng Account đã tồn tại'
END
GO

-- =============================================
-- 8. BẢNG ROLEACCOUNT (Phân quyền)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleAccount]') AND type in (N'U'))
BEGIN
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
END
ELSE
BEGIN
    PRINT '✓ Bảng RoleAccount đã tồn tại'
END
GO

-- =============================================
-- 9. BẢNG INVOICE (Hóa đơn) - QUAN TRỌNG!
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
BEGIN
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
END
ELSE
BEGIN
    PRINT '✓ Bảng Invoice đã tồn tại'
    
    -- *** SỬA LỖI: Thêm các cột còn thiếu vào bảng Invoice ***
    
    -- Thêm cột DateCreated
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') 
                   AND name = 'DateCreated')
    BEGIN
        ALTER TABLE [dbo].[Invoice] ADD [DateCreated] [datetime] NOT NULL DEFAULT GETDATE()
        PRINT '  → Đã thêm cột DateCreated vào bảng Invoice'
    END
    
    -- Thêm cột DatePayment
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') 
                   AND name = 'DatePayment')
    BEGIN
        ALTER TABLE [dbo].[Invoice] ADD [DatePayment] [datetime] NULL
        PRINT '  → Đã thêm cột DatePayment vào bảng Invoice'
    END
    
    -- Thêm cột TotalAmount
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') 
                   AND name = 'TotalAmount')
    BEGIN
        ALTER TABLE [dbo].[Invoice] ADD [TotalAmount] [int] NOT NULL DEFAULT 0
        PRINT '  → Đã thêm cột TotalAmount vào bảng Invoice'
    END
    
    -- Thêm cột Discount
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') 
                   AND name = 'Discount')
    BEGIN
        ALTER TABLE [dbo].[Invoice] ADD [Discount] [int] NOT NULL DEFAULT 0
        PRINT '  → Đã thêm cột Discount vào bảng Invoice'
    END
    
    -- Thêm cột Status
    IF NOT EXISTS (SELECT * FROM sys.columns 
                   WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') 
                   AND name = 'Status')
    BEGIN
        ALTER TABLE [dbo].[Invoice] ADD [Status] [nvarchar](50) NOT NULL DEFAULT N'Đang phục vụ'
        PRINT '  → Đã thêm cột Status vào bảng Invoice'
    END
END
GO

-- =============================================
-- 10. BẢNG INVOICEDETAILS (Chi tiết hóa đơn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetails]') AND type in (N'U'))
BEGIN
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
END
ELSE
BEGIN
    PRINT '✓ Bảng InvoiceDetails đã tồn tại'
END
GO

PRINT ''
PRINT '========================================='
PRINT 'BẮT ĐẦU THÊM DỮ LIỆU MẪU'
PRINT '========================================='
PRINT ''

-- =============================================
-- DỮ LIỆU MẪU - CATEGORY
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Category])
BEGIN
    SET IDENTITY_INSERT [dbo].[Category] ON
    
    INSERT INTO [dbo].[Category] ([Id], [Name], [Type]) VALUES 
    (1, N'Đồ uống có cồn', 0),      -- Drink = 0
    (2, N'Đồ uống không cồn', 0),
    (3, N'Món khai vị', 1),          -- Food = 1
    (4, N'Món chính', 1),
    (5, N'Món tráng miệng', 1),
    (6, N'Món ăn nhanh', 1)
    
    SET IDENTITY_INSERT [dbo].[Category] OFF
    PRINT '✓ Đã thêm dữ liệu Category (6 danh mục)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - FOOD
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Food])
BEGIN
    SET IDENTITY_INSERT [dbo].[Food] ON
    
    INSERT INTO [dbo].[Food] ([Id], [Name], [Unit], [FoodCategoryId], [Price], [Notes]) VALUES 
    -- Đồ uống có cồn
    (1, N'Bia Tiger', N'Lon', 1, 15000, N'Bia Tiger 330ml'),
    (2, N'Bia Heineken', N'Chai', 1, 25000, N'Bia Heineken 330ml'),
    (3, N'Rượu vang đỏ', N'Chai', 1, 150000, N'Rượu vang Pháp'),
    
    -- Đồ uống không cồn
    (4, N'Coca Cola', N'Lon', 2, 10000, N'Coca 330ml'),
    (5, N'Pepsi', N'Lon', 2, 10000, N'Pepsi 330ml'),
    (6, N'Nước cam ép', N'Ly', 2, 20000, N'Cam tươi 100%'),
    (7, N'Trà đá', N'Ly', 2, 5000, N'Trà đá truyền thống'),
    
    -- Món khai vị
    (8, N'Gỏi cuốn', N'Đĩa', 3, 30000, N'Gỏi cuốn tôm thịt (4 cuốn)'),
    (9, N'Nem rán', N'Đĩa', 3, 35000, N'Nem rán giòn (5 cái)'),
    (10, N'Salad trộn', N'Đĩa', 3, 40000, N'Salad rau trộn'),
    
    -- Món chính
    (11, N'Cơm rang dương châu', N'Đĩa', 4, 50000, N'Cơm rang thập cẩm'),
    (12, N'Phở bò', N'Tô', 4, 45000, N'Phở bò tái chín'),
    (13, N'Bún chả Hà Nội', N'Suất', 4, 50000, N'Bún chả truyền thống'),
    (14, N'Lẩu Thái', N'Nồi', 4, 250000, N'Lẩu Thái hải sản (2-3 người)'),
    (15, N'Gà nướng mật ong', N'Con', 4, 180000, N'Gà nguyên con nướng'),
    
    -- Món tráng miệng
    (16, N'Chè khúc bạch', N'Chén', 5, 15000, N'Chè khúc bạch truyền thống'),
    (17, N'Kem tươi', N'Ly', 5, 20000, N'Kem tươi các vị'),
    (18, N'Trái cây tráng miệng', N'Đĩa', 5, 30000, N'Trái cây theo mùa'),
    
    -- Món ăn nhanh
    (19, N'Bánh mì thịt', N'Cái', 6, 25000, N'Bánh mì thịt nguội pate'),
    (20, N'Xôi xéo', N'Suất', 6, 20000, N'Xôi xéo đậu xanh')
    
    SET IDENTITY_INSERT [dbo].[Food] OFF
    PRINT '✓ Đã thêm dữ liệu Food (20 món ăn/đồ uống)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - RESTAURANT
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Restaurant])
BEGIN
    SET IDENTITY_INSERT [dbo].[Restaurant] ON
    
    INSERT INTO [dbo].[Restaurant] ([Id], [Name], [Address], [Phone]) VALUES 
    (1, N'Nhà hàng Sài Gòn Xưa', N'123 Nguyễn Huệ, Quận 1, TP.HCM', N'0283 8297 456')
    
    SET IDENTITY_INSERT [dbo].[Restaurant] OFF
    PRINT '✓ Đã thêm dữ liệu Restaurant'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - HALL
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Hall])
BEGIN
    SET IDENTITY_INSERT [dbo].[Hall] ON
    
    INSERT INTO [dbo].[Hall] ([Id], [Name], [RestaurantId]) VALUES 
    (1, N'Tầng 1', 1),
    (2, N'Tầng 2', 1),
    (3, N'Phòng VIP', 1),
    (4, N'Sân thượng', 1)
    
    SET IDENTITY_INSERT [dbo].[Hall] OFF
    PRINT '✓ Đã thêm dữ liệu Hall (4 khu vực)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - TABLE
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Table])
BEGIN
    SET IDENTITY_INSERT [dbo].[Table] ON
    
    INSERT INTO [dbo].[Table] ([Id], [Name], [Capacity], [HallId], [Status]) VALUES 
    -- Tầng 1
    (1, N'Bàn 01', 4, 1, N'Available'),
    (2, N'Bàn 02', 4, 1, N'Available'),
    (3, N'Bàn 03', 6, 1, N'Available'),
    (4, N'Bàn 04', 4, 1, N'Available'),
    (5, N'Bàn 05', 2, 1, N'Available'),
    
    -- Tầng 2
    (6, N'Bàn 06', 6, 2, N'Available'),
    (7, N'Bàn 07', 8, 2, N'Available'),
    (8, N'Bàn 08', 4, 2, N'Available'),
    (9, N'Bàn 09', 4, 2, N'Available'),
    (10, N'Bàn 10', 6, 2, N'Available'),
    
    -- Phòng VIP
    (11, N'VIP 01', 10, 3, N'Available'),
    (12, N'VIP 02', 12, 3, N'Available'),
    (13, N'VIP 03', 8, 3, N'Available'),
    
    -- Sân thượng
    (14, N'ST 01', 6, 4, N'Available'),
    (15, N'ST 02', 4, 4, N'Available')
    
    SET IDENTITY_INSERT [dbo].[Table] OFF
    PRINT '✓ Đã thêm dữ liệu Table (15 bàn ăn)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - ROLE
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Role])
BEGIN
    SET IDENTITY_INSERT [dbo].[Role] ON
    
    INSERT INTO [dbo].[Role] ([Id], [Name], [Description]) VALUES 
    (1, N'Admin', N'Quản trị viên hệ thống - Toàn quyền'),
    (2, N'Manager', N'Quản lý nhà hàng - Quản lý nhân viên, báo cáo'),
    (3, N'Waiter', N'Nhân viên phục vụ - Nhận order, phục vụ khách'),
    (4, N'Cashier', N'Thu ngân - Thanh toán hóa đơn'),
    (5, N'Chef', N'Bếp trưởng - Quản lý bếp, món ăn')
    
    SET IDENTITY_INSERT [dbo].[Role] OFF
    PRINT '✓ Đã thêm dữ liệu Role (5 vai trò)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - ACCOUNT
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Account])
BEGIN
    SET IDENTITY_INSERT [dbo].[Account] ON
    
    INSERT INTO [dbo].[Account] ([Id], [Username], [Password], [FullName], [Email], [Phone], [IsActive]) VALUES 
    (1, N'admin', N'admin', N'Quản trị viên', N'admin@restaurant.com', N'0901234567', 1),
    (2, N'manager', N'123456', N'Nguyễn Văn Quản Lý', N'manager@restaurant.com', N'0902345678', 1),
    (3, N'waiter1', N'123456', N'Trần Thị Thu', N'waiter1@restaurant.com', N'0903456789', 1),
    (4, N'waiter2', N'123456', N'Lê Văn Nam', N'waiter2@restaurant.com', N'0904567890', 1),
    (5, N'cashier', N'123456', N'Phạm Thị Lan', N'cashier@restaurant.com', N'0905678901', 1),
    (6, N'chef', N'123456', N'Hoàng Văn Bếp', N'chef@restaurant.com', N'0906789012', 1)
    
    SET IDENTITY_INSERT [dbo].[Account] OFF
    PRINT '✓ Đã thêm dữ liệu Account (6 tài khoản)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - ROLEACCOUNT
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[RoleAccount])
BEGIN
    INSERT INTO [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES 
    (1, 1),  -- admin có role Admin
    (2, 2),  -- manager có role Manager
    (3, 3),  -- waiter1 có role Waiter
    (3, 4),  -- waiter2 có role Waiter
    (4, 5),  -- cashier có role Cashier
    (5, 6),  -- chef có role Chef
    -- Một số user có nhiều role
    (2, 1),  -- admin cũng có role Manager
    (4, 2)   -- manager cũng có role Cashier
    
    PRINT '✓ Đã thêm dữ liệu RoleAccount (phân quyền)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - INVOICE (Một số hóa đơn mẫu)
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[Invoice])
BEGIN
    SET IDENTITY_INSERT [dbo].[Invoice] ON
    
    INSERT INTO [dbo].[Invoice] ([Id], [TableId], [AccountId], [DateCreated], [DatePayment], [TotalAmount], [Discount], [Status]) VALUES 
    -- Hóa đơn đã thanh toán
    (1, 1, 3, DATEADD(day, -2, GETDATE()), DATEADD(day, -2, DATEADD(hour, 1, GETDATE())), 185000, 0, N'Đã thanh toán'),
    (2, 3, 4, DATEADD(day, -1, GETDATE()), DATEADD(day, -1, DATEADD(hour, 2, GETDATE())), 250000, 10000, N'Đã thanh toán'),
    (3, 5, 3, DATEADD(hour, -5, GETDATE()), DATEADD(hour, -4, GETDATE()), 120000, 0, N'Đã thanh toán'),
    
    -- Hóa đơn đang phục vụ
    (4, 2, 4, DATEADD(hour, -1, GETDATE()), NULL, 0, 0, N'Đang phục vụ'),
    (5, 7, 3, DATEADD(minute, -30, GETDATE()), NULL, 0, 0, N'Đang phục vụ')
    
    SET IDENTITY_INSERT [dbo].[Invoice] OFF
    PRINT '✓ Đã thêm dữ liệu Invoice (5 hóa đơn mẫu)'
END
GO

-- =============================================
-- DỮ LIỆU MẪU - INVOICEDETAILS
-- =============================================
IF NOT EXISTS (SELECT * FROM [dbo].[InvoiceDetails])
BEGIN
    -- Hóa đơn 1
    INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId], [FoodId], [Quantity], [Price], [Amount]) VALUES 
    (1, 12, 2, 45000, 90000),   -- 2 Phở bò
    (1, 4, 2, 10000, 20000),    -- 2 Coca
    (1, 8, 1, 30000, 30000),    -- 1 Gỏi cuốn
    (1, 16, 1, 15000, 15000),   -- 1 Chè khúc bạch
    (1, 6, 2, 20000, 40000),    -- 2 Nước cam
    
    -- Hóa đơn 2
    (2, 14, 1, 250000, 250000), -- 1 Lẩu Thái
    
    -- Hóa đơn 3
    (3, 11, 2, 50000, 100000),  -- 2 Cơm rang
    (3, 6, 1, 20000, 20000),    -- 1 Nước cam
    
    -- Hóa đơn 4 (đang phục vụ)
    (4, 13, 1, 50000, 50000),   -- 1 Bún chả
    (4, 5, 1, 10000, 10000),    -- 1 Pepsi
    
    -- Hóa đơn 5 (đang phục vụ)
    (5, 15, 1, 180000, 180000), -- 1 Gà nướng
    (5, 1, 4, 15000, 60000)     -- 4 Bia Tiger
    
    PRINT '✓ Đã thêm dữ liệu InvoiceDetails'
END
GO

PRINT ''
PRINT '========================================='
PRINT '  HOÀN TẤT SETUP DATABASE'
PRINT '========================================='
PRINT ''
PRINT 'CẤU TRÚC DATABASE:'
PRINT '  ✓ Category          (Danh mục món ăn)'
PRINT '  ✓ Food              (Món ăn/đồ uống)'
PRINT '  ✓ Restaurant        (Thông tin nhà hàng)'
PRINT '  ✓ Hall              (Khu vực/phòng)'
PRINT '  ✓ Table             (Bàn ăn)'
PRINT '  ✓ Role              (Vai trò)'
PRINT '  ✓ Account           (Tài khoản)'
PRINT '  ✓ RoleAccount       (Phân quyền)'
PRINT '  ✓ Invoice           (Hóa đơn) *** ĐÃ SỬA LỖI ***'
PRINT '  ✓ InvoiceDetails    (Chi tiết hóa đơn)'
PRINT ''
PRINT 'DỮ LIỆU MẪU:'
PRINT '  • 6 danh mục món ăn'
PRINT '  • 20 món ăn/đồ uống'
PRINT '  • 1 nhà hàng'
PRINT '  • 4 khu vực'
PRINT '  • 15 bàn ăn'
PRINT '  • 5 vai trò'
PRINT '  • 6 tài khoản'
PRINT '  • 5 hóa đơn mẫu'
PRINT ''
PRINT 'TÀI KHOẢN ĐĂNG NHẬP:'
PRINT '  • Username: admin    | Password: admin      (Admin)'
PRINT '  • Username: manager  | Password: 123456    (Manager)'
PRINT '  • Username: waiter1  | Password: 123456    (Waiter)'
PRINT '  • Username: cashier  | Password: 123456    (Cashier)'
PRINT '  • Username: chef     | Password: 123456    (Chef)'
PRINT ''
PRINT '========================================='
PRINT 'Database đã sẵn sàng cho dự án!'
PRINT 'Tất cả lỗi đã được sửa tự động!'
PRINT '========================================='
GO
