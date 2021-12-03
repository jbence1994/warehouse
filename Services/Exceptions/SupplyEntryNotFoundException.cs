using System;

namespace Warehouse.Services.Exceptions
{
    public class SupplyEntryNotFoundException : Exception
    {
        public SupplyEntryNotFoundException(int supplyEntryId)
            : base($"Supply entry not found with id: {supplyEntryId}.")
        {
        }
    }
}
