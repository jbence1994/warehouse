namespace Warehouse.Controllers.Resources.Responses
{
    public class StockResource
    {
        public int Id { get; set; }
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
