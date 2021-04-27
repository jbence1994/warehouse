using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface ISaleService
    {
        Task<Sale> Checkout(Sale sale);
    }
}
