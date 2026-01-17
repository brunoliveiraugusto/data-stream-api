using DataStream.API.Models;

namespace DataStream.API.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        IAsyncEnumerable<Client> GetStreamingClientsAsync();
    }
}
