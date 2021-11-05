using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
                .ToTable("order_details");

            builder
                .Property(orderDetail => orderDetail.Id)
                .HasColumnName("id");

            builder
                .Property(orderDetail => orderDetail.OrderId)
                .HasColumnName("order_id");

            builder
                .Property(orderDetail => orderDetail.ProductId)
                .HasColumnName("product_id");

            builder
                .Property(orderDetail => orderDetail.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder
                .Property(orderDetail => orderDetail.SubTotal)
                .HasColumnName("sub_total")
                .IsRequired();
        }
    }
}
