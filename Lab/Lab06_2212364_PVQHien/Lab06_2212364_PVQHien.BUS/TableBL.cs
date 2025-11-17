using Lab06_2212364_PVQHien.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.BUS
{
    /// <summary>
    /// Lớp TableBL có các phương thức xử lý bảng Table
    /// </summary>
    public class TableBL
    {
        TableDA tableDA = new TableDA();
        
        // Phương thức lấy hết dữ liệu
        public List<Table> GetAll()
        {
            return tableDA.GetAll();
        }
        
        // Phương thức cập nhật trạng thái bàn
        public int UpdateStatus(int tableID, int status)
        {
            return tableDA.UpdateStatus(tableID, status);
        }
        
        // Phương thức thêm dữ liệu
        public int Insert(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 0);
        }
        
        // Phương thức cập nhật dữ liệu
        public int Update(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 1);
        }
        
        // Phương thức xoá dữ liệu
        public int Delete(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 2);
        }
    }
}
