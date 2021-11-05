using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder
                .ToTable("supplies");

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
