using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockSummary>> GetStocks()
        {
            var stockSummary = await SummarizeStocks();

            return stockSummary.Select(pair =>
                new StockSummary { Product = pair.Key, Quantity = pair.Value }
            );
        }

        public async Task<IDictionary<Product, int>> SummarizeStocks()
        {
            var stockSummary = new Dictionary<Product, int>();
            
            var stocks = await stockRepository.GetStocks();

            foreach (var stock in stocks)
            {
                if (stockSummary.ContainsKey(stock.Product))
                {
                    stockSummary[stock.Product] += stock.Quantity;
                }
                else
                {
                    stockSummary.Add(stock.Product, stock.Quantity);
                }
            }

            return stockSummary;
        }

        public async Task<bool> IsExistingStockProduct(int id)
        {
            var stocks = await stockRepository.GetStocks();

            foreach (var stock in stocks)
            {
                if (stock.ProductId == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
