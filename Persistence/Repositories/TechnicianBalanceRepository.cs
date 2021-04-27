using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class TechnicianBalanceRepository : ITechnicianBalanceRepository
    {
        private readonly ApplicationDbContext context;

        public TechnicianBalanceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(TechnicianBalance technicianBalance)
        {
            await context.TechnicianBalances.AddAsync(technicianBalance);
        }
    }
}
