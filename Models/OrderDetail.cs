namespace Warehouse.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }

        public void CalculateSubTotal()
        {
            SubTotal = Product.Price * Quantity;
        }
    }
}
