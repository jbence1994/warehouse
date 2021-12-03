using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources.Requests
{
    public class CreateOrderRequestResource
    {
        [Required]
        public int TechnicianId { get; set; }

        [Required]
        public ICollection<CreateOrderDetailRequestResource> OrderDetails { get; set; }

        public CreateOrderRequestResource()
        {
            OrderDetails = new Collection<CreateOrderDetailRequestResource>();
        }
    }
}
