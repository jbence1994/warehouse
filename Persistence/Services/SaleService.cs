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
        private readonly IUnitOfWork unitOfWork;

        public SaleService(IProductRepository productRepository, ITechnicianRepository technicianRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.technicianRepository = technicianRepository;
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
            await unitOfWork.CompleteAsync();

            // a) decrement technician's balance ...

            // b) insert a new record to archive technician's balance in a summary

            return sale;
        }
    }
}
