using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder
                .ToTable("stocks");

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(s => s.Quantity)
                .HasColumnName("quantity")
                .IsRequired();
        }
    }
}
