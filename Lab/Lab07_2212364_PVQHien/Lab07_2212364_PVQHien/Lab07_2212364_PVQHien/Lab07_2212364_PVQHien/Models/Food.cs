namespace Lab07_2212364_PVQHien.Models
{
	public class Food
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Unit { get; set; }
		public int FoodCategoryId { get; set; }
		public int Price { get; set; }
		public string Notes { get; set; }
		public Category Category { get; set; }
	}
}
