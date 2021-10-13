using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Warehouse.Core.Facades
{
    public interface IPhotoFacade
    {
        Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}
