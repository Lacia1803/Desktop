using Lab06_2212364_PVQHien.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.BUS
{
    /// <summary>
    /// Lớp AccountBL có các phương thức xử lý bảng Account
    /// </summary>
    public class AccountBL
    {
        AccountDA accountDA = new AccountDA();
        
        // Phương thức lấy hết dữ liệu
        public List<Account> GetAll()
        {
            return accountDA.GetAll();
        }
        
        // Phương thức đăng nhập
        public Account Login(string username, string password)
        {
            return accountDA.Login(username, password);
        }
        
        // Phương thức thêm dữ liệu
        public int Insert(Account account)
        {
            return accountDA.Insert_Update_Delete(account, 0);
        }
        
        // Phương thức cập nhật dữ liệu
        public int Update(Account account)
        {
            return accountDA.Insert_Update_Delete(account, 1);
        }
        
        // Phương thức xoá dữ liệu
        public int Delete(Account account)
        {
            return accountDA.Insert_Update_Delete(account, 2);
        }
    }
}
