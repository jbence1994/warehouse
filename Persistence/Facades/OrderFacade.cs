using System;
using System.Linq;
using System.Threading.Tasks;
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
            await CalculatePrices(order);
            await AssignToTechnician(order);
            await UpdateStockQuantity(order);
        }

        private async Task CalculatePrices(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                var product = await productRepository.GetProduct(orderDetail.ProductId);
                orderDetail.SubTotal = product.Price * orderDetail.Quantity;
            }

            order.Total = order.OrderDetails.Sum(s => s.SubTotal);
        }

        private async Task AssignToTechnician(Order order)
        {
            var technician = await technicianRepository.GetTechnician(order.TechnicianId);
            technician.Orders.Add(order);

            technician.Balance -= order.Total;

            technician.BalanceEntries.Add(new TechnicianBalanceEntry
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance,
                CreatedAt = DateTime.Now
            });
        }

        private async Task UpdateStockQuantity(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                var stock = await stockRepository.GetStock(orderDetail.ProductId);

                var notEnoughProductOnStock = stock.Quantity <= 0 || stock.Quantity < orderDetail.Quantity;
                
                if (notEnoughProductOnStock)
                {
                    throw new Exception("There is not enough product on stock to checkout order.");
                }

                stock.Quantity -= orderDetail.Quantity;
            }
        }
    }
}
