using StreamHub.Repositories.Database;
using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    public class Points : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
        {
            UserPointsRepo mgr = new();
            var msg = $"@{username}, you have {mgr.GetPoints(username)} points!";
            return msg;
        }
    }
}
