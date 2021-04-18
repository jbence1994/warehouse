using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Core.Services
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IPhotoStorage photoStorage;
        private readonly IProductPhotoRepository productPhotoRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductPhotoService(IPhotoStorage photoStorage, IProductPhotoRepository productPhotoRepository, IUnitOfWork unitOfWork)
        {
            this.photoStorage = photoStorage;
            this.productPhotoRepository = productPhotoRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductPhoto> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new ProductPhoto { FileName = fileName };
            product.Photos.Add(photo);
            
            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}
