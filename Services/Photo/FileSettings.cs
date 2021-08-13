using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Warehouse.Services.Photo
{
    public class FileSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public void ValidateFile(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception("Null file.");
            }

            if (file.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            if (file.Length > MaxBytes)
            {
                throw new Exception("Maximum file size exceeded.");
            }

            if (IsSupportedType(file.FileName))
            {
                throw new Exception("Invalid file type.");
            }
        }

        private bool IsSupportedType(string fileName)
        {
            return AcceptedFileTypes
                .Any(type => type == Path.GetExtension(fileName).ToLower());
        }
    }
}
