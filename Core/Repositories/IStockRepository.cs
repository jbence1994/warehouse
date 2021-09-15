using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task<Stock> GetStock(int productId);
        Task<StockEntry> GetStockEntry(int id);
        Task<bool> IsProductOnStock(int productId);
        Task Add(StockEntry stockEntry);
        Task Add(Stock stock);
    }
}
