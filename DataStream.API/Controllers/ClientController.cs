using DataStream.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataStream.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetClients();
            return Ok(clients);
        }
    }
}
