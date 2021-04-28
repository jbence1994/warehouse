using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task<IEnumerable<StockSummary>> GetSummarizedStocks();
        Task<StockSummary> GetStockSummary(int productId);
        Task<Stock> GetStock(int id);
        Task<bool> IsOnStock(int productId);
        Task Add(Stock stock);
        Task Add(StockSummary stockSummary);
    }
}
