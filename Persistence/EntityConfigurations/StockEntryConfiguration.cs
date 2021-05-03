using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class StockEntryConfiguration : IEntityTypeConfiguration<StockEntry>
    {
        public void Configure(EntityTypeBuilder<StockEntry> builder)
        {
            builder
                .ToTable("stock_entries");

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
