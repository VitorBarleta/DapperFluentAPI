using Dapper;
using DapperFluentAPI.Infrastructure.Internal.Common;
using DapperFluentAPI.Infrastructure.Internal.Mapping;
using DapperFluentAPI.Infrastructure.Internal.Query.Builders.Composite;
using DapperFluentAPI.Infrastructure.Internal.Query.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders
{
    public class FluentSqlBuilder<TEntity> : IFluentSqlBuilderAccessor<TEntity>, IFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        private readonly IEntityTypeMapperAccessor<TEntity> _mapperAccessor;
        private readonly SqlBuilder _sqlBuilder;
        private readonly IDictionary<string, object> _paramsDict;

        private readonly int paramsCount = 0;

        public SqlBuilder SqlBuilder => _sqlBuilder;

        public IDictionary<string, object> Params => _paramsDict;

        public FluentSqlBuilder(IEntityTypeMapperAccessor<TEntity> mapperAccessor)
        {
            _mapperAccessor = mapperAccessor;

            _sqlBuilder = new SqlBuilder();
            _paramsDict = new Dictionary<string, object>();
        }

        public IOrCompositeFluentSqlBuilder<TEntity> OrWhere<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value)
        {
            var composite = new OrCompositeFluentSqlBuilder<TEntity>(
                this,
                _mapperAccessor,
                paramsCount);

            return composite.Or(expression, @operator, value);
        }

        //public IFluentWhereSqlBuilder<TEntity> Where<TProperty>(
        //    Expression<Func<TEntity, TProperty>> expression,
        //    TProperty value)
        //{

        //}

        public IFluentSqlBuilder<TEntity> Equal<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.EqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> NotEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.NotEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.EqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrNotEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.NotEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> Like(
            Expression<Func<TEntity, string>> expression,
            string value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.LikeOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> NotLike(
            Expression<Func<TEntity, string>> expression,
            string value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.LikeOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrLike(
            Expression<Func<TEntity, string>> expression,
            string value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.LikeOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrNotLike(
            Expression<Func<TEntity, string>> expression,
            string value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.LikeOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> GreaterThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.GreaterThanOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> LessThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.LessThanOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> GreaterThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.GreaterThanOrEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> LessThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.Where, expression, Operators.OperatorBuilder.LessThanOrEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrGreaterThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.GreaterThanOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrLessThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.LessThanOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrGreaterThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.GreaterThanOrEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrLessThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value)
        {
            AddClause(b => b.OrWhere, expression, Operators.OperatorBuilder.LessThanOrEqualOp, value);
            return this;
        }

        public IFluentSqlBuilder<TEntity> IsNull<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            AddSimpleClause(b => b.Where, expression, Operators.OperatorBuilder.IsNullOp);
            return this;
        }

        public IFluentSqlBuilder<TEntity> IsNotNull<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            AddSimpleClause(b => b.Where, expression, Operators.OperatorBuilder.IsNotNullOp);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrIsNull<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            AddSimpleClause(b => b.OrWhere, expression, Operators.OperatorBuilder.IsNullOp);
            return this;
        }

        public IFluentSqlBuilder<TEntity> OrIsNotNull<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            AddSimpleClause(b => b.OrWhere, expression, Operators.OperatorBuilder.IsNotNullOp);
            return this;
        }

        public void OrderBy<TProperty>(Expression<Func<TEntity, TProperty>> expression, OrderByDirection orderByDirection)
        {
            var name = Checker.GetMemberFromExpression(expression.Body as MemberExpression).Name;
            _sqlBuilder.OrderBy($"{name} {orderByDirection}");
        }

        public void Paginate(int size, int offset)
        {
            _paramsDict.Add(FluentQuery.SizeParamName, size);
            _paramsDict.Add(FluentQuery.OffsetParamName, offset);
        }

        private void AddClause<TProperty>(
            Func<SqlBuilder, Func<string, dynamic, SqlBuilder>> clauseFunc,
            Expression<Func<TEntity, TProperty>> expression,
            string @operator,
            TProperty value)
        {
            var name = Checker.GetMemberFromExpression(expression.Body as MemberExpression).Name;
            var dbCol = _mapperAccessor.GetMapping()[name];

            var paramName = Param.Get(paramsCount);

            clauseFunc(_sqlBuilder)(string.Format(Operators.OperatorBuilder.FilterTemplate, dbCol, @operator, paramName), null);

            _paramsDict.Add(paramName, value);
        }

        private void AddSimpleClause<TProperty>(
            Func<SqlBuilder, Func<string, dynamic, SqlBuilder>> clauseFunc,
            Expression<Func<TEntity, TProperty>> expression,
            string @operator)
        {
            var name = Checker.GetMemberFromExpression(expression.Body as MemberExpression).Name;
            var dbCol = _mapperAccessor.GetMapping()[name];

            clauseFunc(_sqlBuilder)(string.Format(Operators.OperatorBuilder.SimpleFilterTemplate, dbCol, @operator), null);
        }

        public void AddParams(KeyValuePair<string, object> keyValuePair) => _paramsDict.Add(keyValuePair.Key, keyValuePair.Value);
    }
}
