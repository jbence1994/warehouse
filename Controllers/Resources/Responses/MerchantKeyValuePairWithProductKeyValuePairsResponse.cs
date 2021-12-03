using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class MerchantKeyValuePairWithProductKeyValuePairsResponse : KeyValuePairResponse
    {
        public ICollection<KeyValuePairResponse> Products { get; set; }

        public MerchantKeyValuePairWithProductKeyValuePairsResponse()
        {
            Products = new Collection<KeyValuePairResponse>();
        }
    }
}
