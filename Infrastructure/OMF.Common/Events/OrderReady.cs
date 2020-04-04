using System;
using System.Collections.Generic;
using System.Text;
using ServiceBus.Abstractions;

namespace OMF.Common.Events
{
    public class OrderReady:IEvent
    {
        public OrderReady(Guid orderId, string fromAddress, string toAddress)
        {
            OrderId = orderId;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            EventId = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }
        public Guid OrderId { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
