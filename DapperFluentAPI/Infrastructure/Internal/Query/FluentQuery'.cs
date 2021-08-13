using Dapper;
using DapperFluentAPI.Infrastructure.Internal.Mapping;
using DapperFluentAPI.Infrastructure.Internal.Query.Builders;
using System.Collections.Generic;

namespace DapperFluentAPI.Infrastructure.Internal.Query
{
    public class FluentQuery<TEntity> : FluentQuery, IFluentQuery<TEntity>
        where TEntity : class
    {
        private readonly IEntityTypeMapperAccessor<TEntity> _mapperAccessor;

        public FluentQuery(IEntityTypeMapperAccessor<TEntity> mapperAccessor)
        {
            _mapperAccessor = mapperAccessor;
        }

        public string Template
        {
            get => string.Format(
                BaseTemplate,
                string.Join(',', GetColumns(_mapperAccessor.GetMapping())),
                _mapperAccessor.SchemaName,
                _mapperAccessor.TableName);
        }

        public string CountTemplate
        {
            get => string.Format(
                BaseTemplate,
                "COUNT(1)",
                _mapperAccessor.SchemaName,
                _mapperAccessor.TableName);
        }

        public string PaginationTemplate
        {
            get => Template + PaginationComplementTemplate;
        }

        public IFluentSqlBuilder<TEntity> GetFluentSqlBuilder()
        {
            return new FluentSqlBuilder<TEntity>(_mapperAccessor);
        }

        public SqlBuilder.Template GetTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder) =>
            CreateTemplateFrom(Template, (IFluentSqlBuilderAccessor<TEntity>)fluentSqlBuilder);

        public SqlBuilder.Template GetCountTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder) =>
            CreateTemplateFrom(CountTemplate, (IFluentSqlBuilderAccessor<TEntity>)fluentSqlBuilder);

        public SqlBuilder.Template GetPaginationTemplate(IFluentSqlBuilder<TEntity> fluentSqlBuilder) =>
            CreateTemplateFrom(PaginationTemplate, (IFluentSqlBuilderAccessor<TEntity>)fluentSqlBuilder);

        private SqlBuilder.Template CreateTemplateFrom(string template, IFluentSqlBuilderAccessor<TEntity> fluentSqlBuilder)
        {
            var builder = fluentSqlBuilder.SqlBuilder;
            var dynamicParameters = new DynamicParameters(fluentSqlBuilder.Params);
            return builder.AddTemplate(template, dynamicParameters);
        }

        private static IEnumerable<string> GetColumns(IDictionary<string, string> keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
                yield return $"[{keyValuePair.Value}] AS [{keyValuePair.Key}]";
        }
    }
}
