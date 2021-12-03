namespace Warehouse.Controllers.Resources.Responses
{
    public class SupplyResource
    {
        public int Id { get; set; }
        public GetProductRequestResource Product { get; set; }
        public int Quantity { get; set; }
    }
}
