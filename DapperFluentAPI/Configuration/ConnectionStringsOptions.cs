namespace DapperFluentAPI.Configuration
{
    public class ConnectionStringsOptions
    {
        public ConnectionStringsOptions(string sqlServer)
        {
            SqlServer = sqlServer;
        }

        public string SqlServer { get; }
    }
}
