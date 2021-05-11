namespace Warehouse.Core.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public void IncrementQuantity(int amount)
        {
            Quantity += amount;
        }

        public void DecrementQuantity(int amount)
        {
            Quantity -= amount;
        }
    }
}
