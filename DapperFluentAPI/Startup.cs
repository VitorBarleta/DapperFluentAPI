using DapperFluentAPI.Application.Configuration.Data;
using DapperFluentAPI.Infrastructure;
using DapperFluentAPI.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DapperFluentAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            Configuration = configBuilder.Build();
        }

        public IServiceCollection Configure(IServiceCollection services)

        {
            services
                .ConfigureServices()
                .ConfigureDatabase(Configuration);

            services.AddSingleton(typeof(App));
            return services;
        }
    }

    public static class StartupExtensions
    {
        private static readonly string SqlServer = "SqlServer";

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>(
                _ => new SqlConnectionFactory(configuration.GetConnectionString(SqlServer)));

            services.ConfigureDbEntityConfiguration();

            return services;
        }
    }
}
