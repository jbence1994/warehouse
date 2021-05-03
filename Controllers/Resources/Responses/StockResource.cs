namespace Warehouse.Controllers.Resources.Responses
{
    public class StockResource
    {
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
