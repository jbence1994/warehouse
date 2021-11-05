using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly ApplicationDbContext _context;

        public MerchantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Merchant>> GetMerchants(bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await _context.Merchants
                    .Include(m => m.Products)
                    .ToListAsync();
            }

            return await _context.Merchants.ToListAsync();
        }

        public async Task<Merchant> GetMerchant(int id)
        {
            return await _context.Merchants.FindAsync(id);
        }

        public async Task Add(Merchant merchant)
        {
            await _context.Merchants.AddAsync(merchant);
        }
    }
}
