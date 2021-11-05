using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id, bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await _context.Products
                    .Include(product => product.Merchant)
                    .SingleOrDefaultAsync(product => product.Id == id);
            }

            return await _context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
        }
    }
}
