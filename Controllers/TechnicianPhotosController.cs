using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Warehouse.Configuration.FileUpload;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/technicians/{technicianId:int}/photos/")]
    public class TechnicianPhotosController : ControllerBase
    {
        private readonly TechnicianService _technicianService;
        private readonly PhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly FileSettings _fileSettings;

        public TechnicianPhotosController(
            TechnicianService technicianService,
            PhotoService photoService,
            IMapper mapper,
            IWebHostEnvironment host,
            IOptions<FileSettings> options
        )
        {
            _technicianService = technicianService;
            _photoService = photoService;
            _mapper = mapper;
            _host = host;
            _fileSettings = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoto(int technicianId)
        {
            try
            {
                var photos =
                    await _technicianService.GetPhoto(technicianId);

                var response =
                    _mapper.Map<IEnumerable<TechnicianPhoto>, IEnumerable<TechnicianResponse>>(photos);

                return Ok(response);
            }
            catch (TechnicianNotFoundException technicianNotFoundException)
            {
                return NotFound(technicianNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int technicianId, IFile photoToUpload)
        {
            try
            {
                var technician =
                    await _technicianService.GetTechnician(technicianId);

                _photoService.Validate(photoToUpload, _fileSettings);

                var uploadsFolderPath =
                    Path.Combine(_host.WebRootPath, "uploads/technicians");

                var fileName =
                    await _photoService.StorePhoto(uploadsFolderPath, photoToUpload);

                await _technicianService.AddPhoto(technician, fileName);

                return Ok();
            }
            catch (TechnicianNotFoundException technicianNotFoundException)
            {
                return NotFound(technicianNotFoundException.Message);
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
