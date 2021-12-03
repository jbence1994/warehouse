using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources.Requests
{
    public class CreateSupplyEntryRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
