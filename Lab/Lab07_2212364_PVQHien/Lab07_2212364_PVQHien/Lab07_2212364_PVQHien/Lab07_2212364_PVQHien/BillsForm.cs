using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class BillsForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();

		public BillsForm()
		{
			InitializeComponent();
		}

	private void BillsForm_Load(object sender, EventArgs e)
	{
		dtpFrom.Value = DateTime.Now.AddDays(-30);
		dtpTo.Value = DateTime.Now;
		LoadBills();
	}

	private void LoadBills()
	{
		lvwBills.Items.Clear();
		var fromDate = dtpFrom.Value.Date;
		var toDate = dtpTo.Value.Date.AddDays(1);			var bills = _dbContext.Invoices
				.Include(x => x.Table)
				.Include(x => x.Account)
				.Where(x => x.DateCreated >= fromDate && x.DateCreated < toDate)
				.OrderByDescending(x => x.DateCreated)
				.ToList();

			foreach (var bill in bills)
			{
				var item = new ListViewItem(bill.Id.ToString());
				item.SubItems.Add(bill.Table.Name);
				item.SubItems.Add(bill.DateCreated.ToString("dd/MM/yyyy HH:mm"));
				item.SubItems.Add(bill.DatePayment?.ToString("dd/MM/yyyy HH:mm") ?? "");
				item.SubItems.Add(bill.TotalAmount.ToString("N0"));
				item.SubItems.Add(bill.Discount.ToString("N0"));
				item.SubItems.Add((bill.TotalAmount - bill.Discount).ToString("N0"));
				item.SubItems.Add(bill.Status);
				item.Tag = bill;
				lvwBills.Items.Add(item);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			LoadBills();
		}

		private void btnViewDetails_Click(object sender, EventArgs e)
		{
			if (lvwBills.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn hóa đơn", "Thông báo");
				return;
			}

			var bill = lvwBills.SelectedItems[0].Tag as Invoice;
			if (bill != null)
			{
				var form = new BillDetailsForm(bill.Id);
				form.ShowDialog();
			}
		}

		private void lvwBills_DoubleClick(object sender, EventArgs e)
		{
			btnViewDetails_Click(sender, e);
		}
	}
}
