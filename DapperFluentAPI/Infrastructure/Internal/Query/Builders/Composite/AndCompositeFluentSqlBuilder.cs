using DapperFluentAPI.Infrastructure.Internal.Common;
using DapperFluentAPI.Infrastructure.Internal.Mapping;
using DapperFluentAPI.Infrastructure.Internal.Query.Builders.Composite.Abstractions;
using DapperFluentAPI.Infrastructure.Internal.Query.Builders.Operators;
using DapperFluentAPI.Infrastructure.Internal.Query.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.Composite
{
    public interface IAndCompositeFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        IAndCompositeFluentSqlBuilder<TEntity> And<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value);
    }

    public class AndCompositeFluentSqlBuilder<TEntity> : CompositeFluentSqlBuilder<TEntity>, IAndCompositeFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        private readonly IFluentSqlBuilder<TEntity> _fluentSqlBuilder;
        private readonly IEntityTypeMapperAccessor<TEntity> _entityTypeMapperAccessor;

        private readonly IDictionary<string, object> _paramsDict;
        private string _sql;
        private readonly int _paramCount;

        public AndCompositeFluentSqlBuilder(
            IFluentSqlBuilder<TEntity> fluentSqlBuilder,
            IEntityTypeMapperAccessor<TEntity> entityTypeMapperAccessor,
            string sql,
            int paramCount)
        {
            _fluentSqlBuilder = fluentSqlBuilder;
            _entityTypeMapperAccessor = entityTypeMapperAccessor;

            _paramsDict = new Dictionary<string, object>();
            _sql = sql;
            _paramCount = paramCount;
        }

        public IAndCompositeFluentSqlBuilder<TEntity> And<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value)
        {
            var prop = Checker.GetMemberFromExpression(expression.Body as MemberExpression).Name;
            var name = _entityTypeMapperAccessor.GetMapping()[prop];

            _sql += " AND ";

            var op = OperatorBuilder.GetOperatorString(@operator);
            var paramName = Param.Get(_paramCount);

            if (OperatorBuilder.GetIsSimpleFilter(@operator))
            {
                _sql += BuildOrSql(name, op, paramName);
                _paramsDict.Add(paramName, value);
            }
            else
            {
                _sql = BuildOrSql(name, op);
            }

            return this;
        }

        public override IFluentSqlBuilder<TEntity> Build()
        {
            _sql += ")";
            return _fluentSqlBuilder;
        }
    }
}
