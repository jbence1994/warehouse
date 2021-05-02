using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface IOrderFacade
    {
        Task Checkout(Order order);
    }
}
