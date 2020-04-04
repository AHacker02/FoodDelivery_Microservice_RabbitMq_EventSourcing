using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstractions;
using OMF.Common.Models;

namespace OMF.OrderManagementService.Command.Application.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly INoSqlDataAccess _database;

        public OrderRepository(INoSqlDataAccess database)
        {
            _database = database;
        }

        public async Task CreateOrder(Order order)
            => await _database.Add(order);

        public async Task<Order> GetOrder(Guid orderId)
            => (await _database.Single<Order>(x => x.Id == orderId)); 

        public async Task UpdateOrder(Order order)
        {
            await _database.Delete<Order>(x => x.Id == order.Id);
            await _database.Add(order);
        }
    }
}
