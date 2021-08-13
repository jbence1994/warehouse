using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianBalanceEntryConfiguration : IEntityTypeConfiguration<TechnicianBalanceEntry>
    {
        public void Configure(EntityTypeBuilder<TechnicianBalanceEntry> builder)
        {
            builder
                .ToTable("technician_balance_entries");

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
