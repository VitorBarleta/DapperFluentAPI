using System.Collections.Generic;

namespace DapperFluentAPI.Infrastructure.Internal.Mapping
{
    public interface IEntityTypeMapperAccessor<TEntity>
        where TEntity : class
    {
        string SchemaName { get; }
        string TableName { get; }

        IDictionary<string, string> GetMapping();
    }
}
