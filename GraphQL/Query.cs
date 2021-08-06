using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Warehouse.Core.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL
{
    [GraphQLDescription("Represents the root query endpoint")]
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Product> GetProducts([ScopedService] ApplicationDbContext context)
        {
            return context.Products;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public Product GetProduct([ScopedService] ApplicationDbContext context, int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Supplier> GetSuppliers([ScopedService] ApplicationDbContext context)
        {
            return context.Suppliers;
        }
    }
}
