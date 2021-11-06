using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.EntityConfigurations
{
    public class TechnicianBalanceEntryConfiguration : IEntityTypeConfiguration<TechnicianBalanceEntry>
    {
        public void Configure(EntityTypeBuilder<TechnicianBalanceEntry> builder)
        {
            builder
                .ToTable("technician_balance_entries");

            builder
                .Property(technicianBalanceEntry => technicianBalanceEntry.Id)
                .HasColumnName("id");

            builder
                .Property(technicianBalanceEntry => technicianBalanceEntry.TechnicianId)
                .HasColumnName("technician_id");

            builder
                .Property(technicianBalanceEntry => technicianBalanceEntry.Amount)
                .HasColumnName("amount")
                .IsRequired();

            builder
                .Property(technicianBalanceEntry => technicianBalanceEntry.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
