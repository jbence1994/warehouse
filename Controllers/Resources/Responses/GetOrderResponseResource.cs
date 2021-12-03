using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class GetOrderResponseResource
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<GetOrderDetailResponseResource> OrderDetails { get; set; }

        public GetOrderResponseResource()
        {
            OrderDetails = new Collection<GetOrderDetailResponseResource>();
        }
    }
}
