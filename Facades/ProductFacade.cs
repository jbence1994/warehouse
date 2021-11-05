using System.Threading.Tasks;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Facades
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository _productRepository;

        public ProductFacade(IProductRepository productRepository)
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
