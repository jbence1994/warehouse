﻿using System;
using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class TechnicianFacade : ITechnicianFacade
    {
        private readonly ITechnicianRepository _technicianRepository;

        public TechnicianFacade(ITechnicianRepository technicianRepository)
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