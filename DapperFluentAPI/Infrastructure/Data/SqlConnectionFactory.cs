using DapperFluentAPI.Application.Configuration.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DapperFluentAPI.Infrastructure.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _sqlServerConnectionString;
        private IDbConnection _dbConnection;

        public SqlConnectionFactory(string sqlServerConnectionString)
        {
            _sqlServerConnectionString = sqlServerConnectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_dbConnection == null || _dbConnection.State != ConnectionState.Open)
            {
                _dbConnection = new SqlConnection(_sqlServerConnectionString);
                _dbConnection.Open();
            }

            return _dbConnection;
        }

        public void Dispose()
        {
            if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();

            _dbConnection.Dispose();
        }
    }
}
