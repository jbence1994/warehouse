using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class TechnicianOrderRepository : ITechnicianOrderRepository
    {
        private readonly ApplicationDbContext context;

        public TechnicianOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(int technicianId)
        {
            return await context.Orders
                .Include(s => s.OrderDetails)
                .ThenInclude(s => s.Product)
                .ThenInclude(s => s.Supplier)
                .Where(s => s.TechnicianId == technicianId)
                .ToListAsync();
        }
    }
}
