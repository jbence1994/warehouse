using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using System;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
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

        public StocksController(
            IStockRepository stockRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            this.stockRepository = stockRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await stockRepository.GetStocks();

            var stockResources = mapper.Map<IEnumerable<Stock>, IEnumerable<StockResource>>(stocks);

            return Ok(stockResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockEntry([FromBody] SaveStockEntryResource stockEntryResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockEntry = mapper.Map<SaveStockEntryResource, StockEntry>(stockEntryResource);
            stockEntry.CreatedAt = DateTime.Now;

            if (await stockRepository.IsProductOnStock(stockEntry.ProductId))
            {
                var stock = await stockRepository.GetStock(stockEntry.ProductId);
                stock.Quantity += stockEntry.Quantity;
            }
            else
            {
                var stock = new Stock
                {
                    ProductId = stockEntry.ProductId,
                    Quantity = stockEntry.Quantity
                };

                await stockRepository.Add(stock);
            }

            await stockRepository.Add(stockEntry);

            await unitOfWork.CompleteAsync();

            stockEntry = await stockRepository.GetStockEntry(stockEntry.Id);

            var result = mapper.Map<StockEntry, StockEntryResource>(stockEntry);

            return Ok(result);
        }
    }
}
