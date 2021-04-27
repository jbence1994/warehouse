using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources
{
    public class SaveSaleResource
    {
        [Required]
        public int TechnicianId { get; set; }

        [Required]
        public ICollection<SaveSaleDetailResource> SaleDetails { get; set; }

        public SaveSaleResource()
        {
            SaleDetails = new Collection<SaveSaleDetailResource>();
        }
    }
}
