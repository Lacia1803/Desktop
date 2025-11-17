USE [RestaurantManagement]
GO

-- =============================================
-- Stored Procedures cho bảng Food (FIX)
-- =============================================

-- Thủ tục sửa lại Food_InsertUpdateDelete để dùng decimal cho Price
IF OBJECT_ID('Food_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Food_InsertUpdateDelete
GO

CREATE PROCEDURE [dbo].[Food_InsertUpdateDelete]
@ID int output,
@Name nvarchar(1000),
@Unit nvarchar(100),
@FoodCategoryID int,
@Price decimal(18,2),
@Notes nvarchar(3000),
@Action int
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO [Food] ([Name],[Unit],[FoodCategoryID],[Price],[Notes])
        VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE [Food]
        SET [Name] = @Name, [Unit] = @Unit, [FoodCategoryID] = @FoodCategoryID,
            [Price] = @Price, [Notes] = @Notes
        WHERE [ID] = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM [Food] WHERE [ID] = @ID
    END
END
GO

-- =============================================
-- Stored Procedures cho bảng Account
-- =============================================

-- Thủ tục đăng nhập
IF OBJECT_ID('Account_Login', 'P') IS NOT NULL
    DROP PROCEDURE Account_Login
GO

CREATE PROCEDURE [dbo].[Account_Login]
    @AccountName nvarchar(100),
    @Password nvarchar(200)
AS
BEGIN
    SELECT a.AccountName, a.Password, a.FullName, a.Email, a.Tell, a.DateCreated,
           CASE 
               WHEN EXISTS (SELECT 1 FROM RoleAccount ra INNER JOIN Role r ON ra.RoleID = r.ID 
                           WHERE ra.AccountName = a.AccountName AND ra.Actived = 1 AND r.RoleName = 'Adminstrator')
               THEN 'Administrator'
               ELSE 'Nhân viên'
           END as Role
    FROM Account a
    WHERE a.AccountName = @AccountName AND a.Password = @Password
END
GO

-- Thủ tục lấy tất cả tài khoản
IF OBJECT_ID('Account_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE Account_GetAll
GO

CREATE PROCEDURE [dbo].[Account_GetAll]
AS
BEGIN
    SELECT a.AccountName, a.Password, a.FullName, a.Email, a.Tell, a.DateCreated,
           CASE 
               WHEN EXISTS (SELECT 1 FROM RoleAccount ra INNER JOIN Role r ON ra.RoleID = r.ID 
                           WHERE ra.AccountName = a.AccountName AND ra.Actived = 1 AND r.RoleName = 'Adminstrator')
               THEN 'Administrator'
               ELSE 'Nhân viên'
           END as Role
    FROM Account a
END
GO

-- Thủ tục thêm, sửa, xóa tài khoản
IF OBJECT_ID('Account_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Account_InsertUpdateDelete
GO

CREATE PROCEDURE [dbo].[Account_InsertUpdateDelete]
    @AccountName nvarchar(100),
    @Password nvarchar(200),
    @FullName nvarchar(1000),
    @Email nvarchar(1000),
    @Tell nvarchar(200),
    @Role nvarchar(50),
    @Action int
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO Account (AccountName, Password, FullName, Email, Tell, DateCreated)
        VALUES (@AccountName, @Password, @FullName, @Email, @Tell, GETDATE())
        
        -- Gán role mặc định
        IF @Role = 'Administrator'
        BEGIN
            INSERT INTO RoleAccount (RoleID, AccountName, Actived)
            VALUES (1, @AccountName, 1)
        END
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE Account
        SET Password = @Password, FullName = @FullName, Email = @Email, Tell = @Tell
        WHERE AccountName = @AccountName
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM RoleAccount WHERE AccountName = @AccountName
        DELETE FROM Account WHERE AccountName = @AccountName
    END
END
GO

-- =============================================
-- Stored Procedures cho bảng Table
-- =============================================

-- Thủ tục lấy tất cả bàn
IF OBJECT_ID('Table_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE Table_GetAll
GO

CREATE PROCEDURE [dbo].[Table_GetAll]
AS
BEGIN
    SELECT * FROM [Table]
END
GO

-- Thủ tục cập nhật trạng thái bàn
IF OBJECT_ID('Table_UpdateStatus', 'P') IS NOT NULL
    DROP PROCEDURE Table_UpdateStatus
GO

CREATE PROCEDURE [dbo].[Table_UpdateStatus]
    @ID int,
    @Status int
AS
BEGIN
    UPDATE [Table]
    SET Status = @Status
    WHERE ID = @ID
END
GO

-- Thủ tục thêm, sửa, xóa bàn
IF OBJECT_ID('Table_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Table_InsertUpdateDelete
GO

CREATE PROCEDURE [dbo].[Table_InsertUpdateDelete]
    @ID int output,
    @Name nvarchar(1000),
    @Status int,
    @Action int
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO [Table] (Name, Status)
        VALUES (@Name, @Status)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE [Table]
        SET Name = @Name, Status = @Status
        WHERE ID = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM [Table] WHERE ID = @ID
    END
END
GO

-- =============================================
-- Stored Procedures cho bảng Bills
-- =============================================

-- Thủ tục lấy tất cả hóa đơn
IF OBJECT_ID('Bill_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE Bill_GetAll
GO

CREATE PROCEDURE [dbo].[Bill_GetAll]
AS
BEGIN
    SELECT * FROM Bills
END
GO

-- Thủ tục lấy hóa đơn theo bàn (chưa thanh toán)
IF OBJECT_ID('Bill_GetByTable', 'P') IS NOT NULL
    DROP PROCEDURE Bill_GetByTable
GO

CREATE PROCEDURE [dbo].[Bill_GetByTable]
    @TableID int
AS
BEGIN
    SELECT TOP 1 * FROM Bills
    WHERE TableID = @TableID AND Status = 0
    ORDER BY ID DESC
END
GO

-- Thủ tục thêm, sửa, xóa hóa đơn
IF OBJECT_ID('Bill_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE Bill_InsertUpdateDelete
GO

CREATE PROCEDURE [dbo].[Bill_InsertUpdateDelete]
    @ID int output,
    @Name nvarchar(1000),
    @TableID int,
    @Amount int,
    @Discount float,
    @Tax float,
    @Status bit,
    @Account nvarchar(100),
    @Action int
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        INSERT INTO Bills (Name, TableID, Amount, Discount, Tax, Status, Account)
        VALUES (@Name, @TableID, @Amount, @Discount, @Tax, @Status, @Account)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE Bills
        SET Name = @Name, TableID = @TableID, Amount = @Amount, 
            Discount = @Discount, Tax = @Tax, Status = @Status,
            CheckoutDate = CASE WHEN @Status = 1 THEN GETDATE() ELSE CheckoutDate END,
            Account = @Account
        WHERE ID = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM Bills WHERE ID = @ID
    END
END
GO

-- =============================================
-- Stored Procedures cho bảng BillDetails
-- =============================================

-- Thủ tục lấy tất cả chi tiết hóa đơn
IF OBJECT_ID('BillDetail_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE BillDetail_GetAll
GO

CREATE PROCEDURE [dbo].[BillDetail_GetAll]
AS
BEGIN
    SELECT * FROM BillDetails
END
GO

-- Thủ tục lấy chi tiết theo hóa đơn
IF OBJECT_ID('BillDetail_GetByBill', 'P') IS NOT NULL
    DROP PROCEDURE BillDetail_GetByBill
GO

CREATE PROCEDURE [dbo].[BillDetail_GetByBill]
    @InvoiceID int
AS
BEGIN
    SELECT * FROM BillDetails
    WHERE InvoiceID = @InvoiceID
END
GO

-- Thủ tục thêm, sửa, xóa chi tiết hóa đơn
IF OBJECT_ID('BillDetail_InsertUpdateDelete', 'P') IS NOT NULL
    DROP PROCEDURE BillDetail_InsertUpdateDelete
GO

CREATE PROCEDURE [dbo].[BillDetail_InsertUpdateDelete]
    @ID int output,
    @InvoiceID int,
    @FoodID int,
    @Quantity int,
    @Action int
AS
BEGIN
    IF @Action = 0 -- Thêm mới
    BEGIN
        -- Kiểm tra xem món ăn đã có trong hóa đơn chưa
        IF EXISTS (SELECT 1 FROM BillDetails WHERE InvoiceID = @InvoiceID AND FoodID = @FoodID)
        BEGIN
            -- Nếu có rồi thì cộng thêm số lượng
            UPDATE BillDetails
            SET Quantity = Quantity + @Quantity
            WHERE InvoiceID = @InvoiceID AND FoodID = @FoodID
            
            SELECT @ID = ID FROM BillDetails WHERE InvoiceID = @InvoiceID AND FoodID = @FoodID
        END
        ELSE
        BEGIN
            -- Nếu chưa có thì thêm mới
            INSERT INTO BillDetails (InvoiceID, FoodID, Quantity)
            VALUES (@InvoiceID, @FoodID, @Quantity)
            SET @ID = @@IDENTITY
        END
    END
    ELSE IF @Action = 1 -- Cập nhật
    BEGIN
        UPDATE BillDetails
        SET InvoiceID = @InvoiceID, FoodID = @FoodID, Quantity = @Quantity
        WHERE ID = @ID
    END
    ELSE IF @Action = 2 -- Xóa
    BEGIN
        DELETE FROM BillDetails WHERE ID = @ID
    END
END
GO

PRINT 'All stored procedures created successfully!'
GO
