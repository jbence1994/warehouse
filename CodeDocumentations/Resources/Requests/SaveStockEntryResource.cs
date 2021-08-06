using System.ComponentModel.DataAnnotations;

namespace Warehouse.CodeDocumentations.Resources.Requests
{
    public class SaveStockEntryResource
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
