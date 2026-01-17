using DataStream.API.Database.EF;
using DataStream.API.Models;
using DataStream.API.Repositories.Interfaces;

namespace DataStream.API.Repositories.EF
{
    public class ClientRepository(DataStreamDbContext context) : IClientRepository
    {
        private readonly DataStreamDbContext _context = context;

        public Task<IEnumerable<Client>> GetClients()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Client> GetStreamingClientsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
