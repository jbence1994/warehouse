using System;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class SaleService : ISaleService
    {
        private readonly IStockRepository stockRepository;
        private readonly IProductRepository productRepository;
        private readonly ITechnicianRepository technicianRepository;
        private readonly ITechnicianBalanceRepository technicianBalanceRepository;
        private readonly IUnitOfWork unitOfWork;

        public SaleService(IStockRepository stockRepository, IProductRepository productRepository, ITechnicianRepository technicianRepository, ITechnicianBalanceRepository technicianBalanceRepository, IUnitOfWork unitOfWork)
        {
            this.stockRepository = stockRepository;
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
            this.technicianBalanceRepository = technicianBalanceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Sale> Checkout(Sale sale)
        {
            foreach (var saleDetail in sale.SaleDetails)
            {
                var product = await productRepository.GetProduct(saleDetail.ProductId);
                saleDetail.SubTotal = product.Price * saleDetail.Quantity;
            }

            var total = sale.SaleDetails.Sum(s => s.SubTotal);
            sale.Total = total;

            var technician = await technicianRepository.GetTechnician(sale.TechnicianId);
            technician.Balance.Amount -= total;
            technician.Sales.Add(sale);

            var technicianBalance = new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance.Amount,
                CreatedAt = DateTime.Now
            };

            await technicianBalanceRepository.Add(technicianBalance);

            var summarizedStocks = await stockRepository.GetSummarizedStocks();

            foreach (var saleDetail in sale.SaleDetails)
            {
                foreach (var stockSummary in summarizedStocks)
                {
                    if (saleDetail.ProductId == stockSummary.ProductId)
                    {
                        if (stockSummary.Quantity <= 0 || stockSummary.Quantity < saleDetail.Quantity)
                        {
                            throw new Exception("There is not enough product on stock to sell.");
                        }

                        stockSummary.Quantity -= saleDetail.Quantity;
                    }
                }
            }

            await unitOfWork.CompleteAsync();

            return sale;
        }
    }
}
