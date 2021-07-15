using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class SupplierKeyValuePairWithProductKeyValuePairsResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Products { get; set; }

        public SupplierKeyValuePairWithProductKeyValuePairsResource()
        {
            Products = new Collection<KeyValuePairResource>();
        }
    }
}
