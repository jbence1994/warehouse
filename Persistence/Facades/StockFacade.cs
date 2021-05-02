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
