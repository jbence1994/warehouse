using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers(bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await context.Suppliers
                    .Include(s => s.Products)
                    .ToListAsync();
            }

            return await context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await context.Suppliers.FindAsync(id);
        }

        public async Task Add(Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
        }
    }
}
