using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder
                .ToTable("product_photos");

            builder
                .Property(productPhoto => productPhoto.Id)
                .HasColumnName("id");

            builder
                .Property(productPhoto => productPhoto.FileName)
                .HasColumnName("file_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(productPhoto => productPhoto.ProductId)
                .HasColumnName("product_id");
        }
    }
}
