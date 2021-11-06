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
                .Property(product => product.Id)
                .HasColumnName("id");

            builder
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(product => product.Price)
                .HasColumnName("price")
                .IsRequired();

            builder
                .Property(product => product.Unit)
                .HasColumnName("unit")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(product => product.MerchantId)
                .HasColumnName("merchant_id");
        }
    }
}
