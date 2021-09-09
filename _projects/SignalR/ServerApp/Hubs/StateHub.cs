using System.Threading;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace ServerApp.Hubs
{
    public class StateHub : Hub
    {
        public StateHub()
        {      
        }

        public override Task OnConnectedAsync()
        {
            Task connectedTask = base.OnConnectedAsync();

            string connectionId = Context.ConnectionId;
            HttpContext httpContext =  Context.GetHttpContext();
            StringValues accessToken = httpContext.Request.Headers[HeaderNames.Authorization];

            Groups.AddToGroupAsync(connectionId, accessToken[0], CancellationToken.None);

            return connectedTask;
        }

        /// <summary>
        /// These are methods that can be called by the CLIENT
        /// </summary>
        public async Task GetPlayerState()
        {           
            PlayerState? playerState = null;

            do
            {
                playerState = (playerState != null)
                     ? ((PlayerState)playerState).Next()
                     : PlayerState.Sleeping;

                Thread.Sleep(1000);

                // Using auth instead:
                /*
                await Clients
                    .Caller
                    .SendAsync("ReceivePlayerState", playerState);
                */

                HttpContext httpContext = Context.GetHttpContext();
                StringValues accessToken = httpContext.Request.Headers[HeaderNames.Authorization];

                await Clients.Groups(accessToken[0])
                    .SendAsync("ReceivePlayerState", playerState);

            } while (!playerState.IsEndState());
        }
    }
}
