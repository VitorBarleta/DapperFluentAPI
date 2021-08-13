namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.Composite.Abstractions
{
    public abstract class CompositeFluentSqlBuilder<TEntity>
        where TEntity : class
    {
        public abstract IFluentSqlBuilder<TEntity> Build();

        public string BuildOrSql(string dbObject, string op, string paramName)
            => $"{dbObject} {op} {paramName}";

        public string BuildOrSql(string dbObject, string op)
            => $"{dbObject} {op}";
    }
}
