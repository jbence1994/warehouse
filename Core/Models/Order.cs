using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Warehouse.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new Collection<OrderDetail>();
        }

        public void CalculateTotal()
        {
            Total = OrderDetails.Sum(o => o.SubTotal);
        }
    }
}
