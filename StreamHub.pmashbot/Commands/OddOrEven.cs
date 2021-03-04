using StreamHub.Database;
using StreamHub.Database.Models;
using StreamHub.Repositories.Database;
using System;
using TwitchLib.Client.Enums;

namespace StreamHub.pmashbot.Commands
{
    public class OddOrEven : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
        {
            if (args.Length < 3)
            {
                return $"@{username}, to play !bet, try !bet <odd/even> pointsToWager (!bet even 10)";
            }

            UserPointsRepo mgr = new();
            bool betEven = args[1] == "even" ? true : false;

            int wager = 0;
            bool success = int.TryParse(args[2], out wager);
            if (!success)
            {
                return $"@{username}, your wager must be a number!";
            }

            if (wager <= 0)
            {
                return $"@{username}, you must wager a postive amount";
            }

            if (mgr.GetPoints(username) < wager)
            {
                return $"{username}, you don't have enough points to make that bet";
            }

            return PlayGame(betEven, username, wager, mgr);
        }

        public static string PlayGame(bool betEven, string userName, int wager, UserPointsRepo mgr)
        {
            var rand = new Random();
            var number = rand.Next(0, 1000);
            var didWin = false;

            Console.WriteLine($"The random number for this round is {number}");

            var isEven = number % 2 == 0 ? true : false;

            string result = $"The number was {number}. ";

            if (betEven && isEven || !betEven && !isEven)
            {
                result += "YOU WIN!!!!";
                didWin = true;
                mgr.ChangePoints(userName, "", wager, "Won OddOrEven");
            }
            else
            {
                result += "Oh no, you lose! :(";
                didWin = false;
                mgr.ChangePoints(userName, "", wager * -1, "Lost OddOrEven");
            }

            using (var context = new mashDbContext())
            {
                context.WinLoss.Add(new WinLoss
                {
                    UserName = userName,
                    DidWin = didWin,
                    Date = DateTime.Now,
                    Game = "OddOrEven"
                });
                context.SaveChanges();
            }

            return result;
        }
    }
}
