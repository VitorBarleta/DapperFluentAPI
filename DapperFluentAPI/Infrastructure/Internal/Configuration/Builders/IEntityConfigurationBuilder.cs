namespace DapperFluentAPI.Infrastructure.Internal.Configuration.Builders
{
    public interface IEntityConfigurationBuilder
    {
        void AddConfiguration<TEntity>(IEntityConfiguration<TEntity> configuration)
            where TEntity : class;
    }
}
