using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext context;

        public SaleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Sale>> GetSales(int technicianId)
        {
            return await context.Sales
                .Where(s => s.TechnicianId == technicianId)
                .Include(s => s.SaleDetails)
                .ThenInclude(s => s.Product)
                .ThenInclude(s => s.Supplier)
                .ToListAsync();
        }
    }
}
