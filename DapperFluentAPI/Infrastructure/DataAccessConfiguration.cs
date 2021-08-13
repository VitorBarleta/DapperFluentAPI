using DapperFluentAPI.Infrastructure.Domain.Users;
using DapperFluentAPI.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace DapperFluentAPI.Infrastructure
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection ConfigureDbEntityConfiguration(this IServiceCollection services)
        {
            services.AddEntityConfigurations(b =>
            {
                b.AddConfiguration(new UserConfiguration());
            });

            return services;
        }
    }
}
