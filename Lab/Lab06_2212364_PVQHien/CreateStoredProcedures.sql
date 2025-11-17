USE [RestaurantManagement]
GO

-- =============================================
-- TẠO CÁC STORED PROCEDURES CHO DATABASE
-- =============================================

-- =============================================
-- Stored Procedure: Food_GetAll
-- Mô tả: Lấy tất cả món ăn
-- =============================================
IF OBJECT_ID('Food_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE Food_GetAll;
GO

CREATE PROCEDURE Food_GetAll
AS
BEGIN
    SELECT ID, Name, FoodCategoryID, Price, Notes
    FROM Food
END
GO

-- =============================================
-- Stored Procedure: Food_InsertUpdateDelete
-- Mô tả: Thêm, sửa, xóa món ăn
-- =============================================
IF OBJECT_ID('Food_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Food_InsertUpdateDelete;
GO

CREATE PROCEDURE Food_InsertUpdateDelete
    @ID int output, -- ID món ăn (output khi thêm mới)
    @Name nvarchar(1000), -- Tên món ăn
    @FoodCategoryID int, -- ID danh mục
    @Price int, -- Giá (kiểu int)
    @Notes nvarchar(3000), -- Ghi chú
    @Action int -- 0: Thêm, 1: Sửa, 2: Xóa
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO Food (Name, FoodCategoryID, Price, Notes)
        VALUES (@Name, @FoodCategoryID, @Price, @Notes)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE Food 
        SET Name = @Name,
            FoodCategoryID = @FoodCategoryID,
            Price = @Price,
            Notes = @Notes
        WHERE ID = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM Food WHERE ID = @ID
    END
END
GO

-- =============================================
-- Stored Procedure: Category_GetAll (FoodCategory)
-- Mô tả: Lấy tất cả danh mục
-- =============================================
IF OBJECT_ID('Category_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE Category_GetAll;
GO

CREATE PROCEDURE Category_GetAll
AS
BEGIN
    SELECT ID, Name, Type
    FROM FoodCategory
END
GO

-- =============================================
-- Stored Procedure: Category_InsertUpdateDelete
-- Mô tả: Thêm, sửa, xóa danh mục
-- =============================================
IF OBJECT_ID('Category_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Category_InsertUpdateDelete;
GO

CREATE PROCEDURE Category_InsertUpdateDelete
    @ID int output,
    @Name nvarchar(1000),
    @Type int,
    @Action int -- 0: Thêm, 1: Sửa, 2: Xóa
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO FoodCategory (Name, Type)
        VALUES (@Name, @Type)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE FoodCategory 
        SET Name = @Name,
            Type = @Type
        WHERE ID = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM FoodCategory WHERE ID = @ID
    END
END
GO

-- =============================================
-- Stored Procedure: Account_Login
-- Mô tả: Đăng nhập tài khoản
-- =============================================
IF OBJECT_ID('Account_Login', 'P') IS NOT NULL
    DROP PROCEDURE Account_Login;
GO

CREATE PROCEDURE Account_Login
    @AccountName nvarchar(100),
    @Password nvarchar(200)
AS
BEGIN
    SELECT AccountName, FullName, Email, Phone, DateCreated
    FROM Account
    WHERE AccountName = @AccountName AND Password = @Password
END
GO

-- =============================================
-- Stored Procedure: Account_ChangePassword
-- Mô tả: Đổi mật khẩu
-- =============================================
IF OBJECT_ID('Account_ChangePassword', 'P') IS NOT NULL
    DROP PROCEDURE Account_ChangePassword;
GO

CREATE PROCEDURE Account_ChangePassword
    @AccountName nvarchar(100),
    @OldPassword nvarchar(200),
    @NewPassword nvarchar(200)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Account WHERE AccountName = @AccountName AND Password = @OldPassword)
    BEGIN
        UPDATE Account 
        SET Password = @NewPassword
        WHERE AccountName = @AccountName
        RETURN 1
    END
    ELSE
    BEGIN
        RETURN 0
    END
END
GO

PRINT 'All stored procedures created successfully!';
GO
