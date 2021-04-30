using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class TechnicianPhotoService : ITechnicianPhotoService
    {
        private readonly IPhotoStorage photoStorage;
        private readonly IUnitOfWork unitOfWork;

        public TechnicianPhotoService(
            IPhotoStorage photoStorage,
            IUnitOfWork unitOfWork
        )
        {
            this.photoStorage = photoStorage;
            this.unitOfWork = unitOfWork;
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
