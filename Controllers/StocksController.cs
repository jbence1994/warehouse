using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Warehouse.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using System;
using Warehouse.Core;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository stockRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StocksController(IStockRepository stockRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.stockRepository = stockRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await stockRepository.GetStocks();

            var stockResources = mapper.Map<IEnumerable<StockSummary>, IEnumerable<StockSummaryResource>>(stocks);

            return Ok(stockResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] SaveStockResource stockResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = mapper.Map<SaveStockResource, Stock>(stockResource);
            stock.CreatedAt = DateTime.Now;

            await stockRepository.Add(stock);
            await unitOfWork.CompleteAsync();

            stock = await stockRepository.GetStock(stock.Id);

            var result = mapper.Map<Stock, StockResource>(stock);

            return Ok(result);
        }
    }
}
