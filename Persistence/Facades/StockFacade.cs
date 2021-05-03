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
                await UpdateProductQuantityInStock(stockEntry.ProductId, stockEntry.Quantity);
            }
            else
            {
                await AddProductToStockWithInitialQuantity(stockEntry.ProductId, stockEntry.Quantity);
            }

            await AddStockEntry(stockEntry);
        }

        private async Task UpdateProductQuantityInStock(int productId, int quantity)
        {
            var stock = await stockRepository.GetStock(productId);
            stock.Quantity += quantity;
        }

        private async Task AddProductToStockWithInitialQuantity(int productId, int quantity)
        {
            await stockRepository.Add(new Stock
            {
                ProductId = productId,
                Quantity = quantity
            });
        }

        private async Task AddStockEntry(StockEntry stockEntry)
        {
            await stockRepository.Add(stockEntry);
        }
    }
}
