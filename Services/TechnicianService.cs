using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services.Exceptions;

namespace Warehouse.Services
{
    public class TechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TechnicianService(
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork
        )
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Technician>> GetTechnicians()
        {
            return await _technicianRepository.GetTechnicians();
        }

        public async Task<Technician> GetTechnician(int id)
        {
            var technician = await _technicianRepository.GetTechnician(id);

            if (technician == null)
            {
                throw new TechnicianNotFoundException(id);
            }

            return technician;
        }

        public async Task<IEnumerable<TechnicianPhoto>> GetPhoto(int id)
        {
            var technician = _technicianRepository.GetTechnician(id);

            if (technician == null)
            {
                throw new TechnicianNotFoundException(id);
            }

            return await _technicianRepository.GetPhoto(technician.Id);
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
            await _unitOfWork.CompleteAsync();
        }
    }
}
