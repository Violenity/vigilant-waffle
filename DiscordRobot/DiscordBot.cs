using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRobot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService command;

        public DiscordBot()
        {
           //go to discord developer and create bot and token
            command = client.GetService<CommandService>();
            
            client = new DiscordClient(input =>
                {
                    input.LogLevel = LogSeverity.Info;
                    input.LogHandler = Log;
                });

            client.UsingCommands(input =>
                {
                    input.PrefixChar = '!';
                    input.AllowMentionPrefix = true;
                });

            command.CreateCommand("Hello").Do(async (e) =>
                {
                    await e.Channel.SendMessage("world!");
                });

            client.ExecuteAndWait(async () =>
                {
                    await client.Connect("TOKEN GOES HERE", TokenType.Bot);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
