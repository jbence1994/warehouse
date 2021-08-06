using Microsoft.AspNetCore.Mvc;
using Warehouse.CodeDocumentations.Resources.Requests;

namespace Warehouse.CodeDocumentations.Controllers
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
