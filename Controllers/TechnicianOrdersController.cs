using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("/api/technicians/{technicianId:int}/orders")]
    public class TechnicianOrdersController : ControllerBase
    {
        private readonly ITechnicianOrderRepository technicianOrderRepository;
        private readonly IMapper mapper;

        public TechnicianOrdersController(
            ITechnicianOrderRepository technicianOrderRepository,
            IMapper mapper
        )
        {
            this.technicianOrderRepository = technicianOrderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int technicianId)
        {
            var orders = await technicianOrderRepository.GetOrders(technicianId);

            var orderResources = mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);

            return Ok(orderResources);
        }
    }
}
