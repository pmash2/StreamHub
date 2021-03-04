using Microsoft.Extensions.Logging;
using StreamHub.Database.Models;
using StreamHub.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamHub.pmashbot
{
    public class BotSettings
    {
        public BotSettings(string endpoint)
        {
            ConfigsManager = new();
            GlobalSettings = ConfigsManager.GetAllConfigs();
            Endpoint = endpoint;
        }
        public List<GlobalConfigs> GlobalSettings { get; set; }
        private GlobalConfigsRepo ConfigsManager { get; set; }

        public string Endpoint { get; set; }

        public void RefreshSettings(ILogger _logger)
        {
            GlobalSettings.Clear();
            GlobalSettings = ConfigsManager.GetAllConfigs();
            // TODO: Don't log configs every iteration
            _logger.LogInformation($"{PrintConfigs()}");
        }

        private string PrintConfigs()
        {
            string s = "";
            foreach (var setting in GlobalSettings)
            {
                s += $", {setting.Key} - {setting.Value}";
            }

            return s;
        }
    }
}
