using StreamHub.Database.Models;
using StreamHub.Repositories.Database;
using System;
using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    public class Command : ICommand
    {
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            /*
              !command add pmash The coolest guy around
              !command update pmash Some other dude
              !command delete pmash
            */
            string subCommand = args[1];
            string cmdKeyword = args[2];
            string cmdText = String.Join(' ', args, 3, args.Length - 3);

            StaticCommands cmd = new()
            {
                Keyword = cmdKeyword,
                Text = cmdText
            };

            var returnText = "";
            switch (subCommand)
            {
                case "add" :
                    if (!StaticCommandsRepo.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepo.CreateCommand(cmd);
                        returnText = $"{cmd.Keyword} command created successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command already exists!";
                    }
                    break;
                case "update" :
                    if (StaticCommandsRepo.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepo.UpdateCommand(cmd);
                        returnText = $"{cmd.Keyword} command updated successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command doesn't exist!";
                    }
                    break;
                case "remove":
                    if (StaticCommandsRepo.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepo.DeleteCommand(cmd);
                        returnText = $"{cmd.Keyword} command removed successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command doesn't exist!";
                    }
                    break;
                default:
                    break;
            }

            return returnText;
        }
    }
}
