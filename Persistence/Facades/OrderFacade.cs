using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IStockRepository stockRepository;
        private readonly IProductRepository productRepository;
        private readonly ITechnicianRepository technicianRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderFacade(
            IStockRepository stockRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.stockRepository = stockRepository;
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> Checkout(Order order)
        {
            await CalculateOrderDetailSubTotals(order.OrderDetails);
            CalculateOrderTotal(order);
            await AssignOrderToTechnician(order);
            await DecrementProductQuantityInStockSummary(order.OrderDetails);
            await CompleteOrder();

            return order;
        }

        private async Task CalculateOrderDetailSubTotals(ICollection<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                var product = await productRepository.GetProduct(orderDetail.ProductId);
                orderDetail.SubTotal = product.Price * orderDetail.Quantity;
            }
        }

        private void CalculateOrderTotal(Order order)
        {
            var total = order.OrderDetails.Sum(s => s.SubTotal);
            order.Total = total;
        }

        private async Task AssignOrderToTechnician(Order order)
        {
            var technician = await technicianRepository.GetTechnician(order.TechnicianId);

            technician.Orders.Add(order);

            DecrementTechnicianBalance(technician, order.Total);
            
            await AddActualBalanceSummary(technician);
        }

        private void DecrementTechnicianBalance(Technician technician, double amount)
        {
            technician.Balance -= amount;
        }

        private async Task AddActualBalanceSummary(Technician technician)
        {
            technician.TechnicianBalances.Add(new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance,
                CreatedAt = DateTime.Now
            });
        }

        private async Task DecrementProductQuantityInStockSummary(ICollection<OrderDetail> orderDetails)
        {
            var summarizedStocks = await stockRepository.GetSummarizedStocks();

            foreach (var orderDetail in orderDetails)
            {
                foreach (var stockSummary in summarizedStocks)
                {
                    if (orderDetail.ProductId != stockSummary.ProductId)
                    {
                        continue;
                    }

                    if (stockSummary.Quantity <= 0 || stockSummary.Quantity < orderDetail.Quantity)
                    {
                        throw new Exception("There is not enough product on stock to sell.");
                    }

                    stockSummary.Quantity -= orderDetail.Quantity;
                }
            }
        }

        private async Task CompleteOrder()
        {
            await unitOfWork.CompleteAsync();
        }
    }
}
