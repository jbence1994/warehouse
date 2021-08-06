﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<StockEntry> StockEntries { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }

        public Product()
        {
            StockEntries = new Collection<StockEntry>();
            Photos = new Collection<ProductPhoto>();
        }
    }
}
