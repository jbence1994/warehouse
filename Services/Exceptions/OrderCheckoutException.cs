using System;

namespace Warehouse.Services.Exceptions
{
    public class OrderCheckoutException : Exception
    {
        public OrderCheckoutException()
            : base("There is not enough supply of this product to checkout order.")
        {
        }
    }
}
