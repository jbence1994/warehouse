using System;
using System.IO;
using System.Threading.Tasks;
using Warehouse.Configuration.FileUpload;
using Warehouse.Services.Exceptions;

namespace Warehouse.Services
{
    public class PhotoService
    {
        public async Task<string> StorePhoto(string uploadsFolderPath, IFile file)
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

        public void Validate(IFile file, FileSettings fileSettings)
        {
            if (file == null)
            {
                throw new NullFileException();
            }

            if (file.Length == 0)
            {
                throw new EmptyFileException();
            }

            if (file.Length > fileSettings.MaxBytes)
            {
                throw new MaximumFileSizeExceededException();
            }

            if (!fileSettings.IsSupportedType(file.FileName))
            {
                throw new InvalidFileTypeException();
            }
        }
    }
}
