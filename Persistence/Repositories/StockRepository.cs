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

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await context.Stocks
                .Include(s => s.Product)
                .ThenInclude(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<Stock> GetStock(int productId)
        {
            return await context.Stocks
                .Where(s => s.ProductId == productId)
                .SingleOrDefaultAsync();
        }

        public async Task<StockEntry> GetStockEntry(int id)
        {
            return await context.StockEntries
                .Include(s => s.Product)
                .ThenInclude(s => s.Supplier)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> IsProductOnStock(int productId)
        {
            return await context.StockEntries
                .AnyAsync(s => s.ProductId == productId);
        }

        public async Task Add(StockEntry stockEntry)
        {
            await context.StockEntries.AddAsync(stockEntry);
        }

        public async Task Add(Stock stock)
        {
            await context.Stocks.AddAsync(stock);
        }
    }
}
