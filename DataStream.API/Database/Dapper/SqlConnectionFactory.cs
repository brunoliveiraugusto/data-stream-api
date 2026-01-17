using DataStream.API.Database.Dapper.Interfaces;
using DataStream.API.Infra.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataStream.API.Database.Dapper
{
    public class SqlConnectionFactory(IOptions<ConnectionStringSetting> opt) : IDbConnectionFactory
    {
        private readonly string _connectionString = opt.Value.DefaultConnection;

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
