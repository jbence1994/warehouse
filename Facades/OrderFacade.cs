using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITechnicianRepository _technicianRepository;

        public OrderFacade(
            ISupplyRepository supplyRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository
        )
        {
            _supplyRepository = supplyRepository;
            _productRepository = productRepository;
            _technicianRepository = technicianRepository;
        }

        public async Task Checkout(Order order)
        {
            await CalculatePrices(order);
            await UpdateSupply(order.OrderDetails);
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

        private async Task UpdateSupply(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                var supply = await _supplyRepository.GetSupply(orderDetail.ProductId);

                if (!supply.IsAvailable(orderDetail.Quantity))
                {
                    throw new Exception("There is not enough supply of this product to checkout order.");
                }

                supply.Quantity -= orderDetail.Quantity;
            }
        }

        private async Task AddToTechnician(Order order)
        {
            var technician = await _technicianRepository.GetTechnician(order.TechnicianId);
            order.CreatedAt = DateTime.Now;

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
