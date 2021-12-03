using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly SupplyOperations _supplyOperations;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SuppliesController(
            ISupplyRepository supplyRepository,
            SupplyOperations supplyOperations,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _supplyRepository = supplyRepository;
            _supplyOperations = supplyOperations;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplies()
        {
            var supplies = await _supplyRepository.GetSupplies();

            var supplyResources =
                _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);

            return Ok(supplyResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplyEntry([FromBody] SaveSupplyEntryResource saveSupplyEntryResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplyEntry =
                _mapper.Map<SaveSupplyEntryResource, SupplyEntry>(saveSupplyEntryResource);

            await _supplyOperations.Add(supplyEntry);
            await _unitOfWork.CompleteAsync();

            supplyEntry = await _supplyRepository.GetSupplyEntry(supplyEntry.Id);

            var result =
                _mapper.Map<SupplyEntry, SupplyEntryResource>(supplyEntry);

            return Ok(result);
        }
    }
}
