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
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/products/{productId:int}/photos")]
    public class ProductPhotosController : ControllerBase
    {
        private readonly IProductPhotoRepository productPhotoRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductPhotoFacade productPhotoFacade;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly FileSettings fileSettings;

        public ProductPhotosController(
            IProductPhotoRepository productPhotoRepository,
            IProductRepository productRepository,
            IProductPhotoFacade productPhotoFacade,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            IOptionsSnapshot<FileSettings> options
        )
        {
            this.productPhotoRepository = productPhotoRepository;
            this.productRepository = productRepository;
            this.productPhotoFacade = productPhotoFacade;
            this.unitOfWork = unitOfWork;
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
            var photo = await productPhotoFacade.UploadPhoto(product, photoToUpload, uploadsFolderPath);
            await unitOfWork.CompleteAsync();

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
