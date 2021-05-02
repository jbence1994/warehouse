using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Core.Facades
{
    public interface ITechnicianPhotoFacade
    {
        Task<TechnicianPhoto> UploadPhoto(Technician technician, IFormFile file, string uploadsFolderPath);
    }
}
