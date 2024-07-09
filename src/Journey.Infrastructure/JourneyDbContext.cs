using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure;

public class JourneyDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Data Source vai ser diferente dependendo de seu sistema operacional
        optionsBuilder.UseSqlite("Data Source=/home/giovani/github/Journey/JourneyDatabase.db");
    }
}