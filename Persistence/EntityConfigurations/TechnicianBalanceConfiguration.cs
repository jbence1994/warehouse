using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianBalanceConfiguration : IEntityTypeConfiguration<TechnicianBalance>
    {
        public void Configure(EntityTypeBuilder<TechnicianBalance> builder)
        {
            builder
                .ToTable("technician_balances");
            
            builder
                .Property(t => t.Id)
                .HasColumnName("id");
            
            builder
                .Property(t => t.TechnicianId)
                .HasColumnName("technician_id");
            
            builder
                .Property(t => t.Amount)
                .HasColumnName("amount")
                .IsRequired();
            
            builder
                .Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
