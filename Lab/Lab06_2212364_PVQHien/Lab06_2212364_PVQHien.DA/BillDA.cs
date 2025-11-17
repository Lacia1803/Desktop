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
    /// Lớp quản lý Bill: DA = DataAccess
    /// </summary>
    public class BillDA
    {
        // Phương thức lấy hết dữ liệu theo thủ tục Bill_GetAll
        public List<Bill> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<Bill> list = new List<Bill>();
            while (reader.Read())
            {
                Bill bill = new Bill();
                bill.ID = Convert.ToInt32(reader["ID"]);
                bill.Name = reader["Name"].ToString();
                bill.TableID = Convert.ToInt32(reader["TableID"]);
                bill.Total = Convert.ToInt32(reader["Total"]);
                bill.Discount = reader["Discount"] != DBNull.Value ? (float?)Convert.ToSingle(reader["Discount"]) : null;
                bill.Tax = reader["Tax"] != DBNull.Value ? (float?)Convert.ToSingle(reader["Tax"]) : null;
                bill.Status = Convert.ToBoolean(reader["Status"]);
                bill.CheckoutDate = reader["CheckoutDate"] != DBNull.Value ? (DateTime?)reader["CheckoutDate"] : null;
                bill.AccountID = reader["AccountID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["AccountID"]) : null;
                list.Add(bill);
            }
            sqlConn.Close();
            return list;
        }

        // Phương thức lấy hóa đơn theo bàn
        public Bill GetByTable(int tableID)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_GetByTable;
            command.Parameters.Add("@TableID", SqlDbType.Int).Value = tableID;
            SqlDataReader reader = command.ExecuteReader();
            Bill bill = null;
            if (reader.Read())
            {
                bill = new Bill();
                bill.ID = Convert.ToInt32(reader["ID"]);
                bill.Name = reader["Name"].ToString();
                bill.TableID = Convert.ToInt32(reader["TableID"]);
                bill.Total = Convert.ToInt32(reader["Total"]);
                bill.Discount = reader["Discount"] != DBNull.Value ? (float?)Convert.ToSingle(reader["Discount"]) : null;
                bill.Tax = reader["Tax"] != DBNull.Value ? (float?)Convert.ToSingle(reader["Tax"]) : null;
                bill.Status = Convert.ToBoolean(reader["Status"]);
                bill.CheckoutDate = reader["CheckoutDate"] != DBNull.Value ? (DateTime?)reader["CheckoutDate"] : null;
                bill.AccountID = reader["AccountID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["AccountID"]) : null;
            }
            sqlConn.Close();
            return bill;
        }

        // Phương thức thêm, xoá, sửa theo thủ tục Bill_InsertUpdateDelete
        public int Insert_Update_Delete(Bill bill, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_InsertUpdateDelete;
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = bill.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = bill.Name;
            command.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
            command.Parameters.Add("@Total", SqlDbType.Int).Value = bill.Total;
            command.Parameters.Add("@Discount", SqlDbType.Float).Value = (object)bill.Discount ?? DBNull.Value;
            command.Parameters.Add("@Tax", SqlDbType.Float).Value = (object)bill.Tax ?? DBNull.Value;
            command.Parameters.Add("@Status", SqlDbType.Bit).Value = bill.Status;
            command.Parameters.Add("@AccountID", SqlDbType.Int).Value = (object)bill.AccountID ?? DBNull.Value;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return (int)command.Parameters["@ID"].Value;
            return 0;
        }
    }
}
