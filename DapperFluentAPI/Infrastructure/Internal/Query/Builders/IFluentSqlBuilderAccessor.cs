using Dapper;
using System.Collections.Generic;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders
{
    public interface IFluentSqlBuilderAccessor<TEntity>
        where TEntity : class
    {
        SqlBuilder SqlBuilder { get; }
        IDictionary<string, object> Params { get; }
        void AddParams(KeyValuePair<string, object> keyValuePair);
    }
}
