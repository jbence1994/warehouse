using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supply>> GetSupplies()
        {
            return await _context.Supplies
                .Include(s => s.Product)
                .ThenInclude(m => m.Merchant)
                .ToListAsync();
        }

        public async Task<Supply> GetSupply(int productId)
        {
            return await _context.Supplies
                .Where(s => s.ProductId == productId)
                .SingleOrDefaultAsync();
        }

        public async Task<SupplyEntry> GetSupplyEntry(int id)
        {
            return await _context.SupplyEntries
                .Include(s => s.Product)
                .ThenInclude(s => s.Merchant)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Add(SupplyEntry supplyEntry)
        {
            await _context.SupplyEntries.AddAsync(supplyEntry);
        }

        public async Task Add(Supply supply)
        {
            await _context.Supplies.AddAsync(supply);
        }
    }
}
