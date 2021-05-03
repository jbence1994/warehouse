using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Facades
{
    public class StockFacade : IStockFacade
    {
        private readonly IStockRepository stockRepository;

        public StockFacade(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public async Task Add(StockEntry stockEntry)
        {
            if (await stockRepository.IsProductOnStock(stockEntry.ProductId))
            {
                await UpdateProductQuantityInStockSummary(stockEntry.ProductId, stockEntry.Quantity);
            }
            else
            {
                await AddProductToStockSummaryWithInitialQuantity(stockEntry.ProductId, stockEntry.Quantity);
            }

            await AddStock(stockEntry);
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

        private async Task AddStock(StockEntry stockEntry)
        {
            await stockRepository.Add(stockEntry);
        }
    }
}
