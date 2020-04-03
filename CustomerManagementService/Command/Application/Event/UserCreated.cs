using ServiceBus.Abstractions;
using System;

namespace OMF.CustomerManagementService.Command.Application.Event
{
    public class UserCreated : IEvent
    {
        public UserCreated(string email, Guid eventId)
        {
            Email = email;
            EventId = eventId;
        }
        public string Email { get; }
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
