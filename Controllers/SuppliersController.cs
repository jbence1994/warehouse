using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSuppliers()
        {
            return Ok();
        }

        [HttpGet("supplierKeyValuePairsWithProductKeyValuePairs")]
        public IActionResult GetSupplierKeyValuePairsWithProductKeyValuePairs()
        {
            return Ok();
        }

        [HttpGet("supplierKeyValuePairs")]
        public IActionResult GetSupplierKeyValuePairs()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] SaveSupplierResource saveSupplierResource)
        {
            return Ok();
        }
    }
}
