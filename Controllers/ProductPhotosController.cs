using System;
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
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/products/photos/")]
    public class ProductPhotosController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly PhotoService _photoService;
        private readonly FileSettings _fileSettings;

        public ProductPhotosController(
            ProductService productService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            PhotoService photoService,
            IOptions<FileSettings> options
        )
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _host = host;
            _photoService = photoService;
            _fileSettings = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos()
        {
            var photos =
                await _productService.GetPhotos();

            var response =
                _mapper.Map<IEnumerable<ProductPhoto>, IEnumerable<ProductPhotoResource>>(photos);

            return Ok(response);
        }

        [HttpPost("{productId:int}")]
        public async Task<IActionResult> UploadPhoto(int productId, IFormFile photoToUpload)
        {
            try
            {
                var product =
                    await _productService.GetProduct(productId);

                _photoService.Validate(photoToUpload, _fileSettings);

                var uploadsFolderPath =
                    Path.Combine(_host.WebRootPath, "uploads/products");

                var fileName =
                    await _photoService.StorePhoto(uploadsFolderPath, photoToUpload);

                var photo = new ProductPhoto
                {
                    FileName = fileName
                };

                product.Photos.Add(photo);

                await _unitOfWork.CompleteAsync();

                var response =
                    _mapper.Map<ProductPhoto, PhotoResource>(photo);

                return Ok(response);
            }
            catch (ProductNotFoundException productNotFoundException)
            {
                return NotFound(productNotFoundException.Message);
            }
            catch (NullFileException nullFileException)
            {
                return BadRequest(nullFileException.Message);
            }
            catch (EmptyFileException emptyFileException)
            {
                return BadRequest(emptyFileException.Message);
            }
            catch (MaximumFileSizeExceededException maximumFileSizeExceededException)
            {
                return BadRequest(maximumFileSizeExceededException.Message);
            }
            catch (InvalidFileTypeException invalidFileTypeException)
            {
                return BadRequest(invalidFileTypeException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
