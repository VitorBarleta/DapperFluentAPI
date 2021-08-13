using System;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Mapping
{
    public interface IEntityTypeMapper { }

    public interface IEntityTypeMapper<TEntity> : IEntityTypeMapper
        where TEntity : class
    {
        EntityTypeMapper<TEntity> ToSchema(string schemaName);
        EntityTypeMapper<TEntity> ToTable(string tableName);
        EntityTypeMapper<TEntity>.PropertyMapper Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression);
        EntityTypeMapper<TEntity>.PropertyMapper From(string propertyName);
    }
}
