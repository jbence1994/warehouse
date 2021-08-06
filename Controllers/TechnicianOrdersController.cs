using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/technicians/{technicianId:int}/orders")]
    public class TechnicianOrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders(int technicianId)
        {
            return Ok();
        }
    }
}
