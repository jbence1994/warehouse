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
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public ICollection<Supply> Supplies { get; set; }
        public ICollection<SupplyEntry> SupplyEntries { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }

        public Product()
        {
            Supplies = new Collection<Supply>();
            SupplyEntries = new Collection<SupplyEntry>();
            Photos = new Collection<ProductPhoto>();
        }
    }
}
