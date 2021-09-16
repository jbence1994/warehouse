using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products
                .Include(p => p.Supplier)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Product> GetProduct(int id, bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await context.Products
                    .Include(p => p.Supplier)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }

            return await context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            await context.Products.AddAsync(product);
        }
    }
}
