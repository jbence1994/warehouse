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
    [Route("api/products/{productId}/photos")]
    public class ProductPhotosController : ControllerBase
    {
        private readonly IProductPhotoRepository productPhotoRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductPhotoService productPhotoService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly PhotoSettings photoSettings;

        public ProductPhotosController(IProductPhotoRepository productPhotoRepository,
                                IProductRepository productRepository,
                                IProductPhotoService productPhotoService,
                                IMapper mapper,
                                IWebHostEnvironment host,
                                IOptionsSnapshot<PhotoSettings> options)
        {
            this.productPhotoRepository = productPhotoRepository;
            this.productRepository = productRepository;
            this.productPhotoService = productPhotoService;
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

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads/products");
            var photo = await productPhotoService.UploadPhoto(product, photoToUpload, uploadsFolderPath);

            return Ok(mapper.Map<ProductPhoto, PhotoResource>(photo));
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int productId)
        {
            var photos = await productPhotoRepository.GetPhotos(productId);

            var photoResources = mapper.Map<IEnumerable<ProductPhoto>, IEnumerable<PhotoResource>>(photos);

            return Ok(photoResources);
        }
    }
}
