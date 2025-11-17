using Lab07_2212364_PVQHien.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class AccountRolesForm : Form
	{
		private Account _account;
		private List<Role> _roles;

		public AccountRolesForm(Account account, List<Role> roles)
		{
			InitializeComponent();
			_account = account;
			_roles = roles;
		}

		private void AccountRolesForm_Load(object sender, EventArgs e)
		{
			lblAccountName.Text = $"Tài khoản: {_account.Username} - {_account.FullName}";
			
			lvwRoles.Items.Clear();
			foreach (var role in _roles)
			{
				var item = new ListViewItem(role.Name);
				item.SubItems.Add(role.Description);
				lvwRoles.Items.Add(item);
			}
		}
	}
}
