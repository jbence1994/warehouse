using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
                .ToTable("suppliers");

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder
                .Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(25);
        }
    }
}
