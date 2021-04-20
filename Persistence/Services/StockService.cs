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

        public async Task Add(Stock stock)
        {
            var stocks = await stockRepository.GetStocks();
            var summarizedStocks = await stockRepository.GetSummarizedStocks();

            if (stocks.Any(s => s.ProductId == stock.ProductId))
            {
                var stockSummary = summarizedStocks
                    .Where(s => s.ProductId == stock.ProductId)
                    .SingleOrDefault();
                
                stockSummary.Quantity += stock.Quantity;
            }
            else
            {
                var stockSummary = new StockSummary { ProductId = stock.ProductId, Quantity = stock.Quantity };
                
                await stockRepository.Add(stockSummary);
            }
            
            await stockRepository.Add(stock);
        }
    }
}
