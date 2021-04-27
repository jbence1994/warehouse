using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .ToTable("sales");
            
            builder
                .Property(s => s.Id)
                .HasColumnName("id");
            
            builder
                .Property(s => s.TechnicianId)
                .HasColumnName("technician_id");
                        
            builder
                .Property(s => s.Total)
                .HasColumnName("total")
                .IsRequired();
            
            builder
                .Property(s => s.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
