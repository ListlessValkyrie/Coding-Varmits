using Common;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start listening...");
            Console.ReadKey();

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44332/statehub")
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
