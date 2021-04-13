using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources
{
    public class SaveStockResource
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
