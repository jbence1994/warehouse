using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Resources.Responses
{
    public class MerchantKeyValuePairWithProductKeyValuePairsResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Products { get; set; }

        public MerchantKeyValuePairWithProductKeyValuePairsResource()
        {
            Products = new Collection<KeyValuePairResource>();
        }
    }
}
