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
    /// Lớp quản lý Table: DA = DataAccess
    /// </summary>
    public class TableDA
    {
        // Phương thức lấy hết dữ liệu theo thủ tục Table_GetAll
        public List<Table> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<Table> list = new List<Table>();
            while (reader.Read())
            {
                Table table = new Table();
                table.ID = Convert.ToInt32(reader["ID"]);
                table.TableCode = reader["TableCode"] != DBNull.Value ? reader["TableCode"].ToString() : null;
                table.Name = reader["Name"].ToString();
                table.Status = Convert.ToInt32(reader["Status"]);
                table.Seats = reader["Seats"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Seats"]) : null;
                table.HallID = reader["HallID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["HallID"]) : null;
                list.Add(table);
            }
            sqlConn.Close();
            return list;
        }

        // Phương thức cập nhật trạng thái bàn
        public int UpdateStatus(int tableID, int status)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_UpdateStatus;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = tableID;
            command.Parameters.Add("@Status", SqlDbType.Int).Value = status;
            int result = command.ExecuteNonQuery();
            sqlConn.Close();
            return result;
        }

        // Phương thức thêm, xoá, sửa theo thủ tục Table_InsertUpdateDelete
        public int Insert_Update_Delete(Table table, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_InsertUpdateDelete;
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = table.ID;
            command.Parameters.Add("@TableCode", SqlDbType.NVarChar, 200).Value = (object)table.TableCode ?? DBNull.Value;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name;
            command.Parameters.Add("@Status", SqlDbType.Int).Value = table.Status;
            command.Parameters.Add("@Seats", SqlDbType.Int).Value = (object)table.Seats ?? DBNull.Value;
            command.Parameters.Add("@HallID", SqlDbType.Int).Value = (object)table.HallID ?? DBNull.Value;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return (int)command.Parameters["@ID"].Value;
            return 0;
        }
    }
}
