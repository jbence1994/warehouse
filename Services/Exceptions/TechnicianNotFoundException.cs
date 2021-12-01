using System;

namespace Warehouse.Services.Exceptions
{
    public class TechnicianNotFoundException : Exception
    {
        public TechnicianNotFoundException(int productId)
            : base($"Technician not found with id: {productId}")
        {
        }
    }
}
