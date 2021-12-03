using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services.Exceptions;

namespace Warehouse.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISupplyRepository _supplyRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            ISupplyRepository supplyRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork
        )
        {
            _orderRepository = orderRepository;
            _supplyRepository = supplyRepository;
            _productRepository = productRepository;
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Checkout(Order order)
        {
            await CalculatePrices(order);
            await UpdateSupply(order.OrderDetails);
            await AddToTechnician(order);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(int technicianId)
        {
            var technician = await _technicianRepository.GetTechnician(technicianId);

            if (technician == null)
            {
                throw new TechnicianNotFoundException(technicianId);
            }

            return await _orderRepository.GetOrders(technicianId);
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);

            if (order == null)
            {
                throw new OrderNotFoundException(id);
            }

            return order;
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
                    throw new OrderCheckoutException();
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
