using System;
using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Services
{
    public class TechnicianOperations
    {
        private readonly ITechnicianRepository _technicianRepository;

        public TechnicianOperations(ITechnicianRepository technicianRepository)
        {
            _technicianRepository = technicianRepository;
        }

        public async Task Add(Technician technician)
        {
            var initialBalanceEntry = new TechnicianBalanceEntry
            {
                Amount = 0,
                CreatedAt = DateTime.Now
            };

            technician.BalanceEntries.Add(initialBalanceEntry);

            await _technicianRepository.Add(technician);
        }
    }
}
