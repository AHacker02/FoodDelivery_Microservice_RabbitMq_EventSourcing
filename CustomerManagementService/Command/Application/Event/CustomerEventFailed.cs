using ServiceBus.Abstractions;
using System;

namespace OMF.CustomerManagementService.Command.Application.Event
{
    public class CustomerEventFailed : IEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }

        public CustomerEventFailed(string email,
            string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
            EventId = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
    }
}
