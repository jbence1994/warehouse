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
using Warehouse.Core.Repositories;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/technicians/{technicianId:int}/photos/")]
    public class TechnicianPhotosController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository; // TODO: remove this to photo service...
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly PhotoService _photoService;
        private readonly FileSettings _fileSettings;

        public TechnicianPhotosController(
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            PhotoService photoService,
            IOptions<FileSettings> options
        )
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _host = host;
            _photoService = photoService;
            _fileSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int technicianId, IFormFile photoToUpload)
        {
            var technician = await _technicianRepository.GetTechnician(technicianId);

            if (technician == null) // TODO: null-check goes to service ...
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

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads/technicians");

            var fileName = await _photoService.StorePhoto(uploadsFolderPath, photoToUpload);

            var photo = new TechnicianPhoto
            {
                FileName = fileName
            };

            technician.Photos.Add(photo);

            await _unitOfWork.CompleteAsync();

            var result =
                _mapper.Map<TechnicianPhoto, PhotoResource>(photo);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int technicianId)
        {
            var photos = await _technicianRepository.GetPhoto(technicianId);

            var photoResources =
                _mapper.Map<IEnumerable<TechnicianPhoto>, IEnumerable<PhotoResource>>(photos);

            return Ok(photoResources);
        }
    }
}
