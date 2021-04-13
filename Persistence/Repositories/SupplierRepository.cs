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

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await context.Suppliers
                .Include(s => s.Products)
                .ToListAsync();
        }
    }
}
