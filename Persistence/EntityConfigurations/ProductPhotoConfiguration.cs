using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder
                .ToTable("product_photos");

            builder
                .Property(p => p.Id)
                .HasColumnName("id");

            builder
                .Property(p => p.FileName)
                .HasColumnName("file_name")
                .HasMaxLength(255)
                .IsRequired();
            
            builder
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
        }
    }
}
