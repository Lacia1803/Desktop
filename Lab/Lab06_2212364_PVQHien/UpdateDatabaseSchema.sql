USE [RestaurantManagement]
GO

-- =============================================
-- CẬP NHẬT DATABASE THEO THIẾT KẾ MỚI
-- =============================================

-- Xóa các bảng cũ nếu tồn tại (theo thứ tự foreign key)
IF OBJECT_ID('InvoiceDetails', 'U') IS NOT NULL DROP TABLE InvoiceDetails;
IF OBJECT_ID('Invoice', 'U') IS NOT NULL DROP TABLE Invoice;
IF OBJECT_ID('BillDetails', 'U') IS NOT NULL DROP TABLE BillDetails;
IF OBJECT_ID('Bills', 'U') IS NOT NULL DROP TABLE Bills;
IF OBJECT_ID('Food', 'U') IS NOT NULL DROP TABLE Food;
IF OBJECT_ID('FoodCategory', 'U') IS NOT NULL DROP TABLE FoodCategory;
IF OBJECT_ID('Category', 'U') IS NOT NULL DROP TABLE Category;
IF OBJECT_ID('[Table]', 'U') IS NOT NULL DROP TABLE [Table];
IF OBJECT_ID('Hall', 'U') IS NOT NULL DROP TABLE Hall;
IF OBJECT_ID('RoleAccount', 'U') IS NOT NULL DROP TABLE RoleAccount;
IF OBJECT_ID('Role', 'U') IS NOT NULL DROP TABLE Role;
IF OBJECT_ID('Account', 'U') IS NOT NULL DROP TABLE Account;
IF OBJECT_ID('Restaurant', 'U') IS NOT NULL DROP TABLE Restaurant;
GO

-- =============================================
-- Bảng Restaurant (Nhà hàng)
-- =============================================
CREATE TABLE Restaurant (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(1000) NOT NULL,
    Address nvarchar(3000) NULL,
    Phone nvarchar(100) NULL,
    Website nvarchar(1000) NULL
);
GO

-- =============================================
-- Bảng Hall (Sảnh)
-- =============================================
CREATE TABLE Hall (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(1000) NOT NULL,
    RestaurantID int NOT NULL,
    FOREIGN KEY (RestaurantID) REFERENCES Restaurant(ID)
);
GO

-- =============================================
-- Bảng Table (Bàn)
-- =============================================
CREATE TABLE [Table] (
    ID int IDENTITY(1,1) PRIMARY KEY,
    TableCode nvarchar(200) NULL,
    Name nvarchar(1000) NULL,
    Status int NOT NULL DEFAULT 0, -- 0: chưa đặt, 1: Đã đặt, 2: Có khách
    Seats int NULL,
    HallID int NULL,
    FOREIGN KEY (HallID) REFERENCES Hall(ID)
);
GO

-- =============================================
-- Bảng FoodCategory (Danh mục món ăn/thức uống)
-- =============================================
CREATE TABLE FoodCategory (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(1000) NOT NULL,
    Type int NOT NULL -- 1: Đồ ăn, 2: Thức uống
);
GO

-- =============================================
-- Bảng Food (Món ăn)
-- =============================================
CREATE TABLE Food (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(1000) NOT NULL,
    FoodCategoryID int NOT NULL,
    Price int NOT NULL DEFAULT 0,
    Notes nvarchar(3000) NULL,
    FOREIGN KEY (FoodCategoryID) REFERENCES FoodCategory(ID)
);
GO

-- =============================================
-- Bảng Invoice (Hóa đơn)
-- =============================================
CREATE TABLE Invoice (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(1000) NOT NULL,
    TableID int NOT NULL,
    Total int NOT NULL DEFAULT 0,
    Discount float NULL DEFAULT 0,
    Tax float NULL DEFAULT 0,
    Status bit NOT NULL DEFAULT 0, -- 0: Chưa thanh toán, 1: Đã thanh toán
    AccountID int NULL,
    CheckoutDate smalldatetime NULL,
    FOREIGN KEY (TableID) REFERENCES [Table](ID)
);
GO

-- =============================================
-- Bảng InvoiceDetails (Chi tiết hóa đơn)
-- =============================================
CREATE TABLE InvoiceDetails (
    ID int IDENTITY(1,1) PRIMARY KEY,
    InvoiceID int NOT NULL,
    FoodID int NOT NULL,
    Amount int NOT NULL DEFAULT 0, -- Số lượng
    FOREIGN KEY (InvoiceID) REFERENCES Invoice(ID),
    FOREIGN KEY (FoodID) REFERENCES Food(ID)
);
GO

-- =============================================
-- Bảng Account (Tài khoản)
-- =============================================
CREATE TABLE Account (
    AccountName nvarchar(100) PRIMARY KEY,
    Password nvarchar(200) NOT NULL,
    FullName nvarchar(1000) NOT NULL,
    Email nvarchar(1000) NULL,
    Phone nvarchar(200) NULL,
    DateCreated smalldatetime NULL DEFAULT GETDATE()
);
GO

-- =============================================
-- Bảng Role (Quyền)
-- =============================================
CREATE TABLE Role (
    ID int IDENTITY(1,1) PRIMARY KEY,
    RoleName nvarchar(1000) NOT NULL,
    Path nvarchar(3000) NULL,
    Notes nvarchar(3000) NULL
);
GO

-- =============================================
-- Bảng RoleAccount (Phân quyền)
-- =============================================
CREATE TABLE RoleAccount (
    AccountName nvarchar(100) NOT NULL,
    RoleID int NOT NULL,
    Actived bit NOT NULL DEFAULT 1,
    Notes nvarchar(3000) NULL,
    PRIMARY KEY (AccountName, RoleID),
    FOREIGN KEY (AccountName) REFERENCES Account(AccountName),
    FOREIGN KEY (RoleID) REFERENCES Role(ID)
);
GO

-- =============================================
-- THÊM DỮ LIỆU MẪU
-- =============================================

-- Thêm nhà hàng
INSERT INTO Restaurant (Name, Address, Phone, Website) 
VALUES (N'Nhà hàng ABC', N'123 Đường XYZ, TP.HCM', N'02633...', N'www.restaurant.com');
GO

-- Thêm sảnh
INSERT INTO Hall (Name, RestaurantID) VALUES (N'Sảnh 1', 1);
INSERT INTO Hall (Name, RestaurantID) VALUES (N'Sảnh 2', 1);
INSERT INTO Hall (Name, RestaurantID) VALUES (N'Sảnh VIP', 1);
GO

-- Thêm bàn
INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID) 
VALUES (N'2.11', N'Bàn 1', 0, 4, 1);
INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID) 
VALUES (N'2.12', N'Bàn 2', 0, 4, 1);
INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID) 
VALUES (N'2.13', N'Bàn 3', 0, 6, 1);
INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID) 
VALUES (N'2.14', N'Bàn 4', 0, 4, 1);
INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID) 
VALUES (N'2.15', N'Bàn 5', 0, 8, 1);
INSERT INTO [Table] (Name, Status, Seats, HallID) 
VALUES (N'Bàn VIP', 0, 10, 3);
GO

-- Thêm danh mục món ăn
INSERT INTO FoodCategory (Name, Type) VALUES (N'Khai vị', 1);
INSERT INTO FoodCategory (Name, Type) VALUES (N'Món chính', 1);
INSERT INTO FoodCategory (Name, Type) VALUES (N'Món tráng miệng', 1);
INSERT INTO FoodCategory (Name, Type) VALUES (N'Nước ngọt', 2);
INSERT INTO FoodCategory (Name, Type) VALUES (N'Bia rượu', 2);
INSERT INTO FoodCategory (Name, Type) VALUES (N'Nước ép', 2);
GO

-- Thêm món ăn
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Salad rau trộn', 1, 50000, N'Tươi mát');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Gỏi cuốn', 1, 40000, N'Đặc sản');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Bò lúc lắc', 2, 150000, N'Món nổi bật');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Cơm chiên dương châu', 2, 80000, N'');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Phở bò', 2, 70000, N'');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Kem vani', 3, 30000, N'');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Coca Cola', 4, 15000, N'Lon 330ml');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Pepsi', 4, 15000, N'Lon 330ml');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Bia Heineken', 5, 25000, N'Lon 330ml');
INSERT INTO Food (Name, FoodCategoryID, Price, Notes) 
VALUES (N'Nước cam', 6, 35000, N'Tươi');
GO

-- Thêm tài khoản
INSERT INTO Account (AccountName, Password, FullName, Email, Phone) 
VALUES (N'admin', N'admin123', N'Quản trị viên', N'admin@restaurant.com', N'0901234567');
INSERT INTO Account (AccountName, Password, FullName, Email, Phone) 
VALUES (N'lgcong', N'legiacong', N'Lê Gia Công', N'conglg@dlu.edu.vn', NULL);
INSERT INTO Account (AccountName, Password, FullName, Email, Phone) 
VALUES (N'pttnga', N'phanthithanhnga', N'Phan Thị Thanh Nga', N'ngaptt@dlu.edu.vn', NULL);
INSERT INTO Account (AccountName, Password, FullName, Email, Phone) 
VALUES (N'tdquy', N'thaiduyquy', N'Thái Duy Quý', N'quytd@dlu.edu.vn', NULL);
INSERT INTO Account (AccountName, Password, FullName, Email, Phone) 
VALUES (N'ttplinh', N'tranthiphuonglinh', N'Trần Thị Phương Linh', N'linhttp@dlu.edu.vn', NULL);
GO

-- Thêm quyền
INSERT INTO Role (RoleName, Path, Notes) VALUES (N'Adminstrator', NULL, N'Quản trị viên');
INSERT INTO Role (RoleName, Path, Notes) VALUES (N'Manager', NULL, N'Quản lý');
INSERT INTO Role (RoleName, Path, Notes) VALUES (N'Staff', NULL, N'Nhân viên');
GO

-- Phân quyền
INSERT INTO RoleAccount (AccountName, RoleID, Actived) VALUES (N'admin', 1, 1);
INSERT INTO RoleAccount (AccountName, RoleID, Actived) VALUES (N'lgcong', 1, 1);
INSERT INTO RoleAccount (AccountName, RoleID, Actived) VALUES (N'pttnga', 1, 1);
INSERT INTO RoleAccount (AccountName, RoleID, Actived) VALUES (N'tdquy', 1, 1);
INSERT INTO RoleAccount (AccountName, RoleID, Actived) VALUES (N'ttplinh', 3, 1);
GO

PRINT 'Database updated successfully according to new design!';
GO
