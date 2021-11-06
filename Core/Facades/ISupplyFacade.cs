using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface ISupplyFacade
    {
        Task Add(SupplyEntry supplyEntry);
    }
}
