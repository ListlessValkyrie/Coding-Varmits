using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IHubContext<StateHub> stateHub;

        public PlayerController(IHubContext<StateHub> stateHub)
        {
            this.stateHub = stateHub;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer()
        {
            await stateHub.Clients.All.SendAsync("NewPlayer", 69);

            return Accepted();
        }
    }
}
