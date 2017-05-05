
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
        int total = 0;
        int goal = 50000;

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

            command.CreateCommand("AddGil").Parameter("gi", ParameterType.Multiple).Do(async (e) =>
                {
                    await addGil(e);
                });

            client.ExecuteAndWait(async () =>
                {
                    await client.Connect("TOKEN GOES HERE", TokenType.Bot);
                });
        }
        private async System.Threading.Tasks.Task addGil(CommandEventArgs e) 
        {
            var added = e.Args[1];
            var add = Convert.ToInt32(added);         

            //fix this not done yet!!!!!!!*******************************************************************************************************
            await e.Channel.SendMessage(string.Format("Added {0} gil to the fund, currently at {1}. {2}% of the goal has been reached.", added, total, (total/goal)*100 ));
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
