using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Controllers.Resources.Requests
{
    public class CreateOrderRequest
    {
        [Required]
        public int TechnicianId { get; set; }

        [Required]
        public ICollection<CreateOrderDetailRequest> OrderDetails { get; set; }

        public CreateOrderRequest()
        {
            OrderDetails = new Collection<CreateOrderDetailRequest>();
        }
    }
}
