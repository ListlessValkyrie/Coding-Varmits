using Common;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start listening...");
            Console.ReadKey();

            /*
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor description = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(7)
            };

            SecurityToken token = handler.CreateToken(description);

            Console.WriteLine(token);
            */

            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid);

            HubConnection connection = new HubConnectionBuilder()
                //.WithUrl("https://localhost:44332/statehub?AUTHORIZATION="+ token )
                .WithUrl("https://localhost:44332/statehub?AUTHORIZATION=", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(guid.ToString());
                })
                .WithAutomaticReconnect()
                .Build();

            connection.On<int>("NewPlayer", playerId =>
            {
                Console.WriteLine($"NewPlayer: {playerId}");
            });

            connection.On<PlayerState>("ReceivePlayerState", playerState =>
            {
                Console.WriteLine($"ReceivePlayerState: {playerState}");
            });

            connection.StartAsync()             
                .GetAwaiter()
                .GetResult();

            connection.InvokeAsync("GetPlayerState");

            Console.WriteLine("Press <any> key to quit.");
            Console.ReadKey(true);
        }
    }
}
