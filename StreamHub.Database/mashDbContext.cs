using Microsoft.EntityFrameworkCore;
using StreamHub.Database.Models;

namespace StreamHub.Database
{
    public class mashDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<WinLoss> WinLoss { get; set; }
        public DbSet<TodaysMessage> TodaysMessage { get; set; }
        public DbSet<UserPoints> UserPoints { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }
        public DbSet<GlobalConfigs> GlobalConfigs { get; set; }
        public DbSet<StaticCommands> StaticCommands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var location = "./mashDbContext.sqlite";
#if RELEASE
            location = "../Database/mashDbContext.sqlite";
#endif
            optionsBuilder.UseSqlite($"Filename={location}");
        }
    }
}
