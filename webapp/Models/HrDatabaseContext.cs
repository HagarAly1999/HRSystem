using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapp.Models;


namespace webapp.Models
{
        public class HrDatabaseContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Department> Departments { get; set; }
            public DbSet<Employee> Employees { get; set; }

            // Constructor that accepts DbContextOptions
            public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options)
                : base(options)
            {
            }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the primary key for IdentityUserLogin
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
    }


    }

