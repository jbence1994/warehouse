using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianRepository technicianRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechniciansController(
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            this.technicianRepository = technicianRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnicians()
        {
            var technicians = await technicianRepository.GetTechnicians();

            var technicianResources = mapper.Map<IEnumerable<Technician>, IEnumerable<TechnicianResource>>(technicians);

            return Ok(technicianResources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTechnician(int id)
        {
            var technician = await technicianRepository.GetTechnician(id);

            if (technician == null)
            {
                return NotFound();
            }

            var technicianResource = mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(technicianResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnician([FromBody] SaveTechnicianResource technicianResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technician = mapper.Map<SaveTechnicianResource, Technician>(technicianResource);

            technician.BalanceEntries.Add(new TechnicianBalanceEntry
            {
                Amount = 0,
                CreatedAt = DateTime.Now
            });

            await technicianRepository.Add(technician);

            await unitOfWork.CompleteAsync();

            technician = await technicianRepository.GetTechnician(technician.Id);

            var result = mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(result);
        }
    }
}
