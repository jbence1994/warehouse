using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Configuration.FileUpload;

namespace Warehouse.Services
{
    public class FileSystemPhotoOperations
    {
        public async Task<string> StorePhoto(string uploadsFolderPath, IFormFile file)
        {
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        public void Validate(IFormFile file, FileSettings fileSettings)
        {
            if (file == null)
            {
                throw new Exception("Null file.");
            }

            if (file.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            if (file.Length > fileSettings.MaxBytes)
            {
                throw new Exception("Maximum file size exceeded.");
            }

            if (!fileSettings.IsSupportedType(file.FileName))
            {
                throw new Exception("Invalid file type.");
            }
        }
    }
}
