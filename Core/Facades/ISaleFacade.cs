using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface ISaleFacade
    {
        Task<Sale> Checkout(Sale sale);
    }
}
