using Autofac;
using OMF.RestaurantService.Command.Application.Repositories;

namespace OMF.RestaurantService.Command.Application
{
    public class RestaurantModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<Seed>();
        }
    }
}
