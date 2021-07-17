namespace Warehouse.Controllers.Resources.Responses
{
    public class StockResource
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductSupplierName { get; set; }
        public int Quantity { get; set; }
        public string ProductUnit { get; set; }
    }
}
