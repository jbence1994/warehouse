using System;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Facades
{
    public class TechnicianFacade : ITechnicianFacade
    {
        private readonly ITechnicianRepository technicianRepository;
        private readonly IUnitOfWork unitOfWork;

        public TechnicianFacade(
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.technicianRepository = technicianRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(Technician technician)
        {
            await technicianRepository.Add(technician);
            
            technician.TechnicianBalances.Add(new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance,
                CreatedAt = DateTime.Now
            });

            await unitOfWork.CompleteAsync();
        }
    }
}
