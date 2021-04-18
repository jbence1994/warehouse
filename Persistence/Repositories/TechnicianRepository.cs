using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly ApplicationDbContext context;

        public TechnicianRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Technician>> GetTechnicians()
        {
            return await context.Technicians.ToListAsync();
        }
    }
}
