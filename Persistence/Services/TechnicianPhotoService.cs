using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class TechnicianPhotoService : ITechnicianPhotoService
    {
        private readonly IPhotoStorage photoStorage;
        private readonly ITechnicianPhotoRepository technicianPhotoRepository;
        private readonly IUnitOfWork unitOfWork;

        public TechnicianPhotoService(
            IPhotoStorage photoStorage,
            ITechnicianPhotoRepository technicianPhotoRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
            this.technicianPhotoRepository = technicianPhotoRepository;
            this.photoStorage = photoStorage;
        }

        public async Task<TechnicianPhoto> UploadPhoto(Technician technician, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new TechnicianPhoto
            {
                FileName = fileName
            };

            technician.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}
