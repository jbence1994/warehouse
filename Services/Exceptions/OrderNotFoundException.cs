using System;

namespace Warehouse.Services.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int orderId)
            : base($"Order not found with id: {orderId}")
        {
        }
    }
}
