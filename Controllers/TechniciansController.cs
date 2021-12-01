using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly TechnicianOperations _technicianOperations;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TechniciansController(
            ITechnicianRepository technicianRepository,
            TechnicianOperations technicianOperations,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _technicianRepository = technicianRepository;
            _technicianOperations = technicianOperations;
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

            var technicianResource =
                _mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(technicianResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnician([FromBody] SaveTechnicianResource technicianResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technician =
                _mapper.Map<SaveTechnicianResource, Technician>(technicianResource);

            await _technicianOperations.Add(technician);
            await _unitOfWork.CompleteAsync();

            technician = await _technicianRepository.GetTechnician(technician.Id);

            var result =
                _mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(result);
        }
    }
}
