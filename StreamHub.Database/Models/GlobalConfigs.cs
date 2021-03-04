using System;

namespace StreamHub.Database.Models
{
    public class GlobalConfigs
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
