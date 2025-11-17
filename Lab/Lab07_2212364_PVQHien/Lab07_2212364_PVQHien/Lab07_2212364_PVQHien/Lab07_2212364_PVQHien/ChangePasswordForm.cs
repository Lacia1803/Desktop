using Lab07_2212364_PVQHien.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class ChangePasswordForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();
		private int _accountId;

		public ChangePasswordForm(int accountId)
		{
			InitializeComponent();
			_accountId = accountId;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thông báo");
				return;
			}

			if (txtNewPassword.Text != txtConfirmPassword.Text)
			{
				MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo");
				return;
			}

			var account = _dbContext.Accounts.Find(_accountId);
			if (account != null)
			{
				account.Password = txtNewPassword.Text; // Nên mã hóa
				_dbContext.SaveChanges();
				MessageBox.Show("Đã thay đổi mật khẩu!", "Thông báo");
				DialogResult = DialogResult.OK;
			}
		}
	}
}
