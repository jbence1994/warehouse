using System;
using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class StockFacade : IStockFacade
    {
        private readonly IStockRepository _stockRepository;

        public StockFacade(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Add(StockEntry stockEntry)
        {
            stockEntry.CreatedAt = DateTime.Now;

            await _stockRepository.Add(stockEntry);

            await UpdateStockQuantity(stockEntry);
        }

        private async Task UpdateStockQuantity(StockEntry stockEntry)
        {
            var stock = await _stockRepository.GetStock(stockEntry.ProductId);
            stock.Quantity += stockEntry.Quantity;
        }
    }
}
