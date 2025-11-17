using Lab06_2212364_PVQHien.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.BUS
{
    /// <summary>
    /// Lớp BillDetailBL có các phương thức xử lý bảng BillDetail
    /// </summary>
    public class BillDetailBL
    {
        BillDetailDA billDetailDA = new BillDetailDA();
        
        // Phương thức lấy hết dữ liệu
        public List<BillDetail> GetAll()
        {
            return billDetailDA.GetAll();
        }
        
        // Phương thức lấy chi tiết theo hóa đơn
        public List<BillDetail> GetByBill(int billID)
        {
            return billDetailDA.GetByBill(billID);
        }
        
        // Phương thức thêm dữ liệu
        public int Insert(BillDetail detail)
        {
            return billDetailDA.Insert_Update_Delete(detail, 0);
        }
        
        // Phương thức cập nhật dữ liệu
        public int Update(BillDetail detail)
        {
            return billDetailDA.Insert_Update_Delete(detail, 1);
        }
        
        // Phương thức xoá dữ liệu
        public int Delete(BillDetail detail)
        {
            return billDetailDA.Insert_Update_Delete(detail, 2);
        }
    }
}
