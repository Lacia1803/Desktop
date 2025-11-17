using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Restaurant (Nhà hàng)
    /// </summary>
    public class Restaurant
    {
        // ID nhà hàng (ID trong DB)
        public int ID { get; set; }
        // Tên nhà hàng (Name trong DB)
        public string Name { get; set; }
        // Địa chỉ (Address trong DB)
        public string Address { get; set; }
        // Điện thoại (Phone trong DB)
        public string Phone { get; set; }
        // Website (Website trong DB)
        public string Website { get; set; }
    }
}
