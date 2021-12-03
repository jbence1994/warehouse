using System;

namespace Warehouse.Services.Exceptions
{
    public class MerchantNotFoundException : Exception
    {
        public MerchantNotFoundException(int merchantId)
            : base($"Merchant not found with id: {merchantId}")
        {
        }
    }
}
