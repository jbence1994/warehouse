using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface IProductPhotoFacade
    {
        Task<ProductPhoto> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath);
    }
}
