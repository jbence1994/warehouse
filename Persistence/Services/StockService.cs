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
            if (await stockRepository.IsProductOnStock(stock.ProductId))
            {
                await UpdateProductQuantityInStockSummary(stock.ProductId, stock.Quantity);
            }
            else
            {
                await AddProductToStockSummaryWithInitialQuantity(stock.ProductId, stock.Quantity);
            }

            await AddStock(stock);
        }

        private async Task UpdateProductQuantityInStockSummary(int productId, int quantity)
        {
            var stockSummary = await stockRepository.GetStockSummary(productId);
            stockSummary.Quantity += quantity;
        }

        private async Task AddProductToStockSummaryWithInitialQuantity(int productId, int quantity)
        {
            await stockRepository.Add(new StockSummary
            {
                ProductId = productId,
                Quantity = quantity
            });
        }

        private async Task AddStock(Stock stock)
        {
            await stockRepository.Add(stock);
        }
    }
}
