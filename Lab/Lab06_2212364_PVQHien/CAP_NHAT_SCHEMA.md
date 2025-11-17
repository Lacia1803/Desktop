# CẬP NHẬT DỰ ÁN THEO SCHEMA MỚI

## Ngày: 17/11/2025

## Tổng quan thay đổi

Dự án đã được cập nhật hoàn toàn để khớp với thiết kế database trong ảnh bạn cung cấp.

## 1. Thay đổi Database Schema

### Bảng đã cập nhật:

#### Food
- ❌ **Xóa**: cột `Unit` (đơn vị tính)
- ✅ **Giữ nguyên**: `ID`, `Name`, `FoodCategoryID`, `Price` (int), `Notes`

#### FoodCategory (trước đây là Category)
- ✅ **Tên bảng**: `FoodCategory`
- ✅ **Các cột**: `ID`, `Name`, `Type` (1=Đồ ăn, 2=Thức uống)

#### Table
- ✅ **Thêm**: `TableCode`, `Seats`, `HallID`
- ✅ **Đổi**: `Status` từ string → int (0=Chưa đặt, 1=Đã đặt, 2=Có khách)

#### Invoice (trước đây là Bills)
- ✅ **Tên bảng**: `Invoice`
- ✅ **Đổi**: `Amount` → `Total` (int)
- ✅ **Đổi**: `Account` (string) → `AccountID` (int)
- ✅ **Giữ**: `Discount`, `Tax` (float)

#### InvoiceDetails (trước đây là BillDetails)
- ✅ **Tên bảng**: `InvoiceDetails`
- ✅ **Đổi**: `Quantity` → `Amount`

### Bảng mới:
- ✅ **Restaurant**: Thông tin nhà hàng
- ✅ **Hall**: Thông tin sảnh

## 2. Files đã thay đổi

### A. Models (Lab06_2212364_PVQHien.DA)

#### Food.cs
```csharp
// Trước
public int FoodID { get; set; }
public string FoodName { get; set; }
public string Unit { get; set; }
public int CategoryID { get; set; }
public decimal Price { get; set; }

// Sau
public int ID { get; set; }
public string Name { get; set; }
public int FoodCategoryID { get; set; }
public int Price { get; set; }  // Đổi từ decimal → int
public string Notes { get; set; }
```

#### Category.cs
```csharp
// Trước
public int CategoryID { get; set; }
public string CategoryName { get; set; }

// Sau
public int ID { get; set; }
public string Name { get; set; }
public int Type { get; set; }
```

#### Table.cs
```csharp
// Trước
public int TableID { get; set; }
public string TableName { get; set; }
public string Status { get; set; }

// Sau
public int ID { get; set; }
public string TableCode { get; set; }
public string Name { get; set; }
public int Status { get; set; }  // Đổi từ string → int
public int? Seats { get; set; }
public int? HallID { get; set; }
```

#### Bill.cs
```csharp
// Trước
public decimal Amount { get; set; }
public decimal Discount { get; set; }
public decimal Tax { get; set; }
public string Account { get; set; }

// Sau
public int Total { get; set; }  // Đổi từ Amount
public float? Discount { get; set; }
public float? Tax { get; set; }
public int? AccountID { get; set; }  // Đổi từ Account string
```

#### BillDetail.cs
```csharp
// Trước
public int Quantity { get; set; }

// Sau
public int Amount { get; set; }
```

#### Restaurant.cs (MỚI)
```csharp
public int ID { get; set; }
public string Name { get; set; }
public string Address { get; set; }
public string Phone { get; set; }
public string Website { get; set; }
```

#### Hall.cs (MỚI)
```csharp
public int ID { get; set; }
public string Name { get; set; }
public int RestaurantID { get; set; }
```

### B. Data Access Layer

#### FoodDA.cs
- Bỏ tham số `@Unit`
- Đổi `@CategoryID` → `@FoodCategoryID`
- Đổi `@Price` từ `SqlDbType.Decimal` → `SqlDbType.Int`
- Map: `FoodID` → `ID`, `FoodName` → `Name`

#### CategoryDA.cs
- Map: `CategoryID` → `ID`, `CategoryName` → `Name`

#### TableDA.cs
- Thêm: `TableCode`, `Seats`, `HallID`
- Đổi `Status` từ string → int
- Map: `TableID` → `ID`, `TableName` → `Name`

#### BillDA.cs
- Đổi `Amount` → `Total`
- Đổi `Account` (string) → `AccountID` (int)
- Đổi `Discount`, `Tax` từ decimal → float

#### BillDetailDA.cs
- Đổi `Quantity` → `Amount`

### C. Business Logic Layer

#### FoodBL.cs
- Cập nhật GetByID: `item.FoodID` → `item.ID`
- Cập nhật Find: bỏ `Unit`, đổi `FoodID` → `ID`, `FoodName` → `Name`

#### TableBL.cs
- Đổi UpdateStatus: `string status` → `int status`

### D. Presentation Layer

#### Form1.cs (frmFood)
- Bỏ tất cả code liên quan đến `txtUnit`
- Đổi `cbbCategory.ValueMember` từ `"CategoryID"` → `"ID"`
- Đổi `cbbCategory.DisplayMember` từ `"CategoryName"` → `"Name"`
- Đổi price parsing: `decimal.Parse` → `int.Parse`
- Cập nhật ListView: bỏ cột Unit
- Cập nhật InsertFood/UpdateFood: bỏ Unit, đổi tên properties

## 3. Files SQL

### UpdateDatabaseSchema.sql
- **MỤC ĐÍCH**: Xóa và tạo lại toàn bộ database theo schema mới
- **NỘI DUNG**: 
  - Xóa tất cả bảng cũ
  - Tạo lại với cấu trúc mới
  - Thêm dữ liệu mẫu
- **CÁCH CHẠY**: 
  1. Mở SQL Server Management Studio
  2. Kết nối đến server
  3. Mở file và chạy (F5)

### CreateStoredProcedures.sql
- **MỤC ĐÍCH**: Tạo các stored procedures mới
- **NỘI DUNG**:
  - `Food_GetAll`: Lấy tất cả món ăn
  - `Food_InsertUpdateDelete`: Thêm/sửa/xóa món (không có @Unit, @Price là int)
  - `Category_GetAll`: Lấy từ bảng FoodCategory
  - `Category_InsertUpdateDelete`: Thao tác FoodCategory
  - `Account_Login`: Đăng nhập
  - `Account_ChangePassword`: Đổi mật khẩu
- **CÁCH CHẠY**: Sau khi chạy UpdateDatabaseSchema.sql, chạy file này

## 4. Hướng dẫn Deploy

### Bước 1: Cập nhật Database
```sql
-- 1. Chạy UpdateDatabaseSchema.sql
-- File này sẽ xóa database cũ và tạo lại với schema mới

-- 2. Chạy CreateStoredProcedures.sql
-- File này tạo các stored procedures cần thiết
```

### Bước 2: Build và Run
```bash
cd Lab06_2212364_PVQHien
dotnet build
```

### Bước 3: Kiểm tra kết nối
- Mở `App.config` trong project Win
- Kiểm tra connection string:
```xml
<connectionStrings>
  <add name="QLNhaHang" 
       connectionString="Data Source=.;Initial Catalog=RestaurantManagement;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Bước 4: Test các chức năng
1. **Đăng nhập**: admin/admin123 hoặc lgcong/legiacong
2. **Quản lý món ăn**: 
   - Thêm món (không cần nhập Unit nữa)
   - Giá nhập số nguyên (VD: 50000)
   - Chọn danh mục từ ComboBox
3. **Đổi mật khẩu**: Menu System → Đổi mật khẩu

## 5. Lưu ý quan trọng

### ⚠️ Breaking Changes
1. **Price là int**: Không còn hỗ trợ số thập phân (VD: 50000.50)
2. **Không có Unit**: Form không còn ô nhập đơn vị tính
3. **Table Status là số**: 0=Chưa đặt, 1=Đã đặt, 2=Có khách
4. **AccountID**: Hóa đơn lưu ID tài khoản (int), không phải tên (string)

### ✅ Tính năng đã hoàn thành
- ✅ Đăng nhập
- ✅ Quản lý món ăn (CRUD)
- ✅ Quản lý danh mục
- ✅ Đổi mật khẩu
- ✅ Xóa món có kiểm tra ràng buộc

### ⏳ Tính năng chưa làm
- ⏳ Quản lý bàn
- ⏳ Đặt món
- ⏳ Thanh toán
- ⏳ Quản lý tài khoản
- ⏳ Báo cáo thống kê

## 6. Cấu trúc dữ liệu mẫu

### Tài khoản
| AccountName | Password | FullName |
|-------------|----------|----------|
| admin | admin123 | Quản trị viên |
| lgcong | legiacong | Lê Gia Công |
| pttnga | phanthithanhnga | Phan Thị Thanh Nga |

### Danh mục món ăn
| ID | Name | Type |
|----|------|------|
| 1 | Khai vị | 1 (Đồ ăn) |
| 2 | Món chính | 1 (Đồ ăn) |
| 3 | Nước ngọt | 2 (Thức uống) |

### Món ăn
| ID | Name | FoodCategoryID | Price |
|----|------|----------------|-------|
| 1 | Salad rau trộn | 1 | 50000 |
| 2 | Bò lúc lắc | 2 | 150000 |
| 3 | Coca Cola | 3 | 15000 |

## 7. Troubleshooting

### Lỗi build
```
Error: 'Food' does not contain a definition for 'FoodID'
→ Đã sửa: Đổi tất cả FoodID → ID, FoodName → Name
```

### Lỗi database
```
Invalid column name 'Unit'
→ Đã sửa: Bỏ cột Unit khỏi bảng Food và tất cả code
```

### Lỗi type mismatch
```
Cannot convert 'decimal' to 'int'
→ Đã sửa: Price là int trong cả DB và C# code
```

## Kết luận

Dự án đã được đồng bộ hoàn toàn với thiết kế database trong ảnh. Tất cả các file đã được cập nhật và build thành công. Bạn có thể chạy ứng dụng và test các chức năng.
