using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
                .ToTable("order_details");
            
            builder
                .Property(s => s.Id)
                .HasColumnName("id");
            
            builder
                .Property(s => s.OrderId)
                .HasColumnName("order_id");
            
            builder
                .Property(s => s.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(s => s.Quantity)
                .HasColumnName("quantity")
                .IsRequired();
            
            builder
                .Property(s => s.SubTotal)
                .HasColumnName("sub_total")
                .IsRequired();
        }
    }
}
