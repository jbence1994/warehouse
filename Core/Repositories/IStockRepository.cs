using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task<Stock> GetStock(int id);
        Task<StockSummary> GetStockSummary(int productId);
        Task Add(Stock stock);
        Task Add(StockSummary stockSummary);
    }
}
