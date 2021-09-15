using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ITechnicianOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders(int technicianId);
    }
}
