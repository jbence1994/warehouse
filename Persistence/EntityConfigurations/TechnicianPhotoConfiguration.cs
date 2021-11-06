using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianPhotoConfiguration : IEntityTypeConfiguration<TechnicianPhoto>
    {
        public void Configure(EntityTypeBuilder<TechnicianPhoto> builder)
        {
            builder
                .ToTable("technician_photos");

            builder
                .Property(technicianPhoto => technicianPhoto.Id)
                .HasColumnName("id");

            builder
                .Property(technicianPhoto => technicianPhoto.FileName)
                .HasColumnName("file_name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(technicianPhoto => technicianPhoto.TechnicianId)
                .HasColumnName("technician_id");
        }
    }
}
