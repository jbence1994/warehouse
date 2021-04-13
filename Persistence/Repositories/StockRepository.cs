using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext context;

        public StockRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private async Task<IDictionary<Product, int>> GetStockSummary()
        {
            var stockSummary = new Dictionary<Product, int>();

            var stocks = await context.Stocks
                .Include(s =>s.Product)
                .ThenInclude(p => p.Supplier)
                .ToListAsync();

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

        public async Task<IEnumerable<StockSummary>> GetStocks()
        {
            var stockSummary = await GetStockSummary();

            return stockSummary.Select(pair => new StockSummary
            {
                Product = pair.Key,
                Quantity = pair.Value
            });
        }

        public async Task<Stock> GetStock(int id)
        {
            return await context.Stocks
                .Include(s => s.Product)
                .ThenInclude(s => s.Supplier)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Add(Stock stock)
        {
            await context.Stocks.AddAsync(stock);
        }
    }
}
