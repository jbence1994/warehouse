using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoStorage photoStorage;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;

        public PhotoService(IPhotoStorage photoStorage, IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
        {
            this.photoStorage = photoStorage;
            this.photoRepository = photoRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Photo> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new Photo { FileName = fileName };
            product.Photos.Add(photo);
            
            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}
