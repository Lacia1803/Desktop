using System;

namespace Lab07_2212364_PVQHien.Models
{
	public class Invoice
	{
		public int Id { get; set; }
		public int TableId { get; set; }
		public int AccountId { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DatePayment { get; set; }
		public int TotalAmount { get; set; }
		public int Discount { get; set; }
		public string Status { get; set; }
		
		public Table Table { get; set; }
		public Account Account { get; set; }
	}
}
