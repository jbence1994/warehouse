using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.Facades
{
    public class ProductPhotoFacade : IProductPhotoFacade
    {
        private readonly IPhotoStorage photoStorage;

        public ProductPhotoFacade(IPhotoStorage photoStorage)
        {
            this.photoStorage = photoStorage;
        }

        public async Task<ProductPhoto> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new ProductPhoto
            {
                FileName = fileName
            };

            product.Photos.Add(photo);

            return photo;
        }
    }
}
