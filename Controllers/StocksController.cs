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
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StocksController(
            IStockRepository stockRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _stockRepository = stockRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _stockRepository.GetStocks();

            var stockResources = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockResource>>(stocks);

            return Ok(stockResources);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockEntry([FromBody] SaveStockEntryResource stockEntryResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockEntry = _mapper.Map<SaveStockEntryResource, StockEntry>(stockEntryResource);
            stockEntry.CreatedAt = DateTime.Now;

            if (await _stockRepository.IsProductOnStock(stockEntry.ProductId))
            {
                var stock = await _stockRepository.GetStock(stockEntry.ProductId);
                stock.Quantity += stockEntry.Quantity;
            }
            else
            {
                var stock = new Stock
                {
                    ProductId = stockEntry.ProductId,
                    Quantity = stockEntry.Quantity
                };

                await _stockRepository.Add(stock);
            }

            await _stockRepository.Add(stockEntry);

            await _unitOfWork.CompleteAsync();

            stockEntry = await _stockRepository.GetStockEntry(stockEntry.Id);

            var result = _mapper.Map<StockEntry, StockEntryResource>(stockEntry);

            return Ok(result);
        }
    }
}
