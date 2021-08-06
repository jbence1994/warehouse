using System.ComponentModel.DataAnnotations;

namespace Warehouse.CodeDocumentations.Resources.Requests
{
    public class SaveProductResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public int SupplierId { get; set; }
    }
}
