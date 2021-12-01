using System;

namespace Warehouse.Services.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId)
            : base($"Product not found with id: {productId}")
        {
        }
    }
}
