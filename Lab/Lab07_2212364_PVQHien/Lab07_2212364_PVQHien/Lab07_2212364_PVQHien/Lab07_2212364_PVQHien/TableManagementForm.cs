using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class TableManagementForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();

		public TableManagementForm()
		{
			InitializeComponent();
		}

		private void TableManagementForm_Load(object sender, EventArgs e)
		{
			LoadTables();
		}

		private void LoadTables()
		{
			lvwTables.Items.Clear();
			var tables = _dbContext.Tables
				.Include(x => x.Hall)
				.OrderBy(x => x.Name)
				.ToList();

			foreach (var table in tables)
			{
				var item = new ListViewItem(table.Id.ToString());
				item.SubItems.Add(table.Name);
				item.SubItems.Add(table.Capacity.ToString());
				item.SubItems.Add(table.Hall?.Name ?? "");
				item.SubItems.Add(table.Status);
				item.Tag = table;
				lvwTables.Items.Add(item);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var form = new UpdateTableForm(0);
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadTables();
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (lvwTables.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn cần cập nhật", "Thông báo");
				return;
			}

			var table = lvwTables.SelectedItems[0].Tag as Table;
			if (table != null)
			{
				var form = new UpdateTableForm(table.Id);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadTables();
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvwTables.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn bàn cần xóa", "Thông báo");
				return;
			}

			var table = lvwTables.SelectedItems[0].Tag as Table;
			if (table != null)
			{
				if (MessageBox.Show($"Bạn có chắc muốn xóa bàn '{table.Name}'?",
					"Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var tableInDb = _dbContext.Tables.Find(table.Id);
					if (tableInDb != null)
					{
						_dbContext.Tables.Remove(tableInDb);
						_dbContext.SaveChanges();
						LoadTables();
						MessageBox.Show("Đã xóa bàn!", "Thông báo");
					}
				}
			}
		}

		private void viewBillsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvwTables.SelectedItems.Count == 0) return;

			var table = lvwTables.SelectedItems[0].Tag as Table;
			if (table != null)
			{
				var currentBill = _dbContext.Invoices
					.FirstOrDefault(x => x.TableId == table.Id && x.Status == "Đang phục vụ");

				if (currentBill != null)
				{
					var form = new BillDetailsForm(currentBill.Id);
					form.ShowDialog();
				}
				else
				{
					MessageBox.Show("Bàn này chưa có hóa đơn", "Thông báo");
				}
			}
		}

		private void menuViewOrderHistory_Click(object sender, EventArgs e)
		{
			if (lvwTables.SelectedItems.Count == 0) return;

			var table = lvwTables.SelectedItems[0].Tag as Table;
			if (table != null)
			{
				var orders = _dbContext.InvoiceDetails
					.Include(x => x.Invoice)
					.Include(x => x.Food)
					.Where(x => x.Invoice.TableId == table.Id)
					.OrderByDescending(x => x.Invoice.DateCreated)
					.ToList();

				// Hiển thị danh sách đơn hàng
				MessageBox.Show($"Bàn '{table.Name}' có {orders.Count} món đã đặt", "Lịch sử đặt hàng");
			}
		}
	}
}
