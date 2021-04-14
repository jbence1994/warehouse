using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Products
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Product product)
        {
            await context.Products.AddAsync(product);
        }
    }
}
