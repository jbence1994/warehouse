using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources
{
    public class SaveSaleDetailResource
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
