using Microsoft.EntityFrameworkCore;

namespace ValidationAutomapperHomework.Models
{
	public class UsersDBContext:DbContext
	{
		public DbSet<User> _users { get; set; }	
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("UsersDB");
		}
	}
}
