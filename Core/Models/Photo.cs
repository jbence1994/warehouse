using System.ComponentModel.DataAnnotations;

namespace Warehouse.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
    }
}
