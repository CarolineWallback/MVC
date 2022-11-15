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
        public DbSet <City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Thailand"});

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Gothenburg", CountryId = 1});
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Karlstad", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Barcelona", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, CityName = "Malaga", CountryId = 2});
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, CityName = "Bangkok", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 6, CityName = "Rayong", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Hilda", PhoneNumber = "0756845297", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Berit", PhoneNumber = "0735648701", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = Guid.NewGuid().ToString(), Name = "Albert", PhoneNumber = "0765487028", CityId = 1 });


        }
    }

    
}
