using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMF.OrderManagementService.Query.Application.Services;

namespace OMF.OrderManagementService.Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserOrders()
        {
            return Ok(await _orderService.GetUserOrders(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserOrders(string orderId)
        {
            return Ok((await _orderService.GetUserOrders(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).FirstOrDefault(x=>x.OrdeId==orderId)));
        }
    }
}