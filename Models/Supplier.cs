using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new Collection<Product>();
        }
    }
}
