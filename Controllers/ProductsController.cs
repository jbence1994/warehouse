using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductRepository productRepository,
            ProductService productOperations,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _productService = productOperations;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product =
                _mapper.Map<SaveProductResource, Product>(productResource);

            await _productService.Add(product);
            await _unitOfWork.CompleteAsync();

            product = await _productRepository.GetProduct(product.Id);

            var result =
                _mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }
    }
}
