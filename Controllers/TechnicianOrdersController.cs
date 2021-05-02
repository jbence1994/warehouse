using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/technicians/{technicianId}/orders")]
    public class TechnicianOrdersController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public TechnicianOrdersController(
            IOrderRepository orderRepository,
            IMapper mapper
        )
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int technicianId)
        {
            var orders = await orderRepository.GetOrders(technicianId);

            var orderResources = mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);

            return Ok(orderResources);
        }
    }
}
