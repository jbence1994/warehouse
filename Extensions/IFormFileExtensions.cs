using System;
using Warehouse.Core.Models;

namespace Microsoft.AspNetCore.Http
{
    public static class IFormFileExtensions
    {
        public static void Validate(this IFormFile file, FileSettings fileSettings)
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
