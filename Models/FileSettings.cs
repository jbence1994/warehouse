using System.IO;
using System.Linq;

namespace Warehouse.Models
{
    public class FileSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupportedType(string fileName)
        {
            return AcceptedFileTypes
                .Any(type => type == Path.GetExtension(fileName).ToLower());
        }
    }
}
