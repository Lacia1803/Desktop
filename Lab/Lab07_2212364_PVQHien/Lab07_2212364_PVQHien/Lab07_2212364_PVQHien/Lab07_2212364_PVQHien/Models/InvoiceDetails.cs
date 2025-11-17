namespace Lab07_2212364_PVQHien.Models
{
	public class InvoiceDetails
	{
		public int InvoiceId { get; set; }
		public int FoodId { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public int Amount { get; set; }
		
		public Invoice Invoice { get; set; }
		public Food Food { get; set; }
	}
}
