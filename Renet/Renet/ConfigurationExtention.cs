using Application.CommandHandlers;
using Application.IRepositories;
using Application.QueryServices;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repositories;

namespace Renet
{
    public static class ConfigurationExtention
    {
        public static void Configure(this WebApplicationBuilder builder)
        {
            builder.ConfigureAppDbContext();
            builder.ConfigureServices();
            builder.ConfigureRepositories();
            builder.ConfigureCommandHandlers();
        }
        private static void ConfigureAppDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));


        }
        private static void ConfigureCommandHandlers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<BasketCommandHandler>();
        }
        private static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ProductQueryService>();
        }
        private static void ConfigureRepositories(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IProductRepositories ,ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
            builder.Services.AddScoped<IUserRepository , UserRepository>();
            builder.Services.AddScoped<IBasketRepository , BasketRepository>();
        }

    }
}
