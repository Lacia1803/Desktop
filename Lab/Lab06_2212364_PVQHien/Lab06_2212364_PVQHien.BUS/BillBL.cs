using Lab06_2212364_PVQHien.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.BUS
{
    /// <summary>
    /// Lớp BillBL có các phương thức xử lý bảng Bill
    /// </summary>
    public class BillBL
    {
        BillDA billDA = new BillDA();
        
        // Phương thức lấy hết dữ liệu
        public List<Bill> GetAll()
        {
            return billDA.GetAll();
        }
        
        // Phương thức lấy hóa đơn theo bàn
        public Bill GetByTable(int tableID)
        {
            return billDA.GetByTable(tableID);
        }
        
        // Phương thức thêm dữ liệu
        public int Insert(Bill bill)
        {
            return billDA.Insert_Update_Delete(bill, 0);
        }
        
        // Phương thức cập nhật dữ liệu
        public int Update(Bill bill)
        {
            return billDA.Insert_Update_Delete(bill, 1);
        }
        
        // Phương thức xoá dữ liệu
        public int Delete(Bill bill)
        {
            return billDA.Insert_Update_Delete(bill, 2);
        }
    }
}
