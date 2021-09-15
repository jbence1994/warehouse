using System;

namespace Warehouse.Controllers.Resources.Responses
{
    public class StockEntryResource
    {
        public int Id { get; set; }
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
