using System;
using Microsoft.AspNetCore.Http;
using Warehouse.Core.Models;

namespace Warehouse.Extensions
{
    public static class IFormFileExtensions
    {
        public static void Validate(this IFormFile photoToUpload, PhotoSettings photoSettings)
        {
            if (photoToUpload == null)
            {
                throw new Exception("Null file.");
            }

            if (photoToUpload.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            if (photoToUpload.Length > photoSettings.MaxBytes)
            {
                throw new Exception("Maximum file size exceeded.");
            }

            if (!photoSettings.IsSupportedType(photoToUpload.FileName))
            {
                throw new Exception("Invalid file type.");
            }
        }
    }
}
