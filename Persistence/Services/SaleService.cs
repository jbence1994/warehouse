using System;
using System.Collections.Generic;
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

        public SaleService(
            IStockRepository stockRepository,
            IProductRepository productRepository,
            ITechnicianRepository technicianRepository,
            ITechnicianBalanceRepository technicianBalanceRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.stockRepository = stockRepository;
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
            this.technicianBalanceRepository = technicianBalanceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Sale> Checkout(Sale sale)
        {
            await CalculateSaleDetailSubTotals(sale.SaleDetails);
            CalculateSaleTotal(sale);
            await AssignSaleToTechnician(sale);
            await DecrementProductQuantityInStockSummary(sale.SaleDetails);
            await CompleteSale();

            return sale;
        }

        private async Task CalculateSaleDetailSubTotals(ICollection<SaleDetail> saleDetails)
        {
            foreach (var saleDetail in saleDetails)
            {
                var product = await productRepository.GetProduct(saleDetail.ProductId);
                saleDetail.SubTotal = product.Price * saleDetail.Quantity;
            }
        }

        private void CalculateSaleTotal(Sale sale)
        {
            var total = sale.SaleDetails.Sum(s => s.SubTotal);
            sale.Total = total;
        }

        private async Task AssignSaleToTechnician(Sale sale)
        {
            var technician = await technicianRepository.GetTechnician(sale.TechnicianId);

            technician.Sales.Add(sale);

            DecrementTechnicianBalance(technician, sale.Total);
            
            await AddActualBalanceSummary(technician);
        }

        private void DecrementTechnicianBalance(Technician technician, double amount)
        {
            technician.Balance.Amount -= amount;
        }

        private async Task AddActualBalanceSummary(Technician technician)
        {
            await technicianBalanceRepository.Add(new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance.Amount,
                CreatedAt = DateTime.Now
            });
        }

        private async Task DecrementProductQuantityInStockSummary(ICollection<SaleDetail> saleDetails)
        {
            var summarizedStocks = await stockRepository.GetSummarizedStocks();

            foreach (var saleDetail in saleDetails)
            {
                foreach (var stockSummary in summarizedStocks)
                {
                    if (saleDetail.ProductId != stockSummary.ProductId)
                    {
                        continue;
                    }

                    if (stockSummary.Quantity <= 0 || stockSummary.Quantity < saleDetail.Quantity)
                    {
                        throw new Exception("There is not enough product on stock to sell.");
                    }

                    stockSummary.Quantity -= saleDetail.Quantity;
                }
            }
        }

        private async Task CompleteSale()
        {
            await unitOfWork.CompleteAsync();
        }
    }
}
