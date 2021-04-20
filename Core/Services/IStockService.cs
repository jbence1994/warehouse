using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockSummary>> GetStocks();
        Task<IDictionary<Product, int>> SummarizeStocks();
        Task<bool> IsExistingStockProduct(int id);
    }
}
