using System.Threading.Tasks;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            var initialSupply = new Supply
            {
                Quantity = 0
            };

            product.Supplies.Add(initialSupply);

            await _productRepository.Add(product);
        }
    }
}
