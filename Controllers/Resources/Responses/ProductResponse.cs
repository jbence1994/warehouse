namespace Warehouse.Controllers.Resources.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string MerchantName { get; set; }
    }
}
