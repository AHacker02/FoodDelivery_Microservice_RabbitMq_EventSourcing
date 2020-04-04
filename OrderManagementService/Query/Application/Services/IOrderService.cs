using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMF.Common.Models;

namespace OMF.OrderManagementService.Query.Application.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(Guid userId);
    }
}
