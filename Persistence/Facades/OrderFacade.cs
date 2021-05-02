using System;
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

        public async Task Checkout(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                var product = await productRepository.GetProduct(orderDetail.ProductId);
                orderDetail.SubTotal = product.Price * orderDetail.Quantity;
            }

            order.Total = order.OrderDetails.Sum(s => s.SubTotal);

            var technician = await technicianRepository.GetTechnician(order.TechnicianId);
            technician.Orders.Add(order);
            technician.Balance -= order.Total;

            technician.TechnicianBalances.Add(new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance,
                CreatedAt = DateTime.Now
            });

            var summarizedStocks = await stockRepository.GetSummarizedStocks();

            foreach (var orderDetail in order.OrderDetails)
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

            await unitOfWork.CompleteAsync();
        }
    }
}
