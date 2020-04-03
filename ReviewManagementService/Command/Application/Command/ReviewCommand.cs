using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;
using ServiceBus.Abstractions;

namespace OMF.ReviewManagementService.Command.Application.Command
{
    public class ReviewCommand: ICommand
    {
        public Guid RestaurantId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
