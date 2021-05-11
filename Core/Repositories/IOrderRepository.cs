using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(int id);
    }
}
