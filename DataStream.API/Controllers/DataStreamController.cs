using DataStream.API.Models;
using DataStream.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataStream.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataStreamController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]
        [Route("clients")]
        public IAsyncEnumerable<Client> GetStreamingClients()
        {
            return _clientService.GetStreamingClients();
        }
    }
}
