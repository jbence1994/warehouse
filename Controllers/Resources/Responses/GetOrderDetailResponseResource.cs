namespace Warehouse.Controllers.Resources.Responses
{
    public class GetOrderDetailResponseResource
    {
        public GetProductResponseResource Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
