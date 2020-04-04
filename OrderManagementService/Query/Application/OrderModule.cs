using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using OMF.OrderManagementService.Query.Application.Repositories;
using OMF.OrderManagementService.Query.Application.Services;

namespace OMF.OrderManagementService.Query.Application
{
    public class OrderModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>().As<IOrderService>();
        }
    }
}
