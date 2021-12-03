using System;

namespace Warehouse.Controllers.Resources.Responses
{
    public class SupplyEntryResponse
    {
        public int Id { get; set; }
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
