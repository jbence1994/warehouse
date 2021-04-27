using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public double Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }

        public Sale()
        {
            SaleDetails = new Collection<SaleDetail>();
        }
    }
}
