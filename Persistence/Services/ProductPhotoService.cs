using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IPhotoStorage photoStorage;
        private readonly IUnitOfWork unitOfWork;

        public ProductPhotoService(
            IPhotoStorage photoStorage,
            IUnitOfWork unitOfWork
        )
        {
            this.photoStorage = photoStorage;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductPhoto> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new ProductPhoto
            {
                FileName = fileName
            };

            product.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}
