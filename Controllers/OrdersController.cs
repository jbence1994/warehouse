using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core;
using Warehouse.Core.Facades;
using Warehouse.Core.Models;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderFacade orderFacade;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrdersController(
            IOrderFacade orderFacade,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            this.orderFacade = orderFacade;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] SaveOrderResource orderResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = mapper.Map<SaveOrderResource, Order>(orderResource);
            order.CreatedAt = DateTime.Now;

            try
            {
                await orderFacade.Checkout(order);
                await unitOfWork.CompleteAsync();
                
                var result = mapper.Map<Order, OrderResource>(order);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
