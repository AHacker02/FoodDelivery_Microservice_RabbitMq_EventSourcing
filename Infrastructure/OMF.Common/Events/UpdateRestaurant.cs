using System;
using System.Collections.Generic;
using System.Text;
using ServiceBus.Abstractions;

namespace OMF.Common.Events
{
    public class UpdateRestaurant:IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Rating { get; set; }
        public string Location { get; set; }
        public string ListedCity { get; set; }
        public decimal ApproxCost { get; set; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
