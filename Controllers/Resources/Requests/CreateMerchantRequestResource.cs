using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources.Requests
{
    public class CreateMerchantRequestResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(255)]
        public string City { get; set; }
        
        [StringLength(255)]
        public string Email { get; set; }
        
        [StringLength(25)]
        public string Phone { get; set; }
    }
}
