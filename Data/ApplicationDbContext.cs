using InventoryStock.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryStock.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; } // This creates the 'Products' table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, StockCount = 5, LastRestocked = DateTime.Now.AddDays(-10) },
                new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25, StockCount = 50, LastRestocked = DateTime.Now.AddDays(-2) },
                new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 300, StockCount = 8, LastRestocked = DateTime.Now.AddDays(-15) }
            );
        }

    }
}
