using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace discordBotProject
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
           _client = new DiscordSocketClient();
           _client.Log += log;
           _client.MessageReceived += MessageReceivedTask;
           await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("DiscordToken"));
           await _client.StartAsync();
           await Task.Delay(-1);
        }
        private Task log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task MessageReceivedTask(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}
