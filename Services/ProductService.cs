using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services.Exceptions;

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

        public async Task<IEnumerable<ProductPhoto>> GetPhotos()
        {
            return await _productRepository.GetPhotos();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }

            return product;
        }

        public async Task Add(Product product)
        {
            product.Supply = new Supply
            {
                Quantity = 0
            };

            await _productRepository.Add(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
