using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OMF.Common.Events;
using OMF.Common.Helpers;
using OMF.Common.Models;
using OMF.OrderManagementService.Command.Application.Commands;
using OMF.OrderManagementService.Command.Application.Events;
using OMF.OrderManagementService.Command.Application.Repositories;
using ServiceBus.Abstractions;

namespace OMF.OrderManagementService.Command.Application.CommandHandlers
{
    public class OrderCommandHandler:ICommandHandler<OrderCommand>
    {
        private readonly IEventBus _bus;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _map;

        public OrderCommandHandler(IEventBus bus,IOrderRepository orderRepository,IMapper map)
        {
            _bus = bus;
            _orderRepository = orderRepository;
            _map = map;
        }
        public async Task HandleAsync(OrderCommand command)
        {
            var order = _map.Map<Order>(command);
            order.Status = OrderStatus.PaymentPending.ToString();
            await _orderRepository.CreateOrder(order);
            await _bus.PublishEvent(new PaymentInitiated(order.Id));
            while (order.Status == OrderStatus.PaymentPending.ToString())
            {
                order.Status = (await _orderRepository.GetOrder(order.Id)).Status;
            }

            if (order.Status == OrderStatus.PaymentSuccessful.ToString())
            {
                order.Status = OrderStatus.OrderPlaced.ToString();
                await _orderRepository.UpdateOrder(order);
                await _bus.PublishEvent(new OrderConfirmed(order.RestaurantId,order.OrderItems,order.Address));
            }

        }
    }
}
