using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class TechnicianType : ObjectType<Technician>
    {
        protected override void Configure(IObjectTypeDescriptor<Technician> descriptor)
        {
            descriptor
                .Description(
                    "Represents any technician that is registered in the warehouse and can purchase products from it");

            descriptor
                .Field(s => s.Id)
                .Description("Represents the unique identifier of a technician");

            descriptor
                .Field(s => s.FirstName)
                .Description("Represents the first name of a technician");

            descriptor
                .Field(s => s.LastName)
                .Description("Represents the last name of a technician");

            descriptor
                .Field(s => s.Email)
                .Description("Represents the e-mail address of a technician");

            descriptor
                .Field(s => s.Phone)
                .Description("Represents the phone number of a technician");

            descriptor
                .Field(s => s.Balance)
                .Description("Represents the actual balance of a technician");

            descriptor
                .Field(s => s.BalanceEntries)
                .ResolveWith<Resolver>(r => r.GetBalanceEntries(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description(
                    "Represents the collection of balance entries that points to an actual amount of balance at a certain time");

            descriptor
                .Field(s => s.Photos)
                .ResolveWith<Resolver>(r => r.GetPhotos(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the collection of photos that made from a technician");

            descriptor
                .Field(s => s.Orders)
                .ResolveWith<Resolver>(r => r.GetOrders(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the collection of orders of products from stock that a technician purchased");
        }

        private class Resolver
        {
            public IQueryable<TechnicianBalanceEntry> GetBalanceEntries(Technician technician,
                [ScopedService] ApplicationDbContext context)
            {
                return context.TechnicianBalanceEntries.Where(p => p.TechnicianId == technician.Id);
            }

            public IQueryable<TechnicianPhoto> GetPhotos(Technician technician,
                [ScopedService] ApplicationDbContext context)
            {
                return context.TechnicianPhotos.Where(p => p.TechnicianId == technician.Id);
            }

            public IQueryable<Order> GetOrders(Technician technician, [ScopedService] ApplicationDbContext context)
            {
                return context.Orders.Where(p => p.TechnicianId == technician.Id);
            }
        }
    }
}
