using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Abstractions;

namespace OMF.OrderManagementService.Command.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEventBus _bus;

        public OrderController(IEventBus bus)
        {
            _bus = bus;
        }

        [HttpPost("")]
        public async Task<IActionResult> OrderFood(OrderCommand command)
        {

        }
    }
}