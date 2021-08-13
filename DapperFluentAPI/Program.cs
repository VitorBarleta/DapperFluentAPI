using Microsoft.Extensions.DependencyInjection;

namespace DapperFluentAPI
{
    class Program
    {
        static void Main(string[] args) =>
            Build<Startup>()
                .BuildServiceProvider()
                .GetService<App>()
                .Run()
                .GetAwaiter()
                .GetResult();

        static IServiceCollection Build<TStartup>() where TStartup : class, new()
        {
            var services = new ServiceCollection();

            var startup = new TStartup();
            var type = typeof(TStartup);
            var configServices = type.GetMethod("Configure");

            return (IServiceCollection)configServices.Invoke(startup, new object[1] { services });
        }
    }
}
