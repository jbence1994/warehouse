using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources
{
    public class SaleResource
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<SaleDetailResource> SaleDetails { get; set; }

        public SaleResource()
        {
            SaleDetails = new Collection<SaleDetailResource>();
        }
    }
}
