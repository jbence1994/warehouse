using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<SaveProductResource, Product>(productResource);

            await _productRepository.Add(product);
            await _unitOfWork.CompleteAsync();

            product = await _productRepository.GetProduct(product.Id);

            var result = _mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }
    }
}
