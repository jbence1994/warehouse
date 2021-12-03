using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(
            OrderService orderService,
            IMapper mapper
        )
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            [FromBody] CreateOrderRequestResource request
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order =
                _mapper.Map<CreateOrderRequestResource, Order>(request);

            try
            {
                await _orderService.Checkout(order);

                order =
                    await _orderService.GetOrder(order.Id);

                var response =
                    _mapper.Map<Order, GetOrderResponseResource>(order);

                return Ok(response);
            }
            catch (OrderCheckoutException orderCheckoutException)
            {
                return BadRequest(orderCheckoutException.Message);
            }
            catch (OrderNotFoundException orderNotFoundException)
            {
                return NotFound(orderNotFoundException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
