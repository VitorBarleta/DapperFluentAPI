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
    public interface IOrCompositeFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        IOrCompositeFluentSqlBuilder<TEntity> Or<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value);

        IFluentSqlBuilder<TEntity> Build();
    }

    public class OrCompositeFluentSqlBuilder<TEntity> : CompositeFluentSqlBuilder<TEntity>, IOrCompositeFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        private readonly IFluentSqlBuilderAccessor<TEntity> _fluentSqlBuilderAccessor;
        private readonly IEntityTypeMapperAccessor<TEntity> _entityTypeMapperAccessor;

        private readonly List<string> _paramsList;

        private int _paramCount;

        public OrCompositeFluentSqlBuilder(
            IFluentSqlBuilderAccessor<TEntity> fluentSqlBuilderAccessor,
            IEntityTypeMapperAccessor<TEntity> entityTypeMapperAccessor,
            int paramCount)
        {
            _fluentSqlBuilderAccessor = fluentSqlBuilderAccessor;
            _entityTypeMapperAccessor = entityTypeMapperAccessor;

            _paramsList = new List<string>();
            _paramCount = paramCount;
        }

        public IOrCompositeFluentSqlBuilder<TEntity> Or<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value)
        {
            var prop = Checker.GetMemberFromExpression(expression.Body as MemberExpression).Name;
            var name = _entityTypeMapperAccessor.GetMapping()[prop];

            var op = OperatorBuilder.GetOperatorString(@operator);
            var paramName = Param.Get(_paramCount++);

            if (OperatorBuilder.GetIsSimpleFilter(@operator))
            {
                _paramsList.Add(BuildOrSql(name, op, paramName));
                _fluentSqlBuilderAccessor.AddParams(new KeyValuePair<string, object>(paramName, value));
            }
            else
            {
                _paramsList.Add(BuildOrSql(name, op));
            }

            return this;
        }

        public override IFluentSqlBuilder<TEntity> Build()
        {
            _fluentSqlBuilderAccessor.SqlBuilder.Where($"({string.Join(" OR ", _paramsList)})");

            return (IFluentSqlBuilder<TEntity>)_fluentSqlBuilderAccessor;
        }
    }
}
