using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int TechnicianId { get; set; }

        [Required]
        public ICollection<SaveOrderDetailResource> SaleDetails { get; set; }

        public SaveOrderResource()
        {
            SaleDetails = new Collection<SaveOrderDetailResource>();
        }
    }
}
