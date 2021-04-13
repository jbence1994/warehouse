using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockSummary>> GetStocks();
        Task<Stock> GetStock(int id);
        Task Add(Stock stock);
    }
}
