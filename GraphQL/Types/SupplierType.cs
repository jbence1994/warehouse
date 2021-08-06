using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class SupplierType : ObjectType<Supplier>
    {
        protected override void Configure(IObjectTypeDescriptor<Supplier> descriptor)
        {
            descriptor
                .Description("Represents any supplier that is registered in the warehouse and supplies any product");

            descriptor
                .Field(s => s.Id)
                .Description("Represents the unique identifier of a supplier");

            descriptor
                .Field(s => s.Name)
                .Description("Represents the name of a supplier");

            descriptor
                .Field(s => s.City)
                .Description("Represents the headquarters/location of a supplier");

            descriptor
                .Field(s => s.Email)
                .Description("Represents the e-mail address of a supplier");

            descriptor
                .Field(s => s.Phone)
                .Description("Represents the phone number of a supplier");

            descriptor
                .Field(s => s.Products)
                .ResolveWith<Resolver>(s => s.GetProducts(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the collection of the product supplied by a supplier");
        }

        private class Resolver
        {
            public IQueryable<Product> GetProducts(Supplier supplier, [ScopedService] ApplicationDbContext context)
            {
                return context.Products.Where(p => p.SupplierId == supplier.Id);
            }
        }
    }
}
