using DapperFluentAPI.Infrastructure.Internal.Configuration.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DapperFluentAPI.Infrastructure.Internal
{
    public static class DbEntityConfigurator
    {
        public static IServiceCollection AddEntityConfigurations(this IServiceCollection services, Action<IEntityConfigurationBuilder> action)
        {
            var configBuilder = new EntityConfigurationBuilder(services);
            action.Invoke(configBuilder);

            return configBuilder.Inject();
        }
    }
}
