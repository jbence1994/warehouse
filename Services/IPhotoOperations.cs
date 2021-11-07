using System.Threading.Tasks;
using Warehouse.Configuration.FileUpload;

namespace Warehouse.Services
{
    public interface IPhotoOperations
    {
        Task<string> StorePhoto(string rootUploadsFolderPath, IFile file);
        void Validate(IFile file, FileSettings fileSettings);
    }
}
