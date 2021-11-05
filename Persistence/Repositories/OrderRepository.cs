using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders
                .Include(order => order.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .ThenInclude(product => product.Merchant)
                .SingleOrDefaultAsync(order => order.Id == id);
        }
    }
}
