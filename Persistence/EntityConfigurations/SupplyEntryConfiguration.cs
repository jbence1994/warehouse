using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class SupplyEntryConfiguration : IEntityTypeConfiguration<SupplyEntry>
    {
        public void Configure(EntityTypeBuilder<SupplyEntry> builder)
        {
            builder
                .ToTable("stock_entries");

            builder
                .Property(supplyEntry => supplyEntry.Id)
                .HasColumnName("id");

            builder
                .Property(supplyEntry => supplyEntry.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(supplyEntry => supplyEntry.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder
                .Property(supplyEntry => supplyEntry.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
