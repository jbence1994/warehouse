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
            if (await stockRepository.IsOnStock(stock.ProductId))
            {
                var stockSummary = await stockRepository.GetStockSummary(stock.ProductId);
                stockSummary.Quantity += stock.Quantity;
            }
            else
            {
                await stockRepository.Add(new StockSummary
                {
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity
                });
            }
            
            await stockRepository.Add(stock);
        }
    }
}
