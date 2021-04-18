using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IProductRepository productRepository;
        private readonly IPhotoService photoService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly PhotoSettings photoSettings;

        public PhotosController(IPhotoRepository photoRepository,
                                IProductRepository productRepository,
                                IPhotoService photoService,
                                IMapper mapper,
                                IWebHostEnvironment host,
                                IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoRepository = photoRepository;
            this.productRepository = productRepository;
            this.photoService = photoService;
            this.mapper = mapper;
            this.host = host;
            photoSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int productId, IFormFile photoToUpload)
        {
            var product = await productRepository.GetProduct(productId, includeRelated: false);

            if (product == null)
            {
                return NotFound();
            }

            if (photoToUpload == null)
            {
                return BadRequest("Null file.");
            }

            if (photoToUpload.Length == 0)
            {
                return BadRequest("Empty file.");
            }

            if (photoToUpload.Length > photoSettings.MaxBytes)
            {
                return BadRequest("Maximum file size exceeded.");
            }

            if (!photoSettings.IsSupportedType(photoToUpload.FileName))
            {
                return BadRequest("Invalid file type.");
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            var photo = await photoService.UploadPhoto(product, photoToUpload, uploadsFolderPath);

            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int productId)
        {
            var photos = await photoRepository.GetPhotos(productId);

            var photoResources = mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);

            return Ok(photoResources);
        }
    }
}
