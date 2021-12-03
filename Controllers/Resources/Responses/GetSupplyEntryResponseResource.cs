using System;

namespace Warehouse.Controllers.Resources.Responses
{
    public class GetSupplyEntryResponseResource
    {
        public int Id { get; set; }
        public GetProductResponseResource Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
