using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/products/photos")]
    public class ProductPhotosController : ControllerBase
    {
        private readonly IProductPhotoRepository productPhotoRepository;
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly FileSystemPhotoStorage photoStorage;
        private readonly FileSettings fileSettings;

        public ProductPhotosController(
            IProductPhotoRepository productPhotoRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            FileSystemPhotoStorage photoStorage,
            IOptions<FileSettings> options
        )
        {
            this.productPhotoRepository = productPhotoRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.host = host;
            this.photoStorage = photoStorage;
            fileSettings = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos()
        {
            var photos = await productPhotoRepository.GetPhotos();

            var photoResources = mapper.Map<IEnumerable<ProductPhoto>, IEnumerable<ProductPhotoResource>>(photos);

            return Ok(photoResources);
        }

        [HttpPost("{productId:int}")]
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

            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, photoToUpload);

            var photo = new ProductPhoto
            {
                FileName = fileName
            };

            product.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            var result = mapper.Map<ProductPhoto, PhotoResource>(photo);

            return Ok(result);
        }
    }
}
