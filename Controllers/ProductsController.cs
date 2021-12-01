using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

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
            [FromBody] CreateProductRequestResource request
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product =
                    _mapper.Map<CreateProductRequestResource, Product>(request);

                await _productService.Add(product);

                product = await _productService.GetProduct(product.Id);

                var response =
                    _mapper.Map<Product, GetProductRequestResource>(product);

                return Ok(response);
            }
            catch (ProductNotFoundException productNotFoundException)
            {
                return NotFound(productNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
