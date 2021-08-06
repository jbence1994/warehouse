using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder([FromBody] SaveOrderResource orderResource)
        {
            return Ok();
        }
    }
}
