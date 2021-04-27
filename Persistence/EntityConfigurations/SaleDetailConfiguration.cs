using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder
                .ToTable("sale_details");
            
            builder
                .Property(s => s.Id)
                .HasColumnName("id");
            
            builder
                .Property(s => s.SaleId)
                .HasColumnName("sale_id");
            
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
