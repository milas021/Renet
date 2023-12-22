using Application.IRepositories;
using Application.QueryServices;
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
        }
        private static void ConfigureAppDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));


        }

        private static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ProductQueryService>();
        }
        private static void ConfigureRepositories(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IProductRepositories ,ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
        }

    }
}
