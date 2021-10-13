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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _supplierRepository.GetSuppliers();

            var supplierResources =
                _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);

            return Ok(supplierResources);
        }

        [HttpGet("supplierKeyValuePairs")]
        public async Task<IActionResult> GetSupplierKeyValuePairs()
        {
            var suppliers = await _supplierRepository.GetSuppliers(includeRelated: false);

            var supplierResources =
                _mapper.Map<IEnumerable<Supplier>, IEnumerable<KeyValuePairResource>>(suppliers);

            return Ok(supplierResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] SaveSupplierResource saveSupplierResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = _mapper.Map<SaveSupplierResource, Supplier>(saveSupplierResource);

            await _supplierRepository.Add(supplier);
            await _unitOfWork.CompleteAsync();

            supplier = await _supplierRepository.GetSupplier(supplier.Id);

            var result = _mapper.Map<Supplier, SupplierResource>(supplier);

            return Ok(result);
        }
    }
}
