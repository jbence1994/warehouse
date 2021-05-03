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
    [Route("api/technicians/{technicianId}/photos")]
    public class TechnicianPhotosController : ControllerBase
    {
        private readonly ITechnicianPhotoRepository technicianPhotoRepository;
        private readonly ITechnicianRepository technicianRepository;
        private readonly ITechnicianPhotoFacade technicianPhotoFacade;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment host;
        private readonly FileSettings fileSettings;

        public TechnicianPhotosController(
            ITechnicianPhotoRepository technicianPhotoRepository,
            ITechnicianRepository technicianRepository,
            ITechnicianPhotoFacade technicianPhotoFacade,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWebHostEnvironment host,
            IOptionsSnapshot<FileSettings> options
        )
        {
            this.technicianPhotoRepository = technicianPhotoRepository;
            this.technicianRepository = technicianRepository;
            this.technicianPhotoFacade = technicianPhotoFacade;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.host = host;
            fileSettings = options.Value;
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
                photoToUpload.Validate(fileSettings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads/technicians");
            var photo = await technicianPhotoFacade.UploadPhoto(technician, photoToUpload, uploadsFolderPath);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<TechnicianPhoto, PhotoResource>(photo);

            return Ok(result);
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
