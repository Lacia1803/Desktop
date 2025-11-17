using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_2212364_PVQHien.DA
{
    /// <summary>
    /// Lớp quản lý Account: DA = DataAccess
    /// </summary>
    public class AccountDA
    {
        // Phương thức lấy hết dữ liệu theo thủ tục Account_GetAll
        public List<Account> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Account_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<Account> list = new List<Account>();
            while (reader.Read())
            {
                Account account = new Account();
                account.AccountName = reader["AccountName"].ToString();
                account.Password = reader["Password"].ToString();
                account.FullName = reader["FullName"].ToString();
                account.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                account.Tell = reader["Tell"] != DBNull.Value ? reader["Tell"].ToString() : "";
                account.DateCreated = reader["DateCreated"] != DBNull.Value ? (DateTime?)reader["DateCreated"] : null;
                account.Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "Nhân viên";
                list.Add(account);
            }
            sqlConn.Close();
            return list;
        }

        // Phương thức đăng nhập
        public Account Login(string username, string password)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Account_Login;
            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = username;
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = password;
            SqlDataReader reader = command.ExecuteReader();
            Account account = null;
            if (reader.Read())
            {
                account = new Account();
                account.AccountName = reader["AccountName"].ToString();
                account.Password = reader["Password"].ToString();
                account.FullName = reader["FullName"].ToString();
                account.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                account.Tell = reader["Tell"] != DBNull.Value ? reader["Tell"].ToString() : "";
                account.DateCreated = reader["DateCreated"] != DBNull.Value ? (DateTime?)reader["DateCreated"] : null;
                account.Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "Nhân viên";
            }
            sqlConn.Close();
            return account;
        }

        // Phương thức thêm, xoá, sửa theo thủ tục Account_InsertUpdateDelete
        public int Insert_Update_Delete(Account account, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Account_InsertUpdateDelete;
            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = account.AccountName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = account.Password;
            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = account.FullName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = account.Email ?? "";
            command.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = account.Tell ?? "";
            command.Parameters.Add("@Role", SqlDbType.NVarChar, 50).Value = account.Role ?? "Nhân viên";
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            int result = command.ExecuteNonQuery();
            sqlConn.Close();
            return result;
        }
    }
}
