using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Lab06_2212364_PVQHien.DA
{
    public class Ultilities
    {
        // lấy chuỗi kết nối từ tập tin App.Config
        private static string StrName = "ConnectionStringName";
        
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;
        // Các biến của bảng Food
        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";
        // Các biến của bảng Category
        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";
        // Các biến của bảng Account
        public static string Account_GetAll = "Account_GetAll";
        public static string Account_InsertUpdateDelete = "Account_InsertUpdateDelete";
        public static string Account_Login = "Account_Login";
        // Các biến của bảng Table
        public static string Table_GetAll = "Table_GetAll";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";
        public static string Table_UpdateStatus = "Table_UpdateStatus";
        // Các biến của bảng Bill
        public static string Bill_GetAll = "Bill_GetAll";
        public static string Bill_InsertUpdateDelete = "Bill_InsertUpdateDelete";
        public static string Bill_GetByTable = "Bill_GetByTable";
        // Các biến của bảng BillDetails
        public static string BillDetail_GetAll = "BillDetail_GetAll";
        public static string BillDetail_InsertUpdateDelete = "BillDetail_InsertUpdateDelete";
        public static string BillDetail_GetByBill = "BillDetail_GetByBill";
    }
}
