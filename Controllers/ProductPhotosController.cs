using System;
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
using Warehouse.Extensions;

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
        private readonly FileSettings fileSettings;

        public ProductPhotosController(
            IProductPhotoRepository productPhotoRepository,
            IProductRepository productRepository,
            IProductPhotoService productPhotoService,
            IMapper mapper,
            IWebHostEnvironment host,
            IOptionsSnapshot<FileSettings> options
        )
        {
            this.productPhotoRepository = productPhotoRepository;
            this.productRepository = productRepository;
            this.productPhotoService = productPhotoService;
            this.mapper = mapper;
            this.host = host;
            fileSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int productId, IFormFile photoToUpload)
        {
            var product = await productRepository.GetProduct(productId, includeRelated: false);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                photoToUpload.Validate(fileSettings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads/products");
            var photo = await productPhotoService.UploadPhoto(product, photoToUpload, uploadsFolderPath);

            var result = mapper.Map<ProductPhoto, PhotoResource>(photo);

            return Ok(result);
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
