using Warehouse.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("products");

            builder
                .Property(p => p.Id)
                .HasColumnName("id");

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasColumnName("price")
                .IsRequired();

            builder
                .Property(p => p.Unit)
                .HasColumnName("unit")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.SupplierId)
                .HasColumnName("supplier_id");
        }
    }
}
