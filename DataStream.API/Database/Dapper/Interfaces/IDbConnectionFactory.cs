using System.Data;

namespace DataStream.API.Database.Dapper.Interfaces
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
