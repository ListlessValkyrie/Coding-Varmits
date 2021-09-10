using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Hubs;

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

        
        [HttpPost]
        [Route("api/SendToGroup/group")]
        public async Task<IActionResult> SendToGroup(string groupName)
        {
            await stateHub.Clients.Groups(groupName).SendAsync("NewPlayer", 44);

            return Accepted();
        }
    }
}
