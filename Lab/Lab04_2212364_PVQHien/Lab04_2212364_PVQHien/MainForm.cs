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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			LoadTables();
		}

		private void LoadTables()
		{
			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);

			SqlCommand command = connection.CreateCommand();
			command.CommandText = "SELECT ID, Name, Status FROM [Table]";

			connection.Open();

			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable table = new DataTable("Tables");
			adapter.Fill(table);

			dgvTables.DataSource = table;
			dgvTables.Columns[0].ReadOnly = true;

			connection.Close();
			connection.Dispose();
			adapter.Dispose();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtTableName.Text))
			{
				MessageBox.Show("Vui lòng nhập tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "INSERT INTO [Table](Name, Status) VALUES (@Name, 0)";
		command.Parameters.AddWithValue("@Name", txtTableName.Text);

			connection.Open();
			int numOfRowsEffected = command.ExecuteNonQuery();
			connection.Close();

			if (numOfRowsEffected == 1)
			{
				MessageBox.Show("Thêm bàn mới thành công!");
				LoadTables();
				txtTableName.Text = "";
			}
			else
			{
				MessageBox.Show("Có lỗi xảy ra.");
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (dgvTables.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn cần cập nhật.");
				return;
			}

			var selectedRow = dgvTables.SelectedRows[0];
			string tableID = selectedRow.Cells[0].Value.ToString();
			string tableName = selectedRow.Cells[1].Value.ToString();
			string status = selectedRow.Cells[2].Value.ToString();

			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "UPDATE [Table] SET Name = @Name, Status = @Status WHERE ID = @ID";
		command.Parameters.AddWithValue("@Name", tableName);
		command.Parameters.AddWithValue("@Status", status);
		command.Parameters.AddWithValue("@ID", tableID);

			connection.Open();
			int numOfRowsEffected = command.ExecuteNonQuery();
			connection.Close();

			if (numOfRowsEffected == 1)
			{
				MessageBox.Show("Cập nhật thông tin bàn thành công!");
			}
			else
			{
				MessageBox.Show("Có lỗi xảy ra.");
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvTables.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn cần xóa.");
				return;
			}

			var result = MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No) return;

			var selectedRow = dgvTables.SelectedRows[0];
			string tableID = selectedRow.Cells[0].Value.ToString();

			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "DELETE FROM [Table] WHERE ID = @ID";
		command.Parameters.AddWithValue("@ID", tableID);

			connection.Open();
			int numOfRowsEffected = command.ExecuteNonQuery();
			connection.Close();

			if (numOfRowsEffected == 1)
			{
				MessageBox.Show("Xóa bàn thành công!");
				LoadTables();
			}
			else
			{
				MessageBox.Show("Có lỗi xảy ra.");
			}
		}

		private void btnViewBill_Click(object sender, EventArgs e)
		{
			if (dgvTables.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn để xem hóa đơn.");
				return;
			}

			var selectedRow = dgvTables.SelectedRows[0];
			string tableID = selectedRow.Cells[0].Value.ToString();

			// Lấy hóa đơn hiện tại của bàn
			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT TOP 1 ID FROM Bills WHERE TableID = @TableID AND Status = 0 ORDER BY ID DESC";
		command.Parameters.AddWithValue("@TableID", tableID);

			connection.Open();
			var billID = command.ExecuteScalar();
			connection.Close();

			if (billID != null)
			{
				BillDetailsForm billDetails = new BillDetailsForm();
				billDetails.LoadBillDetails(Convert.ToInt32(billID));
				billDetails.ShowDialog();
			}
			else
			{
				MessageBox.Show("Bàn này chưa có hóa đơn nào đang mở.");
			}
		}

		private void tsmDeleteTable_Click(object sender, EventArgs e)
		{
			btnDelete_Click(sender, e);
		}

		private void tsmViewBills_Click(object sender, EventArgs e)
		{
			BillsForm billsForm = new BillsForm();
			billsForm.ShowDialog();
		}

		private void tsmViewBillHistory_Click(object sender, EventArgs e)
		{
			if (dgvTables.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn để xem lịch sử.");
				return;
			}

			var selectedRow = dgvTables.SelectedRows[0];
			string tableID = selectedRow.Cells[0].Value.ToString();
			string tableName = selectedRow.Cells[1].Value.ToString();

			// Hiển thị danh sách hóa đơn của bàn này
			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT * FROM Bills WHERE TableID = @TableID ORDER BY ID DESC";
		command.Parameters.AddWithValue("@TableID", tableID);

			connection.Open();
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable table = new DataTable("BillHistory");
			adapter.Fill(table);
			connection.Close();

			Form historyForm = new Form();
			historyForm.Text = $"Lịch sử hóa đơn - {tableName}";
			historyForm.Size = new Size(800, 600);

			DataGridView dgv = new DataGridView();
			dgv.Dock = DockStyle.Fill;
			dgv.DataSource = table;
			dgv.ReadOnly = true;
			dgv.DoubleClick += (s, ev) =>
			{
				if (dgv.SelectedRows.Count > 0)
				{
					int billID = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
					BillDetailsForm billDetails = new BillDetailsForm();
					billDetails.LoadBillDetails(billID);
					billDetails.ShowDialog();
				}
			};

			historyForm.Controls.Add(dgv);
			historyForm.ShowDialog();

			adapter.Dispose();
		}
	}
}
