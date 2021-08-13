using Dapper;
using DapperFluentAPI.Infrastructure.Internal.Query.Builders;

namespace DapperFluentAPI.Infrastructure.Internal.Query
{
    public interface IFluentQuery<TEntity>
        where TEntity : class
    {
        IFluentSqlBuilder<TEntity> GetFluentSqlBuilder();
        SqlBuilder.Template GetTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder);
        SqlBuilder.Template GetCountTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder);
        SqlBuilder.Template GetPaginationTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder);
    }
}
