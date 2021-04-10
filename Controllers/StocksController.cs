using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Warehouse.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace eWarehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository stockRepository;
        private readonly IMapper mapper;

        public StocksController(IStockRepository stockRepository, IMapper mapper)
        {
            this.stockRepository = stockRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await stockRepository.GetStocks();

            var stockResources = mapper.Map<IEnumerable<StockSummary>, IEnumerable<StockResource>>(stocks);

            return Ok(stockResources);
        }
    }
}
