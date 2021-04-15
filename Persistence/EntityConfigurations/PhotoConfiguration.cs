using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder
                .ToTable("photos");

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
