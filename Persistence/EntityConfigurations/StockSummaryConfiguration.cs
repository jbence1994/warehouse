using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class StockSummaryConfiguration : IEntityTypeConfiguration<StockSummary>
    {
        public void Configure(EntityTypeBuilder<StockSummary> builder)
        {
            builder
                .ToTable("stock_summary");
            
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
