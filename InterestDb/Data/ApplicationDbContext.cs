using InterestDb.Models;
using Microsoft.EntityFrameworkCore;

namespace InterestDb.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Interest>Interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }

	}
}
