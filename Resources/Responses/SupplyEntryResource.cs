using System;

namespace Warehouse.Resources.Responses
{
    public class SupplyEntryResource
    {
        public int Id { get; set; }
        public GetProductRequestResource Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
