using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class AccountForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();

		public AccountForm()
		{
			InitializeComponent();
		}

		private void AccountForm_Load(object sender, EventArgs e)
		{
			LoadRolesToComboBox();
			LoadAccounts();
		}

		private void LoadRolesToComboBox()
		{
			var roles = _dbContext.Roles.ToList();
			cbbRole.DataSource = roles;
			cbbRole.DisplayMember = "Name";
			cbbRole.ValueMember = "Id";
		}

		private void LoadAccounts(int? roleId = null, string searchName = null)
		{
			lvwAccounts.Items.Clear();
			var query = _dbContext.Accounts.AsQueryable();

			if (roleId.HasValue && roleId.Value > 0)
			{
				var accountIds = _dbContext.RoleAccounts
					.Where(x => x.RoleId == roleId.Value)
					.Select(x => x.AccountId)
					.ToList();
				query = query.Where(x => accountIds.Contains(x.Id));
			}

			if (!string.IsNullOrWhiteSpace(searchName))
			{
				query = query.Where(x => x.FullName.Contains(searchName) || x.Username.Contains(searchName));
			}

			var accounts = query.ToList();

			foreach (var account in accounts)
			{
				var item = new ListViewItem(account.Id.ToString());
				item.SubItems.Add(account.Username);
				item.SubItems.Add(account.FullName);
				item.SubItems.Add(account.Email);
				item.SubItems.Add(account.Phone);
				item.SubItems.Add(account.IsActive ? "Hoạt động" : "Inactive");
				item.Tag = account;
				lvwAccounts.Items.Add(item);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			int? roleId = cbbRole.SelectedValue as int?;
			string searchName = txtSearch.Text.Trim();
			LoadAccounts(roleId, searchName);
		}

		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			var form = new UpdateAccountForm(0);
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadAccounts();
			}
		}

		private void btnUpdateAccount_Click(object sender, EventArgs e)
		{
			if (lvwAccounts.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật", "Thông báo");
				return;
			}

			var account = lvwAccounts.SelectedItems[0].Tag as Account;
			if (account != null)
			{
				var form = new UpdateAccountForm(account.Id);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadAccounts();
				}
			}
		}

		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			if (lvwAccounts.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn tài khoản", "Thông báo");
				return;
			}

			var account = lvwAccounts.SelectedItems[0].Tag as Account;
			if (account != null)
			{
				if (MessageBox.Show($"Bạn có chắc muốn reset mật khẩu cho tài khoản '{account.Username}' về '123456'?", 
					"Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var acc = _dbContext.Accounts.Find(account.Id);
					if (acc != null)
					{
						acc.Password = "123456"; // Reset về mật khẩu mặc định
						_dbContext.SaveChanges();
						MessageBox.Show("Đã reset mật khẩu về '123456' thành công!", "Thông báo");
					}
				}
			}
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			if (lvwAccounts.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn tài khoản", "Thông báo");
				return;
			}

			var account = lvwAccounts.SelectedItems[0].Tag as Account;
			if (account != null)
			{
				var form = new ChangePasswordForm(account.Id);
				form.ShowDialog();
			}
		}

		private void menuDeleteAccount_Click(object sender, EventArgs e)
		{
			if (lvwAccounts.SelectedItems.Count == 0) return;

			var account = lvwAccounts.SelectedItems[0].Tag as Account;
			if (account != null)
			{
				if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{account.Username}'?",
					"Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var acc = _dbContext.Accounts.Find(account.Id);
					if (acc != null)
					{
						_dbContext.Accounts.Remove(acc);
						_dbContext.SaveChanges();
						LoadAccounts();
						MessageBox.Show("Đã xóa tài khoản!", "Thông báo");
					}
				}
			}
		}

		private void menuViewRoles_Click(object sender, EventArgs e)
		{
			if (lvwAccounts.SelectedItems.Count == 0) return;

			var account = lvwAccounts.SelectedItems[0].Tag as Account;
			if (account != null)
			{
				var roles = _dbContext.RoleAccounts
					.Include(x => x.Role)
					.Where(x => x.AccountId == account.Id)
					.Select(x => x.Role)
					.ToList();

				var form = new AccountRolesForm(account, roles);
				form.ShowDialog();
			}
		}
	}
}
