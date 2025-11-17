using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab05_2212364_PVQHien
{
	public partial class OrderDetailsForm : Form
	{
		private int orderId;

		public OrderDetailsForm(int orderId)
		{
			InitializeComponent();
			this.orderId = orderId;
		}

		private void OrderDetailsForm_Load(object sender, EventArgs e)
		{
			LoadOrderDetails();
		}

		private void LoadOrderDetails()
		{
			try
			{
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;TrustServerCertificate=True;";
				SqlConnection connection = new SqlConnection(connectionString);
				SqlCommand command = connection.CreateCommand();

				command.CommandText = @"
					SELECT 
						f.Name AS FoodName,
						f.Unit,
						bd.Quantity,
						f.Price,
						f.Price * bd.Quantity AS Amount
					FROM BillDetails bd
					INNER JOIN Food f ON bd.FoodID = f.ID
					WHERE bd.InvoiceID = @orderId";

				command.Parameters.Add("@orderId", SqlDbType.Int);
				command.Parameters["@orderId"].Value = orderId;

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable table = new DataTable();

				connection.Open();
				adapter.Fill(table);
				connection.Close();
				connection.Dispose();

				dgvOrderDetails.DataSource = table;

				// Calculate total
				decimal total = 0;
				foreach (DataRow row in table.Rows)
				{
					total += Convert.ToDecimal(row["Amount"]);
				}

				lblTotal.Text = $"Tổng cộng: {total:N0} VNĐ";
				lblItemCount.Text = $"Số món: {table.Rows.Count}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}
	}
}
