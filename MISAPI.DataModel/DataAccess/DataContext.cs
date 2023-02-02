using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using MISAPI.DataModel.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MISAPI.DataModel.DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SetIndexes(modelBuilder);
            this.SetCompositeKeys(modelBuilder);
            this.SetDefaultValues(modelBuilder); 
            this.SetDecimalPrecision(modelBuilder); 

            //seed the required tables            
            this.SeedCouncilType(modelBuilder);
            this.SeedCountries(modelBuilder);
            this.SeedCouncils(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);

        }
        private void SetIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProposedCouncil>().HasIndex(p => p.TransctionId).IsUnique();

            modelBuilder.Entity<ConsecrationArticle>().HasIndex(p => p.ArticleId).IsUnique();

            modelBuilder.Entity<Article>().HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<Role>().HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<RolePermission>().HasIndex(p => new { p.MenuId, p.SubMenuId, p.OperationId, p.RoleId }).IsUnique();

            modelBuilder.Entity<SubMenu>().HasIndex(p => new { p.Id, p.MenuId, p.Name }).IsUnique();

            modelBuilder.Entity<Operation>().HasIndex(p => new { p.Name }).IsUnique();
        }
        private void SetCompositeKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuOperation>().HasKey(p => new { p.MenuId, p.OperationId });

        }
        private void SetDefaultValues(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .Property(x => x.RoleId).HasDefaultValue(1);

            modelBuilder.Entity<Currency>()
                   .Property(x => x.RateToUSD)
                   .HasPrecision(18, 2);

        }

        private void SetDecimalPrecision(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                   .Property(x => x.Price)
                   .HasPrecision(18, 2);

            modelBuilder.Entity<ProposedCouncil>()
                   .Property(x => x.ApplicationFeed)
                   .HasPrecision(18, 2);

        }

        public DbSet<ProposedCouncil> ProposedCouncils { get; set; }
        public DbSet<ConsecrationRequirement> ConsecrationRequirements { get; set; }
        public DbSet<ConsecrationArticle> ConsecrationArticles { get; set; }
        public DbSet<Ritual> Rituals { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CouncilType> CouncilTypes { get; set; }
        public DbSet<Council> Councils { get; set; }
        public DbSet<MenuOperation> MenuOperations { get; set; }

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
                 new CouncilType {Id = 1,  Name = "JR COUNCIL/COURT",   Description = "The Junior order", CreatedOn = DateTime.Now },
                 new CouncilType {Id = 2,  Name = "ADULT COUNCIL",   Description = "The adult councils and courts", CreatedOn = DateTime.Now },
                 new CouncilType {Id = 3,  Name = "REGIONAL COUNCIL",   Description = "The regional councils and courts", CreatedOn = DateTime.Now },
                 new CouncilType {Id = 4,  Name = "STATE COUNCIL",   Description = "The state councils and courts", CreatedOn = DateTime.Now},
                 new CouncilType {Id = 5,  Name = "SUPREME COUNCIL",   Description = "The supreme council and grand court", CreatedOn = DateTime.Now},

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
                Id = 1,
                Name = "Council #1",
                IsCouncil = true,
                CountryId = 1,
                CouncilTypeId = 1,
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
                Gender = "M",
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
