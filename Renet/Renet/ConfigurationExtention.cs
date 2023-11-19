using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Renet
{
    public static class ConfigurationExtention
    {
        public static void Configure(this WebApplicationBuilder builder)
        {
            builder.ConfigureAppDbContext();
        }
        private static void ConfigureAppDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));


        }

    }
}
