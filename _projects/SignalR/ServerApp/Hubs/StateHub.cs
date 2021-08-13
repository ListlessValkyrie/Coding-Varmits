using Common;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.Hubs
{
    public class StateHub : Hub
    {
        public StateHub()
        {
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

                await Clients
                    .Caller
                    .SendAsync("ReceivePlayerState", playerState);

            } while (!playerState.IsEndState());
        }
    }
}
