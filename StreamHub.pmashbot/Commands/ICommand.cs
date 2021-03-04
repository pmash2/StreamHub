using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    interface ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings);
    }
}
