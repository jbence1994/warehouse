using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources
{
    public class SupplierWithProductsResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Products { get; set; }

        public SupplierWithProductsResource()
        {
            Products = new Collection<KeyValuePairResource>();
        }
    }
}
