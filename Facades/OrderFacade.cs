using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITechnicianRepository _technicianRepository;

        public OrderFacade(
            IStockRepository stockRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository
        )
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _technicianRepository = technicianRepository;
        }

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
                orderDetail.Product = await _productRepository.GetProduct(orderDetail.ProductId, includeRelated: false);
                orderDetail.CalculateSubTotal();
            }

            order.CalculateTotal();
        }

        private async Task UpdateStock(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                var stock = await _stockRepository.GetStock(orderDetail.ProductId);

                if (!stock.IsAvailable(orderDetail.Quantity))
                {
                    throw new Exception("There is not enough product on stock to checkout order.");
                }

                stock.Quantity -= orderDetail.Quantity;
            }
        }

        private async Task AddToTechnician(Order order)
        {
            var technician = await _technicianRepository.GetTechnician(order.TechnicianId);

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
