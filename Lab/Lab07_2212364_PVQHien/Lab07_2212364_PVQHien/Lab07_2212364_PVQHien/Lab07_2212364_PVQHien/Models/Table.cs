namespace Lab07_2212364_PVQHien.Models
{
	public class Table
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Capacity { get; set; }
		public int HallId { get; set; }
		public string Status { get; set; }
		
		public Hall Hall { get; set; }
	}
}
