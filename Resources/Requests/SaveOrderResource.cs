using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Resources.Requests
{
    public class SaveOrderResource
    {
        [Required]
        public int TechnicianId { get; set; }

        [Required]
        public ICollection<SaveOrderDetailResource> OrderDetails { get; set; }

        public SaveOrderResource()
        {
            OrderDetails = new Collection<SaveOrderDetailResource>();
        }
    }
}
