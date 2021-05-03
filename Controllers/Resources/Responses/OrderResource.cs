using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class OrderResource
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderDetailResource> OrderDetails { get; set; }

        public OrderResource()
        {
            OrderDetails = new Collection<OrderDetailResource>();
        }
    }
}
