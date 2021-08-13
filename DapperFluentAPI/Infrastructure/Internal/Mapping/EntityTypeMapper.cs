using DapperFluentAPI.Infrastructure.Internal.Common;
using DapperFluentAPI.Infrastructure.Internal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DapperFluentAPI.Infrastructure.Internal.Mapping
{
    public class EntityTypeMapper<TEntity> : IEntityTypeMapper<TEntity>, IEntityTypeMapperAccessor<TEntity>
        where TEntity : class
    {
        private readonly IDictionary<string, string> _mapping;

        private string _schemaName;
        private string _tableName;

        public EntityTypeMapper()
        {
            _mapping = new Dictionary<string, string>();
        }

        public string SchemaName => _schemaName;
        public string TableName => _tableName;

        public EntityTypeMapper<TEntity> ToSchema(string schemaName)
        {
            _schemaName = schemaName;
            return this;
        }

        public EntityTypeMapper<TEntity> ToTable(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public PropertyMapper Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            var propInfo = Checker.GetMemberFromExpression(propertyExpression.Body as MemberExpression);

            return new PropertyMapper(propInfo.Name, this);
        }

        public PropertyMapper From(string name)
        {
            var property = typeof(TEntity).GetProperty(name, BindingFlags.Public | BindingFlags.IgnoreCase)
                ?? throw new MemberNotValidException(name);

            return new PropertyMapper(property.Name, this);
        }

        private void AddMapping(string from, string to) =>
            _mapping.Add(from, to);

        public IDictionary<string, string> GetMapping() =>
            _mapping;

        public class PropertyMapper
        {
            private readonly string _from;
            private readonly EntityTypeMapper<TEntity> _mapper;

            public PropertyMapper(string from, EntityTypeMapper<TEntity> mapper)
            {
                _from = from;
                _mapper = mapper;
            }

            public EntityTypeMapper<TEntity> HasColumnName(string dbColumnName)
            {
                _mapper.AddMapping(_from, dbColumnName);
                return _mapper;
            }
        }
    }
}
