using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    public class StaticCommand : ICommand
    {
        public string ReturnString { get; set; }
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            return ReturnString;
        }
    }
}
