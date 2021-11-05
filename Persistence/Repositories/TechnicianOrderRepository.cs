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
        private readonly ApplicationDbContext _context;

        public TechnicianOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(int technicianId)
        {
            return await _context.Orders
                .Include(order => order.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .ThenInclude(product => product.Merchant)
                .Where(order => order.TechnicianId == technicianId)
                .ToListAsync();
        }
    }
}
