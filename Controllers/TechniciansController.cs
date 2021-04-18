using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianRepository technicianRepository;
        private readonly IMapper mapper;

        public TechniciansController(ITechnicianRepository technicianRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.technicianRepository = technicianRepository;

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
    }
}
