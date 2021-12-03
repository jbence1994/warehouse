using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class SuppliesController : ControllerBase
    {
        private readonly SupplyService _supplyService;
        private readonly IMapper _mapper;

        public SuppliesController(
            SupplyService supplyService,
            IMapper mapper
        )
        {
            _supplyService = supplyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplies()
        {
            var supplies =
                await _supplyService.GetSupplies();

            var response =
                _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResponse>>(supplies);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplyEntry(
            [FromBody] CreateSupplyEntryRequest request
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var supplyEntry =
                    _mapper.Map<CreateSupplyEntryRequest, SupplyEntry>(request);

                await _supplyService.Add(supplyEntry);

                supplyEntry =
                    await _supplyService.GetSupplyEntry(supplyEntry.Id);

                var response =
                    _mapper.Map<SupplyEntry, SupplyEntryResponse>(supplyEntry);

                return Ok(response);
            }
            catch (SupplyEntryNotFoundException supplyEntryNotFoundException)
            {
                return NotFound(supplyEntryNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
