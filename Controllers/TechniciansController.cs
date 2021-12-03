using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class TechniciansController : ControllerBase
    {
        private readonly TechnicianService _technicianService;
        private readonly IMapper _mapper;

        public TechniciansController(
            TechnicianService technicianService,
            IMapper mapper
        )
        {
            _technicianService = technicianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnicians()
        {
            var technicians =
                await _technicianService.GetTechnicians();

            var response =
                _mapper.Map<IEnumerable<Technician>, IEnumerable<GetTechnicianResponseResource>>(technicians);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTechnician(int id)
        {
            try
            {
                var technician =
                    await _technicianService.GetTechnician(id);

                var response =
                    _mapper.Map<Technician, GetTechnicianResponseResource>(technician);

                return Ok(response);
            }
            catch (TechnicianNotFoundException technicianNotFoundException)
            {
                return NotFound(technicianNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnician(
            [FromBody] CreateTechnicianRequestResource request
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var technician =
                    _mapper.Map<CreateTechnicianRequestResource, Technician>(request);

                await _technicianService.Add(technician);

                technician =
                    await _technicianService.GetTechnician(technician.Id);

                var response =
                    _mapper.Map<Technician, GetTechnicianResponseResource>(technician);

                return Ok(response);

            }
            catch (TechnicianNotFoundException technicianNotFoundException)
            {
                return NotFound(technicianNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
