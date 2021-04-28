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
    [Route("/api/technicians/{technicianId}/sales")]
    public class TechnicianSalesController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper mapper;

        public TechnicianSalesController(
            ISaleRepository saleRepository,
            IMapper mapper
        )
        {
            this.saleRepository = saleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales(int technicianId)
        {
            var sales = await saleRepository.GetSales(technicianId);

            var saleResources = mapper.Map<IEnumerable<Sale>, IEnumerable<SaleResource>>(sales);

            return Ok(saleResources);
        }
    }
}
