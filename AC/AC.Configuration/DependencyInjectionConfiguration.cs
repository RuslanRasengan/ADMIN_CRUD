using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AC.BusinessLogic.Services;
using AC.Interfaces.BusinessLogic.Services;
using AC.Interfaces.DataAccess.Repositories;
using AC.DataAccess.Repositories;
using AC.Integration.Mail;

namespace AC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductServices>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
