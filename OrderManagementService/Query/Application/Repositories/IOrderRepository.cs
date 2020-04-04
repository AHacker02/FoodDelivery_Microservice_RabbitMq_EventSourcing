using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.OrderManagementService.Query.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetUserOrders(Guid userId);
    }
}
