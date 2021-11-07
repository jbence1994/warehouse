using System.ComponentModel.DataAnnotations;

namespace Warehouse.Resources.Requests
{
    public class SaveSupplyEntryResource
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
