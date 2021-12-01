using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(
            ProductService productOperations,
            IMapper mapper
        )
        {
            _productService = productOperations;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateProductRequestResource createProductRequestResource
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product =
                _mapper.Map<CreateProductRequestResource, Product>(createProductRequestResource);

            await _productService.Add(product);

            product = await _productService.GetProduct(product.Id);

            var response =
                _mapper.Map<Product, GetProductRequestResource>(product);

            return Ok(response);
        }
    }
}
