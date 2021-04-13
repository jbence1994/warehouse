using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Controllers.Resources
{
    public class SupplierResource : KeyValuePairResource
    {
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<KeyValuePairResource> Products { get; set; }

        public SupplierResource()
        {
            Products = new Collection<KeyValuePairResource>();
        }
    }
}
