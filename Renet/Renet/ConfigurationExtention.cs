using Application.CommandHandlers;
using Application.IRepositories;
using Application.QueryServices;
using Application.Services;
using Infrastructure;
using Infrastructure.Settings;
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
            builder.ConfigureSettings();
        }
        private static void ConfigureAppDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));


        }
        private static void ConfigureCommandHandlers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<BasketCommandHandler>();
            builder.Services.AddScoped<ProductCommandHandler>();
        }
        private static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<AuthService>();
            
            builder.Services.AddScoped<ProductQueryService>();
            builder.Services.AddScoped<BasketQueryService>();
            builder.Services.AddScoped<UserQueryService>();
            builder.Services.AddScoped<OrderQueryService>();
        }
        private static void ConfigureRepositories(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IProductRepository ,ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
            builder.Services.AddScoped<IUserRepository , UserRepository>();
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();
            builder.Services.AddScoped<IColorRepository, ColorRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        }

        private static void ConfigureSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<AccessTokenSettings>(builder.Configuration.GetSection(nameof(AccessTokenSettings)));
        }



    }
}
