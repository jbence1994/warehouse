using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("orders");
            
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
