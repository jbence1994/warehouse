namespace Warehouse.Controllers.Resources.Responses
{
    public class OrderDetailResource
    {
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
