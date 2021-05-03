using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;

namespace Warehouse.Persistence.Facades
{
    public class TechnicianPhotoFacade : ITechnicianPhotoFacade
    {
        private readonly IPhotoStorage photoStorage;

        public TechnicianPhotoFacade(IPhotoStorage photoStorage)
        {
            this.photoStorage = photoStorage;
        }

        public async Task<TechnicianPhoto> UploadPhoto(Technician technician, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new TechnicianPhoto
            {
                FileName = fileName
            };

            technician.Photos.Add(photo);

            return photo;
        }
    }
}
