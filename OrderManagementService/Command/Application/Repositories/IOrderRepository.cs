using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.OrderManagementService.Command.Application.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task<Order> GetOrder(Guid orderId);
        Task UpdateOrder(Order order);
    }
}
