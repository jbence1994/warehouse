using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface IPhotoService
    {
        Task<Photo> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath);
    }
}
