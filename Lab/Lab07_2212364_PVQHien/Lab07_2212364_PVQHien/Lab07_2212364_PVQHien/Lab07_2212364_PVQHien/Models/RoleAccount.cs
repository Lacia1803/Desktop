namespace Lab07_2212364_PVQHien.Models
{
	public class RoleAccount
	{
		public int RoleId { get; set; }
		public int AccountId { get; set; }
		
		public Role Role { get; set; }
		public Account Account { get; set; }
	}
}
