using Dapper;
using DataStream.API.Database.Dapper.Interfaces;
using DataStream.API.Models;
using DataStream.API.Repositories.Interfaces;

namespace DataStream.API.Repositories.Dapper
{
    public class DClientRepository(IDbConnectionFactory connectionFactory) : IClientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

        public async IAsyncEnumerable<Client> GetStreamingClientsAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            const string sql = @"
                SELECT
                    ClientId,
                    FullName,
                    Email,
                    CreatedAt
                FROM Clients;
            ";

            var clients = connection.Query<Client>(
                sql: sql,
                buffered: false
            );

            foreach (var client in clients)
                yield return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            const string sql = @"
                SELECT
                    ClientId,
                    FullName,
                    Email,
                    CreatedAt
                FROM Clients;
            ";

            return await connection.QueryAsync<Client>(sql);
        }
    }
}
