using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Hall (Sảnh)
    /// </summary>
    public class Hall
    {
        // ID sảnh (ID trong DB)
        public int ID { get; set; }
        // Tên sảnh (Name trong DB)
        public string Name { get; set; }
        // ID nhà hàng (RestaurantID trong DB)
        public int RestaurantID { get; set; }
    }
}
