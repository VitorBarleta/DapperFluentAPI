using System.Collections.Generic;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.WhereBuilders
{
    public class FluentWhereSqlBuilder<TEntity> : IFluentWhereSqlBuilder<TEntity>, IFluentWhereSqlBuilderAccessor<TEntity>
        where TEntity : class
    {
        private readonly IFluentSqlBuilder<TEntity> _fluentSqlBuilder;

        private readonly IDictionary<string, object> _paramsDict;
        private readonly string _sql;

        public FluentWhereSqlBuilder(
            IFluentSqlBuilder<TEntity> fluentSqlBuilder)
        {
            _fluentSqlBuilder = fluentSqlBuilder;
            _paramsDict = new Dictionary<string, object>();
        }

        public IDictionary<string, object> ParamsDict => _paramsDict;

        public IFluentWhereSqlBuilder<TEntity> And<TProperty>(
            Expression<System.Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            return this;
        }

        public IFluentWhereSqlBuilder<TEntity> Or<TProperty>(
            Expression<System.Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            return this;
        }

        public IFluentSqlBuilder<TEntity> Done()
        {
            return _fluentSqlBuilder;
        }
    }
}
