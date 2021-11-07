using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Facades;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly ISupplyFacade _supplyFacade;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SuppliesController(
            ISupplyRepository supplyRepository,
            ISupplyFacade supplyFacade,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _supplyRepository = supplyRepository;
            _supplyFacade = supplyFacade;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplies()
        {
            var supplies = await _supplyRepository.GetSupplies();

            var supplyResources = _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);

            return Ok(supplyResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplyEntry([FromBody] SaveSupplyEntryResource saveSupplyEntryResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplyEntry = _mapper.Map<SaveSupplyEntryResource, SupplyEntry>(saveSupplyEntryResource);

            await _supplyFacade.Add(supplyEntry);
            await _unitOfWork.CompleteAsync();

            supplyEntry = await _supplyRepository.GetSupplyEntry(supplyEntry.Id);

            var result = _mapper.Map<SupplyEntry, SupplyEntryResource>(supplyEntry);

            return Ok(result);
        }
    }
}
