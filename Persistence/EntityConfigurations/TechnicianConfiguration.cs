using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            builder
                .ToTable("technicians");

            builder
                .Property(t => t.Id)
                .HasColumnName("id");

            builder
                .Property(t => t.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(t => t.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(t => t.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(t => t.Phone)
                .HasColumnName("phone")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property(t => t.Balance)
                .HasColumnName("balance")
                .IsRequired();
        }
    }
}
