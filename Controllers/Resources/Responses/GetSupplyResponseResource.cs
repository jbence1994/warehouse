namespace Warehouse.Controllers.Resources.Responses
{
    public class GetSupplyResponseResource
    {
        public int Id { get; set; }
        public GetProductResponseResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
