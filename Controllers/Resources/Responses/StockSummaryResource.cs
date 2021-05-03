namespace Warehouse.Controllers.Resources.Responses
{
    public class StockSummaryResource
    {
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
