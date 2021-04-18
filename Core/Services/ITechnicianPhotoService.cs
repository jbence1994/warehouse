using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Core.Services
{
    public interface ITechnicianPhotoService
    {
        Task<TechnicianPhoto> UploadPhoto(Technician technician, IFormFile file, string uploadsFolderPath);
    }
}
