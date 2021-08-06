using Microsoft.AspNetCore.Mvc;
using Warehouse.CodeDocumentations.Resources.Requests;

namespace Warehouse.CodeDocumentations.Controllers
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
