using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(int id)
        {
            // TODO: null-check
            return await _productRepository.GetProduct(id);
        }

        public async Task Add(Product product)
        {
            var initialSupply = new Supply
            {
                Quantity = 0
            };

            product.Supplies.Add(initialSupply);

            await _productRepository.Add(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
