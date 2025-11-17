using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng InvoiceDetails (Chi tiết hóa đơn)
    /// </summary>
    public class BillDetail
    {
        // ID chi tiết hóa đơn (ID trong DB)
        public int ID { get; set; }
        // ID hóa đơn (InvoiceID trong DB)
        public int InvoiceID { get; set; }
        // ID món ăn (FoodID trong DB)
        public int FoodID { get; set; }
        // Số lượng (Amount trong DB)
        public int Amount { get; set; }
    }
}
