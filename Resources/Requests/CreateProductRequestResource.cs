using System.ComponentModel.DataAnnotations;

namespace Warehouse.Resources.Requests
{
    public class CreateProductRequestResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Unit { get; set; }

        [Required]
        public int MerchantId { get; set; }
    }
}
