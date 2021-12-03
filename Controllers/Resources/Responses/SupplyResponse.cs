namespace Warehouse.Controllers.Resources.Responses
{
    public class SupplyResponse
    {
        public int Id { get; set; }
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
    }
}
