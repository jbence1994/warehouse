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
    [Route("api/technicians/{technicianId}/photos")]
    public class TechnicianPhotosController : ControllerBase
    {
        private readonly ITechnicianPhotoRepository technicianPhotoRepository;
        private readonly ITechnicianRepository technicianRepository;
        private readonly ITechnicianPhotoService technicianPhotoService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly PhotoSettings photoSettings;

        public TechnicianPhotosController(ITechnicianPhotoRepository technicianPhotoRepository,
                                ITechnicianRepository technicianRepository,
                                ITechnicianPhotoService technicianPhotoService,
                                IMapper mapper,
                                IWebHostEnvironment host,
                                IOptionsSnapshot<PhotoSettings> options)
        {
            this.technicianPhotoRepository = technicianPhotoRepository;
            this.technicianRepository = technicianRepository;
            this.technicianPhotoService = technicianPhotoService;
            this.mapper = mapper;
            this.host = host;
            photoSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int technicianId, IFormFile photoToUpload)
        {
            var technician = await technicianRepository.GetTechnician(technicianId);

            if (technician == null)
            {
                return NotFound();
            }

            try
            {
                photoToUpload.Validate(photoSettings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads/technicians");
            var photo = await technicianPhotoService.UploadPhoto(technician, photoToUpload, uploadsFolderPath);

            return Ok(mapper.Map<TechnicianPhoto, PhotoResource>(photo));
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int technicianId)
        {
            var photos = await technicianPhotoRepository.GetPhotos(technicianId);

            var photoResources = mapper.Map<IEnumerable<TechnicianPhoto>, IEnumerable<PhotoResource>>(photos);

            return Ok(photoResources);
        }
    }
}