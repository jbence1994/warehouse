using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class ProductPhotoRepository : IProductPhotoRepository
    {
        private readonly ApplicationDbContext context;

        public ProductPhotoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductPhoto>> GetPhotos(int productId)
        {
            return await context.ProductPhotos
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }
    }
}
