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
    /// Lớp quản lý BillDetail: DA = DataAccess
    /// </summary>
    public class BillDetailDA
    {
        // Phương thức lấy hết dữ liệu theo thủ tục BillDetail_GetAll
        public List<BillDetail> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.BillDetail_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<BillDetail> list = new List<BillDetail>();
            while (reader.Read())
            {
                BillDetail detail = new BillDetail();
                detail.ID = Convert.ToInt32(reader["ID"]);
                detail.InvoiceID = Convert.ToInt32(reader["InvoiceID"]);
                detail.FoodID = Convert.ToInt32(reader["FoodID"]);
                detail.Amount = Convert.ToInt32(reader["Amount"]);
                list.Add(detail);
            }
            sqlConn.Close();
            return list;
        }

        // Phương thức lấy chi tiết theo hóa đơn
        public List<BillDetail> GetByBill(int billID)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.BillDetail_GetByBill;
            command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = billID;
            SqlDataReader reader = command.ExecuteReader();
            List<BillDetail> list = new List<BillDetail>();
            while (reader.Read())
            {
                BillDetail detail = new BillDetail();
                detail.ID = Convert.ToInt32(reader["ID"]);
                detail.InvoiceID = Convert.ToInt32(reader["InvoiceID"]);
                detail.FoodID = Convert.ToInt32(reader["FoodID"]);
                detail.Amount = Convert.ToInt32(reader["Amount"]);
                list.Add(detail);
            }
            sqlConn.Close();
            return list;
        }

        // Phương thức thêm, xoá, sửa theo thủ tục BillDetail_InsertUpdateDelete
        public int Insert_Update_Delete(BillDetail detail, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.BillDetail_InsertUpdateDelete;
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = detail.ID;
            command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = detail.InvoiceID;
            command.Parameters.Add("@FoodID", SqlDbType.Int).Value = detail.FoodID;
            command.Parameters.Add("@Amount", SqlDbType.Int).Value = detail.Amount;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return (int)command.Parameters["@ID"].Value;
            return 0;
        }
    }
}
