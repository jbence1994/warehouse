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
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("suppliersWithProducts")]
        public async Task<IActionResult> GetSuppliersWithProductsResource()
        {
            var suppliers = await supplierRepository.GetSuppliers();

            var supplierResources =
                mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierWithProductsResource>>(suppliers);

            return Ok(supplierResources);
        }

        [HttpGet("supplierKeyValuePairs")]
        public async Task<IActionResult> GetSupplierKeyValuePairs()
        {
            var suppliers = await supplierRepository.GetSuppliers(includeRelated: false);

            var supplierResources = mapper.Map<IEnumerable<Supplier>, IEnumerable<KeyValuePairResource>>(suppliers);

            return Ok(supplierResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] SaveSupplierResource saveSupplierResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = mapper.Map<SaveSupplierResource, Supplier>(saveSupplierResource);

            await supplierRepository.Add(supplier);
            await unitOfWork.CompleteAsync();

            supplier = await supplierRepository.GetSupplier(supplier.Id);

            var result = mapper.Map<Supplier, SupplierResource>(supplier);

            return Ok(result);
        }
    }
}
