using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Represents any product that is registered in the warehouse");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique identifier of a product");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name of a product");

            descriptor
                .Field(p => p.Price)
                .Description("Represents the price of a product");

            descriptor
                .Field(p => p.Unit)
                .Description("Represents the measuring unit of a product");

            descriptor
                .Field(p => p.SupplierId)
                .Description("Represents the unique identifier of the supplier of a product");

            descriptor
                .Field(p => p.Supplier)
                .ResolveWith<Resolver>(p => p.GetSupplier(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the supplier of a product");

            descriptor
                .Field(p => p.Photos)
                .ResolveWith<Resolver>(p => p.GetProductPhotos(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the collection of the photos of a product");
        }

        private class Resolver
        {
            public Supplier GetSupplier(Product product, [ScopedService] ApplicationDbContext context)
            {
                return context.Suppliers.SingleOrDefault(s => s.Id == product.SupplierId);
            }

            public IQueryable<StockEntry> GetStockEntries(Product product, [ScopedService] ApplicationDbContext context)
            {
                return context.StockEntries.Where(s => s.ProductId == product.Id);
            }

            public IQueryable<ProductPhoto> GetProductPhotos(Product product,
                [ScopedService] ApplicationDbContext context)
            {
                return context.ProductPhotos.Where(p => p.ProductId == product.Id);
            }
        }
    }
}
