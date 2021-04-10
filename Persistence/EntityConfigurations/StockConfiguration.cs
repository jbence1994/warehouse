using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

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
                .Property(p => p.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder
                .Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
