using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class ProductPhotoRepository : IProductPhotoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPhotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductPhoto>> GetPhotos()
        {
            return await _context.ProductPhotos.ToListAsync();
        }
    }
}
