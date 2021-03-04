using StreamHub.Database;
using StreamHub.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace StreamHub.Repositories.Database
{
    public class GlobalConfigsRepo
    {
        public GlobalConfigs GetConfig(string key)
        {
            using var context = new mashDbContext();

            return context.GlobalConfigs
                          .SingleOrDefault(x => x.Key == key);
        }

        public List<GlobalConfigs> GetAllConfigs()
        {
            using var context = new mashDbContext();

            return context.GlobalConfigs.ToList();
        }

        public void UpdateDescription(string key, string description)
        {
            using (var context = new mashDbContext())
            {
                var record = GetConfig(key);
                record.Description = description;
                context.GlobalConfigs.Update(record);
            }
        }

        public void UpdateValue(string key, string value)
        {
            using (var context = new mashDbContext())
            {
                var record = GetConfig(key);
                record.Value = value;
                context.GlobalConfigs.Update(record);
            }
        }
    }
}
