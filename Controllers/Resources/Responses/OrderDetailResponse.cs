namespace Warehouse.Controllers.Resources.Responses
{
    public class OrderDetailResponse
    {
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
