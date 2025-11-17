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
	public partial class frmFood : Form
	{
		int categoryID;

		public frmFood()
		{
			InitializeComponent();
		}

	public void LoadFood(int categoryID)
	{
		this.categoryID = categoryID;
		string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
		SqlConnection connection = new SqlConnection(connectionString);
		SqlCommand command = connection.CreateCommand();			command.CommandText = "SELECT Name FROM Category WHERE ID = @ID";
		command.Parameters.AddWithValue("@ID", categoryID);

			connection.Open();

			string categoryName = command.ExecuteScalar().ToString();
			this.Text = "Danh sách các món ăn thuộc nhóm: " + categoryName;

			command.CommandText = "SELECT ID, Name, Unit, Price, Notes FROM Food WHERE FoodCategoryID = @CategoryID";
		command.Parameters.AddWithValue("@CategoryID", categoryID);

			SqlDataAdapter adapter = new SqlDataAdapter(command);

			DataTable table = new DataTable("Food");
			adapter.Fill(table);

			dgvFood.DataSource = table;

			// Prevent user to edit ID
			dgvFood.Columns[0].ReadOnly = true;

			connection.Close();
			connection.Dispose();
			adapter.Dispose();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvFood.SelectedRows.Count == 0) return;

		var selectedRow = dgvFood.SelectedRows[0];

		string foodID = selectedRow.Cells[0].Value.ToString();

		string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
		SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

		command.CommandText = "DELETE FROM Food WHERE ID = @ID";
		command.Parameters.AddWithValue("@ID", foodID);			connection.Open();

			int numOfRowsEffected = command.ExecuteNonQuery();

			if (numOfRowsEffected != 1)
			{
				MessageBox.Show("Có lỗi xảy ra.");
				return;
			}

			dgvFood.Rows.Remove(selectedRow);

			connection.Close();
		}

	private void btnSave_Click(object sender, EventArgs e)
	{
		string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
		SqlConnection connection = new SqlConnection(connectionString);
		SqlCommand command = connection.CreateCommand();			connection.Open();

		command.CommandText = "DELETE FROM Food WHERE FoodCategoryID = @CategoryID";
		command.Parameters.AddWithValue("@CategoryID", categoryID);
		command.ExecuteNonQuery();
		command.Parameters.Clear();			for (int i = 0; i < dgvFood.Rows.Count - 1; i++)
			{
			command.CommandText = "INSERT INTO Food(Name, Unit, FoodCategoryID, Price, Notes) VALUES (@Name, @Unit, @CategoryID, @Price, @Notes)";
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@Name", dgvFood.Rows[i].Cells["Name"].Value);
			command.Parameters.AddWithValue("@Unit", dgvFood.Rows[i].Cells["Unit"].Value);
			command.Parameters.AddWithValue("@CategoryID", categoryID);
			command.Parameters.AddWithValue("@Price", dgvFood.Rows[i].Cells["Price"].Value);
			command.Parameters.AddWithValue("@Notes", dgvFood.Rows[i].Cells["Notes"].Value);
			command.ExecuteNonQuery();
			}

			connection.Close();
		}
	}
}
