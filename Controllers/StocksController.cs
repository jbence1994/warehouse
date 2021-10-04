using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Facades;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockFacade _stockFacade;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StocksController(
            IStockRepository stockRepository,
            IStockFacade stockFacade,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _stockRepository = stockRepository;
            _stockFacade = stockFacade;
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

            await _stockFacade.Add(stockEntry);
            await _unitOfWork.CompleteAsync();

            stockEntry = await _stockRepository.GetStockEntry(stockEntry.Id);

            var result = _mapper.Map<StockEntry, StockEntryResource>(stockEntry);

            return Ok(result);
        }
    }
}
