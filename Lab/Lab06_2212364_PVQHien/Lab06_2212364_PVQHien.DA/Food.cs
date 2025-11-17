using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Food
    /// </summary>
    public class Food
    {
        // ID của bảng Food (ID trong DB)
        public int ID { get; set; }
        // Tên loại đồ ăn, thức uống (Name trong DB)
        public string Name { get; set; }
        // Loại thức ăn (FoodCategoryID trong DB)
        public int FoodCategoryID { get; set; }
        // Giá (Price trong DB, kiểu int)
        public int Price { get; set; }
        // Ghi chú (Notes trong DB)
        public string Notes { get; set; }
    }
}
