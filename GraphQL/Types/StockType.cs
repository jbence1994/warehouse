using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class StockType : ObjectType<Stock>
    {
        protected override void Configure(IObjectTypeDescriptor<Stock> descriptor)
        {
            descriptor
                .Description("Represents a recording about a product is registered on stock");

            descriptor
                .Field(s => s.Id)
                .Description("Represents the unique identifier of a stock");

            descriptor
                .Field(s => s.ProductId)
                .Description("Represents the unique identifier of a product on stock")
                .Ignore();

            descriptor
                .Field(s => s.Product)
                .ResolveWith<Resolver>(r => r.GetProduct(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the product on stock");

            descriptor
                .Field(s => s.Quantity)
                .Description("Represents the available quantity of a product on stock");
        }

        private class Resolver
        {
            public Product GetProduct(Stock stock, [ScopedService] ApplicationDbContext context)
            {
                return context.Products.SingleOrDefault(p => p.Id == stock.ProductId);
            }
        }
    }
}
