using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class RoleForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();

		public RoleForm()
		{
			InitializeComponent();
		}

		private void RoleForm_Load(object sender, EventArgs e)
		{
			LoadRoles();
		}

		private void LoadRoles()
		{
			lvwRoles.Items.Clear();
			var roles = _dbContext.Roles.OrderBy(x => x.Name).ToList();

			foreach (var role in roles)
			{
				var item = new ListViewItem(role.Id.ToString());
				item.SubItems.Add(role.Name);
				item.SubItems.Add(role.Description);
				item.Tag = role;
				lvwRoles.Items.Add(item);
			}
		}

		private void btnAddRole_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtRoleName.Text))
			{
				MessageBox.Show("Vui lòng nhập tên vai trò", "Thông báo");
				return;
			}

			var role = new Role
			{
				Name = txtRoleName.Text.Trim(),
				Description = txtRoleDescription.Text.Trim()
			};

			_dbContext.Roles.Add(role);
			_dbContext.SaveChanges();
			LoadRoles();
			ClearInputs();
			MessageBox.Show("Thêm vai trò thành công!", "Thông báo");
		}

		private void btnUpdateRole_Click(object sender, EventArgs e)
		{
			if (lvwRoles.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn vai trò cần cập nhật", "Thông báo");
				return;
			}

			var role = lvwRoles.SelectedItems[0].Tag as Role;
			if (role == null) return;

			var roleInDb = _dbContext.Roles.Find(role.Id);
			if (roleInDb != null)
			{
				roleInDb.Name = txtRoleName.Text.Trim();
				roleInDb.Description = txtRoleDescription.Text.Trim();
				_dbContext.SaveChanges();
				LoadRoles();
				MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo");
			}
		}

		private void lvwRoles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvwRoles.SelectedItems.Count > 0)
			{
				var role = lvwRoles.SelectedItems[0].Tag as Role;
				if (role != null)
				{
					txtRoleName.Text = role.Name;
					txtRoleDescription.Text = role.Description;
					LoadUsersForRole(role.Id);
				}
			}
		}

		private void LoadUsersForRole(int roleId)
		{
			lvwUsers.Items.Clear();
			var users = _dbContext.RoleAccounts
				.Include(x => x.Account)
				.Where(x => x.RoleId == roleId)
				.Select(x => x.Account)
				.ToList();

			foreach (var user in users)
			{
				var item = new ListViewItem(user.Id.ToString());
				item.SubItems.Add(user.Username);
				item.SubItems.Add(user.FullName);
				item.SubItems.Add(user.Email);
				lvwUsers.Items.Add(item);
			}
		}

		private void ClearInputs()
		{
			txtRoleName.Clear();
			txtRoleDescription.Clear();
		}
	}
}
