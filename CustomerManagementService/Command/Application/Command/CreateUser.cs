using ServiceBus.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMF.CustomerManagementService.Command.Application.Command
{
    public class CreateUser : ICommand
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime TimeStamp { get; set; }
        public Guid Id { get; set; }

        public CreateUser()
        {
            TimeStamp = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }
    }
}
