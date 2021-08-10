using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor
                .Description("Represents any order that is made by a technician");

            descriptor
                .Field(o => o.Id)
                .Description("Represents the unique identifier of an order");

            descriptor
                .Field(o => o.TechnicianId)
                .Description("Represents the unique identifier of a technician who made the order")
                .Ignore();

            descriptor
                .Field(o => o.Technician)
                .Description("Represents a technician who made the order");

            descriptor
                .Field(o => o.Total)
                .Description("Represents the total price of an order");

            descriptor
                .Field(o => o.CreatedAt)
                .Description("Represents the datetime when an order has been made");

            descriptor
                .Field(o => o.OrderDetails)
                .ResolveWith<Resolver>(r => r.GetOrderDetails(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the supplier of a product");
        }

        private class Resolver
        {
            public IQueryable<OrderDetail> GetOrderDetails(Order order, [ScopedService] ApplicationDbContext context)
            {
                return context.OrderDetails.Where(o => o.OrderId == order.Id);
            }
        }
    }
}
