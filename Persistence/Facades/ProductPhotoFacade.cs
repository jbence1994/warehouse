using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.Facades
{
    public class ProductPhotoFacade : IProductPhotoFacade
    {
        private readonly IPhotoStorage photoStorage;
        private readonly IUnitOfWork unitOfWork;

        public ProductPhotoFacade(
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
