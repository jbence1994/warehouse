using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Warehouse.Core.Services
{
    public interface IPhotoStorage
    {
        Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}
