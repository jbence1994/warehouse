using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }

        public Product()
        {
            Photos = new Collection<ProductPhoto>();
        }
    }
}
