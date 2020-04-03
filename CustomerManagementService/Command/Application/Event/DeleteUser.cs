using ServiceBus.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMF.CustomerManagementService.Command.Application.Event
{
    public class DeleteUser : IEvent
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }

        public DeleteUser()
        {
            TimeStamp = DateTime.UtcNow;
            EventId = Guid.NewGuid();
        }
    }
}
