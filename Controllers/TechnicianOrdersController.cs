using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/v1/technicians/{technicianId:int}/orders/")]
    public class TechnicianOrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public TechnicianOrdersController(
            OrderService orderService,
            IMapper mapper
        )
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int technicianId)
        {
            try
            {
                var orders =
                    await _orderService.GetOrders(technicianId);

                var response =
                    _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResponse>>(orders);

                return Ok(response);
            }
            catch (TechnicianNotFoundException technicianNotFoundException)
            {
                return NotFound(technicianNotFoundException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
