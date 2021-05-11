using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers(bool includeRelated = true);
        Task<Supplier> GetSupplier(int id);
        Task Add(Supplier supplier);
    }
}
