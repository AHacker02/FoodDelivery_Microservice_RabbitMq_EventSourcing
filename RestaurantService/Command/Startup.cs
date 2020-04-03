using Autofac;
using BaseService;
using DataAccess.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OMF.RestaurantService.Command.Application;
using OMF.RestaurantService.Command.Application.Repositories;

namespace OMF.RestaurantService.Command
{
    public class Startup : AppStartupBase
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(env, configuration)
        {
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureApplicationServices(services, new OpenApiInfo
            {
                Version = "v1",
                Title = "Restaurant API",
                Description = "Restaurant management service API"
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MongoDbModule(Configuration));
            builder.RegisterModule(new RestaurantModule());
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed seeder)
        {
            base.ConfigureApplication(app, env);
            seeder.SeedRestaurants();
        }
    }
}
