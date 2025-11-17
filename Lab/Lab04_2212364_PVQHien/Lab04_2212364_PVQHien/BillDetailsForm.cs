using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_2212364_PVQHien
{
	public partial class BillDetailsForm : Form
	{
		int billID;

		public BillDetailsForm()
		{
			InitializeComponent();
		}

		public void LoadBillDetails(int billID)
	{
		this.billID = billID;
		string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
		SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT Name FROM Bills WHERE ID = @ID";
		command.Parameters.AddWithValue("@ID", billID);

			connection.Open();

			string billName = command.ExecuteScalar().ToString();
		this.Text = billName + " ID + " + billID;

	string query = string.Format(
		"SELECT Food.Name, Food.Unit, Food.Price, BillDetails.Quantity, Food.Price * BillDetails.Quantity AS Total FROM BillDetails " +
		"JOIN Food ON BillDetails.FoodID = Food.ID " +
		"WHERE BillDetails.BillID = {0}", billID).ToString();
		command.CommandText = query;			SqlDataAdapter adapter = new SqlDataAdapter(command);

			DataTable table = new DataTable("Food");
			adapter.Fill(table);

			dgvBillDetails.DataSource = table;

			// Prevent user to edit ID
			dgvBillDetails.Columns[0].ReadOnly = true;

			connection.Close();
			connection.Dispose();
			adapter.Dispose();
		}

	}
}
