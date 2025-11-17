using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Table (Bàn ăn)
    /// </summary>
    public class Table
    {
        // ID của bàn (ID trong DB)
        public int ID { get; set; }
        // Mã bàn (TableCode trong DB)
        public string TableCode { get; set; }
        // Tên bàn (Name trong DB)
        public string Name { get; set; }
        // Trạng thái: 0: chưa đặt, 1: Đã đặt, 2: Có khách (Status trong DB, kiểu int)
        public int Status { get; set; }
        // Số chỗ ngồi (Seats trong DB)
        public int? Seats { get; set; }
        // ID sảnh (HallID trong DB)
        public int? HallID { get; set; }
    }
}
