using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Persistence.EntityConfigurations;

namespace Warehouse.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<TechnicianPhoto> TechnicianPhotos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new StockEntryConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianBalanceEntryConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianPhotoConfiguration());
        }
    }
}
