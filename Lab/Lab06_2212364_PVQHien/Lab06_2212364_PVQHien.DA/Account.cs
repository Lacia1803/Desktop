using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp ánh xạ bảng Account
    /// </summary>
    public class Account
    {
        // Tên tài khoản (Primary Key)
        public string AccountName { get; set; }
        // Mật khẩu
        public string Password { get; set; }
        // Họ tên đầy đủ
        public string FullName { get; set; }
        // Email
        public string Email { get; set; }
        // Số điện thoại
        public string Tell { get; set; }
        // Ngày tạo tài khoản
        public DateTime? DateCreated { get; set; }
        // Vai trò: Admin, Quản lý, Kế toán, Nhân viên
        public string Role { get; set; }
    }
}
