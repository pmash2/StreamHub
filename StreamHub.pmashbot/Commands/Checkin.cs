using StreamHub.Repositories.Database;
using StreamHub.Repositories.Other;
using System;
using System.Linq;
using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    public class Checkin : ICommand
    {
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            int pointsToGive = 0;
            if (!int.TryParse(settings.GlobalSettings.Where(x => x.Key == "CHECKIN").Select(y => y.Value).FirstOrDefault(), out pointsToGive))
            {
                return "Invalid check-in amount configured!";
            }

            if (HasCheckedInToday(username))
            {
                return $"@{username}, nice try, but you already checked in today!";
            }

            UserPointsRepo mgr = new();
            mgr.ChangePoints(username, "pmashbot", pointsToGive, "Checked in!");

            return $"@{username}, thanks for checking in! You just got yourself {pointsToGive} points!";
        }

        private bool HasCheckedInToday(string username)
        {
            var lastCheckin = CheckInRepo.GetLastCheckIn(username);

            return lastCheckin.Date == DateTime.Today.Date;
        }
    }
}
