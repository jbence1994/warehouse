using System;

namespace Warehouse.Controllers.Resources
{
    public class StockResource
    {
        public int Id { get; set; }
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
