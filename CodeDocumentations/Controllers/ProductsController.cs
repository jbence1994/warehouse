using Microsoft.AspNetCore.Mvc;
using Warehouse.CodeDocumentations.Resources.Requests;

namespace Warehouse.CodeDocumentations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] SaveProductResource productResource)
        {
            return Ok();
        }
    }
}
