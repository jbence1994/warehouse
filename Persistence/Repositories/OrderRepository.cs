using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .ThenInclude(p => p.Supplier)
                .SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}
