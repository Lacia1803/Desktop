using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng FoodCategory
    /// </summary>
    public class Category
    {
        // ID của bảng, tự tăng trong CSDL (ID trong DB)
        public int ID { get; set; }
        // Tên của loại thức ăn (Name trong DB)
        public string Name { get; set; }
        // Kiểu: 1 là đồ ăn; 2 là thức uống (Type trong DB)
        public int Type { get; set; }
    }
}
