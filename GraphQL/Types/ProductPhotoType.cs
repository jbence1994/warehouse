using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class ProductPhotoType : ObjectType<ProductPhoto>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductPhoto> descriptor)
        {
            descriptor
                .Description("Represents any photo that made of a product");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique identifier of a product photo");

            descriptor
                .Field(p => p.FileName)
                .Description("Represents the file name of a photo");

            descriptor
                .Field(p => p.Product)
                .ResolveWith<Resolver>(r => r.GetProduct(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the product that is on the photo");

            descriptor
                .Field(p => p.ProductId)
                .Description("Represents the unique identifier of a product that is on the photo")
                .Ignore();
        }

        private class Resolver
        {
            public Product GetProduct(ProductPhoto photo, [ScopedService] ApplicationDbContext context)
            {
                return context.Products.SingleOrDefault(p => p.Id == photo.ProductId);
            }
        }
    }
}
