using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianBalanceSummaryConfiguration : IEntityTypeConfiguration<TechnicianBalanceSummary>
    {
        public void Configure(EntityTypeBuilder<TechnicianBalanceSummary> builder)
        {
            builder
                .ToTable("technician_balance_summary");
            
            builder
                .Property(t => t.TechnicianId)
                .HasColumnName("technician_id");
            
            builder
                .Property(t => t.Amount)
                .HasColumnName("amount")
                .IsRequired();
        }
    }
}
