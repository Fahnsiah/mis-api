using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MIS_API.Entities;
using MIS_API.Entities.Roles;

namespace MIS_API.Helpers
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .Property(x => x.RoleId)
                .HasDefaultValue(1);

            //seed the required tables
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

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
                Id=1,
                Name = "Super Admin",
                Description = "The super admin roles",
                CreatedOn = System.DateTime.Now,
                Enabled = true,
                IsDeleted = false,

            };

            builder.Entity<Role>().HasData(role);

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
                Created = System.DateTime.Now,
                Verified = System.DateTime.Now,

            };
            //PasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();
            //account.PasswordHash = BC.HashPassword(model.Password);
            //user.PasswordHash = passwordHasher.HashPassword(user, "unity");
            user.PasswordHash = BC.HashPassword("unity");
            builder.Entity<Account>().HasData(user);

        }
    }
}