using Microsoft.EntityFrameworkCore;
using POSUNO.Api.Data.Entities;

namespace POSUNO.Api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
        }
    }
}
