using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTechnicians()
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTechnician(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTechnician([FromBody] SaveTechnicianResource technicianResource)
        {
            return Ok();
        }
    }
}
