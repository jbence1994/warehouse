using System;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Core.Services;

namespace Warehouse.Persistence.Services
{
    public class SaleService : ISaleService
    {
        private readonly IProductRepository productRepository;
        private readonly ITechnicianRepository technicianRepository;
        private readonly ITechnicianBalanceRepository technicianBalanceRepository;
        private readonly IUnitOfWork unitOfWork;

        public SaleService(IProductRepository productRepository, ITechnicianRepository technicianRepository, ITechnicianBalanceRepository technicianBalanceRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
            this.technicianBalanceRepository = technicianBalanceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Sale> Checkout(Sale sale)
        {
            var technician = await technicianRepository.GetTechnician(sale.TechnicianId);

            foreach (var saleDetail in sale.SaleDetails)
            {
                var product = await productRepository.GetProduct(saleDetail.ProductId);
                saleDetail.SubTotal = product.Price * saleDetail.Quantity;
            }

            double total = 0;

            foreach (var saleDetail in sale.SaleDetails)
            {
                total += saleDetail.SubTotal;
            }

            sale.Total = total;

            technician.Sales.Add(sale);

            technician.Balance.Amount -= total;

            var technicianBalance = new TechnicianBalance
            {
                TechnicianId = technician.Id,
                Amount = technician.Balance.Amount,
                CreatedAt = DateTime.Now
            };

            await technicianBalanceRepository.Add(technicianBalance);

            await unitOfWork.CompleteAsync();

            return sale;
        }
    }
}
