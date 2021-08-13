using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class OrderDetailType : ObjectType<OrderDetail>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderDetail> descriptor)
        {
            descriptor
                .Description("Represents any detail in an order");

            descriptor
                .Field(o => o.Id)
                .Description("Represents the unique identifier of an order detail");

            descriptor
                .Field(o => o.OrderId)
                .Description("Represents the unique identifier of an order the order detail belongs to")
                .Ignore();

            descriptor
                .Field(o => o.Order)
                .ResolveWith<Resolver>(r => r.GetOrder(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents an order the order detail belongs to");

            descriptor
                .Field(o => o.ProductId)
                .Description("Represents the unique identifier of a product in an order detail")
                .Ignore();

            descriptor
                .Field(o => o.Product)
                .ResolveWith<Resolver>(r => r.GetProduct(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the product in an order detail");

            descriptor
                .Field(o => o.Quantity)
                .Description("Represents the quantity of a product");

            descriptor
                .Field(o => o.SubTotal)
                .Description("Represents the sub total calculated by products price times quantity");
        }

        private class Resolver
        {
            public Order GetOrder(OrderDetail orderDetail, [ScopedService] ApplicationDbContext context)
            {
                return context.Orders.SingleOrDefault(o => o.Id == orderDetail.OrderId);
            }

            public Product GetProduct(OrderDetail orderDetail, [ScopedService] ApplicationDbContext context)
            {
                return context.Products.SingleOrDefault(p => p.Id == orderDetail.ProductId);
            }
        }
    }
}
