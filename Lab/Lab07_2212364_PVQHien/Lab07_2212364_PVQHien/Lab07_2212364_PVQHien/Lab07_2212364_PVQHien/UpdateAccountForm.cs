using Lab07_2212364_PVQHien.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class UpdateAccountForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();
		private int _accountId;

		public UpdateAccountForm(int accountId)
		{
			InitializeComponent();
			_accountId = accountId;
		}

		private void UpdateAccountForm_Load(object sender, EventArgs e)
		{
			LoadRoles();
			if (_accountId > 0)
			{
				LoadAccountInfo();
			}
		}

		private void LoadRoles()
		{
			var roles = _dbContext.Roles.ToList();
			clbRoles.Items.Clear();
			clbRoles.DisplayMember = "Name";
			clbRoles.ValueMember = "Id";
			foreach (var role in roles)
			{
				clbRoles.Items.Add(role, false);
			}
		}

		private void LoadAccountInfo()
		{
			var account = _dbContext.Accounts.Find(_accountId);
			if (account == null) return;

			txtUsername.Text = account.Username;
			txtUsername.Enabled = false; // Không cho sửa username
			txtFullName.Text = account.FullName;
			txtEmail.Text = account.Email;
			txtPhone.Text = account.Phone;
			chkIsActive.Checked = account.IsActive;

			// Load roles của account
			var accountRoles = _dbContext.RoleAccounts
				.Where(x => x.AccountId == _accountId)
				.Select(x => x.RoleId)
				.ToList();

			for (int i = 0; i < clbRoles.Items.Count; i++)
			{
				var role = clbRoles.Items[i] as Role;
				if (role != null && accountRoles.Contains(role.Id))
				{
					clbRoles.SetItemChecked(i, true);
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			if (_accountId == 0)
			{
				// Thêm mới
				var account = new Account
				{
					Username = txtUsername.Text.Trim(),
					Password = txtPassword.Text, // Nên mã hóa password
					FullName = txtFullName.Text.Trim(),
					Email = txtEmail.Text.Trim(),
					Phone = txtPhone.Text.Trim(),
					DateCreated = DateTime.Now,
					IsActive = chkIsActive.Checked
				};

				_dbContext.Accounts.Add(account);
				_dbContext.SaveChanges();

				// Thêm roles
				SaveRoles(account.Id);
				
				DialogResult = DialogResult.OK;
			}
			else
			{
				// Cập nhật
				var account = _dbContext.Accounts.Find(_accountId);
				if (account != null)
				{
					account.FullName = txtFullName.Text.Trim();
					account.Email = txtEmail.Text.Trim();
					account.Phone = txtPhone.Text.Trim();
					account.IsActive = chkIsActive.Checked;

					if (!string.IsNullOrWhiteSpace(txtPassword.Text))
					{
						account.Password = txtPassword.Text;
					}

					_dbContext.SaveChanges();
					SaveRoles(_accountId);
					
					DialogResult = DialogResult.OK;
				}
			}
		}

		private void SaveRoles(int accountId)
		{
			// Xóa roles cũ
			var oldRoles = _dbContext.RoleAccounts.Where(x => x.AccountId == accountId).ToList();
			_dbContext.RoleAccounts.RemoveRange(oldRoles);

			// Thêm roles mới
			for (int i = 0; i < clbRoles.Items.Count; i++)
			{
				if (clbRoles.GetItemChecked(i))
				{
					var role = clbRoles.Items[i] as Role;
					if (role != null)
					{
						_dbContext.RoleAccounts.Add(new RoleAccount
						{
							AccountId = accountId,
							RoleId = role.Id
						});
					}
				}
			}

			_dbContext.SaveChanges();
		}

		private bool ValidateInput()
		{
			if (string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo");
				return false;
			}

			if (_accountId == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
				return false;
			}

			if (string.IsNullOrWhiteSpace(txtFullName.Text))
			{
				MessageBox.Show("Vui lòng nhập họ tên", "Thông báo");
				return false;
			}

			return true;
		}
	}
}
