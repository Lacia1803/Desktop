using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Invoice (Hóa đơn)
    /// </summary>
    public class Bill
    {
        // ID hóa đơn (ID trong DB)
        public int ID { get; set; }
        // Tên hóa đơn (Name trong DB)
        public string Name { get; set; }
        // ID bàn (TableID trong DB)
        public int TableID { get; set; }
        // Tổng tiền (Total trong DB, kiểu int)
        public int Total { get; set; }
        // Giảm giá (Discount trong DB, kiểu float)
        public float? Discount { get; set; }
        // Thuế (Tax trong DB, kiểu float)
        public float? Tax { get; set; }
        // Trạng thái: 0=Chưa thanh toán, 1=Đã thanh toán (Status trong DB, kiểu bit)
        public bool Status { get; set; }
        // Tài khoản (AccountID trong DB, kiểu int)
        public int? AccountID { get; set; }
        // Ngày thanh toán (CheckoutDate trong DB)
        public DateTime? CheckoutDate { get; set; }
    }
}
