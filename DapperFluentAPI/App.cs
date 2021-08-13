using Dapper;
using DapperFluentAPI.Application.Configuration.Data;
using DapperFluentAPI.Domain.Entities.Users;
using DapperFluentAPI.Infrastructure.Internal.Query;
using DapperFluentAPI.Infrastructure.Internal.Query.Enums;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DapperFluentAPI
{
    public class App
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IFluentQuery<User> _userQuery;

        public App(
            ISqlConnectionFactory connectionFactory,
            IFluentQuery<User> userQuery)
        {
            _connectionFactory = connectionFactory;
            _userQuery = userQuery;
        }

        public async Task Run()
        {
            var conn = _connectionFactory.GetOpenConnection();

            var builder = _userQuery.GetFluentSqlBuilder();
            builder
                .IsNull(p => p.LastModificationDate)
                .OrWhere(p => p.Name, Operator.Like, "V%")
                .Or(p => p.Name, Operator.Like, "%r")
                .Or(p => p.Surname, Operator.Like, "B%")
                .Or(p => p.Surname, Operator.Like, "%a")
                .Build()
                .OrderBy(b => b.Name, OrderByDirection.DESC);

            builder.Paginate(2, 0);

            var template = _userQuery.GetPaginationTemplate(builder);

            var users = await conn.QueryAsync<User>(template.RawSql, template.Parameters);

            foreach (var user in users)
                Console.WriteLine(JsonConvert.SerializeObject(user));

            Console.ReadKey();
        }
    }
}
