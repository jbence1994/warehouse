using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Persistence.EntityConfigurations;

namespace Warehouse.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockSummary> SummarizedStocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<TechnicianPhoto> TechnicianPhotos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new StockSummaryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianPhotoConfiguration());
        }
    }
}
