using DataStream.API.Models;
using DataStream.API.Repositories.Interfaces;
using DataStream.API.Services.Interfaces;

namespace DataStream.API.Services
{
    public class ClientService(IClientRepository repository) : IClientService
    {
        private readonly IClientRepository _repository = repository;

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _repository.GetClients();
        }

        public IAsyncEnumerable<Client> GetStreamingClients()
        {
            return _repository.GetStreamingClientsAsync();
        }
    }
}
