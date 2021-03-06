namespace Warehouse.Core.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public bool IsAvailable(int quantity)
        {
            return Quantity > 0 || Quantity >= quantity;
        }
    }
}
