using Product.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Persistence
{
	public class QueryDatabaseContext : DbContext
	{
		public QueryDatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<QueryDatabaseContext> options) : base(options: options)
		{
			// TODO
			Database.EnsureCreated();
		}

		
		public DbSet<User> Users { get; set; }
		public DbSet<Product.Domain.Models.Product> Products { get; set; }
		

		protected override void OnModelCreating
			(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
