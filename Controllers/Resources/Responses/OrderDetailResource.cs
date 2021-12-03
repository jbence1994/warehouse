namespace Warehouse.Controllers.Resources.Responses
{
    public class OrderDetailResource
    {
        public GetProductRequestResource Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
