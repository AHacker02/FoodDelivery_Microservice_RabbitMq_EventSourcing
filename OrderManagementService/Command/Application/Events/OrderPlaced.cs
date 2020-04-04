using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Abstractions;

namespace OMF.OrderManagementService.Command.Application.Events
{
    public class PaymentInitiated:IEvent
    {
        public PaymentInitiated(Guid orderId)
        {
            OrderId = orderId;
            EventId = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
        public Guid OrderId { get; set; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
