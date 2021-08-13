namespace Warehouse.Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
