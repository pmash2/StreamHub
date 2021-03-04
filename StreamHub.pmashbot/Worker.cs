using dotenv.net;
using dotenv.net.Utilities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StreamHub.Database;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace StreamHub.pmashbot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{Directory.GetCurrentDirectory()}");
            Console.WriteLine("Hello World!");
            var envReader = new EnvReader();
            DotEnv.Config(true, "mySecrets");
            var channel = envReader.GetStringValue("CHANNEL");
            var token = envReader.GetStringValue("BOT_PASSWORD");
            var endpoint = envReader.GetStringValue("API_ENDPOINT");

#if DEBUG
            using (var context = new mashDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
#endif

            BotSettings settings = new(endpoint);
            var bot = new Bot(channel, token, settings);

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                bot.settings.RefreshSettings(_logger);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
