using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ISupplyRepository
    {
        Task<IEnumerable<Supply>> GetSupplies();
        Task<Supply> GetSupply(int productId);
        Task<SupplyEntry> GetSupplyEntry(int id);
        Task Add(SupplyEntry supplyEntry);
    }
}
