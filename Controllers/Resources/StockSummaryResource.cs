namespace Warehouse.Controllers.Resources
{
    public class StockSummaryResource
    {
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
