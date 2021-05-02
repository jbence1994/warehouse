using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Warehouse.Core.Models
{
    public interface IPhotoStorage
    {
        Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}
