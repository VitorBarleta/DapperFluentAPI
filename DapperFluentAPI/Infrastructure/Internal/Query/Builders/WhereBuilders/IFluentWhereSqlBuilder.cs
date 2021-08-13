using System;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.WhereBuilders
{
    public interface IFluentWhereSqlBuilder<TEntity>
        where TEntity : class
    {
        IFluentWhereSqlBuilder<TEntity> And<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentWhereSqlBuilder<TEntity> Or<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentSqlBuilder<TEntity> Done();
    }
}
