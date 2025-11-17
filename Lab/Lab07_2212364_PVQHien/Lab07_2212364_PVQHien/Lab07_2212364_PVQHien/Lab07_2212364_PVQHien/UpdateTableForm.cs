using Lab07_2212364_PVQHien.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class UpdateTableForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();
		private int _tableId;

		public UpdateTableForm(int tableId)
		{
			InitializeComponent();
			_tableId = tableId;
		}

		private void UpdateTableForm_Load(object sender, EventArgs e)
		{
			LoadHalls();
			if (_tableId > 0)
			{
				LoadTableInfo();
			}
		}

		private void LoadHalls()
		{
			var halls = _dbContext.Halls.ToList();
			cbbHall.DataSource = halls;
			cbbHall.DisplayMember = "Name";
			cbbHall.ValueMember = "Id";
		}

		private void LoadTableInfo()
		{
			var table = _dbContext.Tables.Find(_tableId);
			if (table == null) return;

			txtName.Text = table.Name;
			nudCapacity.Value = table.Capacity;
			cbbHall.SelectedValue = table.HallId;
			cbbStatus.SelectedItem = table.Status;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			if (_tableId == 0)
			{
				// Thêm mới
				var table = new Table
				{
					Name = txtName.Text.Trim(),
					Capacity = (int)nudCapacity.Value,
					HallId = (int)cbbHall.SelectedValue,
					Status = cbbStatus.SelectedItem.ToString()
				};

				_dbContext.Tables.Add(table);
			}
			else
			{
				// Cập nhật
				var table = _dbContext.Tables.Find(_tableId);
				if (table != null)
				{
					table.Name = txtName.Text.Trim();
					table.Capacity = (int)nudCapacity.Value;
					table.HallId = (int)cbbHall.SelectedValue;
					table.Status = cbbStatus.SelectedItem.ToString();
				}
			}

			_dbContext.SaveChanges();
			DialogResult = DialogResult.OK;
		}

		private bool ValidateInput()
		{
			if (string.IsNullOrWhiteSpace(txtName.Text))
			{
				MessageBox.Show("Vui lòng nhập tên bàn", "Thông báo");
				return false;
			}

			if (nudCapacity.Value <= 0)
			{
				MessageBox.Show("Sức chứa phải lớn hơn 0", "Thông báo");
				return false;
			}

			return true;
		}
	}
}
