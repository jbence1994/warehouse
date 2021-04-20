using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task<IEnumerable<StockSummary>> GetSummarizedStocks();
        Task<Stock> GetStock(int id);
        Task Add(Stock stock);
        Task Add(StockSummary stockSummary);
    }
}
