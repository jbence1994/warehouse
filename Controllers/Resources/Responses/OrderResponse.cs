using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderDetailResponse> OrderDetails { get; set; }

        public OrderResponse()
        {
            OrderDetails = new Collection<OrderDetailResponse>();
        }
    }
}
