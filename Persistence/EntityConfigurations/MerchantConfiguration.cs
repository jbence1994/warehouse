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
                .ToTable("merchants");

            builder
                .Property(merchant => merchant.Id)
                .HasColumnName("id");

            builder
                .Property(merchant => merchant.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(merchant => merchant.City)
                .HasColumnName("city")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(merchant => merchant.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder
                .Property(merchant => merchant.Phone)
                .HasColumnName("phone")
                .HasMaxLength(25);
        }
    }
}
