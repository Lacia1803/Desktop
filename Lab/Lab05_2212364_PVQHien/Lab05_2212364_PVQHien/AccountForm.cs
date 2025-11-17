using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab05_2212364_PVQHien
{
	public partial class AccountForm : Form
	{
		private DataTable accountsTable;
		private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;TrustServerCertificate=True;";

		public AccountForm()
		{
			InitializeComponent();
		}

		private void AccountForm_Load(object sender, EventArgs e)
		{
			LoadAccounts();
		}

		private void LoadAccounts()
		{
			try
			{
				SqlConnection connection = new SqlConnection(connectionString);
				SqlCommand command = connection.CreateCommand();

				command.CommandText = "SELECT AccountName, FullName, Email, Tell, DateCreated FROM Account ORDER BY AccountName";

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				accountsTable = new DataTable();

				connection.Open();
				adapter.Fill(accountsTable);
				connection.Close();
				connection.Dispose();

				dgvAccounts.DataSource = accountsTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtAccountName.Text))
				{
					MessageBox.Show("Vui lòng nhập tên tài khoản!", "Cảnh báo");
					return;
				}

				SqlConnection connection = new SqlConnection(connectionString);
				SqlCommand command = connection.CreateCommand();

				command.CommandText = @"INSERT INTO Account (AccountName, Password, FullName, Email, Tell, DateCreated)
					VALUES (@accountName, @password, @fullName, @email, @tell, @dateCreated)";

				command.Parameters.Add("@accountName", SqlDbType.NVarChar, 100);
				command.Parameters.Add("@password", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@fullName", SqlDbType.NVarChar, 1000);
				command.Parameters.Add("@email", SqlDbType.NVarChar, 1000);
				command.Parameters.Add("@tell", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@dateCreated", SqlDbType.SmallDateTime);

				command.Parameters["@accountName"].Value = txtAccountName.Text;
				command.Parameters["@password"].Value = "123456"; // Default password
				command.Parameters["@fullName"].Value = txtFullName.Text;
				command.Parameters["@email"].Value = string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text;
				command.Parameters["@tell"].Value = string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text;
				command.Parameters["@dateCreated"].Value = DateTime.Now;

				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				connection.Close();
				connection.Dispose();

				if (rowsAffected > 0)
				{
					MessageBox.Show("Thêm tài khoản thành công! Mật khẩu mặc định: 123456", "Thông báo");
					ResetTextBoxes();
					LoadAccounts();
				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show(ex.Message, "SQL Error");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void btnUpdateAccount_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtAccountName.Text))
				{
					MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!", "Cảnh báo");
					return;
				}

				SqlConnection connection = new SqlConnection(connectionString);
				SqlCommand command = connection.CreateCommand();

				command.CommandText = @"UPDATE Account 
					SET FullName = @fullName, Email = @email, Tell = @tell
					WHERE AccountName = @accountName";

				command.Parameters.Add("@accountName", SqlDbType.NVarChar, 100);
				command.Parameters.Add("@fullName", SqlDbType.NVarChar, 1000);
				command.Parameters.Add("@email", SqlDbType.NVarChar, 1000);
				command.Parameters.Add("@tell", SqlDbType.NVarChar, 200);

				command.Parameters["@accountName"].Value = txtAccountName.Text;
				command.Parameters["@fullName"].Value = txtFullName.Text;
				command.Parameters["@email"].Value = string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text;
				command.Parameters["@tell"].Value = string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text;

				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				connection.Close();
				connection.Dispose();

				if (rowsAffected > 0)
				{
					MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo");
					LoadAccounts();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAccountName.Text))
			{
				MessageBox.Show("Vui lòng chọn tài khoản!", "Cảnh báo");
				return;
			}

			DialogResult result = MessageBox.Show(
				$"Bạn có chắc muốn reset mật khẩu cho tài khoản '{txtAccountName.Text}' về '123456'?",
				"Xác nhận",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				try
				{
					SqlConnection connection = new SqlConnection(connectionString);
					SqlCommand command = connection.CreateCommand();

					command.CommandText = "UPDATE Account SET Password = @password WHERE AccountName = @accountName";

					command.Parameters.Add("@accountName", SqlDbType.NVarChar, 100);
					command.Parameters.Add("@password", SqlDbType.NVarChar, 200);

					command.Parameters["@accountName"].Value = txtAccountName.Text;
					command.Parameters["@password"].Value = "123456";

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
					connection.Dispose();

					MessageBox.Show("Reset mật khẩu thành công! Mật khẩu mới: 123456", "Thông báo");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
				}
			}
		}

		private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			DataGridViewRow selectedRow = dgvAccounts.Rows[e.RowIndex];
			DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

			if (rowView != null)
			{
				txtAccountName.Text = rowView["AccountName"].ToString();
				txtAccountName.ReadOnly = true; // Không cho sửa AccountName
				txtFullName.Text = rowView["FullName"].ToString();
				txtEmail.Text = rowView["Email"] != DBNull.Value ? rowView["Email"].ToString() : "";
				txtPhone.Text = rowView["Tell"] != DBNull.Value ? rowView["Tell"].ToString() : "";
			}
		}

		private void dgvAccounts_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var hitTest = dgvAccounts.HitTest(e.X, e.Y);
				if (hitTest.RowIndex >= 0)
				{
					dgvAccounts.ClearSelection();
					dgvAccounts.Rows[hitTest.RowIndex].Selected = true;
					contextMenuAccounts.Show(dgvAccounts, e.Location);
				}
			}
		}

		private void tsmViewRoles_Click(object sender, EventArgs e)
		{
			if (dgvAccounts.SelectedRows.Count == 0)
				return;

			string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
			MessageBox.Show($"Xem danh sách vai trò của tài khoản: {accountName}\n(Chức năng này cần bảng AccountRole để thực hiện)", "Thông báo");
		}

		private void tsmViewActivityLog_Click(object sender, EventArgs e)
		{
			if (dgvAccounts.SelectedRows.Count == 0)
				return;

			string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
			MessageBox.Show($"Xem nhật ký hoạt động của tài khoản: {accountName}\n(Chức năng này cần bảng ActivityLog để thực hiện)", "Thông báo");
		}

		private void ResetTextBoxes()
		{
			txtAccountName.Clear();
			txtAccountName.ReadOnly = false;
			txtFullName.Clear();
			txtEmail.Clear();
			txtPhone.Clear();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ResetTextBoxes();
		}
	}
}
