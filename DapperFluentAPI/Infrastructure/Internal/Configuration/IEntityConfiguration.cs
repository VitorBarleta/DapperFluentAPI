using DapperFluentAPI.Infrastructure.Internal.Mapping;

namespace DapperFluentAPI.Infrastructure.Internal.Configuration
{
    public interface IEntityConfiguration<TEntity>
        where TEntity : class
    {
        IEntityTypeMapper<TEntity> Configure(IEntityTypeMapper<TEntity> mapper);
    }
}
