using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers(bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await _context.Suppliers
                    .Include(s => s.Products)
                    .ToListAsync();
            }

            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task Add(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
        }
    }
}
