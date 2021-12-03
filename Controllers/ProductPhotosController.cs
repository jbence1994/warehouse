﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Warehouse.Configuration.FileUpload;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/products/photos/")]
    public class ProductPhotosController : ControllerBase
    {
        private readonly IProductPhotoRepository _productPhotoRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly PhotoService _photoService;
        private readonly FileSettings _fileSettings;

        public ProductPhotosController(
            IProductPhotoRepository productPhotoRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            PhotoService photoService,
            IOptions<FileSettings> options
        )
        {
            _productPhotoRepository = productPhotoRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _host = host;
            _photoService = photoService;
            _fileSettings = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos()
        {
            var photos = await _productPhotoRepository.GetPhotos();

            var photoResources =
                _mapper.Map<IEnumerable<ProductPhoto>, IEnumerable<ProductPhotoResource>>(photos);

            return Ok(photoResources);
        }

        [HttpPost("{productId:int}")]
        public async Task<IActionResult> UploadPhoto(int productId, IFormFile photoToUpload)
        {
            var product = await _productRepository.GetProduct(productId, includeRelated: false);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                _photoService.Validate(photoToUpload, _fileSettings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads/products");

            var fileName = await _photoService.StorePhoto(uploadsFolderPath, photoToUpload);

            var photo = new ProductPhoto
            {
                FileName = fileName
            };

            product.Photos.Add(photo);

            await _unitOfWork.CompleteAsync();

            var result =
                _mapper.Map<ProductPhoto, PhotoResource>(photo);

            return Ok(result);
        }
    }
}
