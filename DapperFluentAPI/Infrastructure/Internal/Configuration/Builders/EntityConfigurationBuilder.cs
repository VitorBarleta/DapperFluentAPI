using DapperFluentAPI.Infrastructure.Internal.Mapping;
using DapperFluentAPI.Infrastructure.Internal.Query;
using Microsoft.Extensions.DependencyInjection;

namespace DapperFluentAPI.Infrastructure.Internal.Configuration.Builders
{
    public class EntityConfigurationBuilder : IEntityConfigurationBuilder, IEntityConfigurationBuilderAccessor
    {
        private readonly IServiceCollection _services;

        public EntityConfigurationBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public void AddConfiguration<TEntity>(IEntityConfiguration<TEntity> configuration)
            where TEntity : class
        {
            var mapper = (IEntityTypeMapperAccessor<TEntity>)configuration.Configure(new EntityTypeMapper<TEntity>());
            _services.AddSingleton<IFluentQuery<TEntity>, FluentQuery<TEntity>>(_ => new FluentQuery<TEntity>(mapper));
        }

        public IServiceCollection Inject() => _services;
    }
}
