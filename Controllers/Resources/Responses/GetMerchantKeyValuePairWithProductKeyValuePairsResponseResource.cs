using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources.Responses
{
    public class GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource : GetKeyValuePairResponseResource
    {
        public ICollection<GetKeyValuePairResponseResource> Products { get; set; }

        public GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource()
        {
            Products = new Collection<GetKeyValuePairResponseResource>();
        }
    }
}
