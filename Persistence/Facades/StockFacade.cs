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
                var stock = await stockRepository.GetStock(stockEntry.ProductId);
                stock.IncrementQuantity(stockEntry.Quantity);
            }
            else
            {
                var stock = new Stock
                {
                    ProductId = stockEntry.ProductId,
                    Quantity = stockEntry.Quantity
                };

                await stockRepository.Add(stock);
            }

            await stockRepository.Add(stockEntry);
        }
    }
}
