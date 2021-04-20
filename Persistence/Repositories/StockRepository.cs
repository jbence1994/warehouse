using System.Collections.Generic;
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

        public async Task Add(StockSummary stockSummary)
        {
            await context.StockSummaries.AddAsync(stockSummary);
        }
    }
}
