using System.Collections.Generic;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.WhereBuilders
{
    public interface IFluentWhereSqlBuilderAccessor<TEntity>
        where TEntity : class
    {
        IDictionary<string, object> ParamsDict { get; }
    }
}
