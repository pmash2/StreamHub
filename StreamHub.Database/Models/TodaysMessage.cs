using System;

namespace StreamHub.Database.Models
{
    public class TodaysMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
