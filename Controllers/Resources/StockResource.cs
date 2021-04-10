namespace Warehouse.Controllers.Resources
{
    public class StockResource
    {
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
