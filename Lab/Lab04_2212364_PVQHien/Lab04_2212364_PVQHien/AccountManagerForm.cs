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
	public partial class AccountManagerForm : Form
	{
		public AccountManagerForm()
		{
			InitializeComponent();

			LoadAccountGroups();
			LoadAccount();
		}

		private void LoadAccountGroups()
		{
			// Thêm các nhóm vào ComboBox (nếu có)
			cboGroup.Items.Add("Tất cả");
			cboGroup.Items.Add("Admin");
			cboGroup.Items.Add("Staff");
			cboGroup.SelectedIndex = 0;

			cboStatus.Items.Add("Tất cả");
			cboStatus.Items.Add("Kích hoạt");
			cboStatus.Items.Add("Không kích hoạt");
			cboStatus.SelectedIndex = 0;
		}

		public void LoadAccount()
		{
			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			string whereClause = "WHERE 1=1";

		// Lọc theo nhóm
		if (cboGroup.SelectedIndex > 0)
		{
			// whereClause += $" AND AccountType = '{cboGroup.SelectedItem}'";
		}

		// Lọc theo trạng thái
		if (cboStatus.SelectedIndex == 1)
		{
			// whereClause += " AND Active = 1";
		}
		else if (cboStatus.SelectedIndex == 2)
		{
			// whereClause += " AND Active = 0";
		}		command.CommandText = $"SELECT * FROM Account {whereClause}";

		connection.Open();			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable table = new DataTable("Account");
			adapter.Fill(table);

			dgvAccount.DataSource = table;

			// Prevent user to edit ID
			if (dgvAccount.Columns.Count > 0)
			{
				dgvAccount.Columns[0].ReadOnly = true;
			}

			this.Text = $"Quản lý tài khoản ({table.Rows.Count} tài khoản)";

			connection.Close();
			connection.Dispose();
			adapter.Dispose();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUserName.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated) VALUES (@AccountName, @Password, @FullName, @Email, @Tell, GETDATE())";
		command.Parameters.AddWithValue("@AccountName", txtUserName.Text);
		command.Parameters.AddWithValue("@Password", txtPassword.Text);
		command.Parameters.AddWithValue("@FullName", txtDisplayName.Text);
		command.Parameters.AddWithValue("@Email", "");
		command.Parameters.AddWithValue("@Tell", "");

			connection.Open();
			int numOfRowsEffected = command.ExecuteNonQuery();
			connection.Close();

			if (numOfRowsEffected == 1)
			{
				MessageBox.Show("Thêm tài khoản mới thành công!");
				LoadAccount();
				ClearInputs();
			}
			else
			{
				MessageBox.Show("Có lỗi xảy ra.");
			}
		}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		if (dgvAccount.SelectedRows.Count == 0)
		{
			MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật.");
			return;
		}

	var selectedRow = dgvAccount.SelectedRows[0];
	string accountName = selectedRow.Cells[0].Value.ToString(); // AccountName
	string displayName = selectedRow.Cells[2].Value.ToString(); // FullName

	string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
	SqlConnection connection = new SqlConnection(connectionString);
	SqlCommand command = connection.CreateCommand();

	command.CommandText = "UPDATE Account SET FullName = @FullName WHERE AccountName = @AccountName";
	command.Parameters.AddWithValue("@FullName", displayName);
	command.Parameters.AddWithValue("@AccountName", accountName);

	connection.Open();
	int numOfRowsEffected = command.ExecuteNonQuery();
	connection.Close();		if (numOfRowsEffected == 1)
		{
			MessageBox.Show("Cập nhật thông tin tài khoản thành công!");
		}
		else
		{
			MessageBox.Show("Có lỗi xảy ra.");
		}
	}

	private void btnResetPassword_Click(object sender, EventArgs e)
	{
		if (dgvAccount.SelectedRows.Count == 0)
		{
			MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu.");
			return;
		}

		var result = MessageBox.Show("Bạn có chắc muốn reset mật khẩu về '123456'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (result == DialogResult.No) return;

	var selectedRow = dgvAccount.SelectedRows[0];
	string accountName = selectedRow.Cells[0].Value.ToString();

	string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
	SqlConnection connection = new SqlConnection(connectionString);
	SqlCommand command = connection.CreateCommand();

	command.CommandText = "UPDATE Account SET Password = @Password WHERE AccountName = @AccountName";
	command.Parameters.AddWithValue("@Password", "123456");
	command.Parameters.AddWithValue("@AccountName", accountName);

	connection.Open();
	int numOfRowsEffected = command.ExecuteNonQuery();
	connection.Close();		if (numOfRowsEffected == 1)
		{
			MessageBox.Show("Reset mật khẩu thành công!");
		}
		else
		{
			MessageBox.Show("Có lỗi xảy ra.");
		}
	}		private void btnFilter_Click(object sender, EventArgs e)
		{
			LoadAccount();
		}

		private void tsmDeleteAccount_Click(object sender, EventArgs e)
		{
			if (dgvAccount.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
				return;
			}

	var selectedRow = dgvAccount.SelectedRows[0];
	string accountName = selectedRow.Cells[0].Value.ToString();

	var result = MessageBox.Show("Bạn có chắc muốn XÓA VĨNH VIỄN tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
	if (result == DialogResult.No) return;

	string connectionString = "Data Source=LACIA\\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True;";
	SqlConnection connection = new SqlConnection(connectionString);
	SqlCommand command = connection.CreateCommand();

	command.CommandText = "DELETE FROM Account WHERE AccountName = @AccountName";
	command.Parameters.AddWithValue("@AccountName", accountName);			connection.Open();
			int numOfRowsEffected = command.ExecuteNonQuery();
			connection.Close();

			if (numOfRowsEffected == 1)
			{
				MessageBox.Show("Vô hiệu hóa tài khoản thành công!");
				LoadAccount();
			}
			else
			{
				MessageBox.Show("Có lỗi xảy ra.");
			}
		}

		private void tsmViewRoles_Click(object sender, EventArgs e)
		{
			if (dgvAccount.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn tài khoản để xem vai trò.");
				return;
			}

			var selectedRow = dgvAccount.SelectedRows[0];
			string userName = selectedRow.Cells[1].Value.ToString();
			string accountType = selectedRow.Cells[3].Value.ToString();

			MessageBox.Show($"Tài khoản: {userName}\nVai trò: {accountType}", "Thông tin vai trò", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ClearInputs()
		{
			txtUserName.Text = "";
			txtPassword.Text = "";
			txtDisplayName.Text = "";
		}
	}
}
