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
                .Property(order => order.Id)
                .HasColumnName("id");

            builder
                .Property(order => order.TechnicianId)
                .HasColumnName("technician_id");

            builder
                .Property(order => order.Total)
                .HasColumnName("total")
                .IsRequired();

            builder
                .Property(order => order.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
