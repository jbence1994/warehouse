using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface IProductPhotoService
    {
        Task<ProductPhoto> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath);
    }
}
