using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IMerchantRepository
    {
        Task<IEnumerable<Merchant>> GetMerchants(bool includeRelated = true);
        Task<Merchant> GetMerchant(int id);
        Task Add(Merchant merchant);
    }
}
