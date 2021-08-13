using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class TechnicianBalanceEntryType : ObjectType<TechnicianBalanceEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<TechnicianBalanceEntry> descriptor)
        {
            descriptor
                .Description(
                    "Represents any entry that points in time to an actual amount of balance of a technician at a certain time");

            descriptor
                .Field(e => e.Id)
                .Description("Represents the unique identifier of an entry");

            descriptor
                .Field(e => e.TechnicianId)
                .Description("Represents the unique identifier of a technician that the actual entry is belongs to")
                .Ignore();

            descriptor
                .Field(e => e.Technician)
                .ResolveWith<Resolver>(r => r.GetTechnician(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the technician who the entry is belongs to");

            descriptor
                .Field(e => e.Amount)
                .Description("Represents the actual amount of an entry");

            descriptor
                .Field(e => e.CreatedAt)
                .Description("Represents the datetime when an entry has been recorded");
        }

        private class Resolver
        {
            public Technician GetTechnician(TechnicianBalanceEntry technicianBalanceEntry,
                [ScopedService] ApplicationDbContext context)
            {
                return context.Technicians.SingleOrDefault(t => t.Id == technicianBalanceEntry.TechnicianId);
            }
        }
    }
}
