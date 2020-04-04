using System;
using System.Collections.Generic;
using System.Text;
using OMF.Common.Models;
using ServiceBus.Abstractions;

namespace OMF.Common.Events
{
    public class OrderConfirmed:IEvent
    {
        public OrderConfirmed(Guid restaurantId, List<OrderItem> orderItems,string address)
        {
            RestaurantId = restaurantId;
            OrderItems = orderItems;
            EventId = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
            Address = address;
        }
        public Guid RestaurantId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Address { get; set; }
    }
}
