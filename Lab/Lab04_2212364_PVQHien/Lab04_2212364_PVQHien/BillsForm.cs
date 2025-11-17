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
	public partial class BillsForm : Form
	{
		public BillsForm()
		{
			InitializeComponent();

			// Thiết lập giá trị mặc định cho DateTimePicker
			dtpFromDate.Value = DateTime.Now.AddDays(-30);
			dtpToDate.Value = DateTime.Now;

			LoadBills();
		}

	public void LoadBills()
	{
		string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
		SqlConnection connection = new SqlConnection(connectionString);
		SqlCommand command = connection.CreateCommand();

		command.CommandText = "SELECT * FROM Bills";

		connection.Open();			SqlDataAdapter adapter = new SqlDataAdapter(command);
		DataTable table = new DataTable("Bills");
		adapter.Fill(table);

		dgvHoaDon.DataSource = table;

		// Prevent user to edit ID
		if (dgvHoaDon.Columns.Count > 0)
		{
			dgvHoaDon.Columns[0].ReadOnly = true;
		}

		this.Text = $"Danh sách hóa đơn ({table.Rows.Count} hóa đơn)";

		connection.Close();
		connection.Dispose();
		adapter.Dispose();
	}		private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
	{
		if (dgvHoaDon.SelectedRows.Count == 0) return;

		BillDetailsForm billDetails = new BillDetailsForm();
		
		// Lấy giá trị ID từ cột đầu tiên
		var cellValue = dgvHoaDon.SelectedRows[0].Cells[0].Value;
		
		if (cellValue == null || cellValue == DBNull.Value)
		{
			MessageBox.Show("Không thể lấy ID hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
		
		string billID = cellValue.ToString();
		
		if (!int.TryParse(billID, out int id))
		{
			MessageBox.Show($"ID hóa đơn không hợp lệ: {billID}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
		
		billDetails.LoadBillDetails(id);
		billDetails.Show();
	}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			LoadBills();
		}

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			if (dtpFromDate.Value > dtpToDate.Value)
			{
				MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtpFromDate.Value = dtpToDate.Value;
			}
		}

		private void dtpToDate_ValueChanged(object sender, EventArgs e)
		{
			if (dtpToDate.Value < dtpFromDate.Value)
			{
				MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtpToDate.Value = dtpFromDate.Value;
			}
		}
	}
}
