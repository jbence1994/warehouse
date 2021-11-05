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
                .Include(supply => supply.Product)
                .ThenInclude(product => product.Merchant)
                .ToListAsync();
        }

        public async Task<Supply> GetSupply(int productId)
        {
            return await _context.Supplies
                .Where(supply => supply.ProductId == productId)
                .SingleOrDefaultAsync();
        }

        public async Task<SupplyEntry> GetSupplyEntry(int id)
        {
            return await _context.SupplyEntries
                .Include(supplyEntry => supplyEntry.Product)
                .ThenInclude(product => product.Merchant)
                .SingleOrDefaultAsync(supplyEntry => supplyEntry.Id == id);
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
