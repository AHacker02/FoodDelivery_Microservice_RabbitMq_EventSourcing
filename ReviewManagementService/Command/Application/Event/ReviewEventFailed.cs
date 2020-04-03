using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Abstractions;

namespace OMF.ReviewManagementService.Command.Application.Event
{
    public class ReviewEventFailed:IEvent
    {
        public string Reason { get; }
        public string Code { get; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }

        public ReviewEventFailed(string reason, string code, Guid eventId)
        {
            Reason = reason;
            Code = code;
            EventId = eventId;
            TimeStamp = DateTime.Now;
        }
    }
}
