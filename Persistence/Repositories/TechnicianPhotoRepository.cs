using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class TechnicianPhotoRepository : ITechnicianPhotoRepository
    {
        private readonly ApplicationDbContext context;

        public TechnicianPhotoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TechnicianPhoto>> GetPhotos(int technicianId)
        {
            return await context.TechnicianPhotos
                .Where(p => p.TechnicianId == technicianId)
                .ToListAsync();
        }
    }
}
