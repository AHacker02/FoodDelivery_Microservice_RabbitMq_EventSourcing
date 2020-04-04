using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Events;
using OMF.Common.Helpers;
using OMF.OrderManagementService.Command.Application.Repositories;
using ServiceBus.Abstractions;

namespace OMF.OrderManagementService.Command.Application.EventHandlers
{
    public class DeliveryEventHandler:IEventHandler<OrderReady>
    {
        private readonly IOrderRepository _orderRepository;

        public DeliveryEventHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task HandleAsync(OrderReady @event)
        {
            var order = await _orderRepository.GetOrder(@event.OrderId);
            order.Status = OrderStatus.Delivered.ToString();
            await _orderRepository.UpdateOrder(order);
        }
    }
}
