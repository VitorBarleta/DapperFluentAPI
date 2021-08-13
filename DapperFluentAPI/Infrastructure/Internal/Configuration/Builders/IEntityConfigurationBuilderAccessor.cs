using Microsoft.Extensions.DependencyInjection;

namespace DapperFluentAPI.Infrastructure.Internal.Configuration.Builders
{
    public interface IEntityConfigurationBuilderAccessor
    {
        IServiceCollection Inject();
    }
}
