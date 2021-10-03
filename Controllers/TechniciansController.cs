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
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TechniciansController(
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnicians()
        {
            var technicians = await _technicianRepository.GetTechnicians();

            var technicianResources =
                _mapper.Map<IEnumerable<Technician>, IEnumerable<TechnicianResource>>(technicians);

            return Ok(technicianResources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTechnician(int id)
        {
            var technician = await _technicianRepository.GetTechnician(id);

            if (technician == null)
            {
                return NotFound();
            }

            var technicianResource = _mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(technicianResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnician([FromBody] SaveTechnicianResource technicianResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technician = _mapper.Map<SaveTechnicianResource, Technician>(technicianResource);

            technician.BalanceEntries.Add(new TechnicianBalanceEntry
            {
                Amount = 0,
                CreatedAt = DateTime.Now
            });

            await _technicianRepository.Add(technician);

            await _unitOfWork.CompleteAsync();

            technician = await _technicianRepository.GetTechnician(technician.Id);

            var result = _mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(result);
        }
    }
}
