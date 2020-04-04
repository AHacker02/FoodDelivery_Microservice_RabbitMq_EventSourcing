using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;
using ServiceBus.Abstractions;

namespace OMF.OrderManagementService.Command.Application.Commands
{
    public class OrderCommand:ICommand
    {
        public OrderCommand()
        {
            Id=Guid.NewGuid();
            TimeStamp=DateTime.Now;
        }
        public DateTime TimeStamp { get; set; }
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }
        public List<Item> OrderItems { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
    }

    public class Item
    {
        public int Quantity { get; set; }
        public Menu Food { get; set; }
    }
}
