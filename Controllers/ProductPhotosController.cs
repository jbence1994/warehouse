using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/products/{productId:int}/photos")]
    public class ProductPhotosController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadPhoto(int productId, IFormFile photoToUpload)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPhotos(int productId)
        {
            return Ok();
        }
    }
}
