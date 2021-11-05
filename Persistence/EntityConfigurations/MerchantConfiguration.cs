using Warehouse.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder
                .ToTable("suppliers");

            builder
                .Property(m => m.Id)
                .HasColumnName("id");

            builder
                .Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(m => m.City)
                .HasColumnName("city")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(m => m.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder
                .Property(m => m.Phone)
                .HasColumnName("phone")
                .HasMaxLength(25);
        }
    }
}
