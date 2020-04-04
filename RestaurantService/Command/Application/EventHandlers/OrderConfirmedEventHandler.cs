using System.Linq;
using OMF.Common.Events;
using ServiceBus.Abstractions;
using System.Threading.Tasks;
using OMF.RestaurantService.Command.Application.Repositories;

namespace OMF.RestaurantService.Command.Application.EventHandlers
{
    public class OrderConfirmedEventHandler : IEventHandler<OrderConfirmed>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IEventBus _bus;

        public OrderConfirmedEventHandler(IRestaurantRepository restaurantRepository,IEventBus bus)
        {
            _restaurantRepository = restaurantRepository;
            _bus = bus;
        }
        public async Task HandleAsync(OrderConfirmed @event)
        {
            await _restaurantRepository.UpdateStock(@event.OrderItems);
            var restaurant = (await _restaurantRepository.GetAllRestaurantsAsync()).FirstOrDefault(x=>x.Id==@event.RestaurantId);

            await _bus.PublishEvent(new OrderReady(@event.EventId,restaurant.Address,@event.Address));
        }
    }
}
