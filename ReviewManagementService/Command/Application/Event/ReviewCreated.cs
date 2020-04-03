using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Abstractions;

namespace OMF.ReviewManagementService.Command.Application.Event
{
    public class ReviewCreated:IEvent
    {
        public ReviewCreated(Guid restaurantId)
        {
            RestaurantId = restaurantId;
            EventId = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }
        public Guid RestaurantId { get; set; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
