using System;
using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IStockRepository stockRepository;
        private readonly IProductRepository productRepository;
        private readonly ITechnicianRepository technicianRepository;

        public OrderFacade(
            IStockRepository stockRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository
        )
        {
            this.stockRepository = stockRepository;
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
        }

        public async Task Checkout(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.Product = await productRepository.GetProduct(orderDetail.ProductId, includeRelated: false);
                orderDetail.CalculateSubTotal();
            }

            order.CalculateTotal();

            var technician = await technicianRepository.GetTechnician(order.TechnicianId);

            technician.AddOrder(order);
            technician.DecrementBalance(order.Total);
            technician.AddBalanceEntry();

            foreach (var orderDetail in order.OrderDetails)
            {
                var stock = await stockRepository.GetStock(orderDetail.ProductId);
                
                if (!stock.IsEnough(orderDetail.Quantity))
                {
                    throw new Exception("There is not enough product on stock to checkout order.");
                }

                stock.DecrementQuantity(orderDetail.Quantity);
            }
        }
    }
}
