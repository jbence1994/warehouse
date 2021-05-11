using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Facades
{
    public class TechnicianFacade : ITechnicianFacade
    {
        private readonly ITechnicianRepository technicianRepository;

        public TechnicianFacade(ITechnicianRepository technicianRepository)
        {
            this.technicianRepository = technicianRepository;
        }

        public async Task Add(Technician technician)
        {
            await technicianRepository.Add(technician);

            technician.AddInitialBalanceEntry();
        }
    }
}
