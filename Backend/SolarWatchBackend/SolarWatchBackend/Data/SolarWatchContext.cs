using Microsoft.EntityFrameworkCore;
using SolarWatchBackend.Models;

namespace SolarWatchBackend.Data;

public class SolarWatchContext : DbContext
{
    public DbSet<City> Cities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=SolarWatch;User Id=sa;Password=Benten10.;Encrypt=false;");
    }
    
}