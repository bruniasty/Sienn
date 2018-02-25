using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Type> Types { get; set; }

        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(t => new { t.ProductId, t.CategoryId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}