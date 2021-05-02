using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleFacade saleService;
        private readonly IMapper mapper;

        public SalesController(
            ISaleFacade saleService,
            IMapper mapper
        )
        {
            this.saleService = saleService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaveSaleResource saleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var sale = mapper.Map<SaveSaleResource, Sale>(saleResource);
            sale.CreatedAt = DateTime.Now;

            try
            {
                sale = await saleService.Checkout(sale);

                var result = mapper.Map<Sale, SaleResource>(sale);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
