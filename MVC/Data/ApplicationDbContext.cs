using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

        string AdminRoleId = "Admin";
        string ModeratorRoleId = "Moderator";
        string UserRoleId = "User";
        string userId = Guid.NewGuid().ToString();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedPeople(modelBuilder);
            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);

        }

        private void SeedPeople(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, LanguageName = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, LanguageName = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, LanguageName = "Spanish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, LanguageName = "Thai" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Thailand" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Gothenburg", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Karlstad", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Barcelona", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, CityName = "Malaga", CountryId = 2 });
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

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            //seed admin 
            ApplicationUser user = new ApplicationUser()
            {
                Id = userId,
                UserName = "admin@admin.se",
                NormalizedUserName = "ADMIN@ADMIN.SE",
                FirstName = "Caroline",
                LastName = "Wallbäck",
                BirthDate = new DateTime(1993, 05, 09),
                Email = "admin@admin.se",
                NormalizedEmail = "ADMIN@ADMIN.SE",
                EmailConfirmed = true,
                LockoutEnabled = false,

            };

            PasswordHasher<ApplicationUser> passwordHasher = new();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin");

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = ModeratorRoleId, Name = "Moderator", NormalizedName = "MODERATOR" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = UserRoleId, Name = "User", NormalizedName = "USER" });
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() 
                {
                    RoleId = AdminRoleId, 
                    UserId = userId 
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ModeratorRoleId,
                    UserId = userId
                });
        }
    }

    
}
