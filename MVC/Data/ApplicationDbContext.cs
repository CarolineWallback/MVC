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
        public DbSet <Country> Countries { get; set; }
        public DbSet <Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, LanguageName = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, LanguageName = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, LanguageName = "Spanish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, LanguageName = "Thai" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Thailand"});

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Gothenburg", CountryId = 1});
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Karlstad", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Barcelona", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, CityName = "Malaga", CountryId = 2});
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, CityName = "Bangkok", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 6, CityName = "Rayong", CountryId = 3 });

            var personId1 = Guid.NewGuid().ToString();
            var personId2 = Guid.NewGuid().ToString();
            var personId3 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Person>().HasData(new Person { Id = personId1, Name = "Hilda", PhoneNumber = "0756845297", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = personId2, Name = "Alberto", PhoneNumber = "0735648701", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = personId3, Name = "Gun", PhoneNumber = "0765487028", CityId = 3 });

            //English
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId1, LanguagesLanguageId = 1 }));

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId2, LanguagesLanguageId = 1 }));

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId3, LanguagesLanguageId = 1 }));

            //Swedish
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId1, LanguagesLanguageId = 2 }));

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId3, LanguagesLanguageId = 2 }));

            //Spanish
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(new { PeopleId = personId2, LanguagesLanguageId = 3 }));
        }
    }

    
}
