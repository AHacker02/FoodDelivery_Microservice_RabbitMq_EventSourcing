using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;
using OMF.OrderManagementService.Query.Application.Repositories;

namespace OMF.OrderManagementService.Query.Application.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetUserOrders(Guid userId)
            => await _orderRepository.GetUserOrders(userId);
    }
}
