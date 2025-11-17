using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab05_2212364_PVQHien
{
	public partial class OrdersForm : Form
	{
		private DataTable ordersTable;

		public OrdersForm()
		{
			InitializeComponent();
		}

		private void OrdersForm_Load(object sender, EventArgs e)
		{
			dtpStartDate.Value = DateTime.Now.AddDays(-30);
			dtpEndDate.Value = DateTime.Now;
			LoadOrders();
		}

		private void LoadOrders()
		{
			try
			{
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;TrustServerCertificate=True;";
				SqlConnection connection = new SqlConnection(connectionString);
				SqlCommand command = connection.CreateCommand();

				command.CommandText = @"
					SELECT 
						ID, 
						Name, 
						TableID, 
						Amount, 
						Discount, 
						Tax, 
						CheckoutDate, 
						Account,
						Amount * (1 - ISNULL(Discount, 0)) * (1 + ISNULL(Tax, 0)) as TotalAmount
					FROM Bills
					WHERE CheckoutDate BETWEEN @startDate AND @endDate
					ORDER BY CheckoutDate DESC";

				command.Parameters.Add("@startDate", SqlDbType.DateTime);
				command.Parameters.Add("@endDate", SqlDbType.DateTime);

				command.Parameters["@startDate"].Value = dtpStartDate.Value.Date;
				command.Parameters["@endDate"].Value = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				ordersTable = new DataTable();

				connection.Open();
				adapter.Fill(ordersTable);
				connection.Close();
				connection.Dispose();

				dgvOrders.DataSource = ordersTable;

				// Calculate totals
				CalculateTotals();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void CalculateTotals()
		{
			decimal totalAmount = 0;
			decimal totalDiscount = 0;
			decimal totalTax = 0;
			decimal revenue = 0;

			foreach (DataRow row in ordersTable.Rows)
			{
				decimal amount = Convert.ToDecimal(row["Amount"]);
				decimal discount = row["Discount"] != DBNull.Value ? Convert.ToDecimal(row["Discount"]) : 0;
				decimal tax = row["Tax"] != DBNull.Value ? Convert.ToDecimal(row["Tax"]) : 0;

				totalAmount += amount;
				totalDiscount += amount * discount;
				totalTax += amount * (1 - discount) * tax;
			}

			revenue = totalAmount - totalDiscount + totalTax;

			lblTotalAmount.Text = $"Tổng tiền: {totalAmount:N0} VNĐ";
			lblTotalDiscount.Text = $"Giảm giá: {totalDiscount:N0} VNĐ";
			lblTotalTax.Text = $"Thuế: {totalTax:N0} VNĐ";
			lblRevenue.Text = $"Doanh thu: {revenue:N0} VNĐ";
			lblOrderCount.Text = $"Số hóa đơn: {ordersTable.Rows.Count}";
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			LoadOrders();
		}

		private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			DataGridViewRow selectedRow = dgvOrders.Rows[e.RowIndex];
			DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

			if (rowView != null)
			{
				int orderId = Convert.ToInt32(rowView["ID"]);
				OrderDetailsForm detailsForm = new OrderDetailsForm(orderId);
				detailsForm.ShowDialog(this);
			}
		}
	}
}
