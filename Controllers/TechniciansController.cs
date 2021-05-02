using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianRepository technicianRepository;
        private readonly ITechnicianFacade technicianFacade;
        private readonly IMapper mapper;

        public TechniciansController(
            ITechnicianRepository technicianRepository,
            ITechnicianFacade technicianFacade,
            IMapper mapper
        )
        {
            this.technicianRepository = technicianRepository;
            this.technicianFacade = technicianFacade;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnicians()
        {
            var technicians = await technicianRepository.GetTechnicians();

            var technicianResources = mapper.Map<IEnumerable<Technician>, IEnumerable<TechnicianResource>>(technicians);

            return Ok(technicianResources);
        }

        [HttpGet("{id}")]
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

            await technicianFacade.Add(technician);

            technician = await technicianRepository.GetTechnician(technician.Id);

            var result = mapper.Map<Technician, TechnicianResource>(technician);

            return Ok(result);
        }
    }
}
