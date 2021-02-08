using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AC.DataAccess;

namespace AC.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
