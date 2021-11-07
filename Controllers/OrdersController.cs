using System;
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
    [Route("/api/[controller]/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderOperations _orderOperations;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersController(
            IOrderRepository orderRepository,
            OrderOperations orderOperations,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _orderRepository = orderRepository;
            _orderOperations = orderOperations;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] SaveOrderResource orderResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _mapper.Map<SaveOrderResource, Order>(orderResource);

            try
            {
                await _orderOperations.Checkout(order);
                await _unitOfWork.CompleteAsync();

                order = await _orderRepository.GetOrder(order.Id);

                var result = _mapper.Map<Order, OrderResource>(order);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
