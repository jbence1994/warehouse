using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources;
using Warehouse.Core;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = mapper.Map<SaveProductResource, Product>(productResource);

            await productRepository.Add(product);
            await unitOfWork.CompleteAsync();

            product = await productRepository.GetProduct(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }
    }
}