using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lab07_2212364_PVQHien.Models
{
	public class RestaurantContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Food> Foods { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<RoleAccount> RoleAccounts { get; set; }
		public DbSet<Table> Tables { get; set; }
		public DbSet<Hall> Halls { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			
			modelBuilder.Entity<Food>()
				.HasRequired(x => x.Category)
				.WithMany()
				.HasForeignKey(x => x.FoodCategoryId)
				.WillCascadeOnDelete(true);
				
			modelBuilder.Entity<RoleAccount>()
				.HasKey(x => new { x.RoleId, x.AccountId });
				
			modelBuilder.Entity<InvoiceDetails>()
				.HasKey(x => new { x.InvoiceId, x.FoodId });
		}
	}
}
