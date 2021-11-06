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
                .Property(technician => technician.Id)
                .HasColumnName("id");

            builder
                .Property(technician => technician.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(technician => technician.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(technician => technician.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(technician => technician.Phone)
                .HasColumnName("phone")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property(technician => technician.Balance)
                .HasColumnName("balance")
                .IsRequired();
        }
    }
}
