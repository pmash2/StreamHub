using Microsoft.EntityFrameworkCore;

namespace StreamHub.Database
{
    public class mashDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./mashDbContext.sqlite");
        }
    }
}
