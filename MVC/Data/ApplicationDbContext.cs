using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet <Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Hilda", PhoneNumber = "0756845297", City = "Gothenburg" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Berit", PhoneNumber = "0735648701", City = "Stockholm" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Albert", PhoneNumber = "0765487028", City = "Karlstad" });
        }
    }

    
}
