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

        public async Task<IEnumerable<StockSummary>> GetStockSummaries()
        {
            return await context.StockSummaries
                .Include(s => s.Product)
                .ThenInclude(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<StockSummary> GetStockSummary(int productId)
        {
            return await context.StockSummaries
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

        public async Task Add(StockSummary stockSummary)
        {
            await context.StockSummaries.AddAsync(stockSummary);
        }
    }
}
