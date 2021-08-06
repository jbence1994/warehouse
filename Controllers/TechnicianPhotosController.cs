using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/technicians/{technicianId:int}/photos")]
    public class TechnicianPhotosController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadPhoto(int technicianId, IFormFile photoToUpload)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPhotos(int technicianId)
        {
            return Ok();
        }
    }
}
