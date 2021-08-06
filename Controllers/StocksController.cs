using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStocks()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateStockEntry([FromBody] SaveStockEntryResource stockEntryResource)
        {
            return Ok();
        }
    }
}
