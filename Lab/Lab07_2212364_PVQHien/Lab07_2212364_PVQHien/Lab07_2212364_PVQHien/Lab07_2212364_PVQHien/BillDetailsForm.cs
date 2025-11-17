using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class BillDetailsForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();
		private int _invoiceId;

		public BillDetailsForm(int invoiceId)
		{
			InitializeComponent();
			_invoiceId = invoiceId;
		}

		private void BillDetailsForm_Load(object sender, EventArgs e)
		{
			LoadBillDetails();
		}

		private void LoadBillDetails()
		{
			var invoice = _dbContext.Invoices
				.Include(x => x.Table)
				.Include(x => x.Account)
				.FirstOrDefault(x => x.Id == _invoiceId);

			if (invoice == null) return;

			lblInvoiceId.Text = $"Hóa đơn #{invoice.Id}";
			lblTable.Text = $"Bàn: {invoice.Table.Name}";
			lblDateCreated.Text = $"Ngày tạo: {invoice.DateCreated:dd/MM/yyyy HH:mm}";
			lblDatePayment.Text = $"Ngày thanh toán: {(invoice.DatePayment.HasValue ? invoice.DatePayment.Value.ToString("dd/MM/yyyy HH:mm") : "Chưa thanh toán")}";

			// Load chi tiết
			lvwDetails.Items.Clear();
			var details = _dbContext.InvoiceDetails
				.Include(x => x.Food)
				.Where(x => x.InvoiceId == _invoiceId)
				.ToList();

			int totalAmount = 0;
			int index = 1;
			foreach (var detail in details)
			{
				var item = new ListViewItem(index.ToString());
				item.SubItems.Add(detail.Food.Name);
				item.SubItems.Add(detail.Quantity.ToString());
				item.SubItems.Add(detail.Price.ToString("N0"));
				item.SubItems.Add(detail.Amount.ToString("N0"));
				lvwDetails.Items.Add(item);
				totalAmount += detail.Amount;
				index++;
			}

			lblTotalAmount.Text = $"Tổng tiền: {totalAmount:N0} VNĐ";
			lblStatus.Text = $"Trạng thái: {invoice.Status}";
		}
	}
}
