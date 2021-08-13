using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class StockEntryType : ObjectType<StockEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<StockEntry> descriptor)
        {
            descriptor
                .Description("Represents an entry to register a product with quantity on stock");

            descriptor
                .Field(e => e.Id)
                .Description("Represents the unique identifier of an entry");

            descriptor
                .Field(e => e.ProductId)
                .Description("Represents the unique identifier of a product in the entry")
                .Ignore();

            descriptor
                .Field(e => e.Product)
                .ResolveWith<Resolver>(r => r.GetProduct(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the product in the entry");

            descriptor
                .Field(e => e.Quantity)
                .Description("Represents the quantity of a product in the entry");

            descriptor
                .Field(e => e.CreatedAt)
                .Description("Represents the datetime when the entry created");
        }

        private class Resolver
        {
            public Product GetProduct(StockEntry stockEntry, [ScopedService] ApplicationDbContext context)
            {
                return context.Products.SingleOrDefault(p => p.Id == stockEntry.ProductId);
            }
        }
    }
}
