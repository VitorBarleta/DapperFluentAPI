using DapperFluentAPI.Infrastructure.Internal.Query.Builders.Composite;
using DapperFluentAPI.Infrastructure.Internal.Query.Enums;
using System;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders
{
    public interface IFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        IOrCompositeFluentSqlBuilder<TEntity> OrWhere<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Operator @operator,
            TProperty value);

        IFluentSqlBuilder<TEntity> Equal<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentSqlBuilder<TEntity> NotEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentSqlBuilder<TEntity> OrEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentSqlBuilder<TEntity> OrNotEqual<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            TProperty value);

        IFluentSqlBuilder<TEntity> Like(
            Expression<Func<TEntity, string>> expression,
            string value);

        IFluentSqlBuilder<TEntity> NotLike(
            Expression<Func<TEntity, string>> expression,
            string value);

        IFluentSqlBuilder<TEntity> OrLike(
            Expression<Func<TEntity, string>> expression,
            string value);

        IFluentSqlBuilder<TEntity> OrNotLike(
            Expression<Func<TEntity, string>> expression,
            string value);

        IFluentSqlBuilder<TEntity> GreaterThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> LessThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> GreaterThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> LessThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> OrGreaterThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> OrLessThan(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> OrGreaterThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> OrLessThanOrEqual(
            Expression<Func<TEntity, DateTime>> expression,
            DateTime value);

        IFluentSqlBuilder<TEntity> IsNull<TProperty>(
            Expression<Func<TEntity, TProperty>> expression);

        IFluentSqlBuilder<TEntity> IsNotNull<TProperty>(
            Expression<Func<TEntity, TProperty>> expression);

        IFluentSqlBuilder<TEntity> OrIsNull<TProperty>(
            Expression<Func<TEntity, TProperty>> expression);

        IFluentSqlBuilder<TEntity> OrIsNotNull<TProperty>(
            Expression<Func<TEntity, TProperty>> expression);

        void OrderBy<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            OrderByDirection orderByDirection);

        void Paginate(int size, int offset);
    }
}
