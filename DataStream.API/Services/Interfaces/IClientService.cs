using DataStream.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataStream.API.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        IAsyncEnumerable<Client> GetStreamingClients();
    }
}
