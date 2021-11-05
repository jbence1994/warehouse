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
                .Property(supply => supply.Id)
                .HasColumnName("id");

            builder
                .Property(supply => supply.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(supply => supply.Quantity)
                .HasColumnName("quantity")
                .IsRequired();
        }
    }
}
