using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL
{
    [GraphQLDescription("Represents the root query endpoint")]
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Order> GetOrders([ScopedService] ApplicationDbContext context)
        {
            return context.Orders;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<ProductPhoto> GetProductPhotos([ScopedService] ApplicationDbContext context)
        {
            return context.ProductPhotos;
        }

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
        public IQueryable<StockEntry> GetStockEntries([ScopedService] ApplicationDbContext context)
        {
            return context.StockEntries;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Stock> GetStocks([ScopedService] ApplicationDbContext context)
        {
            return context.Stocks;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Supplier> GetSuppliers([ScopedService] ApplicationDbContext context)
        {
            return context.Suppliers;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<TechnicianBalanceEntry> GetTechnicianBalanceEntries(
            [ScopedService] ApplicationDbContext context)
        {
            return context.TechnicianBalanceEntries;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<TechnicianPhoto> GetTechnicianPhotos([ScopedService] ApplicationDbContext context)
        {
            return context.TechnicianPhotos;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Technician> GetTechnicians([ScopedService] ApplicationDbContext context)
        {
            return context.Technicians;
        }
    }
}
