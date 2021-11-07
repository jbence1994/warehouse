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
using Warehouse.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/technicians/{technicianId:int}/photos/")]
    public class TechnicianPhotosController : ControllerBase
    {
        private readonly ITechnicianPhotoRepository _technicianPhotoRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly FileSystemPhotoOperations _photoOperations;
        private readonly FileSettings _fileSettings;

        public TechnicianPhotosController(
            ITechnicianPhotoRepository technicianPhotoRepository,
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            FileSystemPhotoOperations photoOperations,
            IOptions<FileSettings> options
        )
        {
            _technicianPhotoRepository = technicianPhotoRepository;
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _host = host;
            _photoOperations = photoOperations;
            _fileSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int technicianId, IFormFile photoToUpload)
        {
            var technician = await _technicianRepository.GetTechnician(technicianId);

            if (technician == null)
            {
                return NotFound();
            }

            try
            {
                _photoOperations.Validate(photoToUpload, _fileSettings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads/technicians");

            var fileName = await _photoOperations.StorePhoto(uploadsFolderPath, photoToUpload);

            var photo = new TechnicianPhoto
            {
                FileName = fileName
            };

            technician.Photos.Add(photo);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<TechnicianPhoto, PhotoResource>(photo);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int technicianId)
        {
            var photos = await _technicianPhotoRepository.GetPhotos(technicianId);

            var photoResources = _mapper.Map<IEnumerable<TechnicianPhoto>, IEnumerable<PhotoResource>>(photos);

            return Ok(photoResources);
        }
    }
}
