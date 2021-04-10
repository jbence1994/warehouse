namespace Warehouse.Controllers.Resources
{
    public class ProductResource : KeyValuePairResource
    {
        public double Price { get; set; }
        public string Unit { get; set; }
        public KeyValuePairResource Supplier { get; set; }
    }
}
