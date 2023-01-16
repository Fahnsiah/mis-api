using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using MISAPI.DataModel.Models.Accounts;
using MISAPI.DataModel.Models.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MISAPI.DataModel.Models;
using MISAPI.DataModel.Models.Councils;

namespace MISAPI.DataModel.DataAccess
{
    public class DataContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .Property(x => x.RoleId);

            //seed the required tables            
            this.SeedCouncilType(modelBuilder);
            this.SeedCountries(modelBuilder);
            this.SeedCouncils(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<MISAPI.DataModel.Models.Roles.Action> Actions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Council> Councils { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql database
            options.UseSqlServer(Configuration.GetConnectionString("dbConnection"));
        }

        private void SeedRoles(ModelBuilder builder)
        {
            var role = new Role
            {
                Id = 1,
                Name = "Super Admin",
                Description = "The super admin roles",
                CreatedOn = System.DateTime.Now,
                Enabled = true,
                IsDeleted = false,

            };

            builder.Entity<Role>().HasData(role);

        }
        private void SeedCouncilType(ModelBuilder builder)
        {
            List<CouncilType> councilList = new List<CouncilType>();

            councilList.AddRange(new List<CouncilType>
            {
                 new CouncilType {Id = 1,  Name = "COUNCIL",   Description = "Councils of the order" },
                 new CouncilType {Id = 2,  Name = "COURT",   Description = "Courts of the order" },

             });

            builder.Entity<CouncilType>().HasData(councilList);

        }
        private void SeedCountries(ModelBuilder builder)
        {
            var council = new Country
            {
                Id = 1,
                Name = "Ghana",
                Nationality = "Ghanian",
                Currency = "Cedis",
                CurrencySymbol = "C"

            };
            builder.Entity<Country>().HasData(council);

        }
        private void SeedCouncils(ModelBuilder builder)
        {
            var council = new Council
            {
               Id=1,
               No = 1,
               CouncilTypeId = 1,
               CountryId = 1,
               Address = "SecondI, Ghana",
               ConsecreatedOn = Convert.ToDateTime("November 18, 1926"),
               CreatedOn = DateTime.Now

            };
            builder.Entity<Council>().HasData(council);

        }
        private void SeedUsers(ModelBuilder builder)
        {
            var user = new Account
            {
                Id = 1,
                FirstName = "The Supreme",
                MiddleName = " SK",
                LastName = "Knight",
                Email = "info@mis.org",
                RoleId = 1,
                CouncilId = 1,
                CreatedOn = System.DateTime.Now,
                Verified = System.DateTime.Now,
                AcceptTerms = true,

            };
           
            user.PasswordHash = BC.HashPassword("unity");
            builder.Entity<Account>().HasData(user);

        }
    }
}
