using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace Warehouse.Facades
{
    public class OrderFacade
    {
        public async Task Checkout(Order order)
        {
            await CalculatePrices(order);
            await UpdateStock(order.OrderDetails);
            await AddToTechnician(order);
        }

        private async Task CalculatePrices(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.Product = null;
                // Get a product by the orderDetails's productId field
                orderDetail.CalculateSubTotal();
            }

            order.CalculateTotal();
        }

        private async Task UpdateStock(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                Stock stock = null;
                // Get a stock by the orderDetail's productId field

                if (!stock.IsAvailable(orderDetail.Quantity))
                {
                    throw new Exception("There is not enough product on stock to checkout order.");
                }

                stock.Quantity -= orderDetail.Quantity;
            }
        }

        private async Task AddToTechnician(Order order)
        {
            Technician technician = null;
            // Find the technician by id which is in orderDetails

            technician.Orders.Add(order);

            technician.Balance -= order.Total;

            technician.BalanceEntries.Add(new TechnicianBalanceEntry
            {
                Amount = technician.Balance,
                CreatedAt = DateTime.Now
            });
        }
    }
}
