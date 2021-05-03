using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository,
            IMapper mapper
        )
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        [HttpGet("suppliersWithProducts")]
        public async Task<IActionResult> GetSuppliersWithProductsResource()
        {
            var suppliers = await supplierRepository.GetSuppliers();

            var supplierResources = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierWithProductsResource>>(suppliers);

            return Ok(supplierResources);
        }

        [HttpGet("supplierKeyValuePairs")]
        public async Task<IActionResult> GetSupplierKeyValuePairs()
        {
            var suppliers = await supplierRepository.GetSuppliers(includeRelated: false);

            var supplierResources = mapper.Map<IEnumerable<Supplier>, IEnumerable<KeyValuePairResource>>(suppliers);

            return Ok(supplierResources);
        }
    }
}
