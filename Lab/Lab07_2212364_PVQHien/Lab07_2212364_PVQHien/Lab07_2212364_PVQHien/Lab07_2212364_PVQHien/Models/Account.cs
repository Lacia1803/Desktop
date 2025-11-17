using System;

namespace Lab07_2212364_PVQHien.Models
{
	public class Account
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsActive { get; set; }
	}
}
